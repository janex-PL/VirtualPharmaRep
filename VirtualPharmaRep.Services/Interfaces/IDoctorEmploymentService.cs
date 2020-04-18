using System.Threading.Tasks;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.Interfaces
{
	public interface IDoctorEmploymentEmploymentService
	{
		#region REST Methods
		Task<DoctorEmployment[]> Get();
		Task<DoctorEmployment> Get(int id);
		Task<DoctorEmployment> Add(DoctorEmployment newDoctorEmployment);
		Task<DoctorEmployment> Edit(DoctorEmployment newDoctorEmployment);
		Task<DoctorEmployment> Remove(int id);
		#endregion
		Task<DoctorEmployment[]> GetByDoctor(int doctorId);
		Task<DoctorEmployment[]> GetByClinic(int clinicId);
	}
}
