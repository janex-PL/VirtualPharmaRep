using AutoMapper;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Services.CrudServices
{
    public class BaseCrudService
    {
        protected readonly ApplicationDbContext Context;
        protected readonly IMapper Mapper;

        public BaseCrudService(IMapper mapper, ApplicationDbContext context)
        {
            Mapper = mapper;
            Context = context;
        }
    }
}
