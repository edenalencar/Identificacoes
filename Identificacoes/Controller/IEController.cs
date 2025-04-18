using Identificacoes.Model;
using System;

namespace Identificacoes.Controller
{
    /// <summary>
    /// Controlador para geração e validação de Inscrições Estaduais
    /// </summary>
    public class IEController
    {
        /// <summary>
        /// Gera uma Inscrição Estadual válida para o estado especificado
        /// </summary>
        /// <param name="estado">Sigla do estado (ex: SP, RJ, MG)</param>
        /// <param name="formatado">Indica se o número gerado deve ser formatado ou não</param>
        /// <returns>Inscrição Estadual válida</returns>
        public string Gerar(string estado, bool formatado)
        {
            // Implementação simples para gerar números de Inscrição Estadual
            // Na implementação real, cada estado tem suas regras específicas
            Random random = new Random();
            string ie = string.Empty;
            
            switch (estado.ToUpper())
            {
                case "SP":
                    // São Paulo: 12 dígitos (11 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(11, random);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "RJ":
                    // Rio de Janeiro: 8 dígitos (7 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(7, random);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "MG":
                    // Minas Gerais: 13 dígitos 
                    ie = GerarNumeroAleatorio(12, random);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                // Outros estados seguem padrões diferentes
                default:
                    // Para outros estados, gera um número de 9 dígitos como exemplo
                    ie = GerarNumeroAleatorio(8, random);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
            }
            
            return ie;
        }
        
        /// <summary>
        /// Gera um número aleatório com a quantidade de dígitos especificada
        /// </summary>
        private string GerarNumeroAleatorio(int digitos, Random random)
        {
            string numero = "";
            for (int i = 0; i < digitos; i++)
            {
                numero += random.Next(0, 10).ToString();
            }
            return numero;
        }
        
        /// <summary>
        /// Calcula o dígito verificador para o número da IE de acordo com as regras de cada estado
        /// Esta é uma implementação simplificada, na realidade cada estado tem suas próprias regras
        /// </summary>
        private string CalcularDigitoVerificador(string numero, string estado)
        {
            // Implementação simplificada do dígito verificador
            // Na implementação real, cada estado tem suas regras específicas
            int soma = 0;
            int peso = 2;
            
            for (int i = numero.Length - 1; i >= 0; i--)
            {
                int digito = int.Parse(numero[i].ToString());
                soma += digito * peso;
                peso = peso == 9 ? 2 : peso + 1;
            }
            
            int resto = soma % 11;
            int dv = 11 - resto;
            
            if (dv == 10 || dv == 11)
                dv = 0;
                
            return dv.ToString();
        }
        
        /// <summary>
        /// Formata o número da IE de acordo com as regras de cada estado
        /// </summary>
        private string FormatarIE(string ie, string estado)
        {
            // Implementação simplificada de formatação
            // Na implementação real, cada estado tem seu formato específico
            switch (estado.ToUpper())
            {
                case "SP":
                    // São Paulo: 000.000.000.000
                    return string.Format("{0}.{1}.{2}.{3}", 
                        ie.Substring(0, 3), 
                        ie.Substring(3, 3), 
                        ie.Substring(6, 3), 
                        ie.Substring(9, 3));
                    
                case "RJ":
                    // Rio de Janeiro: 00.000.00-0
                    return string.Format("{0}.{1}.{2}-{3}", 
                        ie.Substring(0, 2), 
                        ie.Substring(2, 3), 
                        ie.Substring(5, 2),
                        ie.Substring(7, 1));
                    
                case "MG":
                    // Minas Gerais: 000.000000.00-0
                    return string.Format("{0}.{1}.{2}-{3}", 
                        ie.Substring(0, 3), 
                        ie.Substring(3, 6), 
                        ie.Substring(9, 2),
                        ie.Substring(11, 1));
                    
                default:
                    // Formato genérico para outros estados
                    if (ie.Length == 9)
                        return string.Format("{0}.{1}.{2}-{3}", 
                            ie.Substring(0, 3), 
                            ie.Substring(3, 3), 
                            ie.Substring(6, 2),
                            ie.Substring(8, 1));
                    else
                        return ie;
            }
        }
    }
}