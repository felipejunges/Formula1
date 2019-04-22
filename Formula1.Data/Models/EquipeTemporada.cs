﻿using System.Collections.Generic;
using System.Linq;

namespace Formula1.Data.Models
{
    public class EquipeTemporada
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int PontosTemporada
        {
            get
            {
                return Resultados != null ? Resultados.Sum(s => s.Pontos) : 0;
            }
        }

        public List<ResultadoTemporada> Resultados { get; set; }
    }
}