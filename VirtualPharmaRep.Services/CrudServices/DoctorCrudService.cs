using AutoMapper;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Database.DbContexts;
using VirtualPharmaRep.Database.EntityValidators;

namespace VirtualPharmaRep.Services.CrudServices
{
    public class DoctorCrudService : BaseCrudService<Doctor, DoctorViewModel, DoctorDto, DoctorEntityValidator>
    {
        public DoctorCrudService(DoctorEntityValidator validator, IMapper mapper, ApplicationDbContext context) : base(
            validator, mapper, context)
        {
        }
    }
}