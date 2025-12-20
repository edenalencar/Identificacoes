using System;
using System.Text;

namespace Identificacoes.Bu
{
    internal class IdentificacaoCNPJAlfanumerico : Identificacao
    {
        // Caracteres válidos para CNPJ alfanumérico conforme documentação oficial
        // Inclui dígitos 0-9 e letras A-Z (agora completo)
        private static readonly char[] caracteresValidos = 
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 
            'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 
            'X', 'Y', 'Z'
        };
        
        private static readonly Random random = new Random();

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
            return caracteresValidos[random.Next(0, caracteresValidos.Length)];
        }

        /// <summary>
        /// Obtém o valor numérico de um caractere alfanumérico conforme documentação oficial (Valor ASCII - 48)
        /// </summary>
        /// <param name="caractere">Caractere a ser convertido</param>
        /// <returns>Valor numérico do caractere</returns>
        private int ObterValorCaractere(char caractere)
        {
            // Tabela ASCII: '0'=48 ... '9'=57 ... 'A'=65 ... 'Z'=90
            // Regra: Valor = ASCII - 48
            // Exemplo: '0' (48) - 48 = 0
            // Exemplo: 'A' (65) - 48 = 17
            return (int)caractere - 48;
        }

        /// <summary>
        /// Calcula o primeiro dígito verificador conforme documentação oficial
        /// IMPORTANTE: O dígito verificador é SEMPRE NUMÉRICO (0-9), nunca alfanumérico
        /// </summary>
        protected override void GerarPrimeiroDigito()
        {
            var somaTotal = 0;
            var nucleoFilial = identificacaoModel.Nucleo + identificacaoModel.Filial;
            
            // Pesos para o primeiro dígito: 5,4,3,2,9,8,7,6,5,4,3,2
            var pesos = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Calcula a soma ponderada
            for (int i = 0; i < nucleoFilial.Length; i++)
            {
                var valorCaractere = ObterValorCaractere(nucleoFilial[i]);
                somaTotal += valorCaractere * pesos[i];
            }

            // Calcula o resto da divisão por 11 (não por 33!)
            var restoDivisao = somaTotal % 11;
            
            // Conforme documentação: se resto < 2, DV = 0; senão DV = 11 - resto
            // O resultado é SEMPRE um dígito numérico (0-9)
            var primeiroDigito = restoDivisao < 2 ? 0 : 11 - restoDivisao;
            
            identificacaoModel.PrimeiroDigito = primeiroDigito.ToString();
        }

        /// <summary>
        /// Calcula o segundo dígito verificador conforme documentação oficial
        /// IMPORTANTE: O dígito verificador é SEMPRE NUMÉRICO (0-9), nunca alfanumérico
        /// </summary>
        protected override void GerarSegundoDigito()
        {
            var somaTotal = 0;
            var nucleoFilialPrimeiroDigito = identificacaoModel.Nucleo + identificacaoModel.Filial + identificacaoModel.PrimeiroDigito;
            
            // Pesos para o segundo dígito: 6,5,4,3,2,9,8,7,6,5,4,3,2
            var pesos = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Calcula a soma ponderada
            for (int i = 0; i < nucleoFilialPrimeiroDigito.Length; i++)
            {
                var valorCaractere = ObterValorCaractere(nucleoFilialPrimeiroDigito[i]);
                somaTotal += valorCaractere * pesos[i];
            }

            // Calcula o resto da divisão por 11 (não por 33!)
            var restoDivisao = somaTotal % 11;
            
            // Conforme documentação: se resto < 2, DV = 0; senão DV = 11 - resto
            // O resultado é SEMPRE um dígito numérico (0-9)
            var segundoDigito = restoDivisao < 2 ? 0 : 11 - restoDivisao;
            
            identificacaoModel.SegundoDigito = segundoDigito.ToString();
        }

        /// <summary>
        /// Gera ou incrementa o número da filial (suporta formato alfanumérico)
        /// </summary>
        public override void GerarFiliais()
        {
            if (string.IsNullOrEmpty(identificacaoModel.Filial))
            {
                // Gera 4 caracteres aleatórios do conjunto válido
                var filial = new StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    filial.Append(GerarCaractereAleatorio());
                }
                identificacaoModel.Filial = filial.ToString();
            }
            else
            {
                identificacaoModel.Filial = IncrementarAlfanumerico(identificacaoModel.Filial);
            }
        }

        private string IncrementarAlfanumerico(string valor)
        {
            var chars = valor.ToCharArray();
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                int index = -1;
                // Encontrar índice do caractere atual
                for (int j = 0; j < caracteresValidos.Length; j++)
                {
                    if (caracteresValidos[j] == chars[i])
                    {
                        index = j;
                        break;
                    }
                }

                if (index != -1 && index < caracteresValidos.Length - 1)
                {
                    // Se não é o último caractere do conjunto, apenas incrementa
                    chars[i] = caracteresValidos[index + 1];
                    return new string(chars);
                }

                // Se é o último, volta para o primeiro e continua o loop para o caractere anterior (vai um)
                if (index != -1)
                {
                    chars[i] = caracteresValidos[0];
                }
            }
            
            // Se chegou aqui, houve overflow (ex: ZZZZ -> 0000)
            return new string(chars);
        }

        /// <summary>
        /// Valida se um caractere é válido para CNPJ alfanumérico
        /// </summary>
        /// <param name="caractere">Caractere a ser validado</param>
        /// <returns>True se o caractere é válido</returns>
        public static bool CaractereValido(char caractere)
        {
            foreach (var c in caracteresValidos)
            {
                if (c == caractere)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Valida se uma string contém apenas caracteres válidos para CNPJ alfanumérico
        /// </summary>
        /// <param name="texto">Texto a ser validado</param>
        /// <returns>True se todos os caracteres são válidos</returns>
        public static bool TextoValido(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return false;

            foreach (char c in texto)
            {
                if (!CaractereValido(c))
                    return false;
            }
            return true;
        }
    }
}