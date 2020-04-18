using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.Interfaces
{
    public interface IGradeService
    {
		Grade[] GetAllGrades();
		Grade GetGrade(int id);
		Grade AddGrade(Grade newGrade);
		Grade EditGrade(Grade newGrade);
		Grade DeleteGrade(int id);
	}
}
