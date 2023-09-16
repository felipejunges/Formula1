using System.Collections.Generic;
using Formula1.Data.Entities;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoListaDados
    {
        public ResultadoDados Dados { get; private set; }
        public List<ResultadoLista> Resultados { get; private set; }
        public List<ResultadoEquipePilotos> EquipesPilotos { get; private set; }
        public string NomeGP { get; private set; }
        public bool CorridaClassificacao => Dados.CorridaClassificacao;

        public ResultadoListaDados(ResultadoDados dados, List<ResultadoLista> resultados, List<ResultadoEquipePilotos> equipesPilotos, Corrida corrida)
        {
            Dados = dados;
            Resultados = resultados;
            EquipesPilotos = equipesPilotos;
            NomeGP = $"{corrida.NomeGrandePremio} - {corrida.Temporada}";
        }
    }
}