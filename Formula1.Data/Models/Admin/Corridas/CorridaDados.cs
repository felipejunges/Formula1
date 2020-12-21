using Formula1.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Corridas
{
    public class CorridaDados
    {
        public int Id { get; set; }

        public int Temporada { get; set; }

        [Required]
        [Display(Name = "Grande prêmio")]
        public string NomeGrandePremio { get; set; }

        [Required]
        public string Circuito { get; set; }

        [Required]
        [Display(Name = "Data/hora Brasil")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Text)]
        public DateTime? DataHoraBrasil { get; set; }

        public CorridaDados()
        {

        }

        public CorridaDados(Corrida corrida)
        {
            Id = corrida.Id;
            Temporada = corrida.Temporada;
            NomeGrandePremio = corrida.NomeGrandePremio;
            Circuito = corrida.Circuito;
            DataHoraBrasil = corrida.DataHoraBrasil;
        }
    }
}