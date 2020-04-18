using System.Threading.Tasks;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.Interfaces
{
    public interface IClinicService
    {
	    Task<Clinic[]> Get();
	    Task<Clinic> Get(int id);
	    Task<Clinic> Add(Clinic newClinic);
	    Task<Clinic> Edit(Clinic newClinic);
	    Task<Clinic> Delete(int id);
    }
}
