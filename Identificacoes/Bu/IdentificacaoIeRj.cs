using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeRj : Identificacao
    {
        public IdentificacaoIeRj()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(2, ".");
            ieFormatada.Insert(6, ".");
            ieFormatada.Insert(9, "-");
            return ieFormatada.ToString();
        }

        protected override void GerarNucleo()
        {
            for (int i = 0; i < 7; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var primeiroDigito = 0;
            var somaTotal = 0;
            var peso = 7;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                if (i == 0)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 2;
                }
                else
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                    peso--;
                }
                
            }
            var restoDivisao = somaTotal % 11;
            if (restoDivisao > 1)
            {
                primeiroDigito = 11 - restoDivisao;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }
    }
}