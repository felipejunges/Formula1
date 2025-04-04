﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Corridas
{
    public class CorridaLista
    {
        public int Id { get; set; }

        [Display(Name = "Corrida")]
        public int NumeroCorrida { get; set; }

        [Display(Name = "Grande prêmio")]
        public string NomeGrandePremio { get; set; }

        public string Circuito { get; set; }

        [Display(Name = "Data/hora Brasil")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm}")]
        public DateTime DataHoraBrasil { get; set; }

        public bool Proxima { get; set; }
        
        public bool CorridaSprint { get; set; }

        // TODO: construtor pode gerar porblema no Ef, nao era melhor setar as props como "init" e setar como string.empty, igual ContratoLista ?
        public CorridaLista(int id, int numeroCorrida, string nomeGrandePremio, string circuito, DateTime dataHoraBrasil, bool corridaSprint)
        {
            Id = id;
            NumeroCorrida = numeroCorrida;
            NomeGrandePremio = nomeGrandePremio;
            Circuito = circuito;
            DataHoraBrasil = dataHoraBrasil;
            CorridaSprint = corridaSprint;
            Proxima = false;
        }
    }
}