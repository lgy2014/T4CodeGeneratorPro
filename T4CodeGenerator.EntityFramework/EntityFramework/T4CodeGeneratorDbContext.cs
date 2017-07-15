using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Core;
using T4CodeGenerator.Core.People;

namespace T4CodeGenerator.EntityFramework.EntityFramework
{
    public class T4CodeGeneratorDbContext : AbpDbContext
    {
        public virtual IDbSet<Person> People { get; set; }
        public virtual IDbSet<SysDatabase> SysDatabase { get; set; }
        public virtual IDbSet<SysTable> SysTable { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public T4CodeGeneratorDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in AbpWpfDemoDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of AbpWpfDemoDbContext since ABP automatically handles it.
         */
        public T4CodeGeneratorDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
