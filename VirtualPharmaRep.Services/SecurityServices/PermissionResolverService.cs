using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using VirtualPharmaRep.Data.CustomObjects;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Services.SecurityServices
{
    public class PermissionResolverService : IPermissionResolverService
    {
        private readonly IPermissionDetailCrudService _permissionDetailService;

        public PermissionResolverService(IPermissionDetailCrudService permissionDetailService)
        {
            _permissionDetailService = permissionDetailService;
        }

        public PermissionResolverResult GetPermissionLevel<TEntity>(ClaimsPrincipal user, string httpMethod)
            where TEntity : class, IEntity
        {
            var entityType = ParseEntityType(typeof(TEntity).Name);
            var httpMethodType = ParseHttpMethod(httpMethod);
            var permissionDetails = _permissionDetailService.GetFromCache().OrderByDescending(pd => pd.PermissionRank);

            foreach (var detail in permissionDetails)
            {
                if (!user.IsInRole(detail.RoleName))
                    continue;

                var permissions =
                    ConvertDetailToList(detail.PermissionLevels[(int) entityType * 4 + (int) httpMethodType]
                        .ToString());
                if (!permissions.First())
                    return new PermissionResolverResult
                    {
                        AccessLevel = AccessLevel.None,
                        SendRequest = SendRequest.None
                    };
                return new PermissionResolverResult
                {
                    AccessLevel = permissions[1]
                        ? AccessLevel.Global
                        : AccessLevel.Private,
                    SendRequest = permissions[2]
                        ? SendRequest.All
                        : permissions[3]
                            ? SendRequest.GlobalOnly
                            : SendRequest.None
                };
            }

            return new PermissionResolverResult
            {
                AccessLevel = AccessLevel.None,
                SendRequest = SendRequest.None
            };
        }

        private static ApplicationEntities ParseEntityType(string entityName)
        {
            return Enum.TryParse(entityName, out ApplicationEntities result) ? result : ApplicationEntities.None;
        }

        private static HttpMethods ParseHttpMethod(string methodName)
        {
            return Enum.TryParse(methodName, out HttpMethods result) ? result : HttpMethods.None;
        }

        private static List<bool> ConvertDetailToList(string hex)
        {
            var details = Convert.ToString(Convert.ToInt32(hex, 16), 2);
            return details.Select(detail => detail.ToString() == "1").ToList();
        }
    }
   

}