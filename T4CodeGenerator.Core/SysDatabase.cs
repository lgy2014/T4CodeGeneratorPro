using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4CodeGenerator.Core
{
    public class SysDatabase:Entity
    {
        public Int16 dbid { get; set; }
        public string name { get; set; }
    }
}
