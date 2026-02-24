using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using System.Collections.Generic;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;   

        public RegionsController(NZWalksDbContext context)
        {
            _context = context;
                
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var Regions = _context.Regions.ToList();
            //map Results to RegionsDto

            var regionsDto = new List<RegionDto>();

            foreach (var region in Regions)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl,

                });
            }
            return Ok(regionsDto);

             
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute]Guid id)
        {

            // var region = _context.Regions.Find(id);
            var region = _context.Regions.FirstOrDefault(x=>x.Id==id);


            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
               
        }





    }
}
