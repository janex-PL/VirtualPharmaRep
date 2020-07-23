using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Services.CrudServices.Interfaces;

namespace VirtualPharmaRep.Test.FakeServices
{
    public class ClinicCrudFakeService : IClinicCrudService
    {
        private List<ClinicDto> ClinicDtos { get; set; }

        public ClinicCrudFakeService()
        {
            ClinicDtos = new List<ClinicDto>()
            {
                new ClinicDto
                {
                    Id = 1,
                    Name = "Klinika 1"
                },
                new ClinicDto
                {
                    Id = 2,
                    Name = "Klinika 2"
                },
            };
        }
        public async Task<PagedListResponse<ClinicDto>> Get(PagedRequest request)
        {
            return new PagedListResponse<ClinicDto>(ClinicDtos, 2, 1);
        }

        public async Task<ClinicDto> Get(int id)
        {
            return ClinicDtos.FirstOrDefault(c => c.Id == id);
        }

        public async Task<ClinicDto> Add(ClinicViewModel model, string requestAuthor)
        {
            ClinicDtos.Add(new ClinicDto()
            {
                Id = 3,
                Name = model.Name
            });
            return ClinicDtos.Last();
        }

        public async Task<ClinicDto> Edit(int id, ClinicViewModel model, string requestAuthor)
        {
            var index = ClinicDtos.FindIndex(c => c.Id == id);
            if (index == -1)
                return null;
            ClinicDtos[index].Name = model.Name;
            return ClinicDtos[index];
        }

        public async Task<ClinicDto> Delete(int id, string requestAuthor)
        {
            var index = ClinicDtos.FindIndex(c => c.Id == id);
            if (index == -1)
                return null;
            var result = ClinicDtos[index];
            ClinicDtos.RemoveAt(index);
            return result;
        }

        public Task<PagedListResponse<ClinicDto>> GetTrash(PagedRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
