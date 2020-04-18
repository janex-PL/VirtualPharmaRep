using System.Threading.Tasks;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.Interfaces
{
    public interface IDoctorService
    {
		Task<Doctor[]> Get();
		Task<Doctor> Get(int id);
		Task<Doctor> Add(Doctor newDoctor);
		Task<Doctor> Edit(Doctor newDoctor);
		Task<Doctor> Delete(int id);
	}
}
