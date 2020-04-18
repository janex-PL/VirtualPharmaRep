using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.Entities.Interfaces;
using VirtualPharmaRep.Repositories.Interfaces;

namespace VirtualPharmaRep.Repositories
{
    public class BaseRepository<TEntity,TContext> : IRepository<TEntity>
		where TEntity : class, IEntity
        where TContext : DbContext
    {
	    public TContext Context { get; private set; }

	    public BaseRepository(TContext context) => Context = context;

	    public async Task<List<TEntity>> Get() => await Context.Set<TEntity>().ToListAsync();

	    public async Task<TEntity> Get(int id) => await Context.Set<TEntity>().FindAsync(id);

	    public async Task<TEntity> Add(TEntity entity)
	    {
			entity.CreatedDateTime = DateTime.Now;
			entity.LastModifiedDateTime = entity.CreatedDateTime;

		    Context.Set<TEntity>().Add(entity);
		    await Context.SaveChangesAsync();

		    return entity;
	    }

	    public async Task<TEntity> Edit(TEntity entity)
	    {
			entity.LastModifiedDateTime = DateTime.Now;

			Context.Entry(entity).State = EntityState.Modified;
			Context.Entry(entity).Property(e => e.CreatedDateTime).IsModified = false;

			await Context.SaveChangesAsync();
			return entity;
		}

	    public async Task<TEntity> Delete(int id)
	    {
		    var entity = await Context.Set<TEntity>().FindAsync(id);

		    if (entity == null)
			    return null;

		    Context.Set<TEntity>().Remove(entity);
		    await Context.SaveChangesAsync();

		    return entity;
	    }

	    public async Task<bool> IsForeignKeyValid<T>(object id) where T : class
	    {
		    return typeof(T) == typeof(ApplicationUser)
			    ? await Context.Set<T>().FindAsync((string) id) != null
			    : await Context.Set<T>().FindAsync((int) id) != null;
	    }
    }
}
