using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using VirtualPharmaRep.API.Entities;
using VirtualPharmaRep.API.Repositories;
using VirtualPharmaRep.API.ViewModels;

namespace VirtualPharmaRep.API.Controllers
{
	public class ClinicController : BaseApiController<ClinicViewModel,Clinic,ClinicRepository>
	{
		public ClinicController(ClinicRepository repository) : base(repository)
		{
		}
	}
}