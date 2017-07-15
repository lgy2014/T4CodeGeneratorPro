using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.Core.People
{
    [Table("People")]
    public class Person : Entity
    {
        public string Name { get; set; }
    }
}
