using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;
using VirtualPharmaRep.Services.Interfaces;

namespace VirtualPharmaRep.Services
{
    public class ClinicService : IClinicService
    {
	    private readonly ApplicationDbContext _context;

	    public ClinicService(ApplicationDbContext context)
	    {
		    _context = context;
	    }

	    public async Task<Clinic[]> Get() => await _context.Clinics.ToArrayAsync();

	    public async Task<Clinic> Get(int id) =>await _context.Clinics.FirstOrDefaultAsync(clinic => clinic.Id == id);

	    public async Task<Clinic> Add(Clinic newClinic)
	    {
		    var searchResult = await _context.Clinics.FirstOrDefaultAsync(clinic =>
			    string.Equals(clinic.Name, newClinic.Name, StringComparison.InvariantCultureIgnoreCase));

		    if (searchResult != null)
			    return null;

			newClinic.CreatedDateTime = DateTime.Now;
			newClinic.LastModifiedDateTime = newClinic.CreatedDateTime;

			var response = await _context.Clinics.AddAsync(newClinic);
			await _context.SaveChangesAsync();

			return response.Entity;
	    }

	    public async Task<Clinic> Edit(Clinic newClinic)
	    {
		    var clinic = await _context.Clinics.FirstOrDefaultAsync(cl => cl.Id == newClinic.Id);

		    if (clinic == null)
			    return null;

			clinic.Name = newClinic.Name;
			clinic.Address = newClinic.Address;
			clinic.City = newClinic.City;
			clinic.Province = newClinic.Province;
			clinic.PostalCode = newClinic.PostalCode;
			clinic.LastModifiedDateTime = DateTime.Now;

			await _context.SaveChangesAsync();

			return clinic;
	    }

	    public async Task<Clinic> Delete(int id)
	    {
		    var searchResult = await _context.Clinics.FirstOrDefaultAsync(clinic => clinic.Id == id);

		    if (searchResult == null)
			    return null;

		    _context.Clinics.Remove(searchResult);
		    await _context.SaveChangesAsync();

		    return searchResult;
	    }
    }
}
