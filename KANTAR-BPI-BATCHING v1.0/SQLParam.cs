using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KANTAR_BPI_BATCHING_v1._0
{
    internal class SQLParam
    {
        private int type;
        private String field;
        private Object data;

        public int getType
        {
            set { type = value; }
            get { return type; }

        }

        public String getField
        {
            set { field = value; }
            get { return field; }
        }
        public Object getData
        {
            set { data = value; }
            get { return data; }
        }
    }
 
}
