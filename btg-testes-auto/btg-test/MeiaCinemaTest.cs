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
        public void VerificarMeiaCinema_Estudante_RetornaTrue()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(true, false, false, false);

            Assert.True(retorno);
        }

        [Fact(DisplayName = "DoadorDeSangue")]
        public void VerificarMeiaCinema_DoadorDeSangue_RetornaTrue()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(false, true, false, false);

            Assert.True(retorno);
        }

        [Fact(DisplayName = "TrabalhadorPrefeitura")]
        public void VerificarMeiaCinema_TrabalhadorPrefeitura_RetornaFalse()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(false, false, true, false);

            Assert.False(retorno);
        }


        [Fact(DisplayName = "ContratoPrefeitura")]
        public void VerificarMeiaCinema_ContratoPrefeitura_RetornaFalse()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(false, false, false, true);

            Assert.False(retorno);
        }

        [Fact(DisplayName = "TrabalhadorPrefeituraEContratoPrefeitura")]
        public void VerificarMeiaCinema_TrabalhadorPrefeituraEContratoPrefeitura_RetornaTrue()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(false, false, true, true);

            Assert.True(retorno);
        }

        [Fact(DisplayName = "PessoaComum")]
        public void VerificarMeiaCinema_PessoaComum_RetornaFalse()
        {
            MeiaCinema meiaCinema = new MeiaCinema();
            bool retorno = meiaCinema.VerificarMeiaCinema(false, false, false, false);

            Assert.False(retorno);
        }
    }
}
