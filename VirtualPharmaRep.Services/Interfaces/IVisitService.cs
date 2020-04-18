using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.Interfaces
{
    public interface IVisitService
    {
		Visit[] GetAllVisits();
		Visit GetVisit(int id);
		Visit AddVisit(Visit newVisit);
		Visit EditVisit(Visit newVisit);
		Visit DeleteVisit(int id);

	}
}
