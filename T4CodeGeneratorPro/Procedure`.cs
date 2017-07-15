using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4CodeGeneratorPro
{
    public partial class Procedure
    {
        public string FileName { get; private set; }
        public string ClassName { get; private set; }
        public string SqlText { get; private set; }
        public string NameSpace { get; private set; }
        public string[] SqlLines { get;private set; }

        public Procedure(string sqlText,string procName, string nameSpace)
        {
            NameSpace = nameSpace;
            DateTime time = DateTime.Now;
            ClassName = string.Format("_{0}_{1}_Procedure", time.ToString("yyyyMMddHHmmss"), procName);
            FileName = ClassName + ".cs";

            SqlLines = sqlText.Split(new string[]{"\r\n"},StringSplitOptions.None);
        }

        public Procedure(string sqlText, string procName) : this(sqlText,procName, "MyNameSpace") { }

    }
}
