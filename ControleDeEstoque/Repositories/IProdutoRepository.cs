using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProdutoRepository
    {
        public void AddProduto(Produto produto);

        public List<Produto> GetAll();

        public Produto? GetProdutoById(int id);

        public void AddLoteAoProduto(Produto produto, Lote lote);

        public int GettQuantidadeTotal(int idProduto);
    }
}
