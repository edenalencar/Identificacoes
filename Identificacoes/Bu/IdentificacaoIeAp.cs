using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeAp : Identificacao
    {
        public IdentificacaoIeAp()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(8, "-");
            ieFormatada.Insert(2, ".");
            return ieFormatada.ToString();
        }

        protected override void GerarNucleo()
        {
            identificacaoModel.Nucleo = "03";
            for (int i = 0; i < 6; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();

            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var primeiroDigito = 0;
            var somaTotal = 0;
            var p = 0;
            var d = 0;
            var nucleo = "";
            var peso = 9;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                if (i > 0)
                {
                    nucleo += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()).ToString();
                }
                peso--;
            }
            if (Convert.ToInt32(nucleo) >= 3000001 && Convert.ToInt32(nucleo) <= 3017000)
            {
                p = 5;
            }
            else if (Convert.ToInt32(nucleo) >= 3017001 && Convert.ToInt32(nucleo) <= 3019022)
            {
                p = 9;
                d = 1;
            }

            int produto = p + somaTotal;
            int restoDivisao = produto % 11;

            if (11 - restoDivisao == 11)
            {
                primeiroDigito = d;
            }
            else if (11 - restoDivisao != 10)
            {
                primeiroDigito = 11 - restoDivisao;
            }

            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();

        }
    }
}