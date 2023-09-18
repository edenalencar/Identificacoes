using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeGo : Identificacao
    {
        public IdentificacaoIeGo()
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
            ieFormatada.Insert(10, "-");
            return ieFormatada.ToString();
        }

        protected override void GerarNucleo()
        {
            identificacaoModel.Nucleo += "10";
            for (int i = 0; i < 6; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var primeiroDigito = 0;
            var somaTotal = 0;
            var peso = 9;
            long inicioIdentificacao = 10103105;
            long fimIdentificacao = 10119997;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                peso--;
            }

            var restoDivisao = somaTotal % 11;


            if (restoDivisao == 1 && inicioIdentificacao <= Convert.ToDouble(identificacaoModel.Nucleo) && fimIdentificacao >= Convert.ToDouble(identificacaoModel.Nucleo))
            {
                primeiroDigito = restoDivisao;
            }
            else if (restoDivisao != 0 && restoDivisao != 1)
            {
                primeiroDigito = 11 - restoDivisao;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }
    }
}