﻿namespace Formula1.Data.Entities
{
    public class EquipeTemporada : Entity
    {
        public EquipeTemporada()
        {
        }

        public Equipe Equipe { get; set; }

        public int Temporada { get; set; }

        public double Pontos { get; set; }

        public int Posicao { get; set; }
    }
}