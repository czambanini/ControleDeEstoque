using Domain.Entities;
using Domain.Repositories;
using Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private IEntradaService _entradaservice;

        public EntradaController(IEntradaService entradaservice)
        {
            _entradaservice = entradaservice;
        }

        [HttpPost("cadastrar-lote")]
        public IActionResult Post([FromBody] LoteRequest loteRequest)
        {
            Lote novoLote = _entradaservice.CriarLote(loteRequest.idProduto, loteRequest.CodigoLote, loteRequest.Quantidade, loteRequest.Fabricacao, loteRequest.Validade);

            return Ok(novoLote);
        }
    }
}
