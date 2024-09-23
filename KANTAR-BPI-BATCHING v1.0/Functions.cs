using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.VisualBasic.Compatibility.VB6;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Google.Protobuf.WellKnownTypes;



namespace KANTAR_BPI_BATCHING_v1._0
{
    public class Functions
    {
        public DirListBox form1DirListBox;
        public DataGridView frm1dgv;

        public Button addBatch_BTN;
        public Button addAllBatch_BTN;
        public Button remove_BTN;
        public Button batch_BTN;
        public Button Cancelbatch_btn;
        public Button trucate_btn;
        public Button remove_btn;
        public Button batch_btn;
        public Button clear_btn;
        public Button exit;

        public DataGridView form1DataGrid;
        public DataGridView dataGridLrd;
        public DataGridView dataGridSml;

        public TextBox totalImgCnt;
        public TextBox totalDuplicatesCnt;
        public TextBox ElapsedTime;
        public TextBox operatorTxtBox;

        public BackgroundWorker worker;

        public Timer elapsedTimer;

        public ProgressBar progressBar;

        private Stopwatch stopwatch;

        BatchTable batchTable;

        List<string> jpgFileWholePathList = new List<string>();
        List<string> alldups = new List<string>();
        private Dictionary<string, List<string>> folderDuplicates = new Dictionary<string, List<string>>();

        private List<string> jpgfileList;
        private List<string> dupjpgfileList;

        private volatile bool cancelRequest;

        private Task processingTask;

        private int imgCtr = 0;

        // Folder Declaration
        private string filedestination = @"\\192.168.23.178\non fpo test data\KANTAR-BPI-ALOE";

        private Dictionary<string, List<string>> fileHashes = new Dictionary<string, List<string>>();

        List<string> paths = new List<string>();

        public void dirListBoxDoubleClick()
        {
            dataGridSml.Rows.Clear();   

            if (DataGridHaveRecords())
            {
                return;
            }

            jpgfileList = new List<string>();

            var mainDir = form1DirListBox.Path;
            var dirlist = Directory.GetDirectories(mainDir);

            List<string> jpglist = new List<string>();

            foreach (var dir in dirlist)
            {
                var jpgFilesPerfolder = Directory.GetFiles(dir, "*.jpg");

                int dupCtr = getDuplicatesJpg(jpgFilesPerfolder);

                imgCtr = jpgFilesPerfolder.Length;
                string batchName = Path.GetFileName(dir);

                if (imgCtr > 0)
                {
                    jpglist.AddRange(jpgFilesPerfolder);
                    dataGridSml.Rows.Add(batchName, imgCtr, dir, dupCtr);
                }
            }
        }

        // Cannot OverWrite into the Small and large grid
        private bool DataGridHaveRecords()
        {
            return dataGridSml.Rows.Count > 0 || dataGridLrd.Rows.Count > 0;
        }

        // Batching Process
        public void batching()
        {

            CopyImgAndProcessBatchDB();
            cancelRequest = false;
        }

        private void CopyImgAndProcessBatchDB()
        {
            processingTask = Task.Run(() => getCopyImages());
        }

        List<string> imagesPerFolder = new List<string>();


        // Copy only Valid Images And Process DB
        public async Task getCopyImages()
        {
            string dir = Directory.GetCurrentDirectory();

            string dateFolder = Path.Combine(filedestination, DateTime.Now.ToString("MMddyyy"));
            string imagesfolder = Path.Combine(dateFolder, "Images");

            if (!Directory.Exists(dateFolder))
            {
                Directory.CreateDirectory(dateFolder);
            }

            if (Directory.Exists(dateFolder))
            {
                Directory.Delete(dateFolder, true);
            }


            // Duplicate Folder
            string duplicateFolder = Path.Combine(Application.StartupPath, "Duplicates", DateTime.Now.ToString("MMddyyyy"));


            if (!Directory.Exists(duplicateFolder))
            {
                Directory.CreateDirectory(duplicateFolder);
            }


            if(Directory.Exists(duplicateFolder))
            {
                Directory.Delete(duplicateFolder, true);
            }


            //Dictionary Duplicate per image
            Dictionary<string, string> fileDuplicates = new Dictionary<string, string>();

            // HashSet to keep track of log Duplicate entries
            HashSet<string> writtenLogEntries = new HashSet<string>();

            string keyid = Form2.User_Name;
            DateTime reportDate = DateTime.Now.Date;
            string programType = "Batching";

            HashSet<string> processedImages = new HashSet<string>();
            var directories = Directory.GetDirectories(filedestination);

            // Dictionary for Inserting batchFiles
            Dictionary<string, int> jpgPerfolders = new Dictionary<string, int>();

            string batcher = Form2.User_Name;
            string origPath = Path.GetFullPath(dir);
            string batch = "";
            int totalImagesToBatch = 0;
            TimeSpan totalElapsedTime = TimeSpan.Zero;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            foreach (DataGridViewRow row in dataGridLrd.Rows)
            {
                totalImagesToBatch += Convert.ToInt32(row.Cells[4].Value);
            }


            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke((MethodInvoker)(() =>
                {
                    progressBar.Maximum = totalImagesToBatch;
                    progressBar.Value = 0;
                }));
            }
            else
            {
                progressBar.Maximum = totalImagesToBatch;
                progressBar.Value = 0;
            }


            // Inserting Batch Table 
            ConnectDB conn = new ConnectDB();
            conn.Connect();
            for (int i = 0; i < dataGridLrd.RowCount; i++)
            {
                int totalImagesInRow = Convert.ToInt32(dataGridLrd.Rows[i].Cells[3].Value);
                int processImagesInRow = 0;


                if (cancelRequest)
                {
                    CancelButton();                
                    dataGridLrd.Rows[i].DefaultCellStyle.BackColor = Color.Gainsboro;

                    for (int j = i; j < dataGridLrd.RowCount; j++)
                    {
                        dataGridLrd.Rows[j].Cells[2].Value = "Canceled"; // Or any other status indicating cancellation
                        dataGridLrd.Rows[j].DefaultCellStyle.BackColor = Color.Gainsboro; // Optional: Change row color
                    }
                
                    conn.RollBack();
                    break;                 
                }

                string hasBatch = dataGridLrd.Rows[i].Cells[1].Value.ToString();

                bool hasRecords = ConnectDB.CheckDatabaseForRecords(hasBatch);
               
                if (hasRecords)
                {

                    // IF true 
                    DialogResult result = MessageBox.Show($"Do you want to Rebatch {hasBatch} ?", "Confirmation", MessageBoxButtons.YesNo);
                  

                    if (result == DialogResult.Yes)
                    {

                       // ConnectDB.UpdateBatchArchive(hasBatch, 1);

                        string pathName = dataGridLrd.Rows[i].Cells[0].Value.ToString();
                        string batchName = dataGridLrd.Rows[i].Cells[1].Value.ToString();
                       


                        //Getting files in the Directory
                        string[] jpgfiles = Directory.GetFiles(pathName, "*.jpg");

                        foreach (string dupImg in jpgfiles)
                        {
                            string folderName = Path.GetFileName(dupImg);

                            //// Make sure Duplicate folder exist
                            if (!Directory.Exists(duplicateFolder))
                            {
                                Directory.CreateDirectory(duplicateFolder);
                            }

                            // Read existing duplicate log entries into the HashSet
                            string[] logFiles = Directory.GetFiles(duplicateFolder, "*.txt");
                            foreach (string logFile in logFiles)
                            {
                                string[] existingEntries = File.ReadAllLines(logFile);
                                foreach (string entry in existingEntries)
                                {
                                    writtenLogEntries.Add(entry);
                                }
                            }

                            // Duplicates per folder
                            if (!fileDuplicates.ContainsKey(folderName))
                            {
                                fileDuplicates[folderName] = dupImg;
                            }
                            else
                            {
                                // Found a duplicate
                                string originalPath = fileDuplicates[folderName];
                                string originalFolder = Path.GetFileName(Path.GetDirectoryName(originalPath));

                                string originalLogFileName = $"{originalFolder} .txt";

                                string originalTextFilePath = Path.Combine(duplicateFolder, originalLogFileName);

                                // Log the original and duplicate folder names
                                string logEntry = $"{originalFolder} {folderName} DUPLICATE {batchName} {folderName}";

                                // Check if the log entry has already been written
                                if (!writtenLogEntries.Contains(logEntry))
                                {
                                    // Append the log entry to the text file
                                    File.AppendAllText(originalTextFilePath, logEntry + Environment.NewLine);
                                    // Add the log entry to the HashSet
                                    writtenLogEntries.Add(logEntry);
                                }


                                string fileNames = Path.GetFileName(dupImg);
                                string dupPath = Path.Combine(duplicateFolder, batchName);

                                if (!Directory.Exists(dupPath))
                                {
                                    Directory.CreateDirectory(dupPath);
                                }

                                if (File.Exists(dupImg))
                                {
                                    string destination = Path.Combine(dupPath, folderName);
                                    File.Copy(dupImg, destination, true);
                                }

                            }


                        }


                        if (!batch.Equals(batchName))
                        {
                            int validc = Convert.ToInt32(dataGridLrd.Rows[i].Cells[4].Value.ToString());

                            // Inserting to the Database
                            if (validc > 0)
                            {
                                int imgcount = totalImagesInRow;

                                // Inserting Batch Table
                                BatchTable batchTable = new BatchTable(batcher, origPath, batchName, filedestination, validc, imgcount, DateTime.Now, 0);       
                                int batchid = conn.InsertBatchTableDB(batchTable);
                                conn.Maintain6BatchesWith3Active();                                

                                foreach (string jpgfile in jpgfiles)
                                {
                                    string folderName = Path.GetFileName(jpgfile);
                                    string BatchName = Path.GetFileName(Path.GetDirectoryName(jpgfile));
                                    string copyfilesPerFolder = Path.Combine(imagesfolder, BatchName);

                                    if (!jpgPerfolders.ContainsKey(BatchName))
                                    {
                                        jpgPerfolders[BatchName] = 1;
                                    }

                                    string new_img_name = $"{jpgPerfolders[BatchName]:D8}";
                                    int rec_num = jpgPerfolders[BatchName];

                                    if (!processedImages.Contains(folderName))
                                    {
                                        DateTime startTime = DateTime.Now;
                                        int batchtableID = ConnectDB.GetBatchTableID(BatchName);
                                        string jpg = ".jpg";

                                        if (!Directory.Exists(copyfilesPerFolder))
                                        {
                                            Directory.CreateDirectory(copyfilesPerFolder);
                                        }

                                        string destinationfile = Path.Combine(copyfilesPerFolder, new_img_name + jpg);

                                        if (!File.Exists(destinationfile))
                                        {
                                            File.Copy(jpgfile, destinationfile);
                                        }

                                        processedImages.Add(folderName);

                                        // Inserting Batch File Record
                                        BatchFile batchFile = new BatchFile(batchtableID, folderName, new_img_name, 0);
                                        conn.InsertBatchFileDB(batchFile,batchid);

                                        string mode = conn.GetTimelogMode();

                                        DateTime endTime = DateTime.Now;

                                        // Inserting Timelog Table
                                        Timelog timelog = new Timelog(rec_num, keyid, programType, mode, startTime, endTime, batchtableID, reportDate);
                                        conn.InsertTimeLogDB(timelog);

                                        // Count Image per folder
                                        jpgPerfolders[BatchName]++;

                                        //Inserting Entry Table Images

                                        string barcode = folderName.Substring(0, folderName.IndexOf('.'));
                                        //EntryTable entryTable = new EntryTable(batchid, "", barcode, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                                        //conn.InsertEntryTable(entryTable);
                                      //  conn.Maintain26RecordsEntryTbl();

                                        // Calculate elapsed time for the current row
                                        TimeSpan elapsedTime = endTime - startTime;

                                        // Accumulate total elapsed time
                                        totalElapsedTime += elapsedTime;

                                        // Display or store elapsed time for the current row in a TextBox
                                        if (ElapsedTime != null && !ElapsedTime.IsDisposed)
                                        {
                                            if (ElapsedTime.InvokeRequired)
                                            {
                                                ElapsedTime.Invoke((MethodInvoker)(() =>
                                                {
                                                    ElapsedTime.Text = $"{(int)sw.Elapsed.TotalSeconds} seconds" + Environment.NewLine;

                                                }));
                                            }
                                            else
                                            {
                                                ElapsedTime.Text = $"{(int)sw.Elapsed.TotalSeconds} seconds" + Environment.NewLine;
                                            }
                                        }

                                        processImagesInRow++;
                                        dataGridLrd.Rows[i].Cells[2].Value = $"{processImagesInRow} out of {totalImagesInRow}";

                                        // Update progress bar
                                        if (progressBar.InvokeRequired)
                                        {
                                            progressBar.Invoke((MethodInvoker)(() =>
                                            {
                                                if (progressBar.Value < progressBar.Maximum)
                                                {
                                                    progressBar.Value++;
                                                }

                                            }));
                                        }
                                        else
                                        {
                                            if (progressBar.Value < progressBar.Maximum)
                                            {
                                                progressBar.Value++;

                                            }
                                        }
                                    }

                                }

                            }

                            //Set the Status Column to DONE 
                            dataGridLrd.Rows[i].Cells[2].Value = "Done";
                        
                            //***************************** Processing Highlight *****************************\\
                            // Move selection to the next row
                            if (i < dataGridLrd.RowCount - 1)
                            {
                                if (dataGridLrd.InvokeRequired)
                                {
                                    dataGridLrd.Invoke((MethodInvoker)(() =>
                                    {
                                        dataGridLrd.ClearSelection();
                                        dataGridLrd.Rows[i + 1].Selected = true;
                                        dataGridLrd.CurrentCell = dataGridLrd.Rows[i + 1].Cells[0];
                                        dataGridLrd.FirstDisplayedScrollingRowIndex = i + 1;
                                        dataGridLrd.FirstDisplayedScrollingColumnIndex = i + 1;

                                    }));
                                }
                                else
                                {
                                    dataGridLrd.ClearSelection();
                                    dataGridLrd.Rows[i + 1].Selected = true;
                                    dataGridLrd.CurrentCell = dataGridLrd.Rows[i + 1].Cells[0];
                                    dataGridLrd.FirstDisplayedScrollingRowIndex = i + 1;
                                    dataGridLrd.FirstDisplayedScrollingColumnIndex = i + 1;
                                }

                                await Task.Delay(100);
                            }

                        }           
                    }

                    else if (result == DialogResult.No)
                    {

                        //  dataGridLrd.Rows[i].Cells[2].Value = "Canceled";
                        processImagesInRow++;
                        dataGridLrd.Rows[i].Cells[2].Value = $"{totalImagesInRow} out of {totalImagesInRow}";

                        //***************************** Processing Highlight *****************************\\
                        // Move selection to the next row
                        if (i < dataGridLrd.RowCount - 1)
                        {
                            if (dataGridLrd.InvokeRequired)
                            {
                                dataGridLrd.Invoke((MethodInvoker)(() =>
                                {
                                    dataGridLrd.ClearSelection();
                                    dataGridLrd.Rows[i + 1].Selected = true;
                                    dataGridLrd.CurrentCell = dataGridLrd.Rows[i + 1].Cells[0];
                                    dataGridLrd.FirstDisplayedScrollingRowIndex = i + 1;
                                    dataGridLrd.FirstDisplayedScrollingColumnIndex = i + 1;

                                }));
                            }
                            else
                            {
                                dataGridLrd.ClearSelection();
                                dataGridLrd.Rows[i + 1].Selected = true;
                                dataGridLrd.CurrentCell = dataGridLrd.Rows[i + 1].Cells[0];
                                dataGridLrd.FirstDisplayedScrollingRowIndex = i + 1;
                                dataGridLrd.FirstDisplayedScrollingColumnIndex = i + 1;
                            }

                            await Task.Delay(100);
                        }
                    }
                }
                else
                {
                    string pathName = dataGridLrd.Rows[i].Cells[0].Value.ToString();
                    string batchName = dataGridLrd.Rows[i].Cells[1].Value.ToString();
                  
                    //Getting files in the Directory
                    string[] jpgfiles = Directory.GetFiles(pathName, "*.jpg");

                    //******************************** Creating Duplicate Folders and Text ********************************\\

                    foreach (string dupImg in jpgfiles)
                    {
                        string folderName = Path.GetFileName(dupImg);                        
                        // Make sure Duplicate folder exist
                        if (!Directory.Exists(duplicateFolder))
                        {
                            Directory.CreateDirectory(duplicateFolder);
                        }

                        // Read existing duplicate log entries into the HashSet
                        string[] logFiles = Directory.GetFiles(duplicateFolder, "*.txt");
                        foreach (string logFile in logFiles)
                        {
                            string[] existingEntries = File.ReadAllLines(logFile);
                            foreach (string entry in existingEntries)
                            {
                                writtenLogEntries.Add(entry);
                            }
                        }

                        // Duplicates per folder
                        if (!fileDuplicates.ContainsKey(folderName))
                        {
                            fileDuplicates[folderName] = dupImg;
                        }
                        else
                        {
                            // Found a duplicate
                            string originalPath = fileDuplicates[folderName];
                            string originalFolder = Path.GetFileName(Path.GetDirectoryName(originalPath));

                            string originalLogFileName = $"{originalFolder} .txt";

                            string originalTextFilePath = Path.Combine(duplicateFolder, originalLogFileName);

                            // Log the original and duplicate folder names
                            string logEntry = $"{originalFolder} {folderName} DUPLICATE {batchName} {folderName}";

                            // Check if the log entry has already been written
                            if (!writtenLogEntries.Contains(logEntry))
                            {
                                // Append the log entry to the text file
                                File.AppendAllText(originalTextFilePath, logEntry + Environment.NewLine);
                                // Add the log entry to the HashSet
                                writtenLogEntries.Add(logEntry);
                            }


                            string fileNames = Path.GetFileName(dupImg);
                            string dupPath = Path.Combine(duplicateFolder, batchName);

                            if (!Directory.Exists(dupPath))
                            {
                                Directory.CreateDirectory(dupPath);
                            }

                            if (File.Exists(dupImg))
                            {
                                string destination = Path.Combine(dupPath, folderName);
                                File.Copy(dupImg, destination, true);
                            }

                        }


                    }


                    if (!batch.Equals(batchName))
                    {
                        int validc = Convert.ToInt32(dataGridLrd.Rows[i].Cells[4].Value.ToString());

                        // Inserting to the Database
                        if (validc > 0)
                        {
                            
                            int imgcount = totalImagesInRow;

                            // Inserting Batch Table
                            BatchTable batchTable = new BatchTable(batcher, origPath, batchName, filedestination, validc, imgcount, DateTime.Now, 0);
                            int batchid = conn.InsertBatchTableDB(batchTable);
                            conn.Maintain6BatchesWith3Active();

                            foreach (string jpgfile in jpgfiles)
                            {
                                string folderName = Path.GetFileName(jpgfile);
                                string BatchName = Path.GetFileName(Path.GetDirectoryName(jpgfile));
                                string copyfilesPerFolder = Path.Combine(imagesfolder, BatchName);

                                if (!jpgPerfolders.ContainsKey(BatchName))
                                {
                                    jpgPerfolders[BatchName] = 1;
                                }

                                string new_img_name = $"{jpgPerfolders[BatchName]:D8}";
                                int rec_num = jpgPerfolders[BatchName];

                                if (!processedImages.Contains(folderName))
                                {
                                    DateTime startTime = DateTime.Now;
                                    int batchtableID = ConnectDB.GetBatchTableID(BatchName);
                                    string jpg = ".jpg";

                                    if (!Directory.Exists(copyfilesPerFolder))
                                    {
                                        Directory.CreateDirectory(copyfilesPerFolder);
                                    }

                                    string destinationfile = Path.Combine(copyfilesPerFolder, new_img_name + jpg);

                                    if (!File.Exists(destinationfile))
                                    {
                                        File.Copy(jpgfile, destinationfile);
                                    }

                                    processedImages.Add(folderName);

                                    // Inserting Batch File Record
                                    BatchFile batchFile = new BatchFile(batchtableID, folderName, new_img_name, 0);
                                    int batchfileid = conn.InsertBatchFileDB(batchFile, batchid);

                                    string mode = conn.GetTimelogMode();

                                    DateTime endTime = DateTime.Now;

                                    // Inserting Timelog Table
                                    Timelog timelog = new Timelog(rec_num, keyid, programType, mode, startTime, endTime, batchtableID, reportDate);
                                    conn.InsertTimeLogDB(timelog);

                                    // Count Image per folder
                                    jpgPerfolders[BatchName]++;

                                    //Inserting Entry Table Images
                                    string barcode = folderName.Substring(0, folderName.IndexOf('.'));
                                    EntryTable entryTable = new EntryTable(batchfileid, "", barcode, "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    conn.InsertEntryTable(entryTable);


                                    // Calculate elapsed time for the current row
                                    TimeSpan elapsedTime = endTime - startTime;

                                    // Accumulate total elapsed time
                                    totalElapsedTime += elapsedTime;

                                    // Display or store elapsed time for the current row in a TextBox
                                    if (ElapsedTime != null && !ElapsedTime.IsDisposed)
                                    {
                                        if (ElapsedTime.InvokeRequired)
                                        {
                                            ElapsedTime.Invoke((MethodInvoker)(() =>
                                            {
                                                ElapsedTime.Text = $"{(int)sw.Elapsed.TotalSeconds} seconds" + Environment.NewLine;

                                            }));
                                        }
                                        else
                                        {
                                            ElapsedTime.Text = $"{(int)sw.Elapsed.TotalSeconds} seconds" + Environment.NewLine;
                                        }
                                    }

                                    processImagesInRow++;
                                    dataGridLrd.Rows[i].Cells[2].Value = $"{processImagesInRow} out of {totalImagesInRow}";

                                    // Update progress bar
                                  
                                    if (progressBar.InvokeRequired)
                                    {
                                        progressBar.Invoke((MethodInvoker)(() =>
                                        {
                                            if (progressBar.Value < progressBar.Maximum)
                                            {
                                                progressBar.Value++;

                                            }

                                        }));
                                    }
                                    else
                                    {
                                        if (progressBar.Value < progressBar.Maximum)
                                        {
                                            progressBar.Value++;

                                        }
                                    }
                                }
                            }
                        }

                        //Set the Status Column to DONE 
                
                        dataGridLrd.Rows[i].Cells[2].Value = "Done";
                    }

                    //***************************** Processing Highlight *****************************\\
                    // Move selection to the next row
                    if (i < dataGridLrd.RowCount - 1)
                    {
                        if (dataGridLrd.InvokeRequired)
                        {
                            dataGridLrd.Invoke((MethodInvoker)(() =>
                            {
                                dataGridLrd.ClearSelection();
                                dataGridLrd.Rows[i + 1].Selected = true;
                                dataGridLrd.CurrentCell = dataGridLrd.Rows[i + 1].Cells[0];
                                dataGridLrd.FirstDisplayedScrollingRowIndex = i + 1;
                                dataGridLrd.FirstDisplayedScrollingColumnIndex = i + 1;

                            }));
                        }
                        else
                        {
                            dataGridLrd.ClearSelection();
                            dataGridLrd.Rows[i + 1].Selected = true;
                            dataGridLrd.CurrentCell = dataGridLrd.Rows[i + 1].Cells[0];
                            dataGridLrd.FirstDisplayedScrollingRowIndex = i + 1;
                            dataGridLrd.FirstDisplayedScrollingColumnIndex = i + 1;
                        }

                        await Task.Delay(100);
                    }

                }
            }

            conn.Commit();
            conn.DisconnectDb();
            sw.Stop();
            MessageBox.Show("Batching process completed.", "Batching Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private HashSet<string> writtenLogEntries = new HashSet<string>();
        private Dictionary<string, string> fileDuplicates = new Dictionary<string, string>();

       

        // Update total Images and total duplicates when remove 
        public void updateTotalValue(DataGridViewRow selectedRow)
        {
            int valueToSubtract = 0;
            int valueImgToSubtract = 0;

            if (selectedRow.Cells[3].Value.ToString() != null)
            {
                int cellValue;
                if (int.TryParse(selectedRow.Cells[3].Value.ToString(), out cellValue))
                {
                    valueToSubtract += cellValue;
                }
                else
                {
                    return;
                }
            }

            int imgCellValue;
            if (int.TryParse(selectedRow.Cells[5].Value.ToString(), out imgCellValue))
            {

            }

            int currentTotalImg;
            if (int.TryParse(totalImgCnt.Text, out currentTotalImg))
            {
                currentTotalImg -= valueToSubtract;
                totalImgCnt.Text = currentTotalImg.ToString();
            }
        }

        // Back the data to the small grid when pressing remove
        public void backToGridSml(DataGridViewRow selectedRow)
        {
            dataGridSml.Rows.Add(selectedRow.Cells[1].Value, selectedRow.Cells[3].Value, selectedRow.Cells[0].Value, selectedRow.Cells[5].Value);
        }

        public void updateTotalDuplicateValue(DataGridViewRow selectedRow)
        {
            int valueToSubtract = 0;

            if (selectedRow.Cells[5].Value != null)
            {
                int cellValue;
                if (int.TryParse(selectedRow.Cells[5].Value.ToString(), out cellValue))
                {
                    valueToSubtract = cellValue;
                }
                else
                {
                    return;
                }
            }

            int currentTotal;
            if (int.TryParse(totalDuplicatesCnt.Text, out currentTotal))
            {
                currentTotal -= valueToSubtract;
                totalDuplicatesCnt.Text = currentTotal.ToString();
            }

        }

        // Clear all Rows in the Data Grid
        public void clearRows(DataGridViewSelectedRowCollection selectedRow)
        {
            if (selectedRow.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridLrd.Rows)
                {
                    backToGridSml(row);
                }

            }
            dataGridLrd.Rows.Clear();
            totalImgCnt.Text = String.Empty;
            totalDuplicatesCnt.Text = String.Empty;
            ElapsedTime.Text = String.Empty;

        }



        // Getting the Duplicates record in every folder
        public int getDuplicatesJpg(string[] jpgFilesPerfolder)
        {
            dupjpgfileList = new List<string>();
            foreach (string path in jpgFilesPerfolder)
            {
                if (!jpgfileList.Contains(Path.GetFileName(path)))
                {
                    jpgfileList.Add(Path.GetFileName(path));
                    jpgFileWholePathList.Add(path);
                }
                else
                {
                    dupjpgfileList.Add(path);
                    alldups.Add(path);
                }
            }

            return alldups.Count();
        }

        // Cancel Button
        public void CancelButton()
        {
            string cancel = "Canceled";

            for (int i = 0; i < dataGridLrd.Rows.Count; i++)
            {
                dataGridLrd.Rows[i].Cells[2].Value = cancel;
            }
            
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke((MethodInvoker)(() =>
                {
                   
                    progressBar.Maximum = 26;
                }));
            }
            else
            {
          
                progressBar.Value = 26;
            }
         
            cancelRequest = true;

        }
    }
}
