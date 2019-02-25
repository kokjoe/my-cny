using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_cny.API.Controllers.Resource;
using my_cny.API.Data;
using my_cny.API.Model;

namespace my_cny.API.Controllers
{
    [Route("api/visits")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IPatientRepo _patientRepo;
        private readonly IUnitOfWork _unitOfWork;

        public VisitController(IMapper mapper, DataContext context, IPatientRepo patientRepo, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _context = context;
            _patientRepo = patientRepo;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetVisits()
        {
            var visits = await _context.Visits.AsNoTracking()
                .Where(v => v.IsAudit == false)
                .Include(p => p.Patient)
                .ToListAsync();
            var visitToReturn = _mapper.Map<IEnumerable<VisitResource>>(visits);
            return Ok(visitToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddVisit(VisitResource visitResource)
        {
            var mapVisit = _mapper.Map<Visit>(visitResource);
            mapVisit.IsAudit = false;
            mapVisit.CreatedDate = DateTime.Now;
            mapVisit.EditedDate = mapVisit.CreatedDate;

            _patientRepo.Add(mapVisit);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetVisits", new { id = mapVisit.VisitId }, mapVisit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisit(int id, [FromBody]VisitResource visitResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != visitResource.PatientId)
                return Unauthorized();

            var currVisit = await _context.Visits.AsNoTracking()
                .Where(i => i.VisitId == id)
                .FirstOrDefaultAsync();

            var tempVisitInsert = new Visit{
                VisitType = currVisit.VisitType,
                PatientId = currVisit.PatientId,
                VisitDate = currVisit.VisitDate,
                VisitNo = currVisit.VisitNo,
                Version = currVisit.Version,
                IsAudit = true,
                EditedDate = DateTime.Now
            };

            var mapVisit = _mapper.Map<VisitResource, Visit>(visitResource, currVisit);
            mapVisit.Version = currVisit.Version + 1;
            mapVisit.IsAudit = false;
            mapVisit.EditedDate = DateTime.Now;

            _patientRepo.Add(tempVisitInsert);
            _context.Update(mapVisit);

            if (await _unitOfWork.CompleteAsync() > 0)
            {
                return Ok();
            }

            throw new Exception($"Updating visit {id} failed on save");
        }
    }
}