using Formula1.Data.Entities;
using System;
using System.Collections.Generic;

namespace Formula1.Infra.Database.Mock
{
    public class CorridasMock
    {
        public static List<Corrida> Corridas = new List<Corrida>
        {
            new Corrida(998, 2019, "GP da Austrália", "Austrália", new DateTime(2019, 3, 17, 2, 10, 0)),
            new Corrida(999, 2019, "GP do Bahrein", "Bahrein", new DateTime(2019, 3, 31, 12, 10, 0)),
            new Corrida(1000, 2019, "GP da China", "China", new DateTime(2019, 4, 14, 03, 10, 0))
        };
    }
}