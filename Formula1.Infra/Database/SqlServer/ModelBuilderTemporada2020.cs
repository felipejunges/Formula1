using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Formula1.Infra.Database.SqlServer
{
    public static class ModelBuilderTemporada2020
    {
        public static void Seed2020(this ModelBuilder modelBuilder)
        {
            var CORRIDA1019 = new Corrida(1019, 2020, "GP da Austrália", "Circuito de Albert Park", new DateTime(2020, 3, 15, 2, 10, 0));
        }
    }
}