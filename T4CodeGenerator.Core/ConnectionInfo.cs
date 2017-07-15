using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.Core
{
    public class ConnectionInfo:Entity
    {
        public string FServer { get; set; }
        public int FType { get; set; }
        public string FUserId { get; set; }
        public string FPassword { get; set; }
        public int FRemember { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}.", Id, FServer, FType, FUserId, FPassword, FRemember);
        }
    }
}
