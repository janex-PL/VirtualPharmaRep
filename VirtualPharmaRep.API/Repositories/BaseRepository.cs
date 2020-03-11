﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities.Interfaces;
using VirtualPharmaRep.API.Repositories.Interfaces;

namespace VirtualPharmaRep.API.Repositories
{
	public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
		where TEntity : class, IEntity
		where TContext : ApplicationDbContext
	{
		private readonly TContext _context;

		protected BaseRepository(TContext context) => _context = context;
		public async Task<List<TEntity>> GetAll() => await _context.Set<TEntity>().ToListAsync();

		public async Task<TEntity> Get(int id) => await _context.Set<TEntity>().FindAsync(id);

		public async Task<TEntity> Add(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<TEntity> Update(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<TEntity> Delete(int id)
		{
			var entity = await _context.Set<TEntity>().FindAsync(id);
			if (entity == null)
				return null;
			_context.Set<TEntity>().Remove(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}