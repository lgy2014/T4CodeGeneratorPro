﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 12.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CodeTemplate.T4
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class Migration : MigrationBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
                    "m.Text;\r\n\r\nnamespace ");
            
            #line 7 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NameSpace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    class ");
            
            #line 9 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(":IMigration\r\n    {\r\n        public void Create(string connectionString)\r\n        " +
                    "{\r\n\t\t\tStringBuilder createBuilder = new StringBuilder(500);\r\n            createB" +
                    "uilder.AppendLine(\"CREATE TABLE ");
            
            #line 14 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Table.name));
            
            #line default
            #line hidden
            this.Write(" (\");\r\n");
            
            #line 15 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
  foreach (var item in Columns)
	   {
		   string identity = string.Empty;
		if (item.is_identity)
		{
			identity = " IDENTITY(1,1)";
		}

		string notNull = string.Empty;
        if (!item.is_nullable)
        {
            notNull = " NOT NULL";
        }
		string column_max="("+item.max+")";
        if (string.IsNullOrEmpty(item.collation_name))
        {
			column_max=string.Empty;
        }
	   
            
            #line default
            #line hidden
            this.Write("\t\t\tcreateBuilder.AppendLine(\"\\t ");
            
            #line 34 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.name));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 34 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.user_type));
            
            #line default
            #line hidden
            
            #line 34 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(column_max));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 34 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(notNull));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 34 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(identity));
            
            #line default
            #line hidden
            this.Write(",\");\r\n");
            
            #line 35 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
} 
            
            #line default
            #line hidden
            this.Write("            int len = Environment.NewLine.Length + 1;\r\n            createBuilder." +
                    "Remove(createBuilder.Length - len, len);//移除最后一个逗号。\r\n");
            
            #line 38 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
 if (SysIndexClumns != null && SysIndexClumns.Length > 0)
  {
            
            #line default
            #line hidden
            this.Write("\t\t\tcreateBuilder.Append(\"\\t,PRIMARY KEY(\");\r\n");
            
            #line 41 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
 
	foreach (var item in SysIndexClumns)
{
            
            #line default
            #line hidden
            this.Write("            createBuilder.Append(\"");
            
            #line 44 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.column));
            
            #line default
            #line hidden
            this.Write(",\");\r\n");
            
            #line 45 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
} 
            
            #line default
            #line hidden
            this.Write("\t\t\tcreateBuilder.Remove(createBuilder.Length - 1, 1);//移除最后一个逗号。\r\n\t\t\tcreateBuilde" +
                    "r.Append(\")\");\r\n");
            
            #line 48 "D:\_coding.net\Lgy\T4CodeGeneratorPro\CodeTemplate\T4\Migration.tt"
}
            
            #line default
            #line hidden
            this.Write("            createBuilder.AppendLine(\");\");\r\n            string sql = createBuild" +
                    "er.ToString();\r\n\t\t\tWebCommon.SqlDBHelper.ExecuteNonQuery(connectionString, sql, " +
                    "commandType: System.Data.CommandType.Text);\r\n        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public class MigrationBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
