using AutoMapper;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.Pagination;

namespace VirtualPharmaRep.API.Mapping
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Clinic, ClinicDto>();
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorEmployment, DoctorEmploymentDto>();
            CreateMap<Drug, DrugDto>();
            CreateMap<DrugCategory, DrugCategoryDto>();
            CreateMap<DrugProperty, DrugPropertyDto>();
            CreateMap<DrugPropertyReport, DrugPropertyReportDto>();
            CreateMap<DrugReport, DrugReportDto>();
            CreateMap<Team, TeamDto>();
            CreateMap<TeamMember, TeamMemberDto>();
            CreateMap<Visit, VisitDto>();

            CreateMap<PagedListResponse<Clinic>, PagedListResponse<ClinicDto>>();
            CreateMap<PagedListResponse<Doctor>, PagedListResponse<DoctorDto>>();
            CreateMap<PagedListResponse<DoctorEmployment>, PagedListResponse<DoctorEmploymentDto>>();
            CreateMap<PagedListResponse<Drug>, PagedListResponse<DrugDto>>();
            CreateMap<PagedListResponse<DrugCategory>, PagedListResponse<DrugCategoryDto>>();
            CreateMap<PagedListResponse<DrugProperty>, PagedListResponse<DrugPropertyDto>>();
            CreateMap<PagedListResponse<DrugPropertyReport>, PagedListResponse<DrugPropertyReportDto>>();
            CreateMap<PagedListResponse<DrugReport>, PagedListResponse<DrugReportDto>>();
            CreateMap<PagedListResponse<Team>, PagedListResponse<TeamDto>>();
            CreateMap<PagedListResponse<TeamMember>, PagedListResponse<TeamMemberDto>>();
            CreateMap<PagedListResponse<Visit>, PagedListResponse<VisitDto>>();
        }
    }
}
