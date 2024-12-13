using HospitalAPI.Entities;

namespace HospitalAPI.Repositories;

public interface IPatientRepository:IRepository<Patient>
{
    Task<IEnumerable<Patient>> GetPatientsByName(string name);
}