using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRetiradaService
    {
        public void ProcessarRetirada(int idProduto, int quantidade);

        public void ProcessarRetiradaLoteEscolhido(int idLote, int quantidade);
    }
}
