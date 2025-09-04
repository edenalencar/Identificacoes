using Identificacoes.Util;
using System.Collections.Generic;

namespace Identificacoes.Bu
{
    class IdentificacaoFactory
    {
        private readonly Dictionary<string, Identificacao> _ident = new Dictionary<string, Identificacao>();
        private IdentificacaoFactory() 
        {
            _ident.Add(Constantes.CPF, new IdentificacaoCPF());
            _ident.Add(Constantes.CNPJ, new IdentificacaoCNPJ());
            _ident.Add(Constantes.CNPJ_ALFANUMERICO, new IdentificacaoCNPJAlfanumerico());           
        }

        public Identificacao GetIdentificacao(string tipoIdentificacao)
        {
            return _ident[tipoIdentificacao];
        }
        public static IdentificacaoFactory GetInstance()
        {
            return new IdentificacaoFactory();
        }
    }
}
