using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_cny.API.Data;
using my_cny.API.Resource;

namespace my_cny.API.Controllers
{
    [Route("api/relationships")]
    [ApiController]
    public class RelationshipController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public RelationshipController(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

            [HttpGet]
        public async Task<IActionResult> GetRelationships() {
            var relationships = await _context.Relationships.ToListAsync();

            var relationshipToReturn = _mapper.Map<IEnumerable<RelationshipResource>>(relationships);

            return Ok(relationshipToReturn);
        }
    }
    
}