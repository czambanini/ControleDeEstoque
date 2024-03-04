using Domain.Entities;
using Domain.Repositories;
using Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("consultar")]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("verificar-quantidade/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.GettQuantidadeTotal(id));
        }

        [HttpPost("registar")]
        public IActionResult Post([FromBody] ProdutoRequestcs produtoRequest)
        {
            Produto novoProduto = new Produto() { Nome = produtoRequest.Nome, Marca = produtoRequest.Marca };
            _repository.AddProduto(novoProduto);
            return Ok();
        }


    }
}
