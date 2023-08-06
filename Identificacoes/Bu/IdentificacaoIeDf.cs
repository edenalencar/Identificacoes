using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeDf : Identificacao
    {
        public IdentificacaoIeDf()
        {
            GerarNucleo();
            GerarFiliais();
            GerarPrimeiroDigito();
            GerarSegundoDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(11, "-");
            return ieFormatada.ToString();
        }
        public override void GerarFiliais()
        {
            identificacaoModel.Filial = "001";
        }

        protected override void GerarNucleo()
        {
            identificacaoModel.Nucleo = "07";
            for (int i = 0; i < 6; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var primeiroDigito = 0;
            var somaTotal = 0;
            var nucleoFilial = identificacaoModel.Nucleo + identificacaoModel.Filial;

            for (int i = 0; i < nucleoFilial.Length; i++)
            {
                if (i == 0 || i == 8)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 4;
                }
                else if (i == 1 || i == 9)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 3;
                }
                else if (i == 2 || i == 10)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 2;
                }
                else if (i == 3)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 9;
                }
                else if (i == 4)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 8;
                }
                else if (i == 5)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 7;
                }
                else if (i == 6)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 6;
                }
                else if (i == 7)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 5;
                }
            }
            var calculoPrimeiroDigito = 11 - (somaTotal % 11);
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
            var nucleoSegundoDigito = identificacaoModel.Nucleo + identificacaoModel.Filial + identificacaoModel.PrimeiroDigito;

            for (int i = 0; i < nucleoSegundoDigito.Length; i++)
            {
                if (i == 0 || i == 8)
                {
                    somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * 5;
                }
                else if (i == 1 || i == 9)
                {
                    somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * 4;
                }
                else if (i == 2 || i == 10)
                {
                    somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * 3;
                }
                else if (i == 3 || i == 11)
                {
                    somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * 2;
                }
                else if (i == 4)
                {
                    somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * 9;
                }
                else if (i == 5)
                {
                    somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * 8;
                }
                else if (i == 6)
                {
                    somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * 7;
                }
                else if (i == 7)
                {
                    somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * 6;
                }
            }

            var calculoSegundoDigito = 11 - (somaTotal % 11);
            if (calculoSegundoDigito != 10 && calculoSegundoDigito != 11)
            {
                segundoDigito = calculoSegundoDigito;
            }
            identificacaoModel.SegundoDigito = segundoDigito.ToString();
        }
    }
}