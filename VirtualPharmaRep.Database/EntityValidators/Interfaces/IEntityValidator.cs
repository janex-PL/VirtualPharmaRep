using System.Threading.Tasks;
using VirtualPharmaRep.Data.CustomObjects;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Database.EntityValidators.Interfaces
{
    public interface IEntityValidator<in T> where T: class, IEntity
    {
	    Task PerformValidationChecks(T entity, PermissionResolverResult permissionResult);
    }
}
