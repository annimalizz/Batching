using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KANTAR_BPI_BATCHING_v1._0
{
    public class Timelog
    {
        private int id;
        private int recNum;
        private string keyId;
        private string programType;
        private string mode;
        private DateTime startTime;
        private DateTime endTime;
        private string batchDir;
        private int batchTableId;
        private int batchFileId;
        private string imageName;
        private DateTime reportDate;


        public Timelog(int recNum, string keyId, string programType, string mode, DateTime startTime, DateTime endTime,
             int batchFileId, DateTime reportDate)
        {
            
            this.recNum = recNum;
            this.keyId = keyId;
            this.programType = programType;
            this.mode = mode;
            this.startTime = startTime;
            this.endTime = endTime;
            this.batchFileId = batchFileId;
            this.reportDate = reportDate;
        }

        public int getId
        { 
            get { return id; } 
            set { id = value; } 
        }

        public int getRecNum
        {
            get { return recNum; }
            set {  recNum = value; }
        }

        public string getKeyId
        {
            get { return keyId; }
            set { keyId = value; }
        }

        public string getProgramType
        {
            get { return programType; }
            set { programType = value; }
        }

        public string getMode
        {
            get { return mode; }
            set { mode = value; }
        }

        public DateTime getStartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public DateTime getEndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public string getBatchDir
        {
            get { return batchDir; }
            set { batchDir = value; }
        }

        public int getBatchTableId
        {
            get { return batchTableId; }
            set { batchTableId = value; }
        }

        public int getBatchFileId
        {
            get { return batchFileId; }
            set { batchFileId = value; }
        }

        public string getImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }

        public DateTime getReportDateType
        {
            get { return reportDate; }
            set { reportDate = value; }
        }
    }
}
