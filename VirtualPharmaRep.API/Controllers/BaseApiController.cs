using System.Text.Json;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using VirtualPharmaRep.Data.CustomObjects;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.Entities.Interfaces;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Repositories.Interfaces;

namespace VirtualPharmaRep.API.Controllers
{
	/// <summary>
	/// Base API Controller
	/// </summary>
	public abstract class BaseApiController<TEntity,TRepository,TViewModel> : ControllerBase
		where TEntity : class, IEntity
		where TRepository : IRepository<TEntity>
		where TViewModel : class, IEntity
	{
		#region Properties


		protected readonly TRepository Repository;
		/// <summary>
		/// JSON serializing options
		/// </summary>
		protected JsonSerializerOptions JsonSerializerOptions { get; private set; }
		/// <summary>
		/// Injected role manager
		/// </summary>
		protected RoleManager<IdentityRole> RoleManager { get; private set; }
		/// <summary>
		/// Injected user manager
		/// </summary>
		protected UserManager<ApplicationUser> UserManager { get; private set; }
		/// <summary>
		/// Injected application configuration
		/// </summary>
		protected IConfiguration Configuration { get; private set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor with injected properties
		/// </summary>
		/// <param name="roleManager"></param>
		/// <param name="userManager"></param>
		/// <param name="configuration"></param>
		/// <param name="repository"></param>
		protected BaseApiController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,
			IConfiguration configuration, TRepository repository)
		{
			RoleManager = roleManager;
			UserManager = userManager;
			Configuration = configuration;
			Repository = repository;
			JsonSerializerOptions = new JsonSerializerOptions()
			{
				WriteIndented = true
			};
		}
		#endregion
		#region Methods

		[HttpGet]
		public virtual async Task<IActionResult> Get()
		{
			var result = await Repository.Get();

			return new JsonResult(result.Adapt<TViewModel[]>(), JsonSerializerOptions);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var result = await Repository.Get(id);

			return result switch
			{
				null => NotFound(new { Error = $"Couldn't find {typeof(TEntity).Name} with id: {id}." }),
				_ => new JsonResult(result.Adapt<ClinicViewModel>(), JsonSerializerOptions)
			};
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] TViewModel model)
		{
			if (model == null)
				return BadRequest(new
				{
					Error = "Required data was not provided"
				});

			var entity = model.Adapt<TEntity>();

			var validationResult = await PerformValidationChecks(entity);

			if (!validationResult.IsSuccess)
				return BadRequest(new
				{	
					Error = validationResult.Message
				});

			var result = await Repository.Add(entity);

			return result switch
			{
				null => Conflict(new { Error = $"{typeof(TEntity).Name} already exists." }),
				_ => new JsonResult(result.Adapt<TViewModel>(), JsonSerializerOptions)
			};
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] TViewModel model)
		{

			if (model == null)
				return BadRequest(new
				{
					Error = "Required data was not provided"
				});

			var entity = model.Adapt<TEntity>();

			var validationResult = await PerformValidationChecks(entity);

			if (!validationResult.IsSuccess)
				return BadRequest(new
				{
					Error = validationResult.Message
				});


			var result = await Repository.Edit(entity);

			return result switch
			{
				null => NotFound(new { Error = $"Couldn't find {typeof(TEntity).Name} with id: {model.Id}" }),
				_ => new JsonResult(result.Adapt<TViewModel>(), JsonSerializerOptions)
			};
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var entity = await Repository.Delete(id);

			return entity switch
			{
				null => Ok(new { Message = $"{typeof(TEntity).Name} with id: {id} doesn't exist." }),
				_ => Accepted(new JsonResult(entity.Adapt<ClinicViewModel>(), JsonSerializerOptions))
			};
		}

		public async virtual Task<EntityValidationResult> PerformValidationChecks(TEntity entity)
		{
			return new EntityValidationResult(true, string.Empty);
		}
		#endregion
	}
}