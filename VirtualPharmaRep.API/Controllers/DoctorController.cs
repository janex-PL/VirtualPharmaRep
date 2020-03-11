using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VirtualPharmaRep.API.Entities;
using VirtualPharmaRep.API.Repositories;
using VirtualPharmaRep.API.ViewModels;

namespace VirtualPharmaRep.API.Controllers
{
	public class DoctorController : BaseApiController<DoctorViewModel,Doctor,DoctorRepository>
	{
		public DoctorController(DoctorRepository repository) : base(repository)
		{
		}
	}
}