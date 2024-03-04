using Domain.Entities;
using Domain.Repositories;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Services
{
    public class EntradaService : IEntradaService
    {
        private ILoteRepository _repository;
        private IProdutoRepository _produtorepository;

        public EntradaService(ILoteRepository repository, IProdutoRepository produtorepository)
        {
            _repository = repository;
            _produtorepository = produtorepository;
        }

        public Lote CriarLote(int id, string codigoLote, int quantidade, DateTime fabricacao, DateTime validade)
        {
            var produtoLote = _produtorepository.GetProdutoById(id);

            if (ValidarQuantidade(quantidade) == false)
                throw new ArgumentException("Quantidade deve ser maior que 0");

            if (produtoLote == null)
                throw new ArgumentException("Não foi encontrado produto com esse ID");

            if (ValidarFabricacao(fabricacao) == false)
                throw new ArgumentException("Data de fabricação incorreta, data já deve ter passado.");

            if (ValidarValidade(validade) == false)
                throw new ArgumentException("Produtos estão vencidos, lote não pode ser adicionado ao estoque");

            Lote novoLote = new Lote() { CodigoLote = codigoLote, Produto = produtoLote, Quantidade = quantidade, Fabricacao = fabricacao, Validade = validade };

            _repository.AddLote(novoLote);
            _produtorepository.AddLoteAoProduto(produtoLote, novoLote);

            return novoLote;
        }

        public bool ValidarFabricacao(DateTime fabricacao)
        {
            if (fabricacao > DateTime.Now)
                return false;
                else return true;
        }

        public bool ValidarValidade(DateTime vencimento)
        {
            return ValidarValidadeService.ValidarValidade(vencimento);
        }

        public bool ValidarQuantidade(int quantidade)
        {
            if (quantidade > 0) return true;
            else return false;
        }

    }
}
