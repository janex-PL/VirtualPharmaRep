using System;
using VirtualPharmaRep.Data.Dtos.Interfaces;

namespace VirtualPharmaRep.Data.Dtos
{
	public class VisitDto : IDto
	{
		public int Id { get; set; }
        public int DoctorEmploymentId { get; set; }
		public string UserId { get; set; }
		public string Description { get; set; }
		public DateTime VisitDateTime { get; set; }
	}
}