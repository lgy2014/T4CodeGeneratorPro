using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Application._SysTable.Dto;
using T4CodeGenerator.Core;
using T4CodeGenerator.Core.IRepositories;

namespace T4CodeGenerator.Application._SysTable
{
    public class SysTableAppService:T4CodeGeneratorAppServiceBase,ISysTableAppService
    {
        private readonly ISysTableRepository _sysTableRepository;

        public SysTableAppService(ISysTableRepository sysTableRepository)
        {
            _sysTableRepository = sysTableRepository;
            Logger = NullLogger.Instance;
        }

        public List<SysTableDto> GetSystablesByDbName(string dbName)
        {
            List<SysTable> list = _sysTableRepository.GetSystablesByDbName(dbName);
            if (null ==list)
            {
                return null;
            }
            List<SysTableDto> listdto = new List<SysTableDto>();
            foreach (var item in list)
            {
                SysTableDto dto = AutoMapper.Mapper.Map<SysTableDto>(item);
                listdto.Add(dto);
            }

            return listdto;
        }

        public List<SysTableDto> GetSysViewsByDbName(string dbName)
        {
            List<SysTable> list = _sysTableRepository.GetSysViewsByDbName(dbName);
            if (null==list)
            {
                return null;
            }
            List<SysTableDto> listdto = new List<SysTableDto>();
            foreach (var item in list)
            {
                SysTableDto dto = AutoMapper.Mapper.Map<SysTableDto>(item);
                listdto.Add(dto);
            }

            return listdto;
        }
    }
}
