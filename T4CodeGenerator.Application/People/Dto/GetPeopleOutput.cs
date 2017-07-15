using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.Application.People.Dto
{
    public class GetPeopleOutput : Entity
    {
        public List<PersonDto> People { get; set; }
    }
}
