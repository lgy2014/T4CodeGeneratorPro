using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.Application._SysDatabase.Dto
{
    public class SysDatabaseDto:EntityDto
    {
        public Int16 dbid { get; set; }
        public string name { get; set; }
    }
}
