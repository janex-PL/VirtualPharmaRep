using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VirtualPharmaRep.Data.CustomObjects;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.EntityValidators
{
    public class DoctorEmploymentEntityValidator : BaseEntityValidator<DoctorEmployment, ApplicationDbContext>
    {
        public DoctorEmploymentEntityValidator(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task PerformValidationChecks(DoctorEmployment entity, PermissionResolverResult permissionResult)
        {
            if (!await Context.IsForeignKeyValid<Doctor>(entity.DoctorId))
                throw new ValidationException($"Couldn't find Doctor with id: {entity.DoctorId}");

            if (!await Context.IsForeignKeyValid<Clinic>(entity.ClinicId))
                throw new ValidationException($"Couldn't find Clinic with id: {entity.ClinicId}");
        }
    }
}