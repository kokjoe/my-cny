using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_cny.API.Data;
using my_cny.API.Model;
using my_cny.API.Resource;
using Newtonsoft.Json;

namespace my_cny.API.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IPatientRepo _patientRepo;
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IMapper mapper, DataContext context, IPatientRepo patientRepo, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _patientRepo = patientRepo;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _context.Patients
                .Where(p => p.IsAudit == false)
                .Include(l => l.EmergencyContacts).ThenInclude(l => l.Identification)
                .Include(g => g.Identification)
                .ToListAsync();

            var patientsToReturn = _mapper.Map<IEnumerable<PatientResource>>(patients);

            return Ok(patientsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(u => u.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }
            var patientToReturn = _mapper.Map<PatientResource>(patient);
            return Ok(patientToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientResource patientResource)
        {
            var mapPatient = _mapper.Map<Patient>(patientResource);
            mapPatient.IsAudit = false;
            mapPatient.CreatedDate = DateTime.Now;
            mapPatient.EditedDate = mapPatient.CreatedDate;
            // var newPatient = await _context.Patients.AddAsync(mapPatient);
            _patientRepo.Add(mapPatient);
            // await _context.SaveChangesAsync();
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetPatients", new { id = mapPatient.PatientId }, mapPatient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody]PatientResource patientResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != patientResource.PatientId)
                return Unauthorized();

            var currPatient = await _context.Patients.Where(p => p.PatientId == id)
                .AsNoTracking()
                .Include(e => e.EmergencyContacts)
                .FirstOrDefaultAsync();


            // var tempPatient = await _context.Patients.Where(p => p.PatientId == id)
            //     .AsNoTracking()
            //     .FirstOrDefaultAsync();

            var tempPatient = new Patient
            {
                PatientName = currPatient.PatientName,
                MRN = currPatient.MRN,
                Gender = currPatient.Gender,
                DOB = currPatient.DOB,
                IdentificationId = currPatient.IdentificationId,
                IdentificationNo = currPatient.IdentificationNo,
                Version = currPatient.Version,
                ZipCode = currPatient.ZipCode,
                IsAudit = true,
                CreatedDate = currPatient.CreatedDate,
                EditedDate = DateTime.Now
                // EmergencyContacts.ContactNo = currPatient.EmergencyContacts.ContactNo,
            };

            var tempEcListInsert = new List<EmergencyContact>();
            var tempEcListUpdate = new List<EmergencyContact>();
            foreach (var a in patientResource.EmergencyContactsResource)
            { 
                var currEc = currPatient.EmergencyContacts.Where(e => e.EmergencyContactId == a.EmergencyContactId)
                    .FirstOrDefault();

                tempEcListUpdate.Add(new EmergencyContact()
                {
                    EmergencyContactId = currEc.EmergencyContactId,
                    ContactNo = a.ContactNo,
                    RelationshipId = a.RelationshipId,
                    IdentificationId = a.IdentificationId,
                    IdentificationNo = a.IdentificationNo,
                    CreatedDate = currEc.CreatedDate,
                    EditedDate = DateTime.Now,
                    Version = currEc.Version + 1
                });

                tempEcListInsert.Add(new EmergencyContact()
                {
                    // EmergencyContactId = currEc.EmergencyContactId,
                    ContactNo = currEc.ContactNo,
                    RelationshipId = currEc.RelationshipId,
                    IdentificationId = currEc.IdentificationId,
                    IdentificationNo = currEc.IdentificationNo,
                    CreatedDate = currEc.CreatedDate,
                    EditedDate = currEc.EditedDate,
                    Version = currEc.Version,
                    IsAudit = true
                });
            }

            tempPatient.EmergencyContacts = tempEcListInsert;

            var mapPatient = _mapper.Map<PatientResource, Patient>(patientResource, currPatient);

            mapPatient.Version = currPatient.Version + 1;
            mapPatient.IsAudit = false;
            mapPatient.EditedDate = DateTime.Now;

            mapPatient.EmergencyContacts = tempEcListUpdate;

            //insert existing record (from db)
            // await _context.Patients.AddAsync(tempPatient);
            _patientRepo.Add(tempPatient);

            //update edited patient record
            _context.Update(mapPatient);

            // if (await _context.SaveChangesAsync() > 0)
            if (await _unitOfWork.CompleteAsync() > 0)
            {
                //var result = _mapper.Map<Patient, PatientResource>(patient, patientResource);  
                return Ok();
            }

            throw new Exception($"Updating patient {id} failed on save");
        }

        public static T DeepCopy<T>(T obj)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new Exception("The source object must be serializable");
            }

            if (Object.ReferenceEquals(obj, null))
            {
                throw new Exception("The source object must not be null");
            }
            T result = default(T);
            using (var memoryStream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                memoryStream.Seek(0, SeekOrigin.Begin);
                result = (T)formatter.Deserialize(memoryStream);
                memoryStream.Close();
            }
            return result;
        }
    }
}