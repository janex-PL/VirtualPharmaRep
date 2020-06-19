using System.Security.Claims;
using VirtualPharmaRep.Data.CustomObjects;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Services.SecurityServices
{
    public interface IPermissionResolverService
    {
        PermissionResolverResult GetPermissionLevel<TEntity>(ClaimsPrincipal user, string httpMethod) where TEntity : class, IEntity;
    }
}
