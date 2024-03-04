using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ILoteRepository
    {
        public void AddLote(Lote lote);
        
        public List<Lote> GetAll();

        public Lote GetById(int id);

        public void DescartarLote(Lote lote);
        
        public void AlterarQuantidade(Lote lote, int quantidade);

    }
}
