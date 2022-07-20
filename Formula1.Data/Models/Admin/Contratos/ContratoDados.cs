using Formula1.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Formula1.Data.Models.Admin.Contratos
{
    public class ContratoDados
    {
        public int Id { get; set; }

        public int Temporada { get; set; }

        [Display(Name = "Piloto")]
        public int PilotoId { get; set; }

        [Display(Name = "Equipe")]
        public int EquipeId { get; set; }

        public IEnumerable<Piloto> PilotosLista { get; set; }
        public IEnumerable<Equipe> EquipesLista { get; set; }

        public ContratoDados()
        {
            PilotosLista = Enumerable.Empty<Piloto>();
            EquipesLista = Enumerable.Empty<Equipe>();
        }

        public ContratoDados(int temporada, List<Piloto> pilotosLista, List<Equipe> equipesLista)
        {
            Id = 0;
            Temporada = temporada;
            PilotosLista = pilotosLista;
            EquipesLista = equipesLista;
        }

        public ContratoDados(Contrato contato, List<Piloto> pilotosLista, List<Equipe> equipesLista)
        {
            Id = contato.Id;
            Temporada = contato.Temporada;
            PilotoId = contato.PilotoId;
            EquipeId = contato.EquipeId;
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