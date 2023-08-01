using Identificacoes.Model;
using System;

namespace Identificacoes.Bu
{
    abstract class Identificacao
    {
        public IdentificacaoModel identificacaoModel = new IdentificacaoModel();
        public string getIdentificacao()
        {
            return identificacaoModel.Nucleo + identificacaoModel.Filial + identificacaoModel.PrimeiroDigito + identificacaoModel.SegundoDigito;           
        }
        
        protected int gerarNumeroAleatorio()
        {
            Random rnd = new Random();
            return rnd.Next(0, 10);
        }

        protected abstract void gerarNucleo();
        protected abstract void gerarPrimeiroDigito();
        protected virtual void gerarSegundoDigito() { }
        public virtual void gerarFiliais() { }
        public abstract string obterIdentificacaoFormatada();
        
    }
}
