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
    public class DescartarVencidos : IDescartarVencidos
    {
        private ILoteRepository _loteRepository;
        private IProdutoRepository _produtoRepository;

        public DescartarVencidos(ILoteRepository repository, IProdutoRepository produtorepository)
        {
            _loteRepository = repository;
            _produtoRepository = produtorepository;
        }

        public async Task DescartarVencidosAsync()
        {
            List<Lote> lotesDescartados = new List<Lote>();
            await Task.Run(() =>
            {
                foreach (Lote lote in _loteRepository.GetAll())
                {
                    if (ValidarValidade(lote.Validade) == false)
                    {
                        _loteRepository.DescartarLote(lote);
                        lotesDescartados.Add(lote);
                    }
                }
            });

            Console.WriteLine("---------------------------------------------------------------------------");
            foreach (Lote lote in lotesDescartados) Console.WriteLine($"         Lote {lote.Id}-{lote.CodigoLote} fora da validade. Descartado");
            Console.WriteLine("                Descarte de lotes vencidos concluído.");
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        public bool ValidarValidade(DateTime vencimento)
        {
            return ValidarValidadeService.ValidarValidade(vencimento);
        }
    }
}
