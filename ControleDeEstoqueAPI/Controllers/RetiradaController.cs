using Domain.Entities;
using Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RetiradaController : ControllerBase
    {
        private IRetiradaService _retiradaService;

        public RetiradaController(IRetiradaService retiradaService)
        {
            _retiradaService = retiradaService;
        }

        [HttpPost("produto-{idProduto}")]
        public IActionResult Post([FromQuery, Required] int quantidade, int idProduto)
        {
            _retiradaService.ProcessarRetirada(idProduto, quantidade);
            return Ok();
        }

        [HttpPost("lote-{idLote}")]
        public IActionResult Post2([FromQuery, Required] int quantidade, int idLote)
        {
            _retiradaService.ProcessarRetiradaLoteEscolhido(idLote, quantidade);
            return Ok();
        }

    }
}
