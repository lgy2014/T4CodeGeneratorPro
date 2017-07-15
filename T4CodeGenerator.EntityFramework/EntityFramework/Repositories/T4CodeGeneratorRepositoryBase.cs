using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.EntityFramework.EntityFramework.Repositories
{
    public abstract class T4CodeGeneratorRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<T4CodeGeneratorDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected T4CodeGeneratorRepositoryBase(IDbContextProvider<T4CodeGeneratorDbContext> dbContextProvider) : base(dbContextProvider) { }
    }

    public abstract class T4CodeGeneratorRepositoryBase<TEntity> : EfRepositoryBase<T4CodeGeneratorDbContext, TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected T4CodeGeneratorRepositoryBase(IDbContextProvider<T4CodeGeneratorDbContext> dbContextProvider) : base(dbContextProvider) { }
    }
}
