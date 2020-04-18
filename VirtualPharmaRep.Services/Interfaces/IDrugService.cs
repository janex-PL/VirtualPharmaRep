using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.Interfaces
{
    public interface IDrugService
    {
		Drug[] GetAllDrugs();
		Drug GetDrug(int id);
		Drug AddDrug(Drug newDrug);
		Drug EditDrug(Drug newDrug);
		Drug DeleteDrug(int id);
	}
}
