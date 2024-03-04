using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEntradaService
    {
        public Lote CriarLote(int id, string codigoLote, int quantidade, DateTime frabricacao, DateTime validade);

        public bool ValidarFabricacao(DateTime fabricacao);

        public bool ValidarValidade(DateTime vencimento);
    }
}
