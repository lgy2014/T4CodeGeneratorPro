using System.Data;
using Abp.Domain.Repositories;
using AutoMapper;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Application.People.Dto;
using T4CodeGenerator.Core.IRepositories;
using T4CodeGenerator.Core.People;

namespace T4CodeGenerator.Application.People
{
    public class PersonAppService : IPersonAppService //T4CodeGeneratorAppServiceBase
    {
        private IPersonRepository _personRepository;

        public PersonAppService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Dto.GetPeopleOutput> GetAllPeopleAsync()
        {

            //return new GetPeopleOutput
            //{
            //    People = Mapper.Map<List<PersonDto>>(await _personRepository.GetAllListAsync())
            //};
            return null;
        }

        public async Task AddNewPerson(Dto.AddNewPersonInput input)
        {
            //Logger.Debug("Adding a new person: " + input.Name);
            //await _personRepository.InsertAsync(new Person { Name = input.Name });

        }


        public void Test()
        {
            _personRepository.Test();
        }
    }
}
