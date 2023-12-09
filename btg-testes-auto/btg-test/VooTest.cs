using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class VooTest
    {
        Voo voo = new Voo("Boing146", "A1370", new DateTime(2023, 12, 15, 14, 30, 0));

        [Fact(DisplayName = "Vagas Disponiveis Voo vazio")]
        public void DefinirQuantidadeVagasDisponivel_VooVazio_Retorna100()
        {
            int retorno = voo.QuantidadeVagasDisponivel();

            Assert.Equal(100, retorno);
        }

        [Fact(DisplayName = "Vagas Disponiveis com dois Assentos Ocupados ")]
        public void DefinirQuantidadeVagasDisponivel_2AssentosOcupados_Retorna98()
        {
            voo.OcupaAssento(33);
            voo.OcupaAssento(75);
            int retorno = voo.QuantidadeVagasDisponivel();

            Assert.Equal(98, retorno);
        }

        [Fact(DisplayName = "Vagas Disponiveis com Voo Cheio ")]
        public void DefinirQuantidadeVagasDisponivel_VooCheio_Retorna0()
        {
            for (int i = 1; i <= 100; i++)
            {
                voo.OcupaAssento(i);
            }
            int retorno = voo.QuantidadeVagasDisponivel();

            Assert.Equal(0, retorno);
        }

        [Fact(DisplayName = "Proximo Livre Voo vazio")]
        public void DefinirProximoLivre_VooVazio_Retorna1()
        {
            int retorno = voo.ProximoLivre();

            Assert.Equal(1, retorno);
        }

        [Fact(DisplayName = "Proximo Livre Primeiro Assento Ocupado")]
        public void DefinirProximoLivre_PrimeiroAssentoOcupado_Retorna2()
        {
            voo.OcupaAssento(1);
            int retorno = voo.ProximoLivre();

            Assert.Equal(2, retorno);
        }

        [Fact(DisplayName = "Proximo Assento Livre Voo Cheio")]
        public void DefinirProximoLivre_VooCheio_Retorna0()
        {
            for (int i = 1; i <= 100; i++)
            {
                voo.OcupaAssento(i);
            }
            int retorno = voo.ProximoLivre();

            Assert.Equal(0, retorno);
        }

        [Fact(DisplayName = "Iformações do voo")]
        public void DefinirInformacoesDoVoo_RetornaInformacoes()
        {
            string retorno = voo.ExibeInformacoesVoo();

            Assert.Contains("Boing146", retorno);
            Assert.Contains("A1370", retorno);
            Assert.Contains("15/12/2023 14:30:00", retorno);
        }

        [Fact(DisplayName = "Assento disponivel voo vazio")]
        public void DefinirDisponibilidadeAssento_Assento45VooVazio_RetornaTrue()
        {
            bool retorno = voo.AssentoDisponivel(45);

            Assert.True(retorno);
        }

        [Fact(DisplayName = "Assento não disponível")]
        public void DefinirDisponibilidadeAssento_Assento45_RetornaFalse()
        {
            voo.OcupaAssento(45);
            bool retorno = voo.AssentoDisponivel(45);

            Assert.False(retorno);
        }

        [Fact(DisplayName = "Ocupa assento voo vazio")]
        public void DefinirOcupacaoAssento_Acenco45VooVazio_RetornaTrue()
        {
            bool retorno = voo.OcupaAssento(45);

            Assert.True(retorno);
        }

        [Fact(DisplayName = "Não Ocupa assento")]
        public void DefinirOcupacaoAssento_Acento45Ocupado_RetornaFalse()
        {
            voo.OcupaAssento(45);
            bool retorno = voo.OcupaAssento(45);

            Assert.False(retorno);
        }
 
    }
}
