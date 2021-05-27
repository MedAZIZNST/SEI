using API.Models;
using API.Service;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandeController : ControllerBase
    {
        private readonly IMapper _mapper;
        IDemandeService _service;
        public DemandeController(IDemandeService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("{DemandeId}")]
        public IActionResult GetById(int DemandeId)
        {
            return Ok(_service.GetById(DemandeId));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetDemandes());
        }


        [HttpPost]
        public ActionResult<Demande> AddDemande(Demande demande)
        {
            _service.AddDemande(demande);

            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult PutDemandes(int Id, [FromBody] Demande d)
        {
            if (Id != d.Id)
            {
                return BadRequest();
            }
            _service.UpdateDemande(d);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var demandeToDelete = _service.GetById(Id);
           if (demandeToDelete == null)
                return NotFound();

            _service.DeleteDemande(demandeToDelete);
            return Ok();
        }
    }
}
