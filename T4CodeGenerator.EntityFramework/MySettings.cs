using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration;

namespace T4CodeGenerator.EntityFramework
{
    internal class MySettings : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                //new SettingDefinition("sqlite",ConfigurationManager.ConnectionStrings["Default"].ConnectionString), 
                new SettingDefinition("sqlite","")
            };
        }
    }
}
