﻿using System.Collections.Generic;

namespace Formula1.Data.Entities
{
    public class Piloto : Entity
    {
        public Piloto()
        {
            Contratos = new HashSet<Contrato>();
            Resultados = new HashSet<Resultado>();
        }

        public Piloto(int id, string nome, string nomeGuerra, string sigla, int numeroCarro, string paisOrigem) : this()
        {
            Id = id;
            Nome = nome;
            NomeGuerra = nomeGuerra;
            Sigla = sigla;
            NumeroCarro = numeroCarro;
            PaisOrigem = paisOrigem;
        }

        public string Nome { get; set; }

        public string NomeGuerra { get; set; }

        public string Sigla { get; set; }

        public int NumeroCarro { get; set; }

        public string PaisOrigem { get; set; }

        public virtual ICollection<Contrato> Contratos { get; set; }

        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}