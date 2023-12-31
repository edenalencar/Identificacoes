﻿using Identificacoes.Util;
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
            _ident.Add(Constantes.IE_ES, new IdentificacaoIeEs());
            _ident.Add(Constantes.IE_GO, new IdentificacaoIeGo());
            _ident.Add(Constantes.IE_MA, new IdentificacaoIeMa());
            _ident.Add(Constantes.IE_MT, new IdentificacaoIeMt());
            _ident.Add(Constantes.IE_MS, new IdentificacaoIeMs());
            _ident.Add(Constantes.IE_MG, new IdentificacaoIeMg());
            _ident.Add(Constantes.IE_PA, new IdentificacaoIePa());
            _ident.Add(Constantes.IE_PB, new IdentificacaoIePb());
            _ident.Add(Constantes.IE_PR, new IdentificacaoIePr());
            _ident.Add(Constantes.IE_PE, new IdentificacaoIePe());
            _ident.Add(Constantes.IE_PI, new IdentificacaoIePi());
            _ident.Add(Constantes.IE_RJ, new IdentificacaoIeRj());
            _ident.Add(Constantes.IE_RN, new IdentificacaoIeRn());
            _ident.Add(Constantes.IE_RS, new IdentificacaoIeRs());
            _ident.Add(Constantes.IE_RO, new IdentificacaoIeRo());
            _ident.Add(Constantes.IE_RR, new IdentificacaoIeRr());
            _ident.Add(Constantes.IE_SP, new IdentificacaoIeSp());
            _ident.Add(Constantes.IE_SC, new IdentificacaoIeSc());
            _ident.Add(Constantes.IE_SE, new IdentificacaoIeSe());
            _ident.Add(Constantes.IE_TO, new IdentificacaoIeTo());
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
