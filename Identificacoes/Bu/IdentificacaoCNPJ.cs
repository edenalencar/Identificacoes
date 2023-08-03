using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoCNPJ : Identificacao
    {
        public IdentificacaoCNPJ()
        {
            GerarNucleo();
            GerarFiliais();
            GerarPrimeiroDigito();
            GerarSegundoDigito();
        }
        public IdentificacaoCNPJ(string nucleo, string filial) 
        { 
            identificacaoModel.Nucleo = nucleo;
            identificacaoModel.Filial = filial;
            GerarFiliais();
            GerarPrimeiroDigito();
            GerarSegundoDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var cnpjFormatado = new StringBuilder();
            cnpjFormatado.Append(GetIdentificacao());
            cnpjFormatado.Insert(12, "-");
            cnpjFormatado.Insert(8, "/");
            cnpjFormatado.Insert(5, ".");
            cnpjFormatado.Insert(2, ".");
            return cnpjFormatado.ToString();
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
            var primeiroDigito = 0;
            var somaTotal = 0;
            var restoDivisao = 0;
            var nucleoFilial = identificacaoModel.Nucleo + (identificacaoModel.Filial);

            for (int i = 0; i < nucleoFilial.Length; i++)
            {
                if (i == 0 || i == 8)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 5;
                }else if (i == 1 || i == 9)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 4;
                }else if(i == 2 || i == 10)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 3;
                }
                else if (i == 3 || i == 11)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 2;
                }
                else if (i == 4)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 9;
                }
                else if (i == 5)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 8;
                }
                else if (i == 6)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 7;
                }
                else if (i == 7)
                {
                    somaTotal += Convert.ToInt32(nucleoFilial[i].ToString()) * 6;
                }
            }

            restoDivisao = (somaTotal % 11);
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
            var restoDivisao = 0;
            var nucleoPrimeiroDigito = identificacaoModel.Nucleo + identificacaoModel.Filial + identificacaoModel.PrimeiroDigito ;

            for (int i = 0; i < nucleoPrimeiroDigito.Length; i++)
            {
                if (i == 0 || i == 8)
                {
                    somaTotal += Convert.ToInt32(nucleoPrimeiroDigito[i].ToString()) * 6;
                }
                else if (i == 1 || i == 9)
                {
                    somaTotal += Convert.ToInt32(nucleoPrimeiroDigito[i].ToString()) * 5;
                }
                else if (i == 2 || i == 10)
                {
                    somaTotal += Convert.ToInt32(nucleoPrimeiroDigito[i].ToString()) * 4;
                }
                else if (i == 3 || i == 11)
                {
                    somaTotal += Convert.ToInt32(nucleoPrimeiroDigito[i].ToString()) * 3;
                }
                else if (i == 4 || i == 12)
                {
                    somaTotal += Convert.ToInt32(nucleoPrimeiroDigito[i].ToString()) * 2;
                }
                else if (i == 5)
                {
                    somaTotal += Convert.ToInt32(nucleoPrimeiroDigito[i].ToString()) * 9;
                }
                else if (i == 6)
                {
                    somaTotal += Convert.ToInt32(nucleoPrimeiroDigito[i].ToString()) * 8;
                }
                else if (i == 7)
                {
                    somaTotal += Convert.ToInt32(nucleoPrimeiroDigito[i].ToString()) * 7;
                }
            }

            restoDivisao = (somaTotal % 11);
            if (restoDivisao >= 2)
            {
                segundoDigito = 11 - restoDivisao;
            }
            identificacaoModel.SegundoDigito = segundoDigito.ToString();
        }
        public override void GerarFiliais()
        {
            if (identificacaoModel.Filial == null)
            {
                identificacaoModel.Filial = "0001";
            }
            else
            {
                var filial = Convert.ToInt32(identificacaoModel.Filial);
                filial++;
                identificacaoModel.Filial = Convert.ToString(filial).PadLeft(4, '0') ;
            }
        }
    }
}
