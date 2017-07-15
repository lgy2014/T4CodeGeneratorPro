using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.Application._SysTable.Dto
{
    public class SysTableDto:EntityDto
    {
        public string name { get; set; }
        public int object_id { get; set; }
        public string type { get; set; }
    }
}
