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
    public class PieceJustificativeController : ControllerBase
    {
        IPieceJustificativeService _service;
        public PieceJustificativeController(IPieceJustificativeService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("{ PieceJustificativeId}")]
        public IActionResult GetById(int PieceJustificativeId)
        {
            return Ok(_service.GetById(PieceJustificativeId));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetPieceJustificatives());
        }


        [HttpPost]
        public ActionResult<PieceJustificative> AddDemande(PieceJustificative pieceJustificative)
        {
            _service.AddPieceJustificative(pieceJustificative);

            return Ok();
        }
    }
}
