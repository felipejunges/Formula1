﻿using System.Collections.Generic;

namespace Formula1.Data.Entities
{
    public class Piloto : Entity
    {
        public string Nome { get; set; }

        public string NomeGuerra { get; set; }

        public string Sigla { get; set; }

        public int NumeroCarro { get; set; }

        public string PaisOrigem { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<Punicao> Punicoes { get; set; }
        public virtual ICollection<Resultado> Resultados { get; set; }
        public virtual ICollection<PilotoTemporada> Temporadas { get; set; }

        public Piloto()
        {
            Nome = string.Empty;
            NomeGuerra = string.Empty;
            Sigla = string.Empty;
            PaisOrigem = string.Empty;

            Contratos = new HashSet<Contrato>();
            Punicoes = new HashSet<Punicao>();
            Resultados = new HashSet<Resultado>();
            Temporadas = new HashSet<PilotoTemporada>();
        }
    }
}