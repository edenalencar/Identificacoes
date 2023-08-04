using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeAm : Identificacao
    {
        public IdentificacaoIeAm()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());            
            ieFormatada.Insert(8, "-");
            ieFormatada.Insert(5, ".");
            ieFormatada.Insert(2, ".");
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
            var somaTotal = 0;
            var peso = 9;
            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                peso--;
            }
            int primeiroDigito;
            if (somaTotal < 11)
            {
                primeiroDigito = 11 - somaTotal;
            }
            else
            {
                int restoDivisao = somaTotal % 11;
                primeiroDigito = restoDivisao <= 1 ? 0 : 11 - restoDivisao;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }
    }
}