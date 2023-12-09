using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_testes_auto
{
    public class PrecoProduto
    {
        public decimal Valor {  get; set; }
        public string Estado { get; set; }

        public PrecoProduto(decimal valor, string estado)
        {
            Valor = valor;
            Estado = estado;
        }

        public decimal ImpostoProduto()
        {
            try
            {
                switch (Estado)
                {
                    case "MG":
                        return Valor * 1.07M;
                    case "SP":
                    case "ES":
                        return Valor * 1.12M;
                    case "RJ":
                        return Valor * 1.15M;
                    case "MS":
                        return Valor * 1.08M;
                    case "SC":
                        return Valor * 1.18M;
                    default:
                        throw new Exception("Estado inválido");
                }
            } catch (Exception)
            {
                throw;
            }
            
        }
    }
}
