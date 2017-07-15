using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTemplate.T4
{
    /// <summary>
    /// 
    /// </summary>
    /// object_id	name	index_id	type	type_desc	is_unique	data_space_id	ignore_dup_key	is_primary_key	is_unique_constraint	fill_factor	is_padded	is_disabled	is_hypothetical	allow_row_locks	allow_page_locks	has_filter	filter_definition 1333579789	PK_AAAddff	1	1	CLUSTERED	0	1	0	0	0	0	0	0	0	1	1	0	NULL
    public class SysIndex
    {
        public Int32 object_id { get; set; }
        public string name { get; set; }
        public Int32 index_id { get; set; }
        public Byte type { get; set; }
        public String type_desc { get; set; }
        public Boolean is_unique { get; set; }
        public Boolean is_primary_key { get; set; }
        public Boolean is_unique_constraint { get; set; }

    }
}
