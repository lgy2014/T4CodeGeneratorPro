using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTemplate.T4
{
    /// <summary>
    /// 
    /// </summary>
    /// object_id	name	column_id	system_type_id	user_type_id	max_length	precision	scale	collation_name	is_nullable	is_ansi_padded	is_rowguidcol	is_identity	is_computed	is_filestream	is_replicated	is_non_sql_subscribed	is_merge_published	is_dts_replicated	is_xml_document	xml_collection_id	default_object_id	rule_object_id	is_sparse	is_column_set
    /// 2137058649	CourtCode	1	167	167	50	0	0	Chinese_PRC_CI_AS	0	1	0	0	0	0	0	0	0	0	0	0	0	0	0	0
    public class SysColumn
    {
        public Int32 object_id { get; set; }
        public Int32 column_id { get; set; }
        public string name { get; set; }
        public Int32 user_type_id { get; set; }
        public string user_type { get; set; }
        public Boolean is_identity { get; set; }
        public Boolean is_nullable { get; set; }
        public string collation_name { get; set; }
        
        public Int16 max_length { get; set; }
        
        public string max
        {
            get
            {
                string ret = "max";
                if (max_length > 0)
                {
                    ret = max_length.ToString();
                }
                return ret;
            }
        }
    }
}
