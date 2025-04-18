using System.Collections.Generic;

namespace Identificacoes.Model
{
    /// <summary>
    /// Classe que representa uma Unidade Federativa do Brasil
    /// </summary>
    public class UF
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }

        public UF(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }

        /// <summary>
        /// Retorna uma lista com todas as UFs do Brasil
        /// </summary>
        /// <returns>Lista de UFs</returns>
        public static List<UF> ListarTodas()
        {
            var lista = new List<UF>
            {
                new UF("AC", "Acre"),
                new UF("AL", "Alagoas"),
                new UF("AP", "Amapá"),
                new UF("AM", "Amazonas"),
                new UF("BA", "Bahia"),
                new UF("CE", "Ceará"),
                new UF("DF", "Distrito Federal"),
                new UF("ES", "Espírito Santo"),
                new UF("GO", "Goiás"),
                new UF("MA", "Maranhão"),
                new UF("MT", "Mato Grosso"),
                new UF("MS", "Mato Grosso do Sul"),
                new UF("MG", "Minas Gerais"),
                new UF("PA", "Pará"),
                new UF("PB", "Paraíba"),
                new UF("PR", "Paraná"),
                new UF("PE", "Pernambuco"),
                new UF("PI", "Piauí"),
                new UF("RJ", "Rio de Janeiro"),
                new UF("RN", "Rio Grande do Norte"),
                new UF("RS", "Rio Grande do Sul"),
                new UF("RO", "Rondônia"),
                new UF("RR", "Roraima"),
                new UF("SC", "Santa Catarina"),
                new UF("SP", "São Paulo"),
                new UF("SE", "Sergipe"),
                new UF("TO", "Tocantins")
            };

            return lista;
        }
    }
}