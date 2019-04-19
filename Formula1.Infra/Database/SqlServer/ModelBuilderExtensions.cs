using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Formula1.Infra.Database.SqlServer
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // pilotos
            Piloto LEWIS_HAMILTON = new Piloto("Lewis Hamilton", "Hamilton", "HAM", 44, "Inglaterra");
            Piloto VALTTERI_BOTTAS = new Piloto("Valtteri Bottas", "Bottas", "BOT", 77, "Finlândia");
            Piloto SEBASTIAN_VETTEL = new Piloto("Sebastian Vettel", "Vettel", "VET", 5, "Alemanha");
            Piloto CHARLES_LECLERC = new Piloto("Charles Leclerc", "Leclerc", "LEC", 16, "Mônaco");
            Piloto MAX_VERSTAPPEN = new Piloto("Max Verstappen", "Verstappen", "VER", 33, "Holanda (talvez)");
            Piloto PIERRE_GASLY = new Piloto("Pierre Gasly", "Gasly", "GAS", 10, "França");
            Piloto DANIEL_RICCARDO = new Piloto("Daniel Riccardo", "Riccardo", "RIC", 3, "Austrália");
            Piloto NICO_HULKENBERG = new Piloto("Nico Hülkenberg", "Hülkenberg", "HUL", 27, "Alemanha");
            Piloto KEVIN_MAGNUSSEN = new Piloto("Kevin Magnussen", "Magnussen", "MAG", 20, "Dinamarca");
            Piloto ROMAIN_GROSJEAN = new Piloto("Romain Grosjean", "Grosjean", "GRO", 8, "França");
            Piloto DANIIL_KVYAT = new Piloto("Daniil Kvyat", "Kvyat", "KVY", 26, "Rússia");
            Piloto ALEXANDER_ALBON = new Piloto("Alexander Albon", "Albon", "ALB", 23, "?");
            Piloto LANDO_NORRIS = new Piloto("Lando Norris", "Norris", "NOR", 4, "Inglaterra");
            Piloto CARLOS_SAINZ_JR = new Piloto("Carlos Sainz Jr.", "Sainz", "SAI", 55, "Espanha");
            Piloto KIMI_RAIKKONEN = new Piloto("Kimi Räikkönen", "Räikkönen", "RAI", 7, "Finlândia");
            Piloto ANTONIO_GIOVANAZZI = new Piloto("Antonio Giovinazzi", "Giovinazzi", "GIO", 99, "Itália");
            Piloto SERGIO_PEREZ = new Piloto("Sergio Perez", "Perez", "PER", 11, "México");
            Piloto LANCE_STROLL = new Piloto("Lance Stroll", "Stroll", "STR", 18, "Canadá");
            Piloto ROBERT_KUBICA = new Piloto("Robert Kubica", "Kubica", "KUB", 88, "Polônia");
            Piloto GEORGE_RUSSEL = new Piloto("George Russell", "Russell", "RUS", 63, "Inglaterra");

            // equipes
            Equipe MERCEDES = new Equipe("Mercedes");
            Equipe FERRARI = new Equipe("Ferrari");
            Equipe REDBULL = new Equipe("RedBull Racing");
            Equipe TORO_ROSSO = new Equipe("Scuderia Toro Rosso");
            Equipe RENAULT = new Equipe("Renault");
            Equipe WILLIAMS = new Equipe("Williams");
            Equipe MCLAREN = new Equipe("McLaren");
            Equipe RACING_POINT = new Equipe("Racing Point");
            Equipe HAAS = new Equipe("Haas");
            Equipe ALFA_ROMEO = new Equipe("Alfa Romeo");

            // corridas
            Corrida CORRIDA998 = new Corrida(998, 2019, "GP da Austrália", "Circuito de Albert Park", new DateTime(2019, 3, 17, 2, 10, 0));
            Corrida CORRIDA999 = new Corrida(999, 2019, "GP do Bahrein", "Circuito Internacional do Bahrein", new DateTime(2019, 3, 31, 12, 10, 0));
            Corrida CORRIDA1000 = new Corrida(1000, 2019, "GP da China", "Circuito Internacional de Xangai", new DateTime(2019, 4, 14, 03, 10, 0));
            Corrida CORRIDA1001 = new Corrida(1001, 2019, "GP do Azerbaijão", "Curcuito Urbano de Baku", new DateTime(2019, 4, 28, 9, 10, 0));
            Corrida CORRIDA1002 = new Corrida(1002, 2019, "GP da Espanha", "Circuito da Catalunha", new DateTime(2019, 5, 12, 10, 10, 0));
            Corrida CORRIDA1003 = new Corrida(1003, 2019, "GP de Mônaco", "Circuito de Mônaco", new DateTime(2019, 5, 26, 10, 10, 0));
            Corrida CORRIDA1004 = new Corrida(1004, 2019, "GP do Canadá", "Circuito Gilles Villeneuve", new DateTime(2019, 6, 9, 15, 10, 0));
            Corrida CORRIDA1005 = new Corrida(1005, 2019, "GP da França", "Circuito Paul Ricard", new DateTime(2019, 6, 23, 10, 10, 0));
            Corrida CORRIDA1006 = new Corrida(1006, 2019, "GP da Áustria", "Red Bull Ring", new DateTime(2019, 6, 30, 10, 10, 0));
            Corrida CORRIDA1007 = new Corrida(1007, 2019, "GP da Grã-Bretanha", "Silverstone", new DateTime(2019, 7, 14, 11, 10, 0));
            Corrida CORRIDA1008 = new Corrida(1008, 2019, "GP da Alemanha", "Hockenheimring", new DateTime(2019, 7, 28, 10, 10, 0));
            Corrida CORRIDA1009 = new Corrida(1009, 2019, "GP da Hungria", "Hungaroring", new DateTime(2019, 8, 4, 10, 10, 0));
            Corrida CORRIDA1010 = new Corrida(1010, 2019, "GP da Bélgica", "Spa-Francorchamps", new DateTime(2019, 9, 1, 10, 10, 0));
            Corrida CORRIDA1011 = new Corrida(1011, 2019, "GP da Itália", "Circuito de Monza", new DateTime(2019, 9, 8, 10, 10, 0));
            Corrida CORRIDA1012 = new Corrida(1012, 2019, "GP de Singapura", "Circuito Urbano de Marina Bay", new DateTime(2019, 9, 22, 9, 10, 0));
            Corrida CORRIDA1013 = new Corrida(1013, 2019, "GP da Rússia", "Autódromo de Sóchi", new DateTime(2019, 9, 29, 8, 10, 0));
            Corrida CORRIDA1014 = new Corrida(1014, 2019, "GP do Japão", "Circuito de Suzuka", new DateTime(2019, 10, 13, 2, 10, 0));
            Corrida CORRIDA1015 = new Corrida(1015, 2019, "GP do México", "Autódromo Hermanos Rodríguez", new DateTime(2019, 10, 27, 16, 10, 0));
            Corrida CORRIDA1016 = new Corrida(1016, 2019, "GP dos Estados Unidos", "Circuito das Américas", new DateTime(2019, 11, 3, 17, 10, 0));
            Corrida CORRIDA1017 = new Corrida(1017, 2019, "GP do Brasil", "Autódromo José Carlos Pace", new DateTime(2019, 11, 17, 15, 10, 0));
            Corrida CORRIDA1018 = new Corrida(1018, 2019, "GP do Abu Dhabi", "Circuito de Yas Marina", new DateTime(2019, 12, 1, 11, 10, 0));

            //
            // -------------------- adiciona dados

            // pilotos
            modelBuilder.Entity<Piloto>().HasData(
                    LEWIS_HAMILTON,
                    VALTTERI_BOTTAS,
                    SEBASTIAN_VETTEL,
                    CHARLES_LECLERC,
                    MAX_VERSTAPPEN,
                    PIERRE_GASLY,
                    DANIEL_RICCARDO,
                    NICO_HULKENBERG,
                    KEVIN_MAGNUSSEN,
                    ROMAIN_GROSJEAN,
                    DANIIL_KVYAT,
                    ALEXANDER_ALBON,
                    LANDO_NORRIS,
                    CARLOS_SAINZ_JR,
                    KIMI_RAIKKONEN,
                    ANTONIO_GIOVANAZZI,
                    SERGIO_PEREZ,
                    LANCE_STROLL,
                    ROBERT_KUBICA,
                    GEORGE_RUSSEL
                );

            // equipes
            modelBuilder.Entity<Equipe>().HasData(
                    MERCEDES,
                    FERRARI,
                    REDBULL,
                    TORO_ROSSO,
                    RENAULT,
                    WILLIAMS,
                    MCLAREN,
                    RACING_POINT,
                    HAAS,
                    ALFA_ROMEO
                );

            // corridas
            modelBuilder.Entity<Corrida>().HasData(
                    CORRIDA998,
                    CORRIDA999,
                    CORRIDA1000,
                    CORRIDA1001,
                    CORRIDA1002,
                    CORRIDA1003,
                    CORRIDA1004,
                    CORRIDA1005,
                    CORRIDA1006,
                    CORRIDA1007,
                    CORRIDA1008,
                    CORRIDA1009,
                    CORRIDA1010,
                    CORRIDA1011,
                    CORRIDA1012,
                    CORRIDA1013,
                    CORRIDA1014,
                    CORRIDA1015,
                    CORRIDA1016,
                    CORRIDA1017,
                    CORRIDA1018
                );

            // resultados (998)
            modelBuilder.Entity<Resultado>().HasData(
                    new Resultado(CORRIDA998, VALTTERI_BOTTAS, MERCEDES, 2, 1, 26),
                    new Resultado(CORRIDA998, LEWIS_HAMILTON, MERCEDES, 1, 2, 18),
                    new Resultado(CORRIDA998, MAX_VERSTAPPEN, REDBULL, 4, 3, 15),
                    new Resultado(CORRIDA998, SEBASTIAN_VETTEL, FERRARI, 3, 4, 12),
                    new Resultado(CORRIDA998, CHARLES_LECLERC, FERRARI, 5, 5, 10),
                    new Resultado(CORRIDA998, KEVIN_MAGNUSSEN, HAAS, 7, 6, 8),
                    new Resultado(CORRIDA998, NICO_HULKENBERG, RENAULT, 11, 7, 6),
                    new Resultado(CORRIDA998, KIMI_RAIKKONEN, ALFA_ROMEO, 9, 8, 4),
                    new Resultado(CORRIDA998, LANCE_STROLL, RACING_POINT, 16, 9, 2),
                    new Resultado(CORRIDA998, DANIIL_KVYAT, TORO_ROSSO, 15, 10, 1),
                    new Resultado(CORRIDA998, PIERRE_GASLY, REDBULL, 17, 11, 0),
                    new Resultado(CORRIDA998, LANDO_NORRIS, MCLAREN, 8, 12, 0),
                    new Resultado(CORRIDA998, SERGIO_PEREZ, RACING_POINT, 10, 13, 0),
                    new Resultado(CORRIDA998, ALEXANDER_ALBON, TORO_ROSSO, 13, 14, 0),
                    new Resultado(CORRIDA998, ANTONIO_GIOVANAZZI, ALFA_ROMEO, 14, 15, 0),
                    new Resultado(CORRIDA998, GEORGE_RUSSEL, WILLIAMS, 19, 16, 0),
                    new Resultado(CORRIDA998, ROBERT_KUBICA, WILLIAMS, 20, 17, 0),
                    new Resultado(CORRIDA998, ROMAIN_GROSJEAN, HAAS, 6, 18, 0, MotivoDNF.Pneu),
                    new Resultado(CORRIDA998, DANIEL_RICCARDO, RENAULT, 12, 19, 0, MotivoDNF.Colisao),
                    new Resultado(CORRIDA998, CARLOS_SAINZ_JR, MCLAREN, 18, 20, 0, MotivoDNF.Motor)
                );

            // resultados (999)
            modelBuilder.Entity<Resultado>().HasData(
                    new Resultado(CORRIDA999, LEWIS_HAMILTON, MERCEDES, 3, 1, 25),
                    new Resultado(CORRIDA999, VALTTERI_BOTTAS, MERCEDES, 4, 2, 18),
                    new Resultado(CORRIDA999, CHARLES_LECLERC, FERRARI, 1, 3, 16),
                    new Resultado(CORRIDA999, MAX_VERSTAPPEN, REDBULL, 5, 4, 12),
                    new Resultado(CORRIDA999, SEBASTIAN_VETTEL, FERRARI, 2, 5, 10),
                    new Resultado(CORRIDA999, LANDO_NORRIS, MCLAREN, 9, 6, 8),
                    new Resultado(CORRIDA999, KIMI_RAIKKONEN, ALFA_ROMEO, 8, 7, 6),
                    new Resultado(CORRIDA999, PIERRE_GASLY, REDBULL, 13, 8, 4),
                    new Resultado(CORRIDA999, ALEXANDER_ALBON, TORO_ROSSO, 12, 9, 2),
                    new Resultado(CORRIDA999, SERGIO_PEREZ, RACING_POINT, 14, 10, 1),
                    new Resultado(CORRIDA999, ANTONIO_GIOVANAZZI, ALFA_ROMEO, 16, 11, 0),
                    new Resultado(CORRIDA999, DANIIL_KVYAT, TORO_ROSSO, 15, 12, 0),
                    new Resultado(CORRIDA999, KEVIN_MAGNUSSEN, HAAS, 6, 13, 0),
                    new Resultado(CORRIDA999, LANCE_STROLL, RACING_POINT, 18, 14, 0),
                    new Resultado(CORRIDA999, GEORGE_RUSSEL, WILLIAMS, 19, 15, 0),
                    new Resultado(CORRIDA999, ROBERT_KUBICA, WILLIAMS, 20, 16, 0),
                    new Resultado(CORRIDA999, NICO_HULKENBERG, RENAULT, 17, 17, 6),
                    new Resultado(CORRIDA999, DANIEL_RICCARDO, RENAULT, 10, 18, 0),
                    new Resultado(CORRIDA999, CARLOS_SAINZ_JR, MCLAREN, 7, 19, 0),
                    new Resultado(CORRIDA999, ROMAIN_GROSJEAN, HAAS, 11, 20, 0, MotivoDNF.Danos)
                );

            // resultados (1000)
            modelBuilder.Entity<Resultado>().HasData(
                    new Resultado(CORRIDA1000, LEWIS_HAMILTON, MERCEDES, 2, 1, 25),
                    new Resultado(CORRIDA1000, VALTTERI_BOTTAS, MERCEDES, 1, 2, 18),
                    new Resultado(CORRIDA1000, SEBASTIAN_VETTEL, FERRARI, 3, 3, 15),
                    new Resultado(CORRIDA1000, MAX_VERSTAPPEN, REDBULL, 5, 4, 12),
                    new Resultado(CORRIDA1000, CHARLES_LECLERC, FERRARI, 4, 5, 10),
                    new Resultado(CORRIDA1000, PIERRE_GASLY, REDBULL, 6, 6, 9),
                    new Resultado(CORRIDA1000, DANIEL_RICCARDO, RENAULT, 7, 7, 6),
                    new Resultado(CORRIDA1000, SERGIO_PEREZ, RACING_POINT, 12, 8, 4),
                    new Resultado(CORRIDA1000, KIMI_RAIKKONEN, ALFA_ROMEO, 13, 9, 2),
                    new Resultado(CORRIDA1000, ALEXANDER_ALBON, TORO_ROSSO, 0, 10, 1), // PL
                    new Resultado(CORRIDA1000, ROMAIN_GROSJEAN, HAAS, 10, 11, 0),
                    new Resultado(CORRIDA1000, LANCE_STROLL, RACING_POINT, 16, 12, 0),
                    new Resultado(CORRIDA1000, KEVIN_MAGNUSSEN, HAAS, 9, 13, 0),
                    new Resultado(CORRIDA1000, CARLOS_SAINZ_JR, MCLAREN, 14, 14, 0),
                    new Resultado(CORRIDA1000, ANTONIO_GIOVANAZZI, ALFA_ROMEO, 0, 15, 0), // PL
                    new Resultado(CORRIDA1000, GEORGE_RUSSEL, WILLIAMS, 17, 16, 0),
                    new Resultado(CORRIDA1000, ROBERT_KUBICA, WILLIAMS, 18, 17, 0),
                    new Resultado(CORRIDA1000, LANDO_NORRIS, MCLAREN, 15, 18, 8, MotivoDNF.Danos),
                    new Resultado(CORRIDA1000, DANIIL_KVYAT, TORO_ROSSO, 11, 19, 0, MotivoDNF.Danos),
                    new Resultado(CORRIDA1000, NICO_HULKENBERG, RENAULT, 8, 20, 0, MotivoDNF.Motor)
                );
        }
    }
}