using System.Collections.Generic;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoListaDados
    {
        public ResultadoDados Dados { get; set; }
        public List<ResultadoLista> Resultados { get; set; }

        public ResultadoListaDados(ResultadoDados dados, List<ResultadoLista> resultados)
        {
            Dados = dados;
            Resultados = resultados;
        }
    }
}