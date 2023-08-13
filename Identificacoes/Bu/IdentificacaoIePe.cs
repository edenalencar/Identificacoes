using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIePe : Identificacao
    {
        public IdentificacaoIePe()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
            GerarSegundoDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());            
            ieFormatada.Insert(7, "-");
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
            var peso = 8;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                peso--;
            }
            var restoDivisao = somaTotal % 11;
            if (restoDivisao != 0 && restoDivisao != 1)
            {
                primeiroDigito = 11 - restoDivisao;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }

        protected override void GerarSegundoDigito()
        {
            var segundoDigito = 0;
            var somaTotal = 0;
            var nucleoSegundoDigito = identificacaoModel.Nucleo + identificacaoModel.PrimeiroDigito;
            var peso = 9;

            for (int i = 0; i < nucleoSegundoDigito.Length; i++)
            {
                somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * peso;
                peso--;
            }

            var restoDivisao = somaTotal % 11;
            if (restoDivisao != 0 && restoDivisao != 1)
            {
                segundoDigito = 11 - restoDivisao;
            }
            identificacaoModel.SegundoDigito = segundoDigito.ToString();
        }
    }
}