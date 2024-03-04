using ControleDeEstoque.Services;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Requests;
using FluentAssertions;
using Infraestructure.Repository;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Tracing;
using NSubstitute;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoqueTests
{
    public class RetiradaTest
    {
        private RetiradaService _sut;
        private ILoteRepository _mockLoteRepository;
        private IProdutoRepository _mockProdutoRepository;


        public RetiradaTest()
        {
            _mockLoteRepository = Substitute.For<ILoteRepository>();
            _mockProdutoRepository = Substitute.For<IProdutoRepository>();
            _sut = new RetiradaService(_mockLoteRepository,_mockProdutoRepository);
        }


        [Theory]
        [InlineData(-2, false)]
        [InlineData(0, false)]
        [InlineData(2, true)]
        public void Numero_de_itens_retirados_deve_ser_maior_que_zero(int quantidade, bool resultadoEsperado)
        {
            //Arrange / Act
            var resultado = _sut.ValidarQuantidade(quantidade);

            //Assert
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void Erro_quando_o_estoque_eh_menor_que_o_pedido()
        {
            //Arrange
            int pedido = 12;
            _mockProdutoRepository.GettQuantidadeTotal(Arg.Any<int>()).Returns(10);
            var produtoMock = new Produto();
            _mockProdutoRepository.GetProdutoById(Arg.Any<int>()).Returns(produtoMock);

            //Act/Assert
            Assert.Throws<QuantidadeInsuficienteException>(() => _sut.ProcessarRetirada(1,pedido));

        }

        [Fact]
        public void Erro_quando_a_quantidade_do_lote_eh_menor_que_o_pedido()
        {
            //Arrange
            int pedido = 6;
            var loteMock = new Lote() { Quantidade = 5 };
            _mockLoteRepository.GetById(Arg.Any<int>()).Returns(loteMock);

            //Act/Assert
            Assert.Throws<QuantidadeInsuficienteException>(() => _sut.ProcessarRetiradaLoteEscolhido(1, pedido));

        }


        //TESTES QUE EU PRETENDIA FAZER, MAS AINDA ESTOU COM DIFICULDADE
        //Produto_retirado_deve_estar_na_validade
        //Produto_pertence_a_lote_escolhido
        //Retirar_produto_diminui_quantidade_do_lote
        //Retirar_produto_diminui_quantidade_do_estoque

    }
}
