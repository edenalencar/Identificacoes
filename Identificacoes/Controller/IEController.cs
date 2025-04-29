using Identificacoes.Model;
using System;
using System.Text;
using System.Collections.Generic;

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
            // Implementação para gerar números de Inscrição Estadual de acordo com as regras específicas de cada estado
            Random random = new Random();
            string ie = string.Empty;
            
            switch (estado.ToUpper())
            {
                case "AC":
                    // Acre: 13 dígitos (11 + 2 dígitos verificadores)
                    ie = GerarNumeroAleatorio(11, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    ie += CalcularDigitoVerificador(ie + ie[ie.Length - 1], estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "AL":
                    // Alagoas: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "AP":
                    // Amapá: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "AM":
                    // Amazonas: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "BA":
                    // Bahia: 8 ou 9 dígitos (7/8 + 1 dígito verificador)
                    // Neste exemplo, vamos usar 8 dígitos
                    ie = GerarNumeroAleatorio(7, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "CE":
                    // Ceará: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "DF":
                    // Distrito Federal: 13 dígitos (11 + 2 dígitos verificadores)
                    ie = GerarNumeroAleatorio(11, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    ie += CalcularDigitoVerificador(ie + ie[ie.Length - 1], estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "ES":
                    // Espírito Santo: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "GO":
                    // Goiás: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "MA":
                    // Maranhão: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "MT":
                    // Mato Grosso: 11 dígitos (10 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(10, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "MS":
                    // Mato Grosso do Sul: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "MG":
                    // Minas Gerais: 13 dígitos (11 base + 2 DV)
                    ie = GerarNumeroAleatorio(11, random, estado); // Base com 11 dígitos
                    var dv = CalcularDigitoVerificador(ie, estado); // Retorna 2 dígitos (DV1 + DV2)
                    ie += dv;
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "PA":
                    // Pará: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "PB":
                    // Paraíba: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "PR":
                    // Paraná: 10 dígitos (8 + 2 dígitos verificadores)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    ie += CalcularDigitoVerificador(ie + ie[ie.Length - 1], estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "PE":
                    // Pernambuco: 9 dígitos (7 + 2 dígitos verificadores)
                    ie = GerarNumeroAleatorio(7, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    ie += CalcularDigitoVerificador(ie + ie[ie.Length - 1], estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "PI":
                    // Piauí: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "RJ":
                    // Rio de Janeiro: 8 dígitos (7 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(7, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "RN":
                    // Rio Grande do Norte: 9 ou 10 dígitos (8/9 + 1 dígito verificador)
                    // Neste exemplo, vamos usar 9 dígitos
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "RS":
                    // Rio Grande do Sul: 10 dígitos (9 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(9, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "RO":
                    // Rondônia: 14 dígitos (13 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(13, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "RR":
                    // Roraima: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "SC":
                    // Santa Catarina: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "SP":
                    // São Paulo: 12 dígitos no total (8 dígitos base + 1 DV + 2 dígitos aleatórios + 1 DV)
                    ie = GerarNumeroAleatorio(8, random, estado); // Gera os 8 primeiros dígitos
                    ie += CalcularDigitoVerificador(ie, estado); // Calcula o primeiro DV (9º dígito)
                    ie += random.Next(0, 10).ToString() + random.Next(0, 10).ToString(); // Adiciona 2 dígitos aleatórios (10º e 11º)
                    ie += CalcularDigitoVerificador(ie, estado); // Calcula o segundo DV (12º dígito)
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "SE":
                    // Sergipe: 9 dígitos (8 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(8, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                case "TO":
                    // Tocantins: 11 dígitos (10 + 1 dígito verificador)
                    ie = GerarNumeroAleatorio(10, random, estado);
                    ie += CalcularDigitoVerificador(ie, estado);
                    if (formatado)
                        ie = FormatarIE(ie, estado);
                    break;
                    
                default:
                    // Caso a sigla do estado não seja válida, retorna vazio
                    ie = string.Empty;
                    break;
            }
            
            return ie;
        }
        
        /// <summary>
        /// Gera um número aleatório com a quantidade de dígitos especificada,
        /// respeitando as regras específicas de cada estado para o núcleo da inscrição estadual
        /// </summary>
        private static string GerarNumeroAleatorio(int digitos, Random random, string estado = "")
        {
            var numero = new StringBuilder();
            
            // Regras específicas para cada estado
            switch (estado.ToUpper())
            {
                case "AC":
                    numero.Append("01");
                    AppendRandomDigits(numero, digitos - 2, random);
                    break;
                    
                case "AL":
                    numero.Append("240");
                    AppendRandomDigits(numero, digitos - 3, random);
                    break;
                    
                case "AP":
                    numero.Append("03");
                    AppendRandomDigits(numero, digitos - 2, random);
                    break;

                case "AM":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;

                case "BA":
                    // Primeiro dígito define o módulo
                    AppendRandomDigits(numero, digitos, random);
                    break;

                case "CE":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;
                    
                case "DF":
                    numero.Append("07");
                    AppendRandomDigits(numero, digitos - 2, random);
                    break;

                case "ES":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;
                    
                case "GO":
                    numero.Append("10");
                    AppendRandomDigits(numero, digitos - 2, random);
                    break;
                    
                case "MA":
                    numero.Append("12");
                    AppendRandomDigits(numero, digitos - 2, random);
                    break;

                case "MT":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;
                    
                case "MS":
                    numero.Append("28");
                    AppendRandomDigits(numero, digitos - 2, random);
                    break;

                case "MG":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;
                    
                case "PA":
                    numero.Append("15");
                    AppendRandomDigits(numero, digitos - 2, random);
                    break;

                case "PB":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;

                case "PR":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;

                case "PE":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;

                case "PI":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;

                case "RJ":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;
                    
                case "RN":
                    numero.Append("20");
                    AppendRandomDigits(numero, digitos - 2, random);
                    break;

                case "RS":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;

                case "RO":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;
                    
                case "RR":
                    numero.Append("24");
                    AppendRandomDigits(numero, digitos - 2, random);
                    break;

                case "SC":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;

                case "SP":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;

                case "SE":
                    // Começa com dígito aleatório
                    AppendRandomDigits(numero, digitos, random);
                    break;
                    
                case "TO":
                    AppendRandomDigits(numero, 2, random);
                    numero.Append("03");
                    AppendRandomDigits(numero, digitos - 4, random);
                    break;
                    
                default:
                    AppendRandomDigits(numero, digitos, random);
                    break;
            }
            
            return numero.ToString();
        }

        private static void AppendRandomDigits(StringBuilder sb, int count, Random random)
        {
            for (int i = 0; i < count; i++)
            {
                sb.Append(random.Next(0, 10));
            }
        }

        /// <summary>
        /// Calcula o dígito verificador para o número da IE de acordo com as regras de cada estado
        /// </summary>
        private string CalcularDigitoVerificador(string numero, string estado)
        {
            switch (estado.ToUpper())
            {
                case "AC":
                    // Acre: primeiro DV usa pesos 4,3,2,9,8,7,6,5,4,3,2 
                    // Segundo DV usa pesos 5,4,3,2,9,8,7,6,5,4,3,2
                    if (numero.Length == 11) // Primeiro dígito
                        return CalcularDVPadrao(numero, new int[] { 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });
                    else // Segundo dígito
                        return CalcularDVPadrao(numero, new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });
                    
                case "AL":
                    // Alagoas: multiplicação por pesos 9 a 2 e cálculo especial
                    {
                        int soma = 0;
                        int peso = 9;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * peso;
                            peso--;
                        }
                        
                        int produto = soma * 10;
                        int resto = produto % 11;
                        int dv = resto == 10 ? 0 : resto;
                        return dv.ToString();
                    }
                    
                case "AP":
                    // Amapá: regra específica com valores p e d
                    {
                        int soma = 0;
                        int peso = 9;
                        int p = 0;
                        int d = 0;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * peso;
                            peso--;
                        }
                        
                        // Definição de p e d conforme faixa
                        string nucleo = numero;
                        if (nucleo.Length > 1)
                        {
                            if (int.Parse(nucleo) >= 3000001 && int.Parse(nucleo) <= 3017000)
                            {
                                p = 5;
                                d = 0;
                            }
                            else if (int.Parse(nucleo) >= 3017001 && int.Parse(nucleo) <= 3019022)
                            {
                                p = 9;
                                d = 1;
                            }
                            else
                            {
                                p = 0;
                                d = 0;
                            }
                        }
                        
                        int produto = p + soma;
                        int resto = produto % 11;
                        int dv = 0;
                        
                        if (11 - resto == 11)
                            dv = d;
                        else if (11 - resto != 10)
                            dv = 11 - resto;
                        
                        return dv.ToString();
                    }
                    
                case "AM":
                    // Amazonas: multiplicação por pesos 9 a 2 e cálculo especial
                    {
                        int soma = 0;
                        int peso = 9;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * peso;
                            peso--;
                        }
                        
                        int dv;
                        if (soma < 11)
                            dv = 11 - soma;
                        else
                        {
                            int resto = soma % 11;
                            dv = resto < 2 ? 0 : 11 - resto;
                        }
                        return dv.ToString();
                    }
                    
                case "BA":
                    // Bahia: algoritmo muda conforme primeiro dígito do núcleo
                    {
                        int primDigito = int.Parse(numero[0].ToString());
                        int[] pesos = { 8, 7, 6, 5, 4, 3, 2 };
                        int soma = 0;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * (i < pesos.Length ? pesos[i] : 2);
                        }
                        
                        int resto = soma % 11;
                        int dv;
                        
                        if (primDigito >= 6 && primDigito <= 9)
                        {
                            // Módulo 11
                            dv = (resto == 0 || resto == 1) ? 0 : 11 - resto;
                        }
                        else
                        {
                            // Módulo 10
                            resto = soma % 10;
                            dv = resto == 0 ? 0 : 10 - resto;
                        }
                        
                        return dv.ToString();
                    }
                    
                case "CE":
                    // Ceará: pesos 9,8,7,6,5,4,3,2
                    return CalcularDVPadrao(numero, new int[] { 9, 8, 7, 6, 5, 4, 3, 2 });
                    
                case "DF":
                    // DF: pesos 4,3,2,9,8,7,6,5,4,3,2 para primeiro DV
                    // Para o segundo: 5,4,3,2,9,8,7,6,5,4,3,2
                    if (numero.Length == 11) // Primeiro dígito
                        return CalcularDVPadrao(numero, new int[] { 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });
                    else // Segundo dígito
                        return CalcularDVPadrao(numero, new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });
                        
                case "ES":
                    // Espírito Santo: pesos 9,8,7,6,5,4,3,2
                    {
                        int soma = 0;
                        int peso = 9;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * peso;
                            peso--;
                        }
                        
                        int resto = soma % 11;
                        int dv = resto > 1 ? 11 - resto : 0;
                        return dv.ToString();
                    }
                    
                case "GO":
                    // Goiás: pesos 9,8,7,6,5,4,3,2
                    {
                        int soma = 0;
                        int[] pesos = { 9, 8, 7, 6, 5, 4, 3, 2 };
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * pesos[i];
                        }
                        
                        int resto = soma % 11;
                        int dv = 0;
                        
                        if (resto == 0)
                            dv = 0;
                        else if (resto == 1)
                        {
                            // Caso específico para a faixa 10.103.105 - 10.119.997
                            long num = long.Parse(numero);
                            dv = (num >= 10103105 && num <= 10119997) ? 1 : 0;
                        }
                        else
                            dv = 11 - resto;
                        
                        return dv.ToString();
                    }
                    
                case "MA":
                    // Maranhão: pesos 9,8,7,6,5,4,3,2
                    return CalcularDVPadrao(numero, new int[] { 9, 8, 7, 6, 5, 4, 3, 2 });
                    
                case "MT":
                    // Mato Grosso: pesos especiais
                    {
                        int soma = 0;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            if (i <= 1)
                                soma += int.Parse(numero[i].ToString()) * (3 - i);
                            else
                                soma += int.Parse(numero[i].ToString()) * (11 - i);
                        }
                        
                        int resto = soma % 11;
                        int dv = resto == 0 || resto == 1 ? 0 : 11 - resto;
                        return dv.ToString();
                    }
                    
                case "MS":
                    // Mato Grosso do Sul: pesos 9,8,7,6,5,4,3,2
                    {
                        int soma = 0;
                        int peso = 9;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * peso;
                            peso--;
                        }
                        
                        int resto = soma % 11;
                        int dv = 0;
                        
                        if (resto != 0 && (11 - resto) < 10)
                            dv = 11 - resto;
                        
                        return dv.ToString();
                    }
                    
                case "MG":
                    // Minas Gerais: cálculo específico conforme SINTEGRA
                    {
                        // Primeiro dígito (D1)
                        // Inserir 0 após o código do município (posição 3)
                        var numeroD1 = numero.Substring(0, 3) + "0" + numero.Substring(3);
                        var somaTotal = 0;
                        var produtos = new List<int>();
                        
                        // 1. Multiplicar da esquerda para direita por 1 e 2 alternadamente
                        for (int i = 0; i < numeroD1.Length; i++)
                        {
                            var digito = int.Parse(numeroD1[i].ToString());
                            produtos.Add(digito * (i % 2 == 0 ? 1 : 2));
                        }

                        // 2. Somar os algarismos dos produtos
                        foreach (var produto in produtos)
                        {
                            if (produto >= 10)
                            {
                                somaTotal += (produto / 10) + (produto % 10);
                            }
                            else
                            {
                                somaTotal += produto;
                            }
                        }
                        
                        // 3. Subtrair da primeira dezena superior
                        var dezena = ((somaTotal / 10) + 1) * 10;
                        var dv1 = dezena - somaTotal;
                        
                        // Segundo dígito (D2)
                        var numeroD2 = numero + dv1.ToString();
                        var soma2 = 0;
                        var peso = 2;
                        
                        // Multiplicar da direita para esquerda por 2,3,4,5,6,7,8,9,10,11
                        for (int i = numeroD2.Length - 1; i >= 0; i--)
                        {
                            soma2 += int.Parse(numeroD2[i].ToString()) * peso;
                            peso = peso == 11 ? 2 : peso + 1;
                        }
                        
                        // Dividir por 11 e subtrair o resto de 11
                        var resto = soma2 % 11;
                        var dv2 = resto <= 1 ? 0 : 11 - resto;
                        
                        return dv1.ToString() + dv2.ToString();
                    }
                    
                case "PA":
                    // Pará: pesos 9,8,7,6,5,4,3,2
                    {
                        int soma = 0;
                        int peso = 9;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * peso;
                            peso--;
                        }
                        
                        int resto = soma % 11;
                        int dv = resto != 0 && resto != 1 ? 11 - resto : 0;
                        return dv.ToString();
                    }
                    
                case "PB":
                    // Paraíba: pesos 9,8,7,6,5,4,3,2
                    {
                        int soma = 0;
                        int peso = 9;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * peso;
                            peso--;
                        }
                        
                        int resto = 11 - (soma % 11);
                        int dv = resto != 10 && resto != 11 ? resto : 0;
                        return dv.ToString();
                    }
                    
                case "PR":
                    // Paraná: pesos diferentes para primeiro e segundo DV
                    if (numero.Length == 8) // Primeiro dígito
                    {
                        int soma = 0;
                        int[] pesos = { 3, 2, 7, 6, 5, 4, 3, 2 };
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * pesos[i];
                        }
                        
                        int resto = soma % 11;
                        int dv = resto == 0 || resto == 1 ? 0 : 11 - resto;
                        return dv.ToString();
                    }
                    else // Segundo dígito
                    {
                        int soma = 0;
                        int[] pesos = { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                        
                        // O número passado inclui o primeiro DV, então temos 9 dígitos
                        for (int i = 0; i < numero.Length && i < pesos.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * pesos[i];
                        }
                        
                        int resto = soma % 11;
                        int dv = resto == 0 || resto == 1 ? 0 : 11 - resto;
                        return dv.ToString();
                    }
                    
                case "PE":
                    // Pernambuco: pesos diferentes para primeiro e segundo DV
                    if (numero.Length == 7) // Primeiro dígito
                    {
                        int soma = 0;
                        int[] pesos = { 8, 7, 6, 5, 4, 3, 2 };
                        
                        for (int i = 0; i < numero.Length && i < pesos.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * pesos[i];
                        }
                        
                        int resto = soma % 11;
                        int dv = resto == 0 || resto == 1 ? 0 : 11 - resto;
                        return dv.ToString();
                    }
                    else // Segundo dígito
                    {
                        int soma = 0;
                        int[] pesos = { 9, 8, 7, 6, 5, 4, 3, 2 };
                        
                        for (int i = 0; i < numero.Length && i < pesos.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * pesos[i];
                        }
                        
                        int resto = soma % 11;
                        int dv = resto == 0 || resto == 1 ? 0 : 11 - resto;
                        return dv.ToString();
                    }
                    
                case "PI":
                    // Piauí: pesos 9,8,7,6,5,4,3,2
                    {
                        int soma = 0;
                        int peso = 9;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * peso;
                            peso--;
                        }
                        
                        int resto = 11 - (soma % 11);
                        int dv = resto != 10 && resto != 11 ? resto : 0;
                        return dv.ToString();
                    }
                    
                case "RJ":
                    // Rio de Janeiro: pesos especiais
                    {
                        int soma = 0;
                        int peso = 7;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            if (i == 0)
                                soma += int.Parse(numero[i].ToString()) * 2;
                            else
                            {
                                soma += int.Parse(numero[i].ToString()) * peso;
                                peso--;
                            }
                        }
                        
                        int resto = soma % 11;
                        int dv = resto <= 1 ? 0 : 11 - resto;
                        return dv.ToString();
                    }
                    
                case "RN":
                    // Rio Grande do Norte: cálculo especial
                    {
                        int soma = 0;
                        int peso = 9;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * peso;
                            peso--;
                        }
                        
                        int resto = (soma * 10) % 11;
                        int dv = resto != 10 ? resto : 0;
                        return dv.ToString();
                    }
                    
                case "RS":
                    // Rio Grande do Sul: pesos 2,9,8,7,6,5,4,3,2
                    {
                        int soma = 0;
                        int[] pesos = { 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * pesos[i];
                        }
                        
                        int resto = soma % 11;
                        int dv = resto == 0 || resto == 1 ? 0 : 11 - resto;
                        return dv.ToString();
                    }
                    
                case "RO":
                    // Rondônia: pesos especiais
                    {
                        int soma = 0;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            if (i < 5)
                                soma += int.Parse(numero[i].ToString()) * (6 - i);
                            else
                                soma += int.Parse(numero[i].ToString()) * (14 - i);
                        }
                        
                        int resto = 11 - (soma % 11);
                        int dv;
                        
                        if (resto != 10 && resto != 11)
                            dv = resto;
                        else
                            dv = resto - 10;
                        
                        return dv.ToString();
                    }
                    
                case "RR":
                    // Roraima: pesos crescentes 1 a 9
                    {
                        int soma = 0;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * (i + 1);
                        }
                        
                        int dv = soma % 9;
                        return dv.ToString();
                    }
                    
                case "SC":
                    // Santa Catarina: pesos 9,8,7,6,5,4,3,2
                    return CalcularDVPadrao(numero, new int[] { 9, 8, 7, 6, 5, 4, 3, 2 });
                    
                case "SP":
                    // São Paulo: pesos específicos para cada posição
                    if (numero.Length == 8) // Primeiro dígito
                    {
                        int soma = 0;
                        int[] peso1 = { 1, 3, 4, 5, 6, 7, 8, 10 };
                        
                        for (int i = 0; i < numero.Length; i++)
                            soma += int.Parse(numero[i].ToString()) * peso1[i];
                        
                        int resto = soma % 11;
                        int dv = resto == 10 ? 0 : resto;
                        return dv.ToString();
                    }
                    else if (numero.Length == 11) // Segundo dígito
                    {
                        int soma = 0;
                        int[] peso2 = { 3, 2, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                        
                        for (int i = 0; i < numero.Length && i < peso2.Length; i++)
                            soma += int.Parse(numero[i].ToString()) * peso2[i];
                        
                        int resto = soma % 11;
                        int dv = resto == 10 ? 0 : resto;
                        return dv.ToString();
                    }
                    
                    // Fallback
                    return CalcularDVPadrao(numero, new int[] { 1, 3, 4, 5, 6, 7, 8, 10 });
                    
                case "SE":
                    // Sergipe: pesos 9,8,7,6,5,4,3,2
                    {
                        int soma = 0;
                        int peso = 9;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            soma += int.Parse(numero[i].ToString()) * peso;
                            peso--;
                        }
                        
                        int resto = 11 - (soma % 11);
                        int dv = resto != 10 && resto != 11 ? resto : 0;
                        return dv.ToString();
                    }
                    
                case "TO":
                    // Tocantins: pesos 9,8,7,6,5,4,3,2 (pulando posições 2 e 3)
                    {
                        int soma = 0;
                        int peso = 9;
                        
                        for (int i = 0; i < numero.Length; i++)
                        {
                            if (i != 2 && i != 3)
                            {
                                soma += int.Parse(numero[i].ToString()) * peso;
                                peso--;
                            }
                        }
                        
                        int resto = soma % 11;
                        int dv = resto >= 2 ? 11 - resto : 0;
                        return dv.ToString();
                    }
                    
                default:
                    // Implementação genérica para caso não tenha regra específica
                    return CalcularDVGenerico(numero);
            }
        }

        /// <summary>
        /// Calcula dígito verificador usando algoritmo padrão com pesos específicos
        /// </summary>
        private string CalcularDVPadrao(string numero, int[] pesos)
        {
            int soma = 0;
            
            for (int i = 0; i < numero.Length && i < pesos.Length; i++)
            {
                soma += int.Parse(numero[i].ToString()) * pesos[i];
            }
            
            int resto = soma % 11;
            int dv = resto <= 1 ? 0 : 11 - resto;
            
            return dv.ToString();
        }

        /// <summary>
        /// Implementação genérica para o cálculo do dígito verificador (fallback)
        /// </summary>
        private string CalcularDVGenerico(string numero)
        {
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
            // Implementação de formatação para todos os estados brasileiros
            switch (estado.ToUpper())
            {
                case "AC":
                    // Acre: 00.000.000/000-00
                    if (ie.Length == 13)
                        return string.Format("{0}.{1}.{2}/{3}-{4}",
                            ie.Substring(0, 2),
                            ie.Substring(2, 3),
                            ie.Substring(5, 3),
                            ie.Substring(8, 3),
                            ie.Substring(11, 2));
                    break;

                case "AL":
                    // Alagoas: 0000000000
                    // Não tem formatação específica, mas alguns sistemas usam: 00-0.000.000
                    if (ie.Length == 9)
                        return string.Format("{0}-{1}.{2}.{3}",
                            ie.Substring(0, 2),
                            ie.Substring(2, 1),
                            ie.Substring(3, 3),
                            ie.Substring(6, 3));
                    break;

                case "AP":
                    // Amapá: 000000000
                    // Alguns sistemas usam: 00.0.000.000-0
                    if (ie.Length == 9)
                        return string.Format("{0}.{1}.{2}.{3}-{4}",
                            ie.Substring(0, 2),
                            ie.Substring(2, 1),
                            ie.Substring(3, 3),
                            ie.Substring(6, 3),
                            ie.Substring(8, 1));
                    break;

                case "AM":
                    // Amazonas: 00.000.000-0
                    if (ie.Length == 9)
                        return string.Format("{0}.{1}.{2}-{3}",
                            ie.Substring(0, 2),
                            ie.Substring(2, 3),
                            ie.Substring(5, 3),
                            ie.Substring(8, 1));
                    break;

                case "BA":
                    // Bahia: 000.000.00-0 ou 0000000-00
                    if (ie.Length == 9) // Formato de 9 dígitos
                        return string.Format("{0}.{1}.{2}-{3}",
                            ie.Substring(0, 3),
                            ie.Substring(3, 3),
                            ie.Substring(6, 2),
                            ie.Substring(8, 1));
                    else if (ie.Length == 8) // Formato de 8 dígitos
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 6),
                            ie.Substring(6, 2));
                    break;

                case "CE":
                    // Ceará: 00000000-0
                    if (ie.Length == 9)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 8),
                            ie.Substring(8, 1));
                    break;

                case "DF":
                    // Distrito Federal: 00000000000-00
                    if (ie.Length == 13)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 11),
                            ie.Substring(11, 2));
                    break;

                case "ES":
                    // Espírito Santo: 00000000-0
                    if (ie.Length == 9)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 8),
                            ie.Substring(8, 1));
                    break;

                case "GO":
                    // Goiás: 00.000.000-0
                    if (ie.Length == 9)
                        return string.Format("{0}.{1}.{2}-{3}",
                            ie.Substring(0, 2),
                            ie.Substring(2, 3),
                            ie.Substring(5, 3),
                            ie.Substring(8, 1));
                    break;

                case "MA":
                    // Maranhão: 00000000-0
                    if (ie.Length == 9)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 8),
                            ie.Substring(8, 1));
                    break;

                case "MT":
                    // Mato Grosso: 0000000000-0
                    if (ie.Length == 11)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 10),
                            ie.Substring(10, 1));
                    break;

                case "MS":
                    // Mato Grosso do Sul: 00000000-0
                    if (ie.Length == 9)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 8),
                            ie.Substring(8, 1));
                    break;

                case "MG":
                    // Minas Gerais: 000.000.000/0000
                    if (ie.Length == 13)
                        return string.Format("{0}.{1}.{2}/{3}",
                            ie.Substring(0, 3),
                            ie.Substring(3, 3),
                            ie.Substring(6, 3),
                            ie.Substring(9, 4));
                    break;

                case "PA":
                    // Pará: 00-000000-0
                    if (ie.Length == 9)
                        return string.Format("{0}-{1}-{2}",
                            ie.Substring(0, 2),
                            ie.Substring(2, 6),
                            ie.Substring(8, 1));
                    break;

                case "PB":
                    // Paraíba: 00000000-0
                    if (ie.Length == 9)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 8),
                            ie.Substring(8, 1));
                    break;

                case "PR":
                    // Paraná: 000.00000-00
                    if (ie.Length == 10)
                        return string.Format("{0}.{1}-{2}",
                            ie.Substring(0, 3),
                            ie.Substring(3, 5),
                            ie.Substring(8, 2));
                    break;

                case "PE":
                    // Pernambuco: 0000000-00
                    if (ie.Length == 9)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 7),
                            ie.Substring(7, 2));
                    break;

                case "PI":
                    // Piauí: 00000000-0
                    if (ie.Length == 9)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 8),
                            ie.Substring(8, 1));
                    break;

                case "RJ":
                    // Rio de Janeiro: 00.000.00-0
                    if (ie.Length == 8)
                        return string.Format("{0}.{1}.{2}-{3}",
                            ie.Substring(0, 2),
                            ie.Substring(2, 3),
                            ie.Substring(5, 2),
                            ie.Substring(7, 1));
                    break;

                case "RN":
                    // Rio Grande do Norte: 00.000.000-0
                    if (ie.Length == 9)
                        return string.Format("{0}.{1}.{2}-{3}",
                            ie.Substring(0, 2),
                            ie.Substring(2, 3),
                            ie.Substring(5, 3),
                            ie.Substring(8, 1));
                    // Para formato de 10 dígitos: 00.0.000.000-0
                    else if (ie.Length == 10)
                        return string.Format("{0}.{1}.{2}.{3}-{4}",
                            ie.Substring(0, 2),
                            ie.Substring(2, 1),
                            ie.Substring(3, 3),
                            ie.Substring(6, 3),
                            ie.Substring(9, 1));
                    break;

                case "RS":
                    // Rio Grande do Sul: 000/0000000
                    if (ie.Length == 10)
                        return string.Format("{0}/{1}",
                            ie.Substring(0, 3),
                            ie.Substring(3, 7));
                    break;

                case "RO":
                    // Rondônia: 0000000000000-0
                    if (ie.Length == 14)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 13),
                            ie.Substring(13, 1));
                    break;

                case "RR":
                    // Roraima: 00000000-0
                    if (ie.Length == 9)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 8),
                            ie.Substring(8, 1));
                    break;

                case "SC":
                    // Santa Catarina: 000.000.000
                    if (ie.Length == 9)
                        return string.Format("{0}.{1}.{2}",
                            ie.Substring(0, 3),
                            ie.Substring(3, 3),
                            ie.Substring(6, 3));
                    break;

                case "SP":
                    // São Paulo: XXX.XXX.XXX.XXX
                    if (ie.Length == 12)
                        return string.Format("{0}.{1}.{2}.{3}",
                            ie.Substring(0, 3),
                            ie.Substring(3, 3),
                            ie.Substring(6, 3),
                            ie.Substring(9, 3));
                    break;

                case "SE":
                    // Sergipe: 00000000-0
                    if (ie.Length == 9)
                        return string.Format("{0}-{1}",
                            ie.Substring(0, 8),
                            ie.Substring(8, 1));
                    break;

                case "TO":
                    // Tocantins: 00000000000
                    if (ie.Length == 11)
                        // Alguns sistemas usam formatação com ponto: 00.00.000000.0
                        return string.Format("{0}.{1}.{2}.{3}",
                            ie.Substring(0, 2),
                            ie.Substring(2, 2),
                            ie.Substring(4, 6),
                            ie.Substring(10, 1));
                    break;
            }

            // Retorna o número original se não houver formatação específica
            // ou se o tamanho não corresponder ao esperado
            return ie;
        }
    }
}