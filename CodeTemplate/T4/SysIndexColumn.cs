using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTemplate.T4
{
    /// <summary>
    /// 
    /// </summary>
    /// object_id	index_id	index_column_id	column_id	key_ordinal	partition_ordinal	is_descending_key	is_included_column 1333579789	1	1	3	1	0	0	0
    public class SysIndexColumn
    {
        public Int32 object_id { get; set; }
        public Int32 index_id { get; set; }
        public Int32 index_column_id { get; set; }
        public Int32 column_id { get; set; }
        public string column { get; set; }
    }
}
