using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using T4CodeGenerator.Application.People.Dto;

namespace T4CodeGenerator.Application.People
{
    public interface IPersonAppService :ITransientDependency //IApplicationService
    {
        Task<GetPeopleOutput> GetAllPeopleAsync();

        Task AddNewPerson(AddNewPersonInput input);

        void Test();
    }
}
