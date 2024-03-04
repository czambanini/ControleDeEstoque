using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class LoteRepository : ILoteRepository
    {
        private ControladorDeEstoqueContext _context;

        public LoteRepository(ControladorDeEstoqueContext context)
        {
            _context = context;
        }

        public void AddLote(Lote lote)
        {
            _context.Lotes.Add(lote);
            _context.SaveChanges();
        }

        public void DescartarLote(Lote lote)
        {
            _context.Lotes.Remove(lote);
            _context.SaveChanges();
        }

        public void AlterarQuantidade(Lote lote, int quantidade)
        {
            lote.Quantidade = quantidade;
            _context.SaveChanges();
        }

        public List<Lote> GetAll()
        {
            List<Lote> allLotes = new List<Lote>();
            foreach (Lote lote in  _context.Lotes)
            { allLotes.Add(lote); };
            return allLotes;
        }

        public Lote GetById(int id)
        {
            var listaLotes = GetAll();
            Lote? loteEncontrado = listaLotes.FirstOrDefault(lote => lote.Id == id);

            if (loteEncontrado == null)
                throw new ArgumentException("Não foi encontrado lote com esse ID");
            else
                return loteEncontrado;

        }
    }
}
