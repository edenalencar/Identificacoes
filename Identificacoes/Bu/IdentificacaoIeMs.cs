﻿using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoIeMs : Identificacao
    {
        public IdentificacaoIeMs()
        {
            GerarNucleo();
            GerarPrimeiroDigito();
        }

        public override string ObterIdentificacaoFormatada()
        {
            var ieFormatada = new StringBuilder();
            ieFormatada.Append(ObterIdentificacao());
            ieFormatada.Insert(8, "-");
            return ieFormatada.ToString();
        }

        protected override void GerarNucleo()
        {
            identificacaoModel.Nucleo = "28";
            for (int i = 0; i < 6; i++)
            {
                identificacaoModel.Nucleo += GerarNumeroAleatorio().ToString();
            }
        }

        protected override void GerarPrimeiroDigito()
        {
            var primeiroDigito = 0;
            var somaTotal = 0;            
            var peso = 9;

            for (int i = 0; i < identificacaoModel.Nucleo.Length; i++)
            {

                somaTotal += Convert.ToInt32(identificacaoModel.Nucleo[i].ToString()) * peso;
                peso--;

            }
            var restoDivisao = somaTotal % 11;
            if (restoDivisao != 0 && (11 - restoDivisao) < 10)
            {
                primeiroDigito = 11 - restoDivisao;
            }
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }
    }
    
}