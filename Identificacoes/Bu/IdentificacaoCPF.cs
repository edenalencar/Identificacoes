using System;
using System.Text;

namespace Identificacoes.Bu
{
    class IdentificacaoCPF : Identificacao
    {
        public IdentificacaoCPF()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
            GerarSegundoDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var cpfFormatado = new StringBuilder();
            cpfFormatado.Append(ObterIdentificacao());
            cpfFormatado.Insert(9, "-");
            cpfFormatado.Insert(6, ".");
            cpfFormatado.Insert(3, ".");
            return cpfFormatado.ToString();
        }

        protected override void GerarNucleo()
        {
            for (int i = 0; i < 9; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var primeiroDigito = 0;
            var somaTotal = 0;
            var peso = 10;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                peso--;
            }
            int restoDivisao = somaTotal % 11;

            if (restoDivisao >= 2)
            {
                primeiroDigito = 11 - restoDivisao;
            }

            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }
        protected override void GerarSegundoDigito()
        {
            var segundoDigito = 0;
            var somaTotal = 0;
            var peso = 11;
            var nucleoPrimeiroDigito = identificacaoModel.Nucleo + identificacaoModel.PrimeiroDigito;

            for (int i = 0; i < nucleoPrimeiroDigito.Length; i++)
            {
                somaTotal += Convert.ToInt32(nucleoPrimeiroDigito[i].ToString()) * peso;
                peso--;
            }

            int restoDivisao = somaTotal % 11;

            if (restoDivisao >= 2)
            {
                segundoDigito = 11 - restoDivisao;
            }

            identificacaoModel.SegundoDigito = segundoDigito.ToString();
        }
    }
}
