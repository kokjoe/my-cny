using System.Collections.Generic;
using System.Threading.Tasks;
using my_cny.API.Model;

namespace my_cny.API.Data
{
    public interface IPatientRepo
    {
         void Add<T>(T entity) where T: class;
         Task<IEnumerable<Patient>> GetPatients();
    }
}