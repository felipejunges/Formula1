﻿namespace Formula1.Data.Entities
{
    public class Resultado : Entity
    {
        public Resultado()
        {
        }

        public int CorridaId { get; set; }

        public Corrida Corrida { get; set; }

        public int PilotoId { get; set; }

        public Piloto Piloto { get; set; }

        public int EquipeId { get; set; }

        public Equipe Equipe { get; set; }

        public int PosicaoLargada { get; set; }

        public int PosicaoChegada { get; set; }

        public double PontosClassificacao { get; set; }

        public double PontosCorrida { get; set; }

        public bool VoltaMaisRapida { get; set; }

        public bool DNF { get; set; }

        public bool DSQ { get; set; }

        public double PontosTotais => PontosClassificacao + PontosCorrida;
    }
}