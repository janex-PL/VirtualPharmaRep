using System;
using Microsoft.Extensions.DependencyInjection;
using VirtualPharmaRep.Data.Entities.Interfaces;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Validators
{
	public static class EntityValidator<TEntity>
		where TEntity : class, IEntity
	{
		private readonly IRepos
		public static bool ValidateEntityId(int id)
		{
			
			using()
		}
	}
}
