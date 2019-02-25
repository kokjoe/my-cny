using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_cny.API.Data;
using my_cny.API.Resource;

namespace my_cny.API.Controllers
{
    [Route("api/identifications")]
    [ApiController]
    public class IdentificationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public IdentificationController(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetIdentifications()
        {
            var identifications = await _context.Identifications.ToListAsync();

            var idenToReturn = _mapper.Map<IEnumerable<IdentificationResource>>(identifications);

            return Ok(idenToReturn);
        }
    }
}