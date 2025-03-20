using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Data.Entities
{
    public class Corrida : Entity
    {
        public int Temporada { get; private set; }

        public int NumeroCorrida { get; private set; }

        public string NomeGrandePremio { get; private set; }

        public string Circuito { get; private set; }

        public DateTime DataHoraBrasil { get; private set; }

        public bool CorridaSprint { get; private set; }

        public bool MetadePontos { get; private set; }

        public virtual ICollection<Punicao> Punicoes { get; private set; }

        public virtual ICollection<Resultado> Resultados { get; private set; }

        public bool TemResultadoDeCorrida => Resultados.Any(c => c.PosicaoChegada > 0);

        public Corrida() : this(
            0,
            0,
            0,
            string.Empty,
            string.Empty,
            DateTime.Now,
            false, 
            false)
        {
        }

        public Corrida(
            int id,
            int temporada,
            int numeroCorrida,
            string nomeGrandePremio,
            string circuito,
            DateTime dataHoraBrasil,
            bool corridaSprint,
            bool metadePontos)
        {
            Id = id;
            Temporada = temporada;
            NumeroCorrida = numeroCorrida;
            NomeGrandePremio = nomeGrandePremio;
            Circuito = circuito;
            DataHoraBrasil = dataHoraBrasil;
            CorridaSprint = corridaSprint;
            MetadePontos = metadePontos;

            Punicoes = new HashSet<Punicao>();
            Resultados = new HashSet<Resultado>();
        }

        public void Atualizar(
            int temporada,
            int numeroCorrida,
            string nomeGrandePremio,
            string circuito,
            DateTime dataHoraBrasil,
            bool corridaSprint,
            bool metadePontos)
        {
            Temporada = temporada;
            NumeroCorrida = numeroCorrida;
            NomeGrandePremio = nomeGrandePremio;
            Circuito = circuito;
            DataHoraBrasil = dataHoraBrasil;
            CorridaSprint = corridaSprint;
            MetadePontos = metadePontos;
        }
    }
}