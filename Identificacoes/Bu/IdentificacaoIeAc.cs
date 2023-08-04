using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeAc : Identificacao
    {
        public IdentificacaoIeAc()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
            GerarSegundoDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(11, "-");
            ieFormatada.Insert(8, "/");
            ieFormatada.Insert(5, ".");
            ieFormatada.Insert(2, ".");
            return ieFormatada.ToString();
        }

        protected override void GerarNucleo()
        {
            identificacaoModel.Nucleo = "01";
            for (int i = 0; i < 9; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var primeiroDigito = 0;
            var somaTotal = 0;
            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                if (i == 0 || i == 8)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 4;
                }
                else if (i == 1 || i == 9)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 3;
                }
                else if (i == 2 || i == 10)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 2;
                }
                else if (i == 3)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 9;
                }
                else if (i == 4)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 8;
                }
                else if (i == 5)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 7;
                }
                else if (i == 6)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 6;
                }
                else if (i == 7)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 5;
                }
            }
            int restoDivisao = somaTotal % 11;
            var calculoPrimeiroDigito = 11 - restoDivisao;
            if (calculoPrimeiroDigito != 10 && calculoPrimeiroDigito != 11)
            {
                primeiroDigito = calculoPrimeiroDigito;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }

        protected override void GerarSegundoDigito()
        {
            var segundoDigito = 0;
            var somaTotal = 0;
            for (int i = 0; i < identificacaoModel.Nucleo.Length + identificacaoModel.PrimeiroDigito.Length; i++)
            {
                if (i == 0 || i == 8)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 5;
                }
                else if (i == 1 || i == 9)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 4;
                }
                else if (i == 2 || i == 10)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 3;
                }
                else if (i == 3)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 2;
                }
                else if (i == 4)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 9;
                }
                else if (i == 5)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 8;
                }
                else if (i == 6)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 7;
                }
                else if (i == 7)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * 6;
                }
                else if (i == 11)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.PrimeiroDigito.ToString()) * 2;
                }
            }
            int restoDivisao = somaTotal % 11;
            var calculoSegundoDigito = 11 - restoDivisao;
            if (calculoSegundoDigito != 10 && calculoSegundoDigito != 11)
            {
                segundoDigito = calculoSegundoDigito;
            }
            identificacaoModel.SegundoDigito = segundoDigito.ToString();
        }

    }
}
