﻿using Formula1.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Corridas
{
    public class CorridaDados
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Corrida")]
        public int? NumeroCorrida { get; set; }

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

        [Display(Name = "Com corrida classificação")]
        public bool CorridaClassificacao { get; set; }

        public bool MetadePontos { get; set; }

        public CorridaDados()
        {
        }

        public CorridaDados(Corrida corrida)
        {
            Id = corrida.Id;
            NumeroCorrida = corrida.NumeroCorrida;
            Temporada = corrida.Temporada;
            NomeGrandePremio = corrida.NomeGrandePremio;
            Circuito = corrida.Circuito;
            DataHoraBrasil = corrida.DataHoraBrasil;
            CorridaClassificacao = corrida.CorridaClassificacao;
            MetadePontos = corrida.MetadePontos;
        }
    }
}