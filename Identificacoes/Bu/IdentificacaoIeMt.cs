using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeMt : Identificacao
    {
        public IdentificacaoIeMt()
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
                identificacaoModel.Nucleo += GerarNumeroAleatorio().ToString();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var primeiroDigito = 0;
            var somaTotal = 0;
            var pesoDoisDigitos = 3;
            var peso = 9;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                if ( i <= 1)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * pesoDoisDigitos;
                    pesoDoisDigitos--;
                }
                else
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                    peso--;
                }
            }
            var restoDivisao = somaTotal % 11;
            if(restoDivisao != 0 && restoDivisao != 1)
            {
                primeiroDigito = 11 - restoDivisao;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }
    }
}