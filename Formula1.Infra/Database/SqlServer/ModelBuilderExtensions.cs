using Formula1.Data.Entities;
using Formula1.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Formula1.Infra.Database.SqlServer
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // pilotos
            Piloto LEWIS_HAMILTON = new Piloto(1, "Lewis Hamilton", "Hamilton", "HAM", 44, "Inglaterra");
            Piloto VALTTERI_BOTTAS = new Piloto(2, "Valtteri Bottas", "Bottas", "BOT", 77, "Finlândia");
            Piloto SEBASTIAN_VETTEL = new Piloto(3, "Sebastian Vettel", "Vettel", "VET", 5, "Alemanha");
            Piloto CHARLES_LECLERC = new Piloto(4, "Charles Leclerc", "Leclerc", "LEC", 16, "Mônaco");
            Piloto MAX_VERSTAPPEN = new Piloto(5, "Max Verstappen", "Verstappen", "VER", 33, "Holanda (talvez)");
            Piloto PIERRE_GASLY = new Piloto(6, "Pierre Gasly", "Gasly", "GAS", 10, "França");
            Piloto DANIEL_RICCARDO = new Piloto(7, "Daniel Riccardo", "Riccardo", "RIC", 3, "Austrália");
            Piloto NICO_HULKENBERG = new Piloto(8, "Nico Hülkenberg", "Hülkenberg", "HUL", 27, "Alemanha");
            Piloto KEVIN_MAGNUSSEN = new Piloto(9, "Kevin Magnussen", "Magnussen", "MAG", 20, "Dinamarca");
            Piloto ROMAIN_GROSJEAN = new Piloto(10, "Romain Grosjean", "Grosjean", "GRO", 8, "França");
            Piloto DANIIL_KVYAT = new Piloto(11, "Daniil Kvyat", "Kvyat", "KVY", 26, "Rússia");
            Piloto ALEXANDER_ALBON = new Piloto(12, "Alexander Albon", "Albon", "ALB", 23, "?");
            Piloto LANDO_NORRIS = new Piloto(13, "Lando Norris", "Norris", "NOR", 4, "Inglaterra");
            Piloto CARLOS_SAINZ_JR = new Piloto(14, "Carlos Sainz Jr.", "Sainz", "SAI", 55, "Espanha");
            Piloto KIMI_RAIKKONEN = new Piloto(15, "Kimi Räikkönen", "Räikkönen", "RAI", 7, "Finlândia");
            Piloto ANTONIO_GIOVANAZZI = new Piloto(16, "Antonio Giovinazzi", "Giovinazzi", "GIO", 99, "Itália");
            Piloto SERGIO_PEREZ = new Piloto(17, "Sergio Perez", "Perez", "PER", 11, "México");
            Piloto LANCE_STROLL = new Piloto(18, "Lance Stroll", "Stroll", "STR", 18, "Canadá");
            Piloto ROBERT_KUBICA = new Piloto(19, "Robert Kubica", "Kubica", "KUB", 88, "Polônia");
            Piloto GEORGE_RUSSEL = new Piloto(20, "George Russell", "Russell", "RUS", 63, "Inglaterra");

            // equipes
            Equipe MERCEDES = new Equipe(1, "Mercedes", "#00D2BE");
            Equipe FERRARI = new Equipe(2, "Ferrari", "#DC0000");
            Equipe REDBULL = new Equipe(3, "RedBull Racing", "#1E41FF");
            Equipe TORO_ROSSO = new Equipe(4, "Scuderia Toro Rosso", "#469BFF");
            Equipe RENAULT = new Equipe(5, "Renault", "#FFF500");
            Equipe WILLIAMS = new Equipe(6, "Williams", "#EEEEEE");
            Equipe MCLAREN = new Equipe(7, "McLaren", "#FF8700");
            Equipe RACING_POINT = new Equipe(8, "Racing Point", "#F596C8");
            Equipe HAAS = new Equipe(9, "Haas", "#F0D787");
            Equipe ALFA_ROMEO = new Equipe(10, "Alfa Romeo", "#9B0000");

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

            // contratos
            modelBuilder.Entity<Contrato>().HasData(
                    new ContratoInclusao(1, LEWIS_HAMILTON, MERCEDES, 2019),
                    new ContratoInclusao(2, VALTTERI_BOTTAS, MERCEDES, 2019),
                    new ContratoInclusao(3, SEBASTIAN_VETTEL, FERRARI, 2019),
                    new ContratoInclusao(4, CHARLES_LECLERC, FERRARI, 2019),
                    new ContratoInclusao(5, MAX_VERSTAPPEN, REDBULL, 2019),
                    new ContratoInclusao(6, PIERRE_GASLY, REDBULL, 2019),
                    new ContratoInclusao(7, NICO_HULKENBERG, RENAULT, 2019),
                    new ContratoInclusao(8, DANIEL_RICCARDO, RENAULT, 2019),
                    new ContratoInclusao(9, SERGIO_PEREZ, RACING_POINT, 2019),
                    new ContratoInclusao(10, LANCE_STROLL, RACING_POINT, 2019),
                    new ContratoInclusao(11, KIMI_RAIKKONEN, ALFA_ROMEO, 2019),
                    new ContratoInclusao(12, ANTONIO_GIOVANAZZI, ALFA_ROMEO, 2019),
                    new ContratoInclusao(13, DANIIL_KVYAT, TORO_ROSSO, 2019),
                    new ContratoInclusao(14, ALEXANDER_ALBON, TORO_ROSSO, 2019),
                    new ContratoInclusao(15, LANDO_NORRIS, MCLAREN, 2019),
                    new ContratoInclusao(16, CARLOS_SAINZ_JR, MCLAREN, 2019),
                    new ContratoInclusao(17, KEVIN_MAGNUSSEN, HAAS, 2019),
                    new ContratoInclusao(18, ROMAIN_GROSJEAN, HAAS, 2019),
                    new ContratoInclusao(19, GEORGE_RUSSEL, WILLIAMS, 2019),
                    new ContratoInclusao(20, ROBERT_KUBICA, WILLIAMS, 2019)
                );

            // resultados (998)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(1, CORRIDA998, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 2, posicaoChegada: 1, pontos: 26, pontoExtra: true),
                    new ResultadoInclusao(2, CORRIDA998, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 1, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(3, CORRIDA998, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 4, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(4, CORRIDA998, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 3, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(5, CORRIDA998, CHARLES_LECLERC, FERRARI, posicaoLargada: 5, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(6, CORRIDA998, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 7, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(7, CORRIDA998, NICO_HULKENBERG, RENAULT, posicaoLargada: 11, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(8, CORRIDA998, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 9, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(9, CORRIDA998, LANCE_STROLL, RACING_POINT, posicaoLargada: 16, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(10, CORRIDA998, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 15, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(11, CORRIDA998, PIERRE_GASLY, REDBULL, posicaoLargada: 17, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(12, CORRIDA998, LANDO_NORRIS, MCLAREN, posicaoLargada: 8, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(13, CORRIDA998, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 10, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(14, CORRIDA998, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 13, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(15, CORRIDA998, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 14, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(16, CORRIDA998, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 19, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(17, CORRIDA998, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 20, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(18, CORRIDA998, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 6, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Pneu),
                    new ResultadoInclusao(19, CORRIDA998, DANIEL_RICCARDO, RENAULT, posicaoLargada: 12, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Colisao),
                    new ResultadoInclusao(20, CORRIDA998, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 18, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Motor)
                );

            // resultados (999)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(21, CORRIDA999, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 3, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(22, CORRIDA999, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 4, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(23, CORRIDA999, CHARLES_LECLERC, FERRARI, posicaoLargada: 1, posicaoChegada: 3, pontos: 16, pontoExtra: true),
                    new ResultadoInclusao(24, CORRIDA999, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 5, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(25, CORRIDA999, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 2, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(26, CORRIDA999, LANDO_NORRIS, MCLAREN, posicaoLargada: 9, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(27, CORRIDA999, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 8, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(28, CORRIDA999, PIERRE_GASLY, REDBULL, posicaoLargada: 13, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(29, CORRIDA999, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 12, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(30, CORRIDA999, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 14, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(31, CORRIDA999, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 16, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(32, CORRIDA999, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 15, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(33, CORRIDA999, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 6, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(34, CORRIDA999, LANCE_STROLL, RACING_POINT, posicaoLargada: 18, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(35, CORRIDA999, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 19, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(36, CORRIDA999, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 20, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(37, CORRIDA999, NICO_HULKENBERG, RENAULT, posicaoLargada: 17, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(38, CORRIDA999, DANIEL_RICCARDO, RENAULT, posicaoLargada: 10, posicaoChegada: 18, pontos: 0),
                    new ResultadoInclusao(39, CORRIDA999, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 7, posicaoChegada: 19, pontos: 0),
                    new ResultadoInclusao(40, CORRIDA999, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 11, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Danos)
                );

            // resultados (1000)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(41, CORRIDA1000, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 2, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(42, CORRIDA1000, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 1, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(43, CORRIDA1000, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 3, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(44, CORRIDA1000, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 5, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(45, CORRIDA1000, CHARLES_LECLERC, FERRARI, posicaoLargada: 4, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(46, CORRIDA1000, PIERRE_GASLY, REDBULL, posicaoLargada: 6, posicaoChegada: 6, pontos: 9, pontoExtra: true),
                    new ResultadoInclusao(47, CORRIDA1000, DANIEL_RICCARDO, RENAULT, posicaoLargada: 7, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(48, CORRIDA1000, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 12, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(49, CORRIDA1000, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 13, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(50, CORRIDA1000, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 20, posicaoChegada: 10, pontos: 1), // PL (Pit lane, largou dos boxes - sem tempo)
                    new ResultadoInclusao(51, CORRIDA1000, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 10, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(52, CORRIDA1000, LANCE_STROLL, RACING_POINT, posicaoLargada: 16, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(53, CORRIDA1000, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 9, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(54, CORRIDA1000, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 14, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(55, CORRIDA1000, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 19, posicaoChegada: 15, pontos: 0), // PL (Pit lane, largou dos boxes - sem tempo)
                    new ResultadoInclusao(56, CORRIDA1000, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 17, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(57, CORRIDA1000, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 18, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(58, CORRIDA1000, LANDO_NORRIS, MCLAREN, posicaoLargada: 15, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Danos),
                    new ResultadoInclusao(59, CORRIDA1000, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 11, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Danos),
                    new ResultadoInclusao(60, CORRIDA1000, NICO_HULKENBERG, RENAULT, posicaoLargada: 8, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Motor)
                );

            // resultados (1001)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(61, CORRIDA1001, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 1, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(62, CORRIDA1001, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 2, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(63, CORRIDA1001, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 3, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(64, CORRIDA1001, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 4, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(65, CORRIDA1001, CHARLES_LECLERC, FERRARI, posicaoLargada: 10, posicaoChegada: 5, pontos: 11, pontoExtra: true),
                    new ResultadoInclusao(66, CORRIDA1001, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 5, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(67, CORRIDA1001, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 11, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(68, CORRIDA1001, LANDO_NORRIS, MCLAREN, posicaoLargada: 7, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(69, CORRIDA1001, LANCE_STROLL, RACING_POINT, posicaoLargada: 16, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(70, CORRIDA1001, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 9, posicaoChegada: 10, pontos: 1), // PL
                    new ResultadoInclusao(71, CORRIDA1001, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 13, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(72, CORRIDA1001, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 8, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(73, CORRIDA1001, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 14, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(74, CORRIDA1001, NICO_HULKENBERG, RENAULT, posicaoLargada: 18, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(75, CORRIDA1001, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 19, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(76, CORRIDA1001, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 20, posicaoChegada: 16, pontos: 0), // PL
                    new ResultadoInclusao(77, CORRIDA1001, PIERRE_GASLY, REDBULL, posicaoLargada: 15, posicaoChegada: 17, pontos: 0, motivoDnf: MotivoDNF.Transmissao), // PL
                    new ResultadoInclusao(78, CORRIDA1001, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 17, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Freios),
                    new ResultadoInclusao(79, CORRIDA1001, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 6, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Colisao),
                    new ResultadoInclusao(80, CORRIDA1001, DANIEL_RICCARDO, RENAULT, posicaoLargada: 12, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Colisao)
                );

            // resultados (1002 - GP ESPANHA - 12/05/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(81, CORRIDA1002, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 2, posicaoChegada: 1, pontos: 26, pontoExtra: true),
                    new ResultadoInclusao(82, CORRIDA1002, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 1, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(83, CORRIDA1002, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 4, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(84, CORRIDA1002, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 3, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(85, CORRIDA1002, CHARLES_LECLERC, FERRARI, posicaoLargada: 5, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(86, CORRIDA1002, PIERRE_GASLY, REDBULL, posicaoLargada: 6, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(87, CORRIDA1002, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 8, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(88, CORRIDA1002, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 13, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(89, CORRIDA1002, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 9, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(90, CORRIDA1002, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 7, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(91, CORRIDA1002, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 12, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(92, CORRIDA1002, DANIEL_RICCARDO, RENAULT, posicaoLargada: 10, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(93, CORRIDA1002, NICO_HULKENBERG, RENAULT, posicaoLargada: 16, posicaoChegada: 13, pontos: 0), // PL
                    new ResultadoInclusao(94, CORRIDA1002, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 14, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(95, CORRIDA1002, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 15, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(96, CORRIDA1002, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 18, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(97, CORRIDA1002, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 19, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(98, CORRIDA1002, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 20, posicaoChegada: 18, pontos: 0),
                    new ResultadoInclusao(99, CORRIDA1002, LANCE_STROLL, RACING_POINT, posicaoLargada: 17, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Colisao),
                    new ResultadoInclusao(100, CORRIDA1002, LANDO_NORRIS, MCLAREN, posicaoLargada: 11, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Colisao)
                );

            // resultados (1003 - GP MÔNACO - 24/05/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(101, CORRIDA1003, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 1, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(104, CORRIDA1003, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 4, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(102, CORRIDA1003, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 2, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(103, CORRIDA1003, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 3, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(106, CORRIDA1003, PIERRE_GASLY, REDBULL, posicaoLargada: 5, posicaoChegada: 5, pontos: 11, pontoExtra: true),
                    new ResultadoInclusao(108, CORRIDA1003, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 9, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(109, CORRIDA1003, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 8, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(111, CORRIDA1003, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 10, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(110, CORRIDA1003, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 13, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(112, CORRIDA1003, DANIEL_RICCARDO, RENAULT, posicaoLargada: 7, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(120, CORRIDA1003, LANDO_NORRIS, MCLAREN, posicaoLargada: 12, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(107, CORRIDA1003, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 6, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(115, CORRIDA1003, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 17, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(113, CORRIDA1003, NICO_HULKENBERG, RENAULT, posicaoLargada: 11, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(117, CORRIDA1003, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 19, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(119, CORRIDA1003, LANCE_STROLL, RACING_POINT, posicaoLargada: 18, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(114, CORRIDA1003, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 14, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(118, CORRIDA1003, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 20, posicaoChegada: 18, pontos: 0),
                    new ResultadoInclusao(116, CORRIDA1003, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 16, posicaoChegada: 19, pontos: 0),
                    new ResultadoInclusao(105, CORRIDA1003, CHARLES_LECLERC, FERRARI, posicaoLargada: 15, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Outros)
                );
        }
    }
}