using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
	    Task<List<T>> Get();
	    Task<T> Get(int id);
	    Task<T> Add(T entity);
	    Task<T> Edit(T entity);
	    Task<T> Delete(int id);
    }
}
