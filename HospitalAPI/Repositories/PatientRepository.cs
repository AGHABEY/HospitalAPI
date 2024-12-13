using HospitalAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repositories;

public class PatientRepository:Repository<Patient>,IPatientRepository
{
    public PatientRepository(DbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Patient>> GetPatientsByName(string name)
    {
        return await _dbSet.Where(p => p.FullName.Contains(name)).ToListAsync();
    }
}