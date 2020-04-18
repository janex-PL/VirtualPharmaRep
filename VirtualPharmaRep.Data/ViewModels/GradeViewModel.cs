﻿using System;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
	public class GradeViewModel : IEntity
	{
		public int Id { get; set; }
		public DateTime CreatedDateTime { get; set; }
		public DateTime LastModifiedDateTime { get; set; }
	}
}