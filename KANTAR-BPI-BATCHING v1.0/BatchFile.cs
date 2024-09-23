using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace KANTAR_BPI_BATCHING_v1._0
{
    public class BatchFile
    {
        private int batchTbl;
        private string origName;
        private string newName;
        private int forEntry;

        public BatchFile(int batchTbl, string origName, string newName, int forEntry)
        {
            this.batchTbl = batchTbl;
            this.origName = origName;
            this.newName = newName;
            this.forEntry = forEntry;     
        }

        public int getBatchTbl
        {
            get { return batchTbl; }
            set { batchTbl = value; }
        }

        public string getOrigName 
        {
            get { return origName; }
            set {  origName = value; }
        }

        public string getnewName
        {
            get { return newName; }
            set { newName = value; }
        }

        public int getForEntry
        {
            get { return forEntry; }
            set { forEntry = value; }
        }


    }
}
