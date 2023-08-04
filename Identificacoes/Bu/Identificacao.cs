using Identificacoes.Model;
using System;

namespace Identificacoes.Bu
{
    abstract class Identificacao
    {
        public IdentificacaoModel identificacaoModel = new IdentificacaoModel();
        public string ObterIdentificacao()
        {
            return identificacaoModel.Nucleo + identificacaoModel.Filial + identificacaoModel.PrimeiroDigito + identificacaoModel.SegundoDigito;           
        }
        
        protected int GerarNumeroAleatorio()
        {
            Random rnd = new Random();
            return rnd.Next(0, 10);
        }

        protected abstract void GerarNucleo();
        protected abstract void GerarPrimeiroDigito();
        protected virtual void GerarSegundoDigito() { }
        public virtual void GerarFiliais() { }
        public abstract string ObterIdentificacaoFormatada();


    }
}
