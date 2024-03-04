using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RetiradaService : IRetiradaService
    {
        private ILoteRepository _loterepository;
        private IProdutoRepository _produtorepository;


        public RetiradaService(ILoteRepository loterepository, IProdutoRepository produtorepository)
        {
            _loterepository = loterepository;
            _produtorepository = produtorepository;
        }

        public void ProcessarRetirada(int idProduto, int quantidade)
        {
            if (ValidarQuantidade(quantidade) == false)
                throw new ArgumentException("Quantidade deve ser maior que 0");

            Produto? produto = _produtorepository.GetProdutoById(idProduto);
            if (produto == null) { throw new ArgumentException("Produto não encontrado"); }

            if (quantidade > _produtorepository.GettQuantidadeTotal(idProduto))
            {
                throw new QuantidadeInsuficienteException("Quantidade de produto no estoque insuficiente para retirada", 400);
                
            }

            RetirarDoProduto(produto, quantidade);

        }

        public void ProcessarRetiradaLoteEscolhido(int idLote, int quantidade)
        {
            if (ValidarQuantidade(quantidade) == false)
                throw new ArgumentException("Quantidade deve ser maior que 0");

            Lote loteEscolhido = _loterepository.GetById(idLote);
            if (loteEscolhido == null) { throw new ArgumentException("Lote não encontrado"); }

            if (quantidade > loteEscolhido.Quantidade)
                throw new QuantidadeInsuficienteException("Quantidade de produto no lote insuficiente para retirada", 400);

            RetirarDoLote(loteEscolhido, quantidade);

        }

        public List<Lote> RetirarDoProduto(Produto produto, int quantidade) //pensei em retornar uma lista de lotes para fazer testes
        {
            //ordenação dos lotes
            produto.Lotes.Sort((l1, l2) => l1.Validade.CompareTo(l2.Validade));

            //retira quantidade dos lotes
            List<Lote> lotesUsados = new List<Lote>();

            while (quantidade > 0)
            {
                if (!produto.Lotes.Any()) break;
                var lote = _loterepository.GetById(produto.Lotes[0].Id);
                quantidade = RetirarDoLote(lote, quantidade);
            }

            if (quantidade > 0)
            {
                throw new QuantidadeInsuficienteException("Quantidade de produto no estoque insuficiente para retirada", 400);
            }
            return lotesUsados;
        }

        public int RetirarDoLote(Lote lote, int quantidade)
        {
            int sobra = quantidade;
            bool loteEstaNaValidade = ValidarValidade(lote.Validade);

            if (loteEstaNaValidade)
            {
                if (quantidade <= lote.Quantidade)
                {
                    lote.Quantidade = lote.Quantidade - quantidade;
                    sobra = 0;
                    _loterepository.AlterarQuantidade(lote, lote.Quantidade);
                }
                else
                {
                    sobra = sobra - lote.Quantidade;
                    lote.Quantidade = 0;
                }
            }
            
            if (lote.Quantidade == 0 || loteEstaNaValidade == false)
            {

                _loterepository.DescartarLote(lote);
            }

            return sobra;
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
