using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_cny.API.Data;
using my_cny.API.Model;
using my_cny.API.Resource;

namespace my_cny.API.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public PatientController(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _context.Patients
                .Include(l => l.EmergencyContacts).ThenInclude(l => l.Identification)
                .Include(g => g.Identification)
                .ToListAsync();

            var patientsToReturn = _mapper.Map<IEnumerable<PatientResource>>(patients);

            return Ok(patientsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientResource patientResource)
        {
            var mapPatient = _mapper.Map<Patient>(patientResource);
            var newPatient = await _context.Patients.AddAsync(mapPatient);
            await _context.SaveChangesAsync();

            return Ok(newPatient);
        }
    }
}