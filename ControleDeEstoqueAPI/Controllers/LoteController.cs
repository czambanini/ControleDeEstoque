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
    public class LoteController : ControllerBase
    {
        private ILoteRepository _repository;
        private IProdutoRepository _produtorepository;
        private IEntradaService _entradaservice;

        public LoteController(ILoteRepository repository, IProdutoRepository produtorepository, IEntradaService entradaservice)
        {
            _repository = repository;
            _produtorepository = produtorepository;
            _entradaservice = entradaservice;
        }

        [HttpGet("consultar")]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

    }
}
