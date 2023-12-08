using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class LucroTest
    {
        [Fact(DisplayName = "Produto valor menor que 20")]
        public void DefinirLucro_ProdutoValorMenorQue20_RetornaLucro()
        {
            Lucro lucro = new Lucro();
            decimal retorno = lucro.Calcular(10);

            Assert.Equal(14.5M, retorno);
        }

        [Fact(DisplayName = "Produto valor igual a 20")]
        public void DefinirLucro_ProdutoValorIgual20_RetornaLucro()
        {
            Lucro lucro = new Lucro();
            decimal retorno = lucro.Calcular(20);

            Assert.Equal(26, retorno);
        }

        [Fact(DisplayName = "Produto valor maior que 20")]
        public void DefinirLucro_ProdutoValorMaiorQue20_RetornaLucro()
        {
            Lucro lucro = new Lucro();
            decimal retorno = lucro.Calcular(30);

            Assert.Equal(39, retorno);
        }
  }
}
