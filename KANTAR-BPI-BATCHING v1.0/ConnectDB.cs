using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI.Design;
using System.Windows.Forms;
using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace KANTAR_BPI_BATCHING_v1._0
{
    public class ConnectDB
    {
        // Connect to local host database
        private static string connectDB = "host=192.168.23.178;port=3306;database=kantar-bpi-fernandez;user=alluser;password=alluser;";
        private  MySqlConnection _conn;
        private  MySqlTransaction _transaction;
        private MySqlCommand _command;

        
        public void Connect()
        {
            _conn = new MySqlConnection(connectDB);
            _conn.Open();
            _command = _conn.CreateCommand();
            _transaction = _conn.BeginTransaction();
            _command.Transaction = _transaction;
        }
        public void Commit()
        {
            _command.Transaction.Commit();
        }

        public void RollBack()
        {
            _command.Transaction.Rollback();
        }

        public void DisconnectDb()
        {
            _transaction.Dispose();
            _command.Dispose();
            _conn.Close();
        }

        // The User Exist in the database
        public bool isUserExist(string user, string pass)
        {                   
            _command.CommandText = "SELECT * FROM user_table WHERE username = @user AND password = @pass";         
            _command.Parameters.AddWithValue("@user", user);
            _command.Parameters.AddWithValue("@pass", pass);

            return (_command.ExecuteScalar() != null);
        }

        // Inserting Batch Table
        public int InsertBatchTableDB(BatchTable batchTable)
        {
            _command.Parameters.Clear();
            _command.CommandText = "INSERT INTO batch_table (batcher, orig_path, batch_name, new_path, valid_counts, img_counts, date_batched, archive)" +
                                        "VALUES (@batcher, @orig_path, @batch_name, @new_path, @valid_counts, @img_counts, @date_batched, @archive)";
            _command.Parameters.AddWithValue("@batcher", batchTable.getBatcher);
            _command.Parameters.AddWithValue("@orig_path", batchTable.getOrigPath);
            _command.Parameters.AddWithValue("@batch_name", batchTable.getBatchName);
            _command.Parameters.AddWithValue("@new_path", batchTable.getNewPath);
            _command.Parameters.AddWithValue("@valid_counts", batchTable.getValidCounts);
            _command.Parameters.AddWithValue("@img_counts", batchTable.getImgCounts);
            _command.Parameters.AddWithValue("@date_batched", batchTable.getDateBatched);
            _command.Parameters.AddWithValue("@archive", batchTable.getArchive);
            _command.ExecuteNonQuery();
            return (int)_command.LastInsertedId;
        }

        // Batch Table Archive Updating Existing
        public void Maintain6BatchesWith3Active()
        {
            // Get the latest 6 batch IDs ordered by date_batched
            _command.CommandText = "SELECT id FROM batch_table ORDER BY date_batched DESC";

            List<int> batchIds = new List<int>();
            using (MySqlDataReader reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    batchIds.Add(reader.GetInt32(0));
                }
            }

            // Ensure only the latest 3 batches are active, the rest are inactive
            for (int i = 0; i < batchIds.Count; i++)
            {
                string updateQuery = i < 3
                    ? "UPDATE batch_table SET archive = 0 WHERE id = @id"
                    : "UPDATE batch_table SET archive = 1 WHERE id = @id";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, _conn);
                updateCmd.Parameters.AddWithValue("@id", batchIds[i]);
                updateCmd.ExecuteNonQuery();
            }

            // Delete oldest records if more than 6
            if (batchIds.Count > 6)
            {
                for (int i = 6; i < batchIds.Count; i++)
                {
                    string deleteQuery = "DELETE FROM batch_table WHERE id = @id";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, _conn);
                    deleteCmd.Parameters.AddWithValue("@id", batchIds[i]);
                    deleteCmd.ExecuteNonQuery();
                }
            }
        }


        // Inserting data to Batch File Table
        public int InsertBatchFileDB(BatchFile batchFile,int id)
        {
            _command.Parameters.Clear();
            _command.CommandText = "INSERT INTO batch_file_tbl (batch_tbl_id, orig_name, new_img_name, forEntry)" + 
                    "VALUES (@batch_tbl_id, @orig_name, @new_img_name, @forEntry)";          
            _command.Parameters.AddWithValue("@batch_tbl_id", id);
            _command.Parameters.AddWithValue("@orig_name", batchFile.getOrigName);
            _command.Parameters.AddWithValue("@new_img_name", batchFile.getnewName);
            _command.Parameters.AddWithValue("@forEntry", batchFile.getForEntry);
            _command.ExecuteNonQuery();
            return (int)_command.LastInsertedId;
        }

        // Inserting Time Log Table
        public void InsertTimeLogDB(Timelog timelog)
        {
            _command.Parameters.Clear();
            _command.CommandText = "INSERT INTO timelog_tbl(rec_num, key_id, program_type, mode, start_time, end_time, batch_file_tbl_id, report_date)" +
                    "VALUES (@rec_num, @key_id, @program_type, @mode, @start_time, @end_time, @batch_file_tbl_id, @report_date)";        
            _command.Parameters.AddWithValue("@rec_num", timelog.getRecNum);
            _command.Parameters.AddWithValue("@key_id", timelog.getKeyId);
            _command.Parameters.AddWithValue("@program_type", timelog.getProgramType);
            _command.Parameters.AddWithValue("@mode", timelog.getMode);
            _command.Parameters.AddWithValue("@start_time", timelog.getStartTime);
            _command.Parameters.AddWithValue("@end_time", timelog.getEndTime);
            _command.Parameters.AddWithValue("@batch_file_tbl_id", timelog.getBatchFileId);
            _command.Parameters.AddWithValue("@report_date", timelog.getReportDateType);
            _command.ExecuteNonQuery();


        }

        // Inserting Entry Table
        public void InsertEntryTable(EntryTable entryTable)
        {
            _command.Parameters.Clear();
            _command.CommandText = "INSERT INTO entry_tbl (batch_file_tbl_id, pull_out, barcode, productName, preparation, energy_kj, energy_kcal," +
                    "protein, carbohydrates, sugar, fat, saturates, mono_unsaturates, poly_unsaturates, fiber, soduim, salt)" +
                    "VALUES (@batch_file_tbl_id, @pull_out, @barcode, @productName, @preparation, @energy_kj, @energy_kcal, @protein, @carbohydrates, " +
                    "@sugar, @fat, @saturates, @mono_unsaturates, @poly_unsaturates, @fiber, @soduim, @salt)";       
            _command.Parameters.AddWithValue("@batch_file_tbl_id", entryTable.GetBatchTblId);
            _command.Parameters.AddWithValue("@pull_out", entryTable.Getpullout);
            _command.Parameters.AddWithValue("@barcode", entryTable.GetBarcode);
            _command.Parameters.AddWithValue("@productName", entryTable.GetProductName);
            _command.Parameters.AddWithValue("@preparation", entryTable.GetPreparation);
            _command.Parameters.AddWithValue("@energy_kj", entryTable.GetEnergyKJ);
            _command.Parameters.AddWithValue("@energy_kcal", entryTable.GetEnergy_Kcal);
            _command.Parameters.AddWithValue("@protein", entryTable.GetProtein);
            _command.Parameters.AddWithValue("@carbohydrates", entryTable.GetCarbohydrates);
            _command.Parameters.AddWithValue("@sugar", entryTable.GetSugar);
            _command.Parameters.AddWithValue("@fat", entryTable.GetFat);
            _command.Parameters.AddWithValue("@saturates", entryTable.GetSaturates);
            _command.Parameters.AddWithValue("@mono_unsaturates", entryTable.GetMonoUnsaturates);
            _command.Parameters.AddWithValue("@poly_unsaturates", entryTable.GetPolyUnsaturates);
            _command.Parameters.AddWithValue("@fiber", entryTable.GetFiber);
            _command.Parameters.AddWithValue("@soduim", entryTable.GetSodium);
            _command.Parameters.AddWithValue("@salt", entryTable.GetSalt);
            _command.ExecuteNonQuery();


        }

        public static void UpdateBatchArchive(string batchname, int arcvhive)
        {
            bool hasSaveRecord = false;

            using(var conn = new MySqlConnection(connectDB))
            {
                // string updateQuery = "UPDATE your_table SET name = @newName WHERE id = @id";
                conn.Open();
                string query = "UPDATE batch_Table SET archive = @arcvhive Where batch_name = @Bathcnmae";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Set the parameters
                    cmd.Parameters.AddWithValue("@arcvhive", arcvhive);
                    cmd.Parameters.AddWithValue("@Bathcnmae", batchname);

                    // Execute the update command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Optional: Check how many rows were affected
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record updated successfully.");
                        hasSaveRecord = true;
                    }
                    else
                    {
                        Console.WriteLine("No record found with the specified ID.");
                        hasSaveRecord = false;
                    }
                }
            }
        }

        // Checking the database for existing records 
        public static bool CheckDatabaseForRecords(string batchName)
        {
            bool hasRecords = false;

            using(var conn = new MySqlConnection(connectDB))
            {
                conn.Open();
                string query = "SELECT * FROM batch_table WHERE batch_name = @batch_name";

                using(var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@batch_name", batchName);
                    using (MySqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            hasRecords = true;
                        }
                    }
                }               
            }

            return hasRecords;
        }
        

        // Time Log mode change
        public string GetTimelogMode()
        {
            string mode = "Batched";

            _command.CommandText = "SELECT COUNT(*)  FROM timelog_tbl";

            int count = Convert.ToInt32(_command.ExecuteScalar());
            if (count >= 26)
            {
                mode = "Rebatch";
            }

            return mode;
        }

        // Truncate Batch Table
        public void TruncateBatchTable()
        {
            _command.CommandText = "TRUNCATE TABLE batch_table";
            _command.ExecuteNonQuery();
        }

        // Truncate Batch File Table
        public void BatchFileTruncate()
        {
            _command.CommandText = "TRUNCATE TABLE batch_file_tbl";

            _command.ExecuteNonQuery();
        }

        // Truncate TimeLog Table
        public void TruncateTimeLog()
        {
            _command.CommandText = "TRUNCATE TABLE timelog_tbl";
            _command.ExecuteNonQuery();
        }

        // Truncate the Entry Table 
        public void TruncateEntryTable()
        {
            _command.CommandText = "TRUNCATE TABLE entry_tbl";
            _command.ExecuteNonQuery();
        }

        // Getting the Batch Table Id
        public static int GetBatchTableID(string batchName)
        {
            int getBatchTableID = 0;
            string query = "SELECT id FROM batch_table WHERE batch_name = @batch_name";

            using (MySqlConnection conn = new MySqlConnection(connectDB))
            {
                           
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@batch_name", batchName);
                conn.Open();

                object result = cmd.ExecuteScalar();

                if(result != null)
                {
                    getBatchTableID = Convert.ToInt32(result);
                }
                conn.Close();
               
            }
            return getBatchTableID;

        }
    }
}
