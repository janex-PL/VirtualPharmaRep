using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.SecurityServices
{
    public interface IPermissionDetailCrudService
    {
        public Task<IList<PermissionDetail>> Get();
        public Task<PermissionDetail> Get(int id);
        public Task<PermissionDetail> Edit(int id, string permissionLevels);
        public Task RefreshCacheData();
        public IList<PermissionDetail> GetFromCache();
    }
}