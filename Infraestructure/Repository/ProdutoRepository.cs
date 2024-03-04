using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private ControladorDeEstoqueContext _context;

        public ProdutoRepository(ControladorDeEstoqueContext context)
        {
            _context = context;
        }

        public void AddProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public List<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public Produto? GetProdutoById(int id)
        {
            var listaProdutos = GetAll();
            Produto? produtoEncontrado = listaProdutos.FirstOrDefault(produto => produto.Id == id);

            return produtoEncontrado;
        }

        public void AddLoteAoProduto(Produto produto, Lote lote)
        {
            produto?.Lotes?.Add(lote);
            _context.SaveChanges();
        }

        public int GettQuantidadeTotal(int idProduto)
        {
            int quantidadeTotal = 0;
            foreach (Lote lote in _context.Lotes)
            {
                if (lote.idProduto == idProduto)
                quantidadeTotal = quantidadeTotal + lote.Quantidade;
            }
            return quantidadeTotal;
        }

    }
}
