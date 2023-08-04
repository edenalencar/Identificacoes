using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeAl : Identificacao
    {
        public IdentificacaoIeAl()
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
            identificacaoModel.Nucleo = "240";
            for (int i = 0; i < 5; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var somaTotal = 0;
            var peso = 9;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                peso--;
            }
            int produto = somaTotal * 10;
            int restoDivisao = produto - produto / 11 * 11;
            int primeiroDigito = restoDivisao == 10 ? 0 : restoDivisao;
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }
    }
}