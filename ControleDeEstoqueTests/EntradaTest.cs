using ControleDeEstoque.Services;
using Domain.Entities;
using Domain.Repositories;
using NSubstitute;
using Services.Interfaces;
using System.Runtime.Intrinsics.X86;

namespace ControleDeEstoqueTests
{
    public class EntradaTest
    {
        private EntradaService _sut;
        private ILoteRepository _loteRepository;
        private IProdutoRepository _produtoRepository;


        public EntradaTest()
        {
            _loteRepository = Substitute.For<ILoteRepository>();
            _produtoRepository = Substitute.For<IProdutoRepository>();
            _sut = new EntradaService(_loteRepository, _produtoRepository);
        }


        //Entrada de produto

        [Theory]
        [InlineData("2023-01-01T00:00:00", false)]
        [InlineData("2024-10-09T00:00:00", true)]
        public void Produto_entrando_tem_que_estar_na_validade(DateTime data, Boolean resultadoEsperado)
        {
            // Arrange / Act
            var resultado = _sut.ValidarValidade(data);

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }


        [Theory]
        [InlineData("2023-12-01T00:00:00", true)]
        [InlineData("2024-10-09T00:00:00", false)]
        public void Produto_entrando_tem_data_de_fabricacao_valida(DateTime data, bool resultadoEsperado)
        {
            // Arrange / Act
            var resultado = _sut.ValidarFabricacao(data);

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }


        [Theory]
        [InlineData(-2, false)]
        [InlineData(0, false)]
        [InlineData(2, true)]
        public void Produto_entrando_deve_ter_quantidade_maior_que_zero(int quantidade, bool resultadoEsperado)
        {
            //Arrange / Act
            var resultado = _sut.ValidarQuantidade(quantidade);

            //Assert
            Assert.Equal(resultado, resultadoEsperado);
        }


        //TESTES QUE EU PRETENDIA FAZER, MAS AINDA ESTOU COM DIFICULDADE
        //Incluir_novo_lote_aumenta_estoque_do_produto


    }
}