﻿using System;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
	public class DoctorViewModel : IEntity
	{
		public int Id { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastModifiedDateTime { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Title { get; set; }
	}
}