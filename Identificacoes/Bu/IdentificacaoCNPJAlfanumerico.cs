using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoCNPJAlfanumerico : Identificacao
    {
        // Caracteres válidos para CNPJ alfanumérico (exclui I, O, U para evitar confusão com 1, 0)
        private static readonly char[] caracteresValidos = 
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 
            'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 
            'X', 'Y', 'Z'
        };
        
        private static readonly int baseAlfanumerica = caracteresValidos.Length; // 33

        public IdentificacaoCNPJAlfanumerico()
        {
            GerarNucleo();
            GerarFiliais();
            GerarPrimeiroDigito();
            GerarSegundoDigito();
        }
        
        public IdentificacaoCNPJAlfanumerico(string nucleo, string filial)
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
            cnpjFormatado.Append(ObterIdentificacao());
            cnpjFormatado.Insert(12, "-");
            cnpjFormatado.Insert(8, "/");
            cnpjFormatado.Insert(5, ".");
            cnpjFormatado.Insert(2, ".");
            return cnpjFormatado.ToString();
        }

        protected override void GerarNucleo()
        {
            identificacaoModel.Nucleo = "";
            for (int i = 0; i < 8; i++)
            {
                identificacaoModel.Nucleo += GerarCaractereAleatorio();
            }
        }

        private char GerarCaractereAleatorio()
        {
            Random rnd = new Random();
            return caracteresValidos[rnd.Next(0, caracteresValidos.Length)];
        }

        private int ObterValorCaractere(char caractere)
        {
            for (int i = 0; i < caracteresValidos.Length; i++)
            {
                if (caracteresValidos[i] == caractere)
                    return i;
            }
            return 0;
        }

        protected override void GerarPrimeiroDigito()
        {
            var somaTotal = 0;
            var nucleoFilial = identificacaoModel.Nucleo + identificacaoModel.Filial;
            var pesos = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < nucleoFilial.Length; i++)
            {
                var valorCaractere = ObterValorCaractere(nucleoFilial[i]);
                somaTotal += valorCaractere * pesos[i];
            }

            var restoDivisao = somaTotal % baseAlfanumerica;
            var primeiroDigito = restoDivisao < 2 ? 0 : baseAlfanumerica - restoDivisao;
            
            identificacaoModel.PrimeiroDigito = caracteresValidos[primeiroDigito].ToString();
        }

        protected override void GerarSegundoDigito()
        {
            var somaTotal = 0;
            var nucleoPrimeiroDigito = identificacaoModel.Nucleo + identificacaoModel.Filial + identificacaoModel.PrimeiroDigito;
            var pesos = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < nucleoPrimeiroDigito.Length; i++)
            {
                var valorCaractere = ObterValorCaractere(nucleoPrimeiroDigito[i]);
                somaTotal += valorCaractere * pesos[i];
            }

            var restoDivisao = somaTotal % baseAlfanumerica;
            var segundoDigito = restoDivisao < 2 ? 0 : baseAlfanumerica - restoDivisao;
            
            identificacaoModel.SegundoDigito = caracteresValidos[segundoDigito].ToString();
        }

        public override void GerarFiliais()
        {
            if (identificacaoModel.Filial == null)
            {
                // Para CNPJ alfanumérico, mantemos o padrão numérico nas filiais por compatibilidade
                identificacaoModel.Filial = "0001";
            }
            else
            {
                var filial = Convert.ToInt32(identificacaoModel.Filial);
                filial++;
                identificacaoModel.Filial = Convert.ToString(filial).PadLeft(4, '0');
            }
        }
    }
}