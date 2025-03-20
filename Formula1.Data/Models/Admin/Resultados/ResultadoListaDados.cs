using System.Collections.Generic;
using Formula1.Data.Entities;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoListaDados
    {
        public int CorridaId { get; set; }
        public bool CorridaSprint { get; set; }
        public List<ResultadoItemDados> Resultados { get; set; }
        public List<Piloto> Pilotos { get; set; }
        public List<Equipe> Equipes { get; set; }
        public List<ResultadoEquipePilotos> EquipesPilotos { get; set; }
        public string NomeGP { get; set; }

        public ResultadoListaDados()
        {
            Resultados = new List<ResultadoItemDados>();
            Pilotos = new List<Piloto>();
            Equipes = new List<Equipe>();
            EquipesPilotos = new List<ResultadoEquipePilotos>();
            NomeGP = string.Empty;
        }

        public ResultadoListaDados(int corridaId, bool corridaSprint, List<ResultadoItemDados> resultados, List<Piloto> pilotos, List<Equipe> equipes, List<ResultadoEquipePilotos> equipesPilotos, Corrida corrida)
        {
            CorridaId = corridaId;
            CorridaSprint = corridaSprint;
            Resultados = resultados;
            Pilotos = pilotos;
            Equipes = equipes;
            EquipesPilotos = equipesPilotos;
            NomeGP = $"{corrida.NomeGrandePremio} - {corrida.Temporada}";
            
            if (CorridaSprint)
                NomeGP += " (corrida sprint)";
        }

        public void AtualizarListas(List<Piloto> pilotos, List<Equipe> equipes, List<ResultadoEquipePilotos> equipesPilotos)
        {
            Pilotos = pilotos;
            Equipes = equipes;
            EquipesPilotos = equipesPilotos;
        }
    }
}