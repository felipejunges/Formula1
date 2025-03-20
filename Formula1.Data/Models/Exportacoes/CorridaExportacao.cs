using Formula1.Data.Entities;
using System;

namespace Formula1.Data.Models.Exportacoes
{
    public class CorridaExportacao
    {
        public int Id { get; private set; }

        public int Temporada { get; private set; }

        public int NumeroCorrida { get; private set; }

        public string NomeGrandePremio { get; private set; }

        public string Circuito { get; private set; }

        public DateTime DataHoraBrasil { get; private set; }

        public bool CorridaSprint { get; private set; }

        public bool MetadePontos { get; private set; }

        public CorridaExportacao()
        {
            NomeGrandePremio = string.Empty;
            Circuito = string.Empty;
        }

        public CorridaExportacao(Corrida corrida)
        {
            Id = corrida.Id;
            Temporada = corrida.Temporada;
            NumeroCorrida = corrida.NumeroCorrida;
            NomeGrandePremio = corrida.NomeGrandePremio;
            Circuito = corrida.Circuito;
            DataHoraBrasil = corrida.DataHoraBrasil;
            MetadePontos = corrida.MetadePontos;
        }

        public Corrida MapCorrida()
        {
            return new Corrida(
                Id,
                Temporada,
                NumeroCorrida,
                NomeGrandePremio,
                Circuito,
                DataHoraBrasil,
                CorridaSprint,
                MetadePontos);
        }
    }
}