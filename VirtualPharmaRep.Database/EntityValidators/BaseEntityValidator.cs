using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.CustomObjects;
using VirtualPharmaRep.Data.Entities.Interfaces;
using VirtualPharmaRep.Database.EntityValidators.Interfaces;

namespace VirtualPharmaRep.Database.EntityValidators
{
    public class BaseEntityValidator<TEntity, TContext> : IEntityValidator<TEntity>
    where TEntity : class, IEntity
    where TContext : DbContext
    {
        public BaseEntityValidator(TContext context)
        {
            Context = context;
        }

        public TContext Context { get; }

        public virtual async Task PerformValidationChecks(TEntity entity, PermissionResolverResult permissionResult)
        {
        }
    }
}
