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
            _ident.Add(Constantes.IE_AC, new IdentificacaoIeAc());
            _ident.Add(Constantes.IE_AL, new IdentificacaoIeAl());
            _ident.Add(Constantes.IE_AP, new IdentificacaoIeAp());
            _ident.Add(Constantes.IE_AM, new IdentificacaoIeAm());
            _ident.Add(Constantes.IE_BA, new IdentificacaoIeBa());
            _ident.Add(Constantes.IE_CE, new IdentificacaoIeCe());
            _ident.Add(Constantes.IE_DF, new IdentificacaoIeDf());
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
