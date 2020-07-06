using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class ResultadoCorridaEdicao
    {
        public ResultadoInclusao Dados { get; set; }
        public List<ResultadoLista> Resultados { get; set; }

        public ResultadoCorridaEdicao(ResultadoInclusao dados, List<ResultadoLista> resultados)
        {
            Dados = dados;
            Resultados = resultados;
        }
    }
}