using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.Interfaces
{
    public interface IDrugCategoryService
    {
		DrugCategory[] Get();
		DrugCategory Get(int id);
		DrugCategory Add(DrugCategory newDrugCategory);
		DrugCategory Edit(DrugCategory newDrugCategory);
		DrugCategory Delete(int id);
	}
}
