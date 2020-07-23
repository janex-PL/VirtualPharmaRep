using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VirtualPharmaRep.API.Controllers;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Services.CrudServices;
using VirtualPharmaRep.Services.CrudServices.Interfaces;
using VirtualPharmaRep.Test.FakeServices;
using Xunit;

namespace VirtualPharmaRep.Test.ControllerTests
{
    public class ClinicControllerTest
    {
        private readonly ClinicCrudFakeService _fakeService;

        public ClinicControllerTest()
        {
            _fakeService = new ClinicCrudFakeService();
        }

        [Fact]
        public async Task ControllerReturnsListOfClinics()
        {

            var controller = new ClinicController(_fakeService);

            var request = new PagedRequest();

            var result = await controller.Get(request);

            Assert.IsType<ActionResult<IEnumerable<ClinicDto>>>(result);
            var response = Assert.IsAssignableFrom<IEnumerable<ClinicDto>>(result.Value);
            Assert.Equal(2, response.Count());
        }

        [Fact]
        public async Task ControllerReturnsExistingClinic()
        {
            const int existingId = 1;

            var controller = new Mock<ClinicController>(_fakeService);

            var result = await controller.Object.Get(existingId);

            Assert.IsType<ActionResult<ClinicDto>>(result);
            var response = Assert.IsAssignableFrom<ClinicDto>(result.Value);
            Assert.Equal(existingId, response.Id);
        }

        [Fact]
        public async Task ControllerReturnsNotFoundOnNonExistingClinic()
        {
            const int nonExistingId = 2;

            var controller = new ClinicController(_fakeService);

            var result = await controller.Get(nonExistingId);

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task ControllerAddsNewClinic()
        {
            var model = new ClinicViewModel()
            {
                Name = "Klinika dodana",
                Address = "Adres",
                City = "Miasto",
                PostalCode = "66-200",
                Province = "Województwo"
            };

            var controller = new ClinicController(_fakeService);

            var result = await controller.Post(model);

            var newClinic = await _fakeService.Get(3);

            Assert.IsType<CreatedResult>(result.Result);
            Assert.Equal(model.Name,newClinic.Name);
        }
    }
}
