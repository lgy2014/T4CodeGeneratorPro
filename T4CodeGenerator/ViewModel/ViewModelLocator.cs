using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T4CodeGenerator.Application.People;

namespace T4CodeGenerator.ViewModel
{
    public class ViewModelLocator : ISingletonDependency
    {
        private MainViewModel _main;
        public CodeGenerateViewModel CodeGenerateViewModel2 { get; set; }
        public CodeForSqlViewModel CodeForSqlViewModel2 { get; set; }
        public IPersonAppService PersonAppService { get; set; }
        public ViewModelLocator()
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return _main;
            }
            set
            {
                _main = value;
            }
        }

    }
}
