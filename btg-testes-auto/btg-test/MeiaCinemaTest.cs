using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class MeiaCinemaTest
    {
        [Fact(DisplayName = "Estudante")]
        public void DefinirSePagaMeia_Estudante_RetornaTrue()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(true, false, false, false);

            Assert.True(retorno);
        }

        [Fact(DisplayName = "DoadorDeSangue")]
        public void DefinirSePagaMeia_DoadorDeSangue_RetornaTrue()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(false, true, false, false);

            Assert.True(retorno);
        }

        [Fact(DisplayName = "TrabalhadorPrefeitura")]
        public void DefinirSePagaMeia_TrabalhadorPrefeitura_RetornaFalse()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(false, false, true, false);

            Assert.False(retorno);
        }


        [Fact(DisplayName = "ContratoPrefeitura")]
        public void DefinirSePagaMeia_ContratoPrefeitura_RetornaFalse()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(false, false, false, true);

            Assert.False(retorno);
        }

        [Fact(DisplayName = "TrabalhadorPrefeituraEContratoPrefeitura")]
        public void DefinirSePagaMeia_TrabalhadorPrefeituraEContratoPrefeitura_RetornaTrue()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(false, false, true, true);

            Assert.True(retorno);
        }

        [Fact(DisplayName = "PessoaComum")]
        public void DefinirSePagaMeia_PessoaComum_RetornaFalse()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(false, false, false, false);

            Assert.False(retorno);
        }
    }
}
