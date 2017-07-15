using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.Application.People.Dto
{
    public class AddNewPersonInput : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
