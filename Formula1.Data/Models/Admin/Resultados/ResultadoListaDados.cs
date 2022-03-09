using System.Collections.Generic;
using Formula1.Data.Entities;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoListaDados
    {
        public ResultadoDados Dados { get; set; }
        public List<ResultadoLista> Resultados { get; set; }
        public string NomeGP { get; set; }
        public bool CorridaClassificacao => Dados.CorridaClassificacao;
        
        public ResultadoListaDados(ResultadoDados dados, List<ResultadoLista> resultados, Corrida corrida)
        {
            Dados = dados;
            Resultados = resultados;
            NomeGP = $"{corrida.NomeGrandePremio} - {corrida.Temporada}";
        }
    }
}