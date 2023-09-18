using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeMg : Identificacao
    {
        public IdentificacaoIeMg()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
            GerarSegundoDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(9, "/");
            ieFormatada.Insert(6, ".");
            ieFormatada.Insert(3, ".");
            return ieFormatada.ToString();
        }

        protected override void GerarNucleo()
        {
            for (int i = 0; i < 11; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var somaTotal = 0;
            var pesoUm = 1;
            var pesoDois = 2;

            StringBuilder identificacaoIgual = new StringBuilder();
            identificacaoIgual.Append(identificacaoModel.Nucleo);
            identificacaoIgual.Insert(3, "0");

            for (int i = 0; i < identificacaoIgual.Length; i++)
            {
                int produto;
                if (i % 2 == 0)
                {
                    produto = Convert.ToInt32(identificacaoIgual[i].ToString()) * pesoUm;
                }
                else
                {
                    produto = Convert.ToInt32(identificacaoIgual[i].ToString()) * pesoDois;
                }

                if (produto.ToString().Length == 1)
                {
                    somaTotal += Convert.ToInt32(produto.ToString());
                }
                else
                {
                    somaTotal += Convert.ToInt32(produto.ToString()[0].ToString()) + Convert.ToInt32(produto.ToString()[1].ToString());
                }
            }

            int primeiroDigito = 10 - (somaTotal.ToString().Length == 1 ? Convert.ToInt32(somaTotal.ToString()) : Convert.ToInt32(somaTotal.ToString()[1].ToString()));

            identificacaoModel.PrimeiroDigito = primeiroDigito < 10 ? primeiroDigito.ToString() : "0";
        }

        protected override void GerarSegundoDigito()
        {
            var segundoDigito = 0;
            var somaTotal = 0;
            var nucleoSugundoDigito = identificacaoModel.Nucleo + identificacaoModel.PrimeiroDigito;
            var pesoUm = 11;
            var pesoDois = 3;
            
            for (int i = 0; i < nucleoSugundoDigito.Length; i++)
            {
                if (i < 2)
                {
                    somaTotal += Convert.ToInt32(nucleoSugundoDigito[i].ToString()) * pesoDois;
                    pesoDois--;
                }
                else
                {
                    somaTotal += Convert.ToInt32(nucleoSugundoDigito[i].ToString()) * pesoUm;
                    pesoUm--;
                }
            }
            int restoDivisao = somaTotal % 11;
            if (restoDivisao != 0 && restoDivisao != 1)
            {
                segundoDigito = 11 - restoDivisao;
            }
            identificacaoModel.SegundoDigito = segundoDigito.ToString();
        }
    }
}