using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTemplate.T4
{
    public class GeneratorFactory
    {
        public static IGenerator GetInstance(string generatorType,string tableName,string nameSpace,string prefix)
        {
            IGenerator generator = null;
            switch (generatorType)
            {
                case "Model":
                    generator = new Model(tableName, nameSpace,prefix);
                    break;
                case "Migration":
                    generator = new Migration(tableName,nameSpace,prefix);
                    break;
                case "SeedData":
                    generator = new SeedData(tableName, nameSpace,prefix);
                    break;
                default:
                    break;
            }
            return generator;
        }

        public static IGenerator GetInstance(string generatorType, string tableName)
        {
            return GetInstance(generatorType,tableName,null);
        }

        public static IGenerator GetInstance(string generatorType, string tableName,string nameSpace)
        {
            return GetInstance(generatorType, tableName, nameSpace, null);
        }
    }
}
