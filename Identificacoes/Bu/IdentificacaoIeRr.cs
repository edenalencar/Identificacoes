using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeRr : Identificacao
    {
        public IdentificacaoIeRr()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
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
            identificacaoModel.Nucleo = "24";
            for (int i = 0; i < 6; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var somaTotal = 0;
            var peso = 1;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                peso++;
            }
            int primeiroDigito = somaTotal % 9;

            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }
    }
}