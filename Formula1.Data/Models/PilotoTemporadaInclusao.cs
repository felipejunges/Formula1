﻿namespace Formula1.Data.Models
{
    public class PilotoTemporadaInclusao
    {
        public int PilotoId { get; set; }

        public int Temporada { get; set; }

        public double Pontos { get; set; }

        public int Posicao { get; set; }

        public PilotoTemporadaInclusao(int pilotoId, int temporada, double pontos, int posicao)
        {
            PilotoId = pilotoId;
            Temporada = temporada;
            Pontos = pontos;
            Posicao = posicao;
        }
    }
}