using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace QUEMENARRASANGULAR.EntityFramework.Repositories
{
    public abstract class QUEMENARRASANGULARRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<QUEMENARRASANGULARDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected QUEMENARRASANGULARRepositoryBase(IDbContextProvider<QUEMENARRASANGULARDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class QUEMENARRASANGULARRepositoryBase<TEntity> : QUEMENARRASANGULARRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected QUEMENARRASANGULARRepositoryBase(IDbContextProvider<QUEMENARRASANGULARDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
