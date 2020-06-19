using AutoMapper;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.API.Mapping
{
    public class ViewModelToEntity : Profile
    {
        public ViewModelToEntity()
        {
            CreateMap<ClinicViewModel, Clinic>();
            CreateMap<DoctorViewModel, Doctor>();
            CreateMap<DoctorEmploymentViewModel, DoctorEmployment>();
            CreateMap<DrugViewModel, Drug>();
            CreateMap<DrugCategoryViewModel, DrugCategory>();
            CreateMap<DrugPropertyViewModel, DrugProperty>();
            CreateMap<DrugPropertyReportViewModel, DrugPropertyReport>();
            CreateMap<DrugReportViewModel, DrugReport>();
            CreateMap<TeamViewModel, Team>();
            CreateMap<TeamMemberViewModel, TeamMember>();
            CreateMap<VisitViewModel, Visit>();
        }
    }
}
