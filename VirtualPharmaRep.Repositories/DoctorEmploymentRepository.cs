using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Repositories
{
    public class DoctorEmploymentRepository : BaseRepository<DoctorEmployment,ApplicationDbContext>
    {
	    public DoctorEmploymentRepository(ApplicationDbContext context) : base(context)
	    {
	    }

	    public async Task<List<DoctorEmployment>> GetByDoctor(int doctorId) => await Context.Set<DoctorEmployment>()
		    .Where(de => de.DoctorId == doctorId).ToListAsync();

	    public async Task<List<DoctorEmployment>> GetByClinic(int clinicId) => await Context.Set<DoctorEmployment>()
		    .Where(de => de.ClinicId == clinicId).ToListAsync();
    }
}
