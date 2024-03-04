using ControleDeEstoque.Services;
using Domain.Repositories;
using NSubstitute;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoqueTests
{
    public class DescartarVencidosTest
    {
        private DescartarVencidos _sut;
        private ILoteRepository _loteRepository;
        private IProdutoRepository _produtoRepository;


        public DescartarVencidosTest()
        {
            _loteRepository = Substitute.For<ILoteRepository>();
            _produtoRepository = Substitute.For<IProdutoRepository>();
            _sut = new DescartarVencidos();
        }


        [Fact]
        public void Lotes_vencidos_devem_ser_descartados()
        {

        }

        [Fact]
        public void Descartar_lote_diminui_quantidade_do_estoque()
        {

        }
    }
}
