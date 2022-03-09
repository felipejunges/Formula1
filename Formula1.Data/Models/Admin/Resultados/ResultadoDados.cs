using Formula1.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoDados
    {
        public int Id { get; set; }

        public int CorridaId { get; set; }

        [Required]
        [Display(Name = "Piloto")]
        public int? PilotoId { get; set; }

        [Required]
        [Display(Name = "Equipe")]
        public int? EquipeId { get; set; }

        [Display(Name = "Pos. largada")]
        public int PosicaoLargada { get; set; }

        [Display(Name = "Pos. chegada")]
        public int PosicaoChegada { get; set; }

        [Required]
        [Display(Name = "Pontos classificação")]
        public double? PontosClassificacao { get; set; }

        [Required]
        [Display(Name = "Pontos corrida")]
        public double? PontosCorrida { get; set; }

        [Display(Name = "Volta mais rápida")]
        public bool VoltaMaisRapida { get; set; }

        public bool DNF { get; set; }

        public bool DSQ { get; set; }

        public bool CorridaClassificacao { get; set; }

        public IEnumerable<Piloto> PilotosLista { get; set; }
        public IEnumerable<Equipe> EquipesLista { get; set; }

        public ResultadoDados()
        {
            PilotosLista = Enumerable.Empty<Piloto>();
            EquipesLista = Enumerable.Empty<Equipe>();
        }

        public ResultadoDados(int corridaId, bool corridaClassificacao, List<Piloto> pilotosLista, List<Equipe> equipesLista)
        {
            Id = 0;
            CorridaId = corridaId;
            PilotoId = null;
            EquipeId = null;
            PosicaoLargada = 0;
            PosicaoChegada = 0;
            PontosClassificacao = 0;
            PontosCorrida = 0;
            VoltaMaisRapida = false;
            DNF = false;
            DSQ = false;
            CorridaClassificacao = corridaClassificacao;;
            PilotosLista = pilotosLista;
            EquipesLista = equipesLista;
        }

        public ResultadoDados(Resultado resultado, List<Piloto> pilotosLista, List<Equipe> equipesLista)
        {
            Id = resultado.Id;
            CorridaId = resultado.CorridaId;
            PilotoId = resultado.PilotoId;
            EquipeId = resultado.EquipeId;
            PosicaoLargada = resultado.PosicaoLargada;
            PosicaoChegada = resultado.PosicaoChegada;
            PontosClassificacao = resultado.PontosClassificacao;
            PontosCorrida = resultado.PontosCorrida;
            VoltaMaisRapida = resultado.VoltaMaisRapida;
            DNF = resultado.DNF;
            DSQ = resultado.DSQ;
            CorridaClassificacao = resultado.Corrida.CorridaClassificacao;
            PilotosLista = pilotosLista;
            EquipesLista = equipesLista;
        }

        public void AtualizarListas(List<Piloto> pilotos, List<Equipe> equipes)
        {
            PilotosLista = pilotos;
            EquipesLista = equipes;
        }
    }
}