using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Compatibility.VB6;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace KANTAR_BPI_BATCHING_v1._0
{
    public partial class Form1 : Form
    {
        private int totalDuplicate = 0;


        Functions functions = new Functions();
        ConnectDB conn = new ConnectDB();
        BatchFile batchFile = new BatchFile(1, "", "", 1);
        private volatile bool cancelRequest = false;
        private MySqlTransaction transaction;




        // List of All Images
        private HashSet<string> listImg = new HashSet<string>();


        private bool isAdd = false;

        public Form1()
        {
            InitializeComponent();


        }

        private void driveListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // Add only one rows if press Batch Button
        private void add_BTN_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in batchgridSML.SelectedRows)
            {
                int rowIdx = row.Index; // To remove the Index

                string dir = row.Cells[2].Value.ToString(); // Path Name
                string batchName = row.Cells[0].Value.ToString(); // Batch Name 
                string status = "PENDING"; // Status Column
                string totalImage = row.Cells[1].Value.ToString(); // Total Image

                var result = ProcessImages(dir);
                var totalValidCount = result.totalValidCount;
                var totalDuplicateCount = result.totalDuplicateCount;


                batchgridLrg.Rows.Add(dir, batchName, status, totalImage, totalValidCount, totalDuplicateCount);
                batchgridSML.Rows.RemoveAt(rowIdx);

            }

            int getTotalPerRow = Convert.ToInt32(batchgridLrg.Rows[0].Cells[3].Value); // Getting Total images Per row
            getTotalPerRow += batchgridLrg.Rows.Cast<DataGridViewRow>()
                                         .Skip(1)
                                         .Sum(totalImagesInRow => Convert.ToInt32(totalImagesInRow.Cells[3].Value));

            // Put the Value on the textbox 
            TotalImgCnt_TXTBOX.Text = getTotalPerRow.ToString();


            int totalDuplicate = batchgridLrg.Rows.Cast<DataGridViewRow>() // Total Duplicate Images 
                                       .Sum(row => Convert.ToInt32(row.Cells[5].Value));

            totalDup_TXTBOX.Text = totalDuplicate.ToString(); // Put the Value on the textbox 

        }



        public (int totalValidCount, int totalDuplicateCount) ProcessImages(string folderPath)
        {
            string[] imgs = Directory.GetFiles(folderPath, "*.jpg"); // Assuming you want to process .jpg files
            int totalValidCount = 0;
            int totalDuplicateCount = 0;

            foreach (string img in imgs)
            {
                string fileName = Path.GetFileName(img);

                if (!listImg.Contains(fileName))
                {
                    listImg.Add(fileName);
                    totalValidCount++;
                }
                else
                {
                    totalDuplicateCount++;
                }
            }

            return (totalValidCount, totalDuplicateCount);
        }


        // Add All rows if press Batch All Button

        private void AddALL_BTN_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in batchgridSML.Rows)
            {

                string dir = row.Cells[2].Value.ToString(); // Path Name
                string batchName = row.Cells[0].Value.ToString(); // Batch Name 
                string status = "PENDING";  // Status
                string totalImages = row.Cells[1].Value.ToString(); // Total Images

                var result = ProcessImages(dir);
                var totalValidCount = result.totalValidCount;
                var totalDuplicateCount = result.totalDuplicateCount;

                batchgridLrg.Rows.Add(dir, batchName, status, totalImages, totalValidCount, totalDuplicateCount);
            }

            batchgridSML.Rows.Clear();

            int getTotalPerRow = Convert.ToInt32(batchgridLrg.Rows[0].Cells[3].Value); // Getting Total images Per row
            getTotalPerRow += batchgridLrg.Rows.Cast<DataGridViewRow>()
                                         .Skip(1)
                                         .Sum(totalImagesInRow => Convert.ToInt32(totalImagesInRow.Cells[3].Value));

            // Put the Value on the textbox 
            TotalImgCnt_TXTBOX.Text = getTotalPerRow.ToString();


            int totalDuplicate = batchgridLrg.Rows.Cast<DataGridViewRow>()         // Total Duplicate Images 
                                       .Sum(row => Convert.ToInt32(row.Cells[5].Value));

            getTotalDuplicateCount();
            //totalDup_TXTBOX.Text = totalDuplicate.ToString(); // Put the Value on the textbox
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Process Batch Button
        private void Batch_BTN_Click(object sender, EventArgs e)
        {
            if (batchgridLrg.RowCount != 0)
            {
                //ConnectDB.BeginTransaction();

                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                   
                    //ConnectDB.CommitTransaction();
                }
            }
        }

        private void batchgridLrg_SelectionChanged(object sender, EventArgs e)
        {
            //bool IsDatabaseFull = ConnectDB.CheckDatabaseForRecords();
            //if (IsDatabaseFull)
            //{
            //    if (batchgridLrg.SelectedRows.Count > 0)
            //    {
            //        foreach (DataGridViewRow row in batchgridLrg.SelectedRows)
            //        {
            //            string selectedValues = functions.PopUpmessage();
            //            if (!string.IsNullOrWhiteSpace(selectedValues))
            //            {
            //                MessageBox.Show($"Are you sure you want to Rebatch\n{selectedValues}");
            //            }
            //        }
            //    }
            //}

            //if (!isAdd)
            //{
            //    string selectedValues = functions.PopUpmessage();
            //    if (!string.IsNullOrWhiteSpace(selectedValues))
            //    {
            //        MessageBox.Show($"Are you sure you want to Rebatch\n{selectedValues}");
            //    }
            //}
        }

        // Truncate The SQL Table if they press TRUNCATE BUTTON
        private void truncate_BTN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Truncate? ", "Confirm Truncate",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
               
                conn.Connect();
                conn.TruncateBatchTable();
                conn.BatchFileTruncate();
                conn.TruncateTimeLog();
                conn.TruncateEntryTable();
                conn.DisconnectDb();
                MessageBox.Show("The database has been truncated.", "Truncate Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // If the user clicked "No", do nothing
                MessageBox.Show("Truncate operation was canceled.", "Operation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        // Removing data on the large grid based on the selected
        private void remove_Click(object sender, EventArgs e)
        {
            listImg.Clear();
            foreach (DataGridViewRow row in batchgridLrg.SelectedRows)
            {

                functions.updateTotalValue(row);
                functions.updateTotalDuplicateValue(row);

                var batchName = row.Cells[1].Value;
                var totalImages = row.Cells[3].Value;
                var pathName = row.Cells[0].Value;
                var totalDuplicates = row.Cells[5].Value;

                batchgridSML.Rows.Add(batchName, totalImages, pathName, totalDuplicates);

                int rowIndx = row.Index;
                batchgridLrg.Rows.RemoveAt(rowIndx);

            }

            foreach (DataGridViewRow row in batchgridLrg.Rows)
            {

                string dir = row.Cells[0].Value.ToString(); // Path Name
                var result = ProcessImages(dir);
                row.Cells[4].Value = result.totalValidCount;
                row.Cells[5].Value = result.totalDuplicateCount;

            }

            getTotalDuplicateCount();

        }


        // Clear all rows if selected
        private void clearButtonClick(object sender, EventArgs e)
        {
            listImg.Clear();

            foreach (DataGridViewRow row in batchgridLrg.Rows)
            {
                var batchName = row.Cells[1].Value;
                var totalImages = row.Cells[3].Value;
                var pathName = row.Cells[0].Value;
                var totalDuplicates = row.Cells[5].Value;

                batchgridSML.Rows.Add(batchName, totalImages, pathName, totalDuplicates);
            }
            batchgridLrg.Rows.Clear();
            TotalImgCnt_TXTBOX.Clear();
            totalDup_TXTBOX.Clear();
            elapsedTime_TXTBOX.Clear();

        }

        // Exit Application
        private void Exit_BTN_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            Environment.Exit(0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cancel_BTN_Click(object sender, EventArgs e)
        {           
            functions.CancelButton();
        }

        private void TotalImgCnt_TXTBOX_TextChanged(object sender, EventArgs e)
        {

        }

        private void elapsedTime_TXTBOX_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }


        // Double Click the DIR Files to get Directories
        private void dirListBox1_DoubleClick(object sender, EventArgs e)
        {
            functions.dirListBoxDoubleClick();

        }


        // Background Worker do the Batching
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            functions.batching();

        }

        // Close the program and it will not running in the TASK BAR
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ElapsedTimer_Tick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Getters of All Elements in form 1
        /// </summary>


        public static string totalElapsedTime
        {
            get; set;
        }

        private DirListBox getDirlistBox
        {
            get { return dirListBox1; }
        }

        private DataGridView getbatchGridSML
        {
            get { return batchgridSML; }
        }

        private Button getAddBatch
        {
            get { return addAltA_BTN; }
        }

        private Button getAddAllBatch
        {
            get { return AddALL_BTN; }
        }

        private Button getRemoveBtn
        {
            get { return Remove_BTN; }
        }

        private Button getClearBtn
        {
            get { return Clear_BTN; }
        }

        private Button getTruncateBtn
        {
            get { return truncate_BTN; }
        }

        private Button getCancelBtn
        {
            get { return cancel_BTN; }
        }

        private DataGridView getDataGridLrg
        {
            get { return batchgridLrg; }
        }

        private DataGridView getDataGridSml
        {
            get { return batchgridSML; }
        }

        private TextBox getTotalImgCnt
        {
            get { return TotalImgCnt_TXTBOX; }
        }

        private TextBox getElapsedTime
        {
            get { return elapsedTime_TXTBOX; }
        }

        private TextBox getTotalDuplicatesCnt
        {
            get { return totalDup_TXTBOX; }
        }

        private TextBox getOperator
        {
            get { return operator_txtbox; }
        }

        private BackgroundWorker getbackgroundWorker1
        {
            get { return backgroundWorker1; }
        }

        private ProgressBar getProgressBar
        {
            get { return progressBar1; }
        }

        private Timer getElapsedTimer
        {
            get { return ElapsedTimer; }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            batchgridLrg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            operator_txtbox.Text = Form2.User_Name;
            functions.form1DirListBox = getDirlistBox;
            functions.form1DataGrid = getbatchGridSML;
            functions.dataGridSml = getbatchGridSML;
            functions.addBatch_BTN = getAddBatch;
            functions.dataGridLrd = getDataGridLrg;
            functions.dataGridSml = getDataGridSml;
            functions.totalImgCnt = getTotalImgCnt;
            functions.totalDuplicatesCnt = getTotalDuplicatesCnt;
            functions.remove_btn = getRemoveBtn;
            functions.clear_btn = getClearBtn;
            functions.addAllBatch_BTN = getAddAllBatch;
            functions.operatorTxtBox = getOperator;
            functions.trucate_btn = getTruncateBtn;
            functions.Cancelbatch_btn = getCancelBtn;
            functions.worker = getbackgroundWorker1;
            functions.progressBar = getProgressBar;
            functions.elapsedTimer = getElapsedTimer;
            functions.ElapsedTime = getElapsedTime;

        }



        private void Exit_BTN_Enter(object sender, EventArgs e)
        {

        }

        private void Exit_BTN_MouseEnter(object sender, EventArgs e)
        {

        }

        private void dirListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("sadsad");
        }


        public void getTotalDuplicateCount()
        {
            int totalDUpli = 0;

            foreach (DataGridViewRow row in batchgridLrg.Rows)
            {
                // Check if the row is not a new row
                if (!row.IsNewRow)
                {
                    var cellValue = row.Cells[5].Value;
                    if (cellValue != null)
                    {

                        int totalget = int.Parse(cellValue.ToString());

                        totalDUpli += totalget;
                    }
                }
            }
            totalDup_TXTBOX.Text = totalDUpli.ToString();
        }
    }
}
