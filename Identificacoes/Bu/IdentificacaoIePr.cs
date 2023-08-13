using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIePr : Identificacao
    {
        public IdentificacaoIePr()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
            GerarSegundoDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(3, "-");
            ieFormatada.Insert(9, "-");
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
            var primeiroDigito = 0;
            var somaTotal = 0;
            var peso = 7;
            var peso_digito_dois = 3;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {
                if (i <= 1)
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso_digito_dois;
                    peso_digito_dois--;
                }
                else
                {
                    somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                    peso--;
                }
                

            }
            var restoDivisao = 11 - (somaTotal % 11);
            if (restoDivisao != 10 && restoDivisao != 11)
            {
                primeiroDigito = restoDivisao;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }

        protected override void GerarSegundoDigito()
        {
            var segundoDigito = 0;
            var somaTotal = 0;
            var nucleoSegundoDigito = identificacaoModel.Nucleo + identificacaoModel.PrimeiroDigito;
            var pesoUm = 7;
            var pesoDois = 4;            

            for (int i = 0; i < nucleoSegundoDigito.Length; i++)
            {
                if (i < 3)
                {
                    somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * pesoDois;
                    pesoDois--;
                }
                else
                {
                    somaTotal += Convert.ToInt32(nucleoSegundoDigito[i].ToString()) * pesoUm;
                    pesoUm--;
                }


            }
            var restoDivisao = 11 - (somaTotal % 11);
            if (restoDivisao != 10 && restoDivisao != 11)
            {
                segundoDigito = restoDivisao;
            }
            identificacaoModel.SegundoDigito = segundoDigito.ToString();
        }
    }
}