using System;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Corridas
{
    public class CorridaLista
    {
        public int Id { get; set; }

        [Display(Name = "Grande prêmio")]
        public string NomeGrandePremio { get; set; }

        public string Circuito { get; set; }

        [Display(Name = "Data/hora Brasil")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm}")]
        public DateTime DataHoraBrasil { get; set; }
    }
}