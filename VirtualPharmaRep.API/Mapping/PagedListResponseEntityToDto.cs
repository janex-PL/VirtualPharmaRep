using AutoMapper;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.Pagination;

namespace VirtualPharmaRep.API.Mapping
{
    public class PagedListResponseEntityToDto : Profile
    {
        public PagedListResponseEntityToDto()
        {
            CreateMap<PagedListResponse<Clinic>, PagedListResponse<ClinicDto>>().ReverseMap();
            CreateMap<PagedListResponse<Doctor>, PagedListResponse<DoctorDto>>().ReverseMap();
            CreateMap<PagedListResponse<DoctorEmployment>, PagedListResponse<DoctorEmploymentDto>>().ReverseMap();
            CreateMap<PagedListResponse<Drug>, PagedListResponse<DrugDto>>().ReverseMap();
            CreateMap<PagedListResponse<DrugCategory>, PagedListResponse<DrugCategoryDto>>().ReverseMap();
            CreateMap<PagedListResponse<DrugProperty>, PagedListResponse<DrugPropertyDto>>().ReverseMap();
            CreateMap<PagedListResponse<DrugPropertyReport>, PagedListResponse<DrugPropertyReportDto>>().ReverseMap();
            CreateMap<PagedListResponse<DrugReport>, PagedListResponse<DrugReportDto>>().ReverseMap();
            CreateMap<PagedListResponse<Team>, PagedListResponse<TeamDto>>().ReverseMap();
            CreateMap<PagedListResponse<TeamMember>, PagedListResponse<TeamMemberDto>>().ReverseMap();
            CreateMap<PagedListResponse<Visit>, PagedListResponse<VisitDto>>().ReverseMap();
        }
    }
}
