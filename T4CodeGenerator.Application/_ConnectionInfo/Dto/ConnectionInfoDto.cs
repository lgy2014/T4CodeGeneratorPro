using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.Application._ConnectionInfo.Dto
{
    public class ConnectionInfoDto:EntityDto
    {
        public string FServer { get; set; }
        public int FType { get; set; }
        public string FUserId { get; set; }
        public string FPassword { get; set; }
        public int FRemember { get; set; }
    }
}
