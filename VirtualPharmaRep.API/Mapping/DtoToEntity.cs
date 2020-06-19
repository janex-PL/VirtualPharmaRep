using AutoMapper;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.API.Mapping
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<ClinicDto, Clinic>();
            CreateMap<DoctorDto, Doctor>();
            CreateMap<DoctorEmploymentDto, DoctorEmployment>();
            CreateMap<DrugDto, Drug>();
            CreateMap<DrugCategoryDto, DrugCategory>();
            CreateMap<DrugPropertyDto, DrugProperty>();
            CreateMap<DrugPropertyReportDto, DrugPropertyReport>();
            CreateMap<DrugReportDto, DrugReport>();
            CreateMap<TeamDto, Team>();
            CreateMap<TeamMemberDto, TeamMember>();
            CreateMap<VisitDto, Visit>();
        }
    }
}
