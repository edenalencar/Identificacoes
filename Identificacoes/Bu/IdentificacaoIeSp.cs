using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeSp : Identificacao
    {
        public IdentificacaoIeSp()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
            GerarSegundoDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(9, ".");
            ieFormatada.Insert(6, ".");
            ieFormatada.Insert(3, ".");
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
            int[] peso = { 1, 3, 4, 5, 6, 7, 8, 10 };

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso[i];
            }
            var restoDivisao = somaTotal % 11;
            var primeiroDigito = Convert.ToInt32((restoDivisao.ToString()[restoDivisao.ToString().Length - 1]).ToString());

            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString() + "11";
        }

        protected override void GerarSegundoDigito()
        {
            var somaTotal = 0;
            var nucleoSegundoDigito = identificacaoModel.Nucleo + identificacaoModel.PrimeiroDigito;
            int[] peso = { 3, 2, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < nucleoSegundoDigito.Length; i++)
            {
                somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * peso[i];
            }
            var restoDivisao = somaTotal % 11;
            var segundoDigito = Convert.ToInt32((restoDivisao.ToString()[restoDivisao.ToString().Length - 1]).ToString());

            identificacaoModel.SegundoDigito = segundoDigito.ToString();
        }
    }
}