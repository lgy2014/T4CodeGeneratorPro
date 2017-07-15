using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4CodeGenerator.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// name	object_id	principal_id	schema_id	parent_object_id	type	type_desc	create_date	modify_date	is_ms_shipped	is_published	is_schema_published	lob_data_space_id	filestream_data_space_id	max_column_id_used	lock_on_bulk_load	uses_ansi_nulls	is_replicated	has_replication_filter	is_merge_published	is_sync_tran_subscribed	has_unchecked_assembly_data	text_in_row_limit	large_value_types_out_of_row	is_tracked_by_cdc	lock_escalation	lock_escalation_desc
    /// t_AudioInfo	757577737	NULL	1	0	U 	USER_TABLE	2016-11-21 11:38:27.817	2016-11-21 11:52:56.180	0	0	0	1	NULL	15	0	1	0	0	0	0	0	0	0	0	0	TABLE
    public class SysTable:Entity
    {
        public string name { get; set; }
        public int object_id { get; set; }
        public string type { get; set; }
    }
}
