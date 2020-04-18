using System;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
    public class DoctorEmploymentViewModel : IEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastModifiedDateTime { get; set; }

        public int DoctorId { get; set; }

        public int ClinicId { get; set; }

        public bool IsCurrentJob { get; set; }

        public string JobTitle { get; set; }
	}
}