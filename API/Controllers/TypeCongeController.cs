using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.Entities;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeCongeController : ControllerBase
    {
        private readonly IMapper _mapper;
        ITypeService _service;
        public TypeCongeController(ITypeService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        [Route("{TypeCongeId}")]
        public IActionResult GetById(int TypeCongeId)
        {
            return Ok(_service.GetById(TypeCongeId));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetTypeConges());
        }


        [HttpPost]
        public ActionResult<TypeConge> AddDemande(TypeConge typeConge)
        {
            _service.AddTypeConge(typeConge);

            return Ok();
        }
    }
}
