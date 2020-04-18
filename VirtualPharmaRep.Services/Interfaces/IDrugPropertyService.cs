using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.Interfaces
{
    public interface IDrugPropertyService
    {
	    DrugProperty[] GetAllDrugProperties();
	    DrugProperty GetDrugProperty(int id);
	    DrugProperty AddDrugProperty(DrugProperty newDrugProperty);
	    DrugProperty EditDrugProperty(DrugProperty newDrugProperty);
	    DrugProperty DeleteDrugProperty(int id);
	}
}
