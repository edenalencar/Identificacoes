using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeEs : Identificacao
    {
        public IdentificacaoIeEs()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
            GerarSegundoDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(8, "-");
            return ieFormatada.ToString();
        }

        protected override void GerarNucleo()
        {
            for (int i = 0; i < 8; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var primeiroDigito = 0;
            var somaTotal = 0;
            var peso = 9;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                peso--;
            }

            var calculoPrimeiroDigito = somaTotal % 11;
            if (calculoPrimeiroDigito > 1)
            {
                primeiroDigito = 11 - calculoPrimeiroDigito;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }
    }
}