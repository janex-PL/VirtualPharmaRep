using VirtualPharmaRep.Data.Dtos.Interfaces;

namespace VirtualPharmaRep.Data.Dtos
{
    public class DoctorEmploymentDto : IDto
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public bool IsJobActive { get; set; }
        public ClinicDto Clinic { get; set; }
        public DoctorDto Doctor { get; set; }
    }
}
