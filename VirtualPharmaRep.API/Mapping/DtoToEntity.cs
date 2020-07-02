using AutoMapper;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.API.Mapping
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<ClinicDto, Clinic>().ReverseMap();
            CreateMap<DoctorDto, Doctor>().ReverseMap();
            CreateMap<DoctorEmploymentDto, DoctorEmployment>().ReverseMap();
            CreateMap<DrugDto, Drug>().ReverseMap();
            CreateMap<DrugCategoryDto, DrugCategory>().ReverseMap();
            CreateMap<DrugPropertyDto, DrugProperty>().ReverseMap();
            CreateMap<DrugPropertyReportDto, DrugPropertyReport>().ReverseMap();
            CreateMap<DrugReportDto, DrugReport>().ReverseMap();
            CreateMap<TeamDto, Team>().ReverseMap();
            CreateMap<TeamMemberDto, TeamMember>().ReverseMap();
            CreateMap<VisitDto, Visit>().ReverseMap();
        }
    }
}
