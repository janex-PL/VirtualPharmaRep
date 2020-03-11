using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Repositories
{
	public class DoctorEmploymentRepository : BaseRepository<DoctorEmployment,ApplicationDbContext>
	{
		public DoctorEmploymentRepository(ApplicationDbContext context) : base(context)
		{
			
		}

		public async Task<List<DoctorEmployment>> GetAllByDoctor(int id)
		{
			var doctorEmployments = await GetAll();
			return doctorEmployments.Where(de => de.DoctorId == id).ToList();
		}

		public async Task<List<DoctorEmployment>> GetAllByClinic(int id)
		{
			var doctorEmployments = await GetAll();
			return doctorEmployments.Where(de => de.ClinicId == id).ToList();
		}
	}
}