using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class AnaliseSuspeitosTest
{
        [Theory(DisplayName = "0 a 1 resposta positivas")]
        [InlineData(true, false, false, false, false)]
        [InlineData(false, false, false, false, false)]
        [InlineData(false, false, true, false, false)]
        public void ExecutarQuestionarioSuspeito_ZeroOuUmaRespostaPositiva_RetornaInocente(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            AnaliseSuspeitos analiseSuspeitos = new AnaliseSuspeitos();
            string retorno = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);
            
            Assert.Equal("Inocente", retorno);
        }

        [Theory(DisplayName = "2 respostas positivas")]
        [InlineData(true, true, false, false, false)]
        [InlineData(false, true, true, false, false)]
        [InlineData(false, false, true, false, true)]
        public void ExecutarQuestionarioSuspeito_DuasRespostaPositiva_RetornaSuspeita(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            AnaliseSuspeitos analiseSuspeitos = new AnaliseSuspeitos();
            string retorno = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            Assert.Equal("Suspeita", retorno);
        }

        [Theory(DisplayName = "3 ou 4 respostas positivas")]
        [InlineData(true, true, true, false, false)]
        [InlineData(false, true, true, true, true)]
        [InlineData(false, false, true, true, true)]
        public void ExecutarQuestionarioSuspeito_TresOuQuatroRespostaPositiva_RetornaCumplice(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            AnaliseSuspeitos analiseSuspeitos = new AnaliseSuspeitos();
            string retorno = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            Assert.Equal("Cúmplice", retorno);
        }

        [Theory(DisplayName = "5 respostas positivas")]
        [InlineData(true, true, true, true, true)]

        public void ExecutarQuestionarioSuspeito_TresOuQuatroRespostaPositiva_RetornaAssassino(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            AnaliseSuspeitos analiseSuspeitos = new AnaliseSuspeitos();
            string retorno = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            Assert.Equal("Assassino", retorno);
        }
    }
}
