using btg_testes_auto;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class PrecoProdutoTest
    {
        /* ImpostoProduto
        * Uma empresa vende o mesmo produto para diferentes estados.
        * Cada estado possui uma taxa diferente de imposto sobre o produto
        * (MG 7%; SP 12%; RJ 15%; MS 8%; ES 12%; SC 18%;).
        * Faça um programa que retorne o preço final do produto acrescido do imposto do estado em que ele será vendido.
        * Se o estado digitado não for válido, estoure uma exception.
        */
        [Fact(DisplayName = "Imposto MG")]
        public void ImpostoProduto_EstadoMG_RetornaPrecoMais7Porcento()
        {
            PrecoProduto precoProduto = new(100, "MG");
            decimal resultado = precoProduto.ImpostoProduto();
            resultado.Should().Be(107);
        }

        [Fact(DisplayName = "Imposto SP")]
        public void ImpostoProduto_EstadoSP_RetornaPrecoMais12Porcento()
        {
            PrecoProduto precoProduto = new(100, "SP");
            decimal resultado = precoProduto.ImpostoProduto();
            resultado.Should().Be(112);
        }

        [Fact(DisplayName = "Imposto RJ")]
        public void ImpostoProduto_EstadoRJ_RetornaPrecoMais15Porcento()
        {
            PrecoProduto precoProduto = new(100, "RJ");
            decimal resultado = precoProduto.ImpostoProduto();
            resultado.Should().Be(115);
        }

        [Fact(DisplayName = "Imposto MS")]
        public void ImpostoProduto_EstadoMS_RetornaPrecoMais8Porcento()
        {
            PrecoProduto precoProduto = new(100, "MS");
            decimal resultado = precoProduto.ImpostoProduto();
            resultado.Should().Be(108);
        }

        [Fact(DisplayName = "Imposto ES")]
        public void ImpostoProduto_EstadoES_RetornaPrecoMais12Porcento()
        {
            PrecoProduto precoProduto = new(100, "ES");
            decimal resultado = precoProduto.ImpostoProduto();
            resultado.Should().Be(112);
        }

        [Fact(DisplayName = "Imposto SC")]
        public void ImpostoProduto_EstadoSC_RetornaPrecoMais18Porcento()
        {
            PrecoProduto precoProduto = new(100, "SC");
            decimal resultado = precoProduto.ImpostoProduto();
            resultado.Should().Be(118);
        }

        [Fact(DisplayName = "Imposto PR")]
        public void ImpostoProduto_EstadoPR_RetornaErro()
        {
            PrecoProduto precoProduto = new(100, "PR");
            Action resultado = () => precoProduto.ImpostoProduto();
            resultado.Should().Throw<Exception>().WithMessage("Estado inválido");

        }
    }
}
