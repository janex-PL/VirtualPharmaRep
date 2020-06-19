using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Services.SecurityServices
{
    public class PermissionDetailCrudService : IPermissionDetailCrudService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        private const string CancelTokenKey = "permission-settings-cancel-token";
        private const string SettingsKey = "permission-settings";

        public PermissionDetailCrudService(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IList<PermissionDetail>> Get()
        {
            return await _context.Set<PermissionDetail>().ToListAsync();
        }

        public async Task<PermissionDetail> Get(int id)
        {
            return await _context.Set<PermissionDetail>().FirstOrDefaultAsync(pd => pd.Id == id);
        }

        public async Task<PermissionDetail> Edit(int id, string permissionLevels)
        {
            var entry = await _context.Set<PermissionDetail>().FirstOrDefaultAsync(pd => pd.Id == id);

            if (entry == null)
                return null;

            entry.PermissionLevels = permissionLevels;
            await _context.SaveChangesAsync();

            await RefreshCacheData();

            return entry;
        }

        public async Task RefreshCacheData()
        {
            var entries = await Get();
            if (_cache.TryGetValue(SettingsKey, out IList<PermissionDetail> _) &&
                _cache.TryGetValue(CancelTokenKey, out CancellationTokenSource cancelToken))
            {
                cancelToken.Cancel();
            }

            var tokenSource = new CancellationTokenSource();
            var token = new CancellationChangeToken(tokenSource.Token);

            _cache.Set(SettingsKey, entries, new MemoryCacheEntryOptions().AddExpirationToken(token));
            _cache.Set(CancelTokenKey, tokenSource);
        }

        public IList<PermissionDetail> GetFromCache()
        {
            return _cache.TryGetValue(SettingsKey, out IList<PermissionDetail> options) ? options : null;
        }
    }
}
