using System.Text.Json;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using VirtualPharmaRep.API.Entities.Interfaces;
using VirtualPharmaRep.API.Repositories.Interfaces;
using VirtualPharmaRep.API.ViewModels.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseApiController<TModel ,TEntity, TRepository> : ControllerBase
		where TModel : class, IViewModel
		where TEntity : class, IEntity
		where TRepository : IRepository<TEntity>
	{
		private readonly TRepository _repository;
		protected JsonSerializerOptions JsonSerializerOptions { get; private set; }

		public BaseApiController(TRepository repository)
		{
			_repository = repository;
			JsonSerializerOptions = new JsonSerializerOptions()
			{
				WriteIndented = true
			};
		}

		[HttpGet]
		public virtual async Task<IActionResult> Get()
		{
			var entities = await _repository.GetAll();
			return new JsonResult(entities.Adapt<TModel[]>(),JsonSerializerOptions);
		}

		[HttpGet("{id}")]
		public virtual async Task<IActionResult> Get(int id)
		{
			var entity = await _repository.Get(id);

			if (entity == null)
				return NotFound();

			return new JsonResult(entity.Adapt<TModel>(),JsonSerializerOptions);
		}

		[HttpPut]
		public virtual async Task<IActionResult> Put([FromBody]TModel model)
		{
			if(model == null)
				return new StatusCodeResult(500);

			var entity = model.Adapt<TEntity>();
			var response = await _repository.Update(entity);

			return new JsonResult(response.Adapt<TModel>(),JsonSerializerOptions);
		}

		[HttpPost]
		public virtual async Task<IActionResult> Post([FromBody]TModel model)
		{
			if(model == null)
				return new StatusCodeResult(500);

			var entity = model.Adapt<TEntity>();
			await _repository.Add(entity);

			return new JsonResult(entity.Adapt<TModel>(),JsonSerializerOptions);
		}

		[HttpDelete("{id}")]
		public virtual async Task<ActionResult<TEntity>> Delete(int id)
		{
			var entity = await _repository.Delete(id);

			if (entity == null)
				return NotFound();

			return new NoContentResult();
		}
	}
}