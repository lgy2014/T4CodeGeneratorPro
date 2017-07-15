using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.Application.People.Dto
{
    public class PersonDto:EntityDto
    {
        public string Name { get; set; }
    }
}
