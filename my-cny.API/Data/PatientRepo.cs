using System.Collections.Generic;
using System.Threading.Tasks;
using my_cny.API.Model;

namespace my_cny.API.Data
{
    public class PatientRepo : IPatientRepo
    {
        public DataContext _context { get; }
        public PatientRepo(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public Task<IEnumerable<Patient>> GetPatients()
        {
            throw new System.NotImplementedException();
        }

    }
}