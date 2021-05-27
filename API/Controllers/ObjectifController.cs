using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectifController : ControllerBase
    {
        private readonly IMapper _mapper;
        IObjectifService _service;
        public ObjectifController(IObjectifService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("{ObjectifId}")]
        public IActionResult GetById(int ObjectidId)
        {
            return Ok(_service.GetById(ObjectidId));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetObjectifs());
        }


        [HttpPost]
        public ActionResult<Objectif> AddObjectif(Objectif objectif)
        {
            _service.AddObjectif(objectif);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutObjectifs(int id, [FromBody] Objectif o)
        {
            if (id != o.Id)
            {
                return BadRequest();
            }
            _service.UpdateObjectif(o);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objectifToDelete = _service.GetById(id);
            if (objectifToDelete == null)
                return NotFound();

            _service.DeleteObjectif(objectifToDelete);
            return Ok();
        }


    }
}

