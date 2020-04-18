using System.Threading.Tasks;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.Interfaces
{
    public interface IDrugPropertyReportService
    {
		Task<DrugPropertyReport[]> Get();
		Task<DrugPropertyReport> Get(int id);
		Task<DrugPropertyReport> Add(DrugPropertyReport newDrugPropertyReport);
		Task<DrugPropertyReport> Edit(DrugPropertyReport newDrugPropertyReport);
		Task<DrugPropertyReport> Delete(int id);
	}
}
