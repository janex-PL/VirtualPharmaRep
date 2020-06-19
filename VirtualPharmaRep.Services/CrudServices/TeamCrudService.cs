using AutoMapper;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Database.DbContexts;
using VirtualPharmaRep.Database.EntityValidators;

namespace VirtualPharmaRep.Services.CrudServices
{
    public class TeamCrudService : BaseCrudService<Team,TeamViewModel,TeamDto,TeamEntityValidator>
    {
        public TeamCrudService(TeamEntityValidator validator, IMapper mapper, ApplicationDbContext context) : base(
            validator, mapper, context)
        {
        }
    }
}