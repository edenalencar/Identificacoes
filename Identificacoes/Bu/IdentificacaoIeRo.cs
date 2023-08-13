using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeRo : Identificacao
    {
        public IdentificacaoIeRo()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(13, "-");
            return ieFormatada.ToString();
        }

        protected override void GerarNucleo()
        {
            for (int i = 0; i < 13; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var somaTotal = 0;
            var pesoUm = 6;
            var pesoDois = 9;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                if (i < 5)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * pesoUm;
                    pesoUm--;
                }
                else
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * pesoDois;
                    pesoDois--;
                }

            }
            var restoDivisao = 11 - (somaTotal % 11);
            int primeiroDigito;
            if (restoDivisao != 10 && restoDivisao != 11)
            {
                primeiroDigito = restoDivisao;
            }
            else
            {
                primeiroDigito = restoDivisao - 10;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }
    }
}