﻿using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class EquipeTemporadaResultado
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CorRgb { get; set; }

        public double Pontos { get; set; }

        public int Posicao { get; set; }

        public List<ResultadoTemporadaEquipe> Resultados { get; set; }

        public int PosicaoMaxima { get; set; }

        public EquipeTemporadaResultado()
        {
            Nome = string.Empty;
            CorRgb = string.Empty;

            Resultados = new List<ResultadoTemporadaEquipe>();
        }
    }
}