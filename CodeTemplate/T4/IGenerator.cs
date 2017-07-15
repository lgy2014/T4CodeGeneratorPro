using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTemplate.T4
{
    public interface IGenerator
    {
        string FileName { get; }
        string TransformTextP();
        /// <summary>
        /// 保存为代码文件
        /// </summary>
        void SaveToCodeFile();
        /// <summary>
        /// 保存为代码文件
        /// </summary>
        /// <param name="filename">代码文件的绝对路径</param>
        void SaveToCodeFile(string filename);
    }
}
