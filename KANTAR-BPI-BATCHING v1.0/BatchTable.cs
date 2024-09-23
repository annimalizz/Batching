using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KANTAR_BPI_BATCHING_v1._0
{
    public class BatchTable
    {
        private int id;
        private string batcher;
        private string origPath;
        private string batchName;
        private string newPath;
        private int validCounts;
        private int img_counts;
        private DateTime dateBatched;
        private int arhive;

        public BatchTable(string batcher, string origPath, string batcthName, string newPath, int validCounts, int img_counts, DateTime dateBatched, int archive)
        {
            
            this.batcher = batcher;
            this.origPath = origPath;
            this.batchName = batcthName;
            this.newPath = newPath;
            this.validCounts = validCounts;
            this.img_counts = img_counts;
            this.dateBatched = dateBatched;
            this.arhive = archive;
        }



        public int getId 
        { 
            set { id = value;}
            get { return id; } 
        }

        public string getBatcher
        { 
            get { return batcher; } 
            set { batcher = value; }
        }

        public string getOrigPath 
        {  
            get { return origPath; } set { origPath = value; } 
        }

        public string getBatchName 
        { 
            get { return batchName; } set { batchName = value; }
        }

        public string getNewPath
        {
            get { return newPath; }
            set { newPath = value; }
        }

        public int getValidCounts
        {
            get { return validCounts; }
            set { validCounts = value; }
        }

        public int getImgCounts
        {
            get { return img_counts; }
            set { img_counts = value; }
        }
        public DateTime getDateBatched 
        {  
            get { return dateBatched; }
            set { dateBatched = value; } 
        }

        public int getArchive
        {
            get { return arhive; }
            set { arhive = value; }
        }
    }
}
