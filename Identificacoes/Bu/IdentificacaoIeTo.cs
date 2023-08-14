using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeTo : Identificacao
    {
        public IdentificacaoIeTo()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(10, "-");
            return ieFormatada.ToString();
        }

        protected override void GerarNucleo()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 2)
                {
                    identificacaoModel.Nucleo += "0";
                }
                else if (i == 3)
                {
                    identificacaoModel.Nucleo += "3";
                }
                else
                {
                    identificacaoModel.Nucleo += GerarNumeroAleatorio();
                }
                
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var primeiroDigito = 0;
            var somaTotal = 0;
            var peso = 9;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                if (i != 2 && i != 3)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                    peso--;
                }
               
            }
            var restoDivisao = somaTotal % 11;
            if (restoDivisao >= 2)
            {
                primeiroDigito = 11 - restoDivisao;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }
    }
}