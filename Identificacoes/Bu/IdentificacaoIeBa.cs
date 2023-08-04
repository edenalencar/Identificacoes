using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeBa : Identificacao
    {
        public IdentificacaoIeBa()
        {
            GerarNucleo();
            GerarSegundoDigito();
            GerarPrimeiroDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(6, "-");
            return ieFormatada.ToString();
        }

        protected override void GerarNucleo()
        {
            for (int i = 0; i < 6; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var somaTotal = 0;
            var peso = 8;
            var nucleoSegundoDigito = identificacaoModel.Nucleo + identificacaoModel.SegundoDigito;

            for (int i = 0; i < nucleoSegundoDigito.Length; i++)
            {
                somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * peso;
                peso--;
            }

            int primeiroDigito;
            int restoDivisao;
            if (Convert.ToInt32(identificacaoModel.Nucleo[0].ToString()) >= 6 ||
                Convert.ToInt32(identificacaoModel.Nucleo[0].ToString()) <= 9)
            {
                restoDivisao = somaTotal % 11;
                primeiroDigito = (restoDivisao == 0 || restoDivisao == 1) ? 0 : 11 - restoDivisao;
            }
            else
            {
                restoDivisao = somaTotal % 10;
                primeiroDigito = restoDivisao == 0 ? 0 : 10 - restoDivisao;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();

        }

        protected override void GerarSegundoDigito()
        {
            var somaTotal = 0;
            var peso = 7;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                peso--;
            }

            int segundoDigito;
            int restoDivisao;
            if (Convert.ToInt32(identificacaoModel.Nucleo[0].ToString()) >= 6 ||
               Convert.ToInt32(identificacaoModel.Nucleo[0].ToString()) <= 9)
            {
                restoDivisao = somaTotal % 11;
                segundoDigito = (restoDivisao == 0 || restoDivisao == 1) ? 0 : 11 - restoDivisao;
            }
            else
            {
                restoDivisao = somaTotal % 10;
                segundoDigito = restoDivisao == 0 ? 0 : 10 - restoDivisao;
            }
            identificacaoModel.SegundoDigito = segundoDigito.ToString();
        }
    }
}