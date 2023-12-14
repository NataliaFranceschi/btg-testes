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
    public class MotoristaTest
    {
        Pessoa pessoa1 = new Pessoa() { Idade = 20, Nome = "Fernando", PossuiHabilitaçãoB = true };
        Pessoa pessoa2 = new Pessoa() { Idade = 15, Nome = "José", PossuiHabilitaçãoB = false };
        Pessoa pessoa3 = new Pessoa() { Idade = 27, Nome = "Rafaela", PossuiHabilitaçãoB = false };
        Pessoa pessoa4 = new Pessoa() { Idade = 18, Nome = "Juliana", PossuiHabilitaçãoB = true };
        Pessoa pessoa5 = new Pessoa() { Idade = 10, Nome = "Sandra", PossuiHabilitaçãoB = false };
        Pessoa pessoa6 = new Pessoa() { Idade = 30, Nome = "Raul", PossuiHabilitaçãoB = true };


        [Fact(DisplayName = "Mostoristas Disponíveis")]
        public void EncontrarMotoristas_DoisMotoristasDisponiveis_RetornaNomesMotoristas()
        {
            List<Pessoa> pessoas = new() { pessoa1, pessoa2, pessoa3, pessoa4 };
            Motorista motorista = new Motorista();
            string resultado = motorista.EncontrarMotoristas(pessoas);

            Assert.Contains("Fernando", resultado);
            Assert.Contains("Juliana", resultado);
            Assert.DoesNotContain("José", resultado);
            Assert.DoesNotContain("Rafaela", resultado);
        }


        [Fact(DisplayName = "Mostoristas Disponíveis")]
        public void EncontrarMotoristas_MaisDeDoisMotoristasDisponiveis_RetornaNomesDoisPrimeirosMotoristas()
        {
            List<Pessoa> pessoas = new() { pessoa1, pessoa6, pessoa3, pessoa4, pessoa2 };
            Motorista motorista = new Motorista();
            string resultado = motorista.EncontrarMotoristas(pessoas);

            Assert.Contains("Fernando", resultado);
            Assert.Contains("Raul", resultado);
            Assert.DoesNotContain("José", resultado);
            Assert.DoesNotContain("Rafaela", resultado);
            Assert.DoesNotContain("Juliana", resultado);
        }

        [Fact(DisplayName = "Viagem Não Realizada")]
        public void EncontrarMotoristas_NenhumMotoristaDisponivel_RetornaErro()
        {
            List<Pessoa> pessoas = new() { pessoa2, pessoa3, pessoa5 };
            Motorista motorista = new Motorista();
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            Assert.Throws<Exception>(resultado);
        }

        [Fact(DisplayName = "Viagem Não Realizada")]
        public void EncontrarMotoristas_UmMotoristaDisponivel_RetornaErro()
        {
            List<Pessoa> pessoas = new() { pessoa1, pessoa2, pessoa3, pessoa5 };
            Motorista motorista = new Motorista();
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            resultado.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");
        }
    }    
    }
