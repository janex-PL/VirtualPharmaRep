using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;
using VirtualPharmaRep.Services.Interfaces;

namespace VirtualPharmaRep.Services
{
	public class DoctorEmploymentService : IDoctorEmploymentEmploymentService
	{
		private readonly ApplicationDbContext _context;

		public DoctorEmploymentService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<DoctorEmployment[]> Get() => await _context.DoctorEmployments.ToArrayAsync();

		public async Task<DoctorEmployment> Get(int id) => await _context.DoctorEmployments.FirstOrDefaultAsync(de => de.Id == id);

		public async Task<DoctorEmployment> Add(DoctorEmployment newDoctorEmployment)
		{
			var searchResult = await _context.DoctorEmployments.FirstOrDefaultAsync(de =>
				de.DoctorId == newDoctorEmployment.DoctorId && de.ClinicId == newDoctorEmployment.ClinicId);

			if (searchResult != null)
				return null;

			newDoctorEmployment.CreatedDateTime = DateTime.Now;
			newDoctorEmployment.LastModifiedDateTime = newDoctorEmployment.CreatedDateTime;

			var response = await _context.DoctorEmployments.AddAsync(newDoctorEmployment);
			await _context.SaveChangesAsync();

			return response.Entity;
		}

		public async Task<DoctorEmployment> Edit(DoctorEmployment newDoctorEmployment)
		{
			var doctorEmployment = await _context.DoctorEmployments.FirstOrDefaultAsync(de => de.Id == newDoctorEmployment.Id);

			if (doctorEmployment == null)
				return null;

			doctorEmployment.JobTitle = newDoctorEmployment.JobTitle;
			doctorEmployment.IsCurrentJob = newDoctorEmployment.IsCurrentJob;
			doctorEmployment.LastModifiedDateTime = DateTime.Now;

			await _context.SaveChangesAsync();

			return doctorEmployment;
		}

		public async Task<DoctorEmployment> Remove(int id)
		{
			var searchResult = await _context.DoctorEmployments.FirstOrDefaultAsync(de => de.Id == id);

			if (searchResult == null)
				return null;

			_context.DoctorEmployments.Remove(searchResult);
			await _context.SaveChangesAsync();

			return searchResult;
		}

		public async Task<DoctorEmployment[]> GetByDoctor(int doctorId) =>
			await _context.DoctorEmployments.Where(de => de.DoctorId == doctorId).ToArrayAsync();

		public async Task<DoctorEmployment[]> GetByClinic(int clinicId) =>
			await _context.DoctorEmployments.Where(de => de.ClinicId == clinicId).ToArrayAsync();
	}
}