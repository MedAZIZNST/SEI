using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Solution.Service;
using Solution.Entities;
using Microsoft.AspNetCore.Authorization;
using Solution.ViewModel;
using API.Helpers;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AutoMapper;

namespace API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetController : ControllerBase
    {

        private readonly IMapper _mapper;
        IProjetService _service;
        public ProjetController(IProjetService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpPost]
        public IActionResult AddProjet([FromBody] ProjetDto model)
        {
            IActionResult response = BadRequest(new { message = "Project already exist" });
            var _projet = _service.GetByName(model.ProjetName);
            if (_projet == null)
            {
                var _newProjet = _mapper.Map<Projet>(model);
                _newProjet.Created_at = DateTime.Now;
                _service.AddProjet(_newProjet);
                response = Ok(_newProjet);
            }
            return response;
        }

        [HttpPut("{id}")]
        public IActionResult PutProjets(int id, [FromBody] Projet p)
        {
            var projet = _service.GetById(id);
            if (id != p.Id)
            {
                projet.ProjetName = p.ProjetName;
                projet.description = p.description;
                return BadRequest();
            }

            _service.UpdateProjet(projet);
            return NoContent();
        }



        [HttpGet]
        [Route("{ProjetId}")]
        public IActionResult GetById(int ProjetId)
        {
            return Ok(_service.GetById(ProjetId));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetProjets());
        }

        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var projetToDelete = _service.GetById(id);
            if (projetToDelete == null)
                return NotFound();

            _service.DeleteProjet(projetToDelete);
            return NoContent();
        }



        [HttpGet]
        [Route("Users")]
        public IActionResult GetAllUsers()
        {
            return Ok(_service.GetUsers());
        }
    }
}
