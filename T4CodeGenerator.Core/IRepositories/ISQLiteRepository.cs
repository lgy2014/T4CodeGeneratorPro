using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Entities;

namespace T4CodeGenerator.Core.IRepositories
{
    public interface ISQLiteRepository<TEntity, TPrimaryKey> : ITransientDependency
        where TEntity:class ,IEntity<TPrimaryKey>
    {
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(TPrimaryKey Id);
        int Count(TPrimaryKey Id);

        IList<TEntity> GetList();
    }

    public interface ISQLiteRepository<TEntity> : ISQLiteRepository<TEntity, int>
        where TEntity:class ,IEntity<int>
    {
        
    }
}
