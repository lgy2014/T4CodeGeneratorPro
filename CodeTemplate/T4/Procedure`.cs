using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeTemplate.T4
{
    public partial class Procedure : IGenerator
    {
        private string _fileName;
        public string ClassName { get; private set; }
        public string SqlText { get; private set; }
        public string NameSpace { get; private set; }
        public string[] SqlLines { get; private set; }
        private string basePath = null;

        public Procedure(string sqlText, string procName, string nameSpace, string prefix)
        {
            NameSpace = nameSpace;
            if (string.IsNullOrEmpty(nameSpace))
            {
                NameSpace = "MyNameSpace";
            }
            DateTime time = DateTime.Now;
            string notPrefix = procName;
            if (!string.IsNullOrEmpty(prefix))
            {
                notPrefix = notPrefix.Replace(prefix, "");
            }
            ClassName = string.Format("_{0}_{1}_Procedure", time.ToString("yyyyMMddHHmmss"), notPrefix);

            basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeFiles");
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            _fileName = Path.Combine(basePath, ClassName + ".cs");

            SqlLines = sqlText.Split(new string[]{"\r\n"},StringSplitOptions.None);
        }

        public Procedure(string sqlText, string procName) : this(sqlText,procName, "MyNameSpace",null) { }


        public string FileName
        {
            get
            {
                return _fileName;
            }
        }

        public string TransformTextP()
        {
            return TransformText();
        }

        public void SaveToCodeFile()
        {
            SaveToCodeFile(FileName);
        }

        public void SaveToCodeFile(string filename)
        {
            File.WriteAllText(filename, TransformTextP());
        }
    }
}
