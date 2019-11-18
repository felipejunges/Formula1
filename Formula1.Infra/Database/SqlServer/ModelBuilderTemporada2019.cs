﻿using Formula1.Data.Entities;
using Formula1.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Formula1.Infra.Database.SqlServer
{
    public static class ModelBuilderTemporada2019
    {
        public static int PONTOS_MAXIMOS_CORRIDA_PILOTO = 26;
        public static int PONTOS_MAXIMOS_CORRIDA_EQUIPE = 44;

        public static void Seed(this ModelBuilder modelBuilder)
        {
            // pilotos
            var LEWIS_HAMILTON = new Piloto(1, "Lewis Hamilton", "Hamilton", "HAM", 44, "Inglaterra");
            var VALTTERI_BOTTAS = new Piloto(2, "Valtteri Bottas", "Bottas", "BOT", 77, "Finlândia");
            var SEBASTIAN_VETTEL = new Piloto(3, "Sebastian Vettel", "Vettel", "VET", 5, "Alemanha");
            var CHARLES_LECLERC = new Piloto(4, "Charles Leclerc", "Leclerc", "LEC", 16, "Mônaco");
            var MAX_VERSTAPPEN = new Piloto(5, "Max Verstappen", "Verstappen", "VER", 33, "Holanda");
            var PIERRE_GASLY = new Piloto(6, "Pierre Gasly", "Gasly", "GAS", 10, "França");
            var DANIEL_RICCARDO = new Piloto(7, "Daniel Riccardo", "Riccardo", "RIC", 3, "Austrália");
            var NICO_HULKENBERG = new Piloto(8, "Nico Hülkenberg", "Hülkenberg", "HUL", 27, "Alemanha");
            var KEVIN_MAGNUSSEN = new Piloto(9, "Kevin Magnussen", "Magnussen", "MAG", 20, "Dinamarca");
            var ROMAIN_GROSJEAN = new Piloto(10, "Romain Grosjean", "Grosjean", "GRO", 8, "França");
            var DANIIL_KVYAT = new Piloto(11, "Daniil Kvyat", "Kvyat", "KVY", 26, "Rússia");
            var ALEXANDER_ALBON = new Piloto(12, "Alexander Albon", "Albon", "ALB", 23, "?");
            var LANDO_NORRIS = new Piloto(13, "Lando Norris", "Norris", "NOR", 4, "Inglaterra");
            var CARLOS_SAINZ_JR = new Piloto(14, "Carlos Sainz Jr.", "Sainz", "SAI", 55, "Espanha");
            var KIMI_RAIKKONEN = new Piloto(15, "Kimi Räikkönen", "Räikkönen", "RAI", 7, "Finlândia");
            var ANTONIO_GIOVANAZZI = new Piloto(16, "Antonio Giovinazzi", "Giovinazzi", "GIO", 99, "Itália");
            var SERGIO_PEREZ = new Piloto(17, "Sergio Perez", "Perez", "PER", 11, "México");
            var LANCE_STROLL = new Piloto(18, "Lance Stroll", "Stroll", "STR", 18, "Canadá");
            var ROBERT_KUBICA = new Piloto(19, "Robert Kubica", "Kubica", "KUB", 88, "Polônia");
            var GEORGE_RUSSEL = new Piloto(20, "George Russell", "Russell", "RUS", 63, "Inglaterra");

            // equipes
            var MERCEDES = new Equipe(1, "Mercedes", "#00D2BE");
            var FERRARI = new Equipe(2, "Ferrari", "#DC0000");
            var REDBULL = new Equipe(3, "RedBull Racing", "#1E41FF");
            var TORO_ROSSO = new Equipe(4, "Scuderia Toro Rosso", "#469BFF");
            var RENAULT = new Equipe(5, "Renault", "#FFF500");
            var WILLIAMS = new Equipe(6, "Williams", "#EEEEEE");
            var MCLAREN = new Equipe(7, "McLaren", "#FF8700");
            var RACING_POINT = new Equipe(8, "Racing Point", "#F596C8");
            var HAAS = new Equipe(9, "Haas", "#F0D787");
            var ALFA_ROMEO = new Equipe(10, "Alfa Romeo", "#9B0000");

            // corridas
            var CORRIDA998 = new Corrida(998, 2019, "GP da Austrália", "Circuito de Albert Park", new DateTime(2019, 3, 17, 2, 10, 0));
            var CORRIDA999 = new Corrida(999, 2019, "GP do Bahrein", "Circuito Internacional do Bahrein", new DateTime(2019, 3, 31, 12, 10, 0));
            var CORRIDA1000 = new Corrida(1000, 2019, "GP da China", "Circuito Internacional de Xangai", new DateTime(2019, 4, 14, 03, 10, 0));
            var CORRIDA1001 = new Corrida(1001, 2019, "GP do Azerbaijão", "Curcuito Urbano de Baku", new DateTime(2019, 4, 28, 9, 10, 0));
            var CORRIDA1002 = new Corrida(1002, 2019, "GP da Espanha", "Circuito da Catalunha", new DateTime(2019, 5, 12, 10, 10, 0));
            var CORRIDA1003 = new Corrida(1003, 2019, "GP de Mônaco", "Circuito de Mônaco", new DateTime(2019, 5, 26, 10, 10, 0));
            var CORRIDA1004 = new Corrida(1004, 2019, "GP do Canadá", "Circuito Gilles Villeneuve", new DateTime(2019, 6, 9, 15, 10, 0));
            var CORRIDA1005 = new Corrida(1005, 2019, "GP da França", "Circuito Paul Ricard", new DateTime(2019, 6, 23, 10, 10, 0));
            var CORRIDA1006 = new Corrida(1006, 2019, "GP da Áustria", "Red Bull Ring", new DateTime(2019, 6, 30, 10, 10, 0));
            var CORRIDA1007 = new Corrida(1007, 2019, "GP da Grã-Bretanha", "Silverstone", new DateTime(2019, 7, 14, 10, 10, 0));
            var CORRIDA1008 = new Corrida(1008, 2019, "GP da Alemanha", "Hockenheimring", new DateTime(2019, 7, 28, 10, 10, 0));
            var CORRIDA1009 = new Corrida(1009, 2019, "GP da Hungria", "Hungaroring", new DateTime(2019, 8, 4, 10, 10, 0));
            var CORRIDA1010 = new Corrida(1010, 2019, "GP da Bélgica", "Spa-Francorchamps", new DateTime(2019, 9, 1, 10, 10, 0));
            var CORRIDA1011 = new Corrida(1011, 2019, "GP da Itália", "Circuito de Monza", new DateTime(2019, 9, 8, 10, 10, 0));
            var CORRIDA1012 = new Corrida(1012, 2019, "GP de Singapura", "Circuito Urbano de Marina Bay", new DateTime(2019, 9, 22, 9, 10, 0));
            var CORRIDA1013 = new Corrida(1013, 2019, "GP da Rússia", "Autódromo de Sóchi", new DateTime(2019, 9, 29, 8, 10, 0));
            var CORRIDA1014 = new Corrida(1014, 2019, "GP do Japão", "Circuito de Suzuka", new DateTime(2019, 10, 13, 2, 10, 0));
            var CORRIDA1015 = new Corrida(1015, 2019, "GP do México", "Autódromo Hermanos Rodríguez", new DateTime(2019, 10, 27, 16, 10, 0));
            var CORRIDA1016 = new Corrida(1016, 2019, "GP dos EUA", "Circuito das Américas", new DateTime(2019, 11, 3, 16, 10, 0));
            var CORRIDA1017 = new Corrida(1017, 2019, "GP do Brasil", "Autódromo José Carlos Pace", new DateTime(2019, 11, 17, 14, 10, 0));
            var CORRIDA1018 = new Corrida(1018, 2019, "GP do Abu Dhabi", "Circuito de Yas Marina", new DateTime(2019, 12, 1, 10, 10, 0));

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
                    new ContratoInclusao(6, PIERRE_GASLY, TORO_ROSSO, 2019), // REDBULL -> TORO_ROSSO
                    new ContratoInclusao(7, NICO_HULKENBERG, RENAULT, 2019),
                    new ContratoInclusao(8, DANIEL_RICCARDO, RENAULT, 2019),
                    new ContratoInclusao(9, SERGIO_PEREZ, RACING_POINT, 2019),
                    new ContratoInclusao(10, LANCE_STROLL, RACING_POINT, 2019),
                    new ContratoInclusao(11, KIMI_RAIKKONEN, ALFA_ROMEO, 2019),
                    new ContratoInclusao(12, ANTONIO_GIOVANAZZI, ALFA_ROMEO, 2019),
                    new ContratoInclusao(13, DANIIL_KVYAT, TORO_ROSSO, 2019),
                    new ContratoInclusao(14, ALEXANDER_ALBON, REDBULL, 2019), // TORO_ROSSO -> REDBULL
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
                    new ResultadoInclusao(102, CORRIDA1003, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 4, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(103, CORRIDA1003, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 2, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(104, CORRIDA1003, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 3, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(105, CORRIDA1003, PIERRE_GASLY, REDBULL, posicaoLargada: 5, posicaoChegada: 5, pontos: 11, pontoExtra: true),
                    new ResultadoInclusao(106, CORRIDA1003, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 9, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(107, CORRIDA1003, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 8, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(108, CORRIDA1003, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 10, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(109, CORRIDA1003, DANIEL_RICCARDO, RENAULT, posicaoLargada: 7, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(110, CORRIDA1003, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 13, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(111, CORRIDA1003, LANDO_NORRIS, MCLAREN, posicaoLargada: 12, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(112, CORRIDA1003, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 6, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(113, CORRIDA1003, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 17, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(114, CORRIDA1003, NICO_HULKENBERG, RENAULT, posicaoLargada: 11, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(115, CORRIDA1003, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 19, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(116, CORRIDA1003, LANCE_STROLL, RACING_POINT, posicaoLargada: 18, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(117, CORRIDA1003, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 14, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(118, CORRIDA1003, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 20, posicaoChegada: 18, pontos: 0),
                    new ResultadoInclusao(119, CORRIDA1003, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 16, posicaoChegada: 19, pontos: 0),
                    new ResultadoInclusao(120, CORRIDA1003, CHARLES_LECLERC, FERRARI, posicaoLargada: 15, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Outros)
                );

            // resultados (1004 - GP DO CANADA - 09/06/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(121, CORRIDA1004, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 2, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(122, CORRIDA1004, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 1, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(123, CORRIDA1004, CHARLES_LECLERC, FERRARI, posicaoLargada: 3, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(124, CORRIDA1004, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 6, posicaoChegada: 4, pontos: 13, pontoExtra: true),
                    new ResultadoInclusao(125, CORRIDA1004, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 9, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(126, CORRIDA1004, DANIEL_RICCARDO, RENAULT, posicaoLargada: 4, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(127, CORRIDA1004, NICO_HULKENBERG, RENAULT, posicaoLargada: 7, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(128, CORRIDA1004, PIERRE_GASLY, REDBULL, posicaoLargada: 5, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(129, CORRIDA1004, LANCE_STROLL, RACING_POINT, posicaoLargada: 17, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(130, CORRIDA1004, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 10, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(131, CORRIDA1004, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 11, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(132, CORRIDA1004, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 15, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(133, CORRIDA1004, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 12, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(134, CORRIDA1004, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 14, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(135, CORRIDA1004, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 16, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(136, CORRIDA1004, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 18, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(137, CORRIDA1004, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 20, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(138, CORRIDA1004, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 19, posicaoChegada: 18, pontos: 0),
                    new ResultadoInclusao(139, CORRIDA1004, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 13, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Outros),
                    new ResultadoInclusao(140, CORRIDA1004, LANDO_NORRIS, MCLAREN, posicaoLargada: 8, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Quebra)
                );

            // resultados (1005 - GP DA FRANÇA - 23/06/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(141, CORRIDA1005, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 1, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(142, CORRIDA1005, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 2, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(143, CORRIDA1005, CHARLES_LECLERC, FERRARI, posicaoLargada: 3, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(144, CORRIDA1005, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 4, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(145, CORRIDA1005, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 7, posicaoChegada: 5, pontos: 11, pontoExtra: true),
                    new ResultadoInclusao(146, CORRIDA1005, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 6, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(147, CORRIDA1005, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 12, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(148, CORRIDA1005, NICO_HULKENBERG, RENAULT, posicaoLargada: 13, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(149, CORRIDA1005, LANDO_NORRIS, MCLAREN, posicaoLargada: 5, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(150, CORRIDA1005, PIERRE_GASLY, REDBULL, posicaoLargada: 9, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(151, CORRIDA1005, DANIEL_RICCARDO, RENAULT, posicaoLargada: 8, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(152, CORRIDA1005, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 14, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(153, CORRIDA1005, LANCE_STROLL, RACING_POINT, posicaoLargada: 17, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(154, CORRIDA1005, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 19, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(155, CORRIDA1005, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 11, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(156, CORRIDA1005, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 15, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(157, CORRIDA1005, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 10, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(158, CORRIDA1005, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 18, posicaoChegada: 18, pontos: 0),
                    new ResultadoInclusao(159, CORRIDA1005, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 20, posicaoChegada: 19, pontos: 0),
                    new ResultadoInclusao(160, CORRIDA1005, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 16, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Outros)
                );

            // resultados (1006 - GP DA ÁUSTRIA - 30/06/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(161, CORRIDA1006, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 2, posicaoChegada: 1, pontos: 26, pontoExtra: true),
                    new ResultadoInclusao(162, CORRIDA1006, CHARLES_LECLERC, FERRARI, posicaoLargada: 1, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(163, CORRIDA1006, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 3, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(164, CORRIDA1006, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 9, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(165, CORRIDA1006, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 4, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(166, CORRIDA1006, LANDO_NORRIS, MCLAREN, posicaoLargada: 5, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(167, CORRIDA1006, PIERRE_GASLY, REDBULL, posicaoLargada: 8, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(168, CORRIDA1006, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 20, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(169, CORRIDA1006, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 6, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(170, CORRIDA1006, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 7, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(171, CORRIDA1006, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 13, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(172, CORRIDA1006, DANIEL_RICCARDO, RENAULT, posicaoLargada: 12, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(173, CORRIDA1006, NICO_HULKENBERG, RENAULT, posicaoLargada: 15, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(174, CORRIDA1006, LANCE_STROLL, RACING_POINT, posicaoLargada: 14, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(175, CORRIDA1006, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 19, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(176, CORRIDA1006, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 11, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(177, CORRIDA1006, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 16, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(178, CORRIDA1006, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 18, posicaoChegada: 18, pontos: 0),
                    new ResultadoInclusao(179, CORRIDA1006, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 10, posicaoChegada: 19, pontos: 0),
                    new ResultadoInclusao(180, CORRIDA1006, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 17, posicaoChegada: 20, pontos: 0)
                );

            // resultados (1007 - GP DA INGLATERRA - 14/07/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(181, CORRIDA1007, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 2, posicaoChegada: 1, pontos: 26, pontoExtra: true),
                    new ResultadoInclusao(182, CORRIDA1007, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 1, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(183, CORRIDA1007, CHARLES_LECLERC, FERRARI, posicaoLargada: 3, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(184, CORRIDA1007, PIERRE_GASLY, REDBULL, posicaoLargada: 5, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(185, CORRIDA1007, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 4, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(186, CORRIDA1007, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 13, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(187, CORRIDA1007, DANIEL_RICCARDO, RENAULT, posicaoLargada: 7, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(188, CORRIDA1007, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 12, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(189, CORRIDA1007, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 17, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(190, CORRIDA1007, NICO_HULKENBERG, RENAULT, posicaoLargada: 10, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(191, CORRIDA1007, LANDO_NORRIS, MCLAREN, posicaoLargada: 8, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(192, CORRIDA1007, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 9, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(193, CORRIDA1007, LANCE_STROLL, RACING_POINT, posicaoLargada: 18, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(194, CORRIDA1007, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 19, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(195, CORRIDA1007, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 20, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(196, CORRIDA1007, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 6, posicaoChegada: 16, pontos: 0), // punição 10 segs.
                    new ResultadoInclusao(197, CORRIDA1007, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 15, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(198, CORRIDA1007, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 11, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Outros), // rodada mma brita
                    new ResultadoInclusao(199, CORRIDA1007, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 14, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Colisao),
                    new ResultadoInclusao(200, CORRIDA1007, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 16, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Colisao)
                );

            // resultados (1008 - GP DA ALEMANHA - 28/07/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(201, CORRIDA1008, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 2, posicaoChegada: 1, pontos: 26, pontoExtra: true),
                    new ResultadoInclusao(202, CORRIDA1008, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 20, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(203, CORRIDA1008, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 14, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(204, CORRIDA1008, LANCE_STROLL, RACING_POINT, posicaoLargada: 15, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(205, CORRIDA1008, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 7, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(206, CORRIDA1008, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 17, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(207, CORRIDA1008, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 6, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(208, CORRIDA1008, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 12, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(209, CORRIDA1008, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 1, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(210, CORRIDA1008, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 19, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(211, CORRIDA1008, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 18, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(212, CORRIDA1008, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 5, posicaoChegada: 12, pontos: 0), // punição 10s pós prova
                    new ResultadoInclusao(213, CORRIDA1008, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 11, posicaoChegada: 13, pontos: 0), // punição 10s pós prova
                    new ResultadoInclusao(214, CORRIDA1008, PIERRE_GASLY, REDBULL, posicaoLargada: 4, posicaoChegada: 14, pontos: 0, motivoDnf: MotivoDNF.Colisao),
                    new ResultadoInclusao(215, CORRIDA1008, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 3, posicaoChegada: 15, pontos: 0, motivoDnf: MotivoDNF.Abandono),
                    new ResultadoInclusao(216, CORRIDA1008, NICO_HULKENBERG, RENAULT, posicaoLargada: 9, posicaoChegada: 16, pontos: 0, motivoDnf: MotivoDNF.Abandono),
                    new ResultadoInclusao(217, CORRIDA1008, CHARLES_LECLERC, FERRARI, posicaoLargada: 10, posicaoChegada: 17, pontos: 0, motivoDnf: MotivoDNF.Abandono),
                    new ResultadoInclusao(218, CORRIDA1008, LANDO_NORRIS, MCLAREN, posicaoLargada: 16, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Abandono),
                    new ResultadoInclusao(219, CORRIDA1008, DANIEL_RICCARDO, RENAULT, posicaoLargada: 13, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Abandono),
                    new ResultadoInclusao(220, CORRIDA1008, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 8, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Abandono)
                );

            // resultados (1009 - GP DA HUNGRIA - 04/08/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(221, CORRIDA1009, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 1, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(222, CORRIDA1009, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 2, posicaoChegada: 2, pontos: 19, pontoExtra: true),
                    new ResultadoInclusao(223, CORRIDA1009, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 20, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(224, CORRIDA1009, CHARLES_LECLERC, FERRARI, posicaoLargada: 10, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(225, CORRIDA1009, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 7, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(226, CORRIDA1009, PIERRE_GASLY, REDBULL, posicaoLargada: 4, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(227, CORRIDA1009, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 5, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(228, CORRIDA1009, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 3, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(229, CORRIDA1009, LANDO_NORRIS, MCLAREN, posicaoLargada: 16, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(230, CORRIDA1009, ALEXANDER_ALBON, TORO_ROSSO, posicaoLargada: 17, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(231, CORRIDA1009, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 8, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(232, CORRIDA1009, NICO_HULKENBERG, RENAULT, posicaoLargada: 9, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(233, CORRIDA1009, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 12, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(234, CORRIDA1009, DANIEL_RICCARDO, RENAULT, posicaoLargada: 13, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(235, CORRIDA1009, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 14, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(236, CORRIDA1009, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 18, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(237, CORRIDA1009, LANCE_STROLL, RACING_POINT, posicaoLargada: 15, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(238, CORRIDA1009, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 11, posicaoChegada: 18, pontos: 0),
                    new ResultadoInclusao(239, CORRIDA1009, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 19, posicaoChegada: 19, pontos: 0),
                    new ResultadoInclusao(240, CORRIDA1009, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 6, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Abandono)
                );

            // resultados (1010 - GP DA BÉLGICA - 01/09/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(241, CORRIDA1010, CHARLES_LECLERC, FERRARI, posicaoLargada: 1, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(242, CORRIDA1010, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 3, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(243, CORRIDA1010, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 4, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(244, CORRIDA1010, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 2, posicaoChegada: 4, pontos: 13, pontoExtra: true),
                    new ResultadoInclusao(245, CORRIDA1010, ALEXANDER_ALBON, REDBULL, posicaoLargada: 14, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(246, CORRIDA1010, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 9, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(247, CORRIDA1010, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 18, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(248, CORRIDA1010, NICO_HULKENBERG, RENAULT, posicaoLargada: 7, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(249, CORRIDA1010, PIERRE_GASLY, TORO_ROSSO, posicaoLargada: 16, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(250, CORRIDA1010, LANCE_STROLL, RACING_POINT, posicaoLargada: 13, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(251, CORRIDA1010, LANDO_NORRIS, MCLAREN, posicaoLargada: 12, posicaoChegada: 11, pontos: 0, motivoDnf: MotivoDNF.Quebra), // última volta, demais não tiraram a diferença
                    new ResultadoInclusao(252, CORRIDA1010, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 10, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(253, CORRIDA1010, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 11, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(254, CORRIDA1010, DANIEL_RICCARDO, RENAULT, posicaoLargada: 6, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(255, CORRIDA1010, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 19, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(256, CORRIDA1010, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 8, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(257, CORRIDA1010, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 20, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(258, CORRIDA1010, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 15, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Colisao),
                    new ResultadoInclusao(259, CORRIDA1010, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 17, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Abandono),
                    new ResultadoInclusao(260, CORRIDA1010, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 5, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Colisao)
                );

            // resultados (1011 - GP DA ITÁLIA - 08/09/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(261, CORRIDA1011, CHARLES_LECLERC, FERRARI, posicaoLargada: 1, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(262, CORRIDA1011, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 3, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(263, CORRIDA1011, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 2, posicaoChegada: 3, pontos: 16, pontoExtra: true),
                    new ResultadoInclusao(264, CORRIDA1011, DANIEL_RICCARDO, RENAULT, posicaoLargada: 5, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(265, CORRIDA1011, NICO_HULKENBERG, RENAULT, posicaoLargada: 6, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(266, CORRIDA1011, ALEXANDER_ALBON, REDBULL, posicaoLargada: 8, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(267, CORRIDA1011, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 15, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(268, CORRIDA1011, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 20, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(269, CORRIDA1011, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 11, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(270, CORRIDA1011, LANDO_NORRIS, MCLAREN, posicaoLargada: 18, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(271, CORRIDA1011, PIERRE_GASLY, TORO_ROSSO, posicaoLargada: 19, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(272, CORRIDA1011, LANCE_STROLL, RACING_POINT, posicaoLargada: 9, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(273, CORRIDA1011, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 16, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(274, CORRIDA1011, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 4, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(275, CORRIDA1011, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 10, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(276, CORRIDA1011, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 14, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(277, CORRIDA1011, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 17, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(278, CORRIDA1011, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 12, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Outros),
                    new ResultadoInclusao(279, CORRIDA1011, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 13, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Outros),
                    new ResultadoInclusao(280, CORRIDA1011, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 7, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Outros) // box: pneu nao preso
                );

            // resultados (1012 - GP DA SINGAPURA - 22/09/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(281, CORRIDA1012, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 3, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(282, CORRIDA1012, CHARLES_LECLERC, FERRARI, posicaoLargada: 1, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(283, CORRIDA1012, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 4, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(284, CORRIDA1012, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 2, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(285, CORRIDA1012, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 5, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(286, CORRIDA1012, ALEXANDER_ALBON, REDBULL, posicaoLargada: 6, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(287, CORRIDA1012, LANDO_NORRIS, MCLAREN, posicaoLargada: 9, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(288, CORRIDA1012, PIERRE_GASLY, TORO_ROSSO, posicaoLargada: 11, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(289, CORRIDA1012, NICO_HULKENBERG, RENAULT, posicaoLargada: 8, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(290, CORRIDA1012, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 10, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(291, CORRIDA1012, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 17, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(292, CORRIDA1012, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 7, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(293, CORRIDA1012, LANCE_STROLL, RACING_POINT, posicaoLargada: 16, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(294, CORRIDA1012, DANIEL_RICCARDO, RENAULT, posicaoLargada: 20, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(295, CORRIDA1012, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 14, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(296, CORRIDA1012, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 19, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(297, CORRIDA1012, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 13, posicaoChegada: 17, pontos: 0, pontoExtra: true),
                    new ResultadoInclusao(298, CORRIDA1012, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 12, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Colisao),
                    new ResultadoInclusao(299, CORRIDA1012, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 15, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Abandono),
                    new ResultadoInclusao(300, CORRIDA1012, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 18, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Colisao)
                );

            // resultados (1013 - GP DA RUSSIA - 29/09/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(301, CORRIDA1013, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 2, posicaoChegada: 1, pontos: 26, pontoExtra: true),
                    new ResultadoInclusao(302, CORRIDA1013, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 5, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(303, CORRIDA1013, CHARLES_LECLERC, FERRARI, posicaoLargada: 1, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(304, CORRIDA1013, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 4, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(305, CORRIDA1013, ALEXANDER_ALBON, REDBULL, posicaoLargada: 20, posicaoChegada: 5, pontos: 10), // largada do box
                    new ResultadoInclusao(306, CORRIDA1013, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 6, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(307, CORRIDA1013, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 12, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(308, CORRIDA1013, LANDO_NORRIS, MCLAREN, posicaoLargada: 8, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(309, CORRIDA1013, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 14, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(310, CORRIDA1013, NICO_HULKENBERG, RENAULT, posicaoLargada: 7, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(311, CORRIDA1013, LANCE_STROLL, RACING_POINT, posicaoLargada: 15, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(312, CORRIDA1013, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 19, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(313, CORRIDA1013, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 16, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(314, CORRIDA1013, PIERRE_GASLY, TORO_ROSSO, posicaoLargada: 11, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(315, CORRIDA1013, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 13, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(316, CORRIDA1013, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 18, posicaoChegada: 16, pontos: 0, motivoDnf: MotivoDNF.Abandono),
                    new ResultadoInclusao(317, CORRIDA1013, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 17, posicaoChegada: 17, pontos: 0, motivoDnf: MotivoDNF.Colisao),
                    new ResultadoInclusao(318, CORRIDA1013, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 3, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Quebra),
                    new ResultadoInclusao(319, CORRIDA1013, DANIEL_RICCARDO, RENAULT, posicaoLargada: 10, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Outros),
                    new ResultadoInclusao(320, CORRIDA1013, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 9, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Colisao)
                );

            // resultados (1014 - GP DO JAPÃO - 13/10/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(321, CORRIDA1014, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 3, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(322, CORRIDA1014, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 1, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(323, CORRIDA1014, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 4, posicaoChegada: 3, pontos: 16, pontoExtra: true),
                    new ResultadoInclusao(324, CORRIDA1014, ALEXANDER_ALBON, REDBULL, posicaoLargada: 6, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(325, CORRIDA1014, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 7, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(326, CORRIDA1014, CHARLES_LECLERC, FERRARI, posicaoLargada: 2, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(327, CORRIDA1014, PIERRE_GASLY, TORO_ROSSO, posicaoLargada: 9, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(328, CORRIDA1014, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 17, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(329, CORRIDA1014, LANCE_STROLL, RACING_POINT, posicaoLargada: 12, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(330, CORRIDA1014, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 14, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(331, CORRIDA1014, LANDO_NORRIS, MCLAREN, posicaoLargada: 8, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(332, CORRIDA1014, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 13, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(333, CORRIDA1014, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 10, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(334, CORRIDA1014, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 11, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(335, CORRIDA1014, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 19, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(336, CORRIDA1014, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 18, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(337, CORRIDA1014, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 20, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(338, CORRIDA1014, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 5, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Colisao),
                    new ResultadoInclusao(339, CORRIDA1014, DANIEL_RICCARDO, RENAULT, posicaoLargada: 16, posicaoChegada: 19, pontos: 0), // desclassificado depois
                    new ResultadoInclusao(340, CORRIDA1014, NICO_HULKENBERG, RENAULT, posicaoLargada: 15, posicaoChegada: 20, pontos: 0) // desclassificado depois
                );

            // resultados (1015 - GP DO MÉXICO - 27/10/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(341, CORRIDA1015, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 3, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(342, CORRIDA1015, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 2, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(343, CORRIDA1015, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 6, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(344, CORRIDA1015, CHARLES_LECLERC, FERRARI, posicaoLargada: 1, posicaoChegada: 4, pontos: 13, pontoExtra: true),
                    new ResultadoInclusao(345, CORRIDA1015, ALEXANDER_ALBON, REDBULL, posicaoLargada: 5, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(346, CORRIDA1015, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 4, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(347, CORRIDA1015, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 11, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(348, CORRIDA1015, DANIEL_RICCARDO, RENAULT, posicaoLargada: 13, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(349, CORRIDA1015, PIERRE_GASLY, TORO_ROSSO, posicaoLargada: 10, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(350, CORRIDA1015, NICO_HULKENBERG, RENAULT, posicaoLargada: 12, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(351, CORRIDA1015, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 9, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(352, CORRIDA1015, LANCE_STROLL, RACING_POINT, posicaoLargada: 16, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(353, CORRIDA1015, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 7, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(354, CORRIDA1015, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 15, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(355, CORRIDA1015, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 17, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(356, CORRIDA1015, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 19, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(357, CORRIDA1015, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 18, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(358, CORRIDA1015, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 20, posicaoChegada: 18, pontos: 0),
                    new ResultadoInclusao(359, CORRIDA1015, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 14, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Abandono),
                    new ResultadoInclusao(360, CORRIDA1015, LANDO_NORRIS, MCLAREN, posicaoLargada: 8, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Abandono)
                );

            // resultados (1016 - GP DO EUA - 03/11/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(361, CORRIDA1016, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 1, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(362, CORRIDA1016, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 5, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(363, CORRIDA1016, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 3, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(364, CORRIDA1016, CHARLES_LECLERC, FERRARI, posicaoLargada: 4, posicaoChegada: 4, pontos: 13, pontoExtra: true),
                    new ResultadoInclusao(365, CORRIDA1016, ALEXANDER_ALBON, REDBULL, posicaoLargada: 6, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(366, CORRIDA1016, DANIEL_RICCARDO, RENAULT, posicaoLargada: 9, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(367, CORRIDA1016, LANDO_NORRIS, MCLAREN, posicaoLargada: 8, posicaoChegada: 7, pontos: 6),
                    new ResultadoInclusao(368, CORRIDA1016, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 7, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(369, CORRIDA1016, NICO_HULKENBERG, RENAULT, posicaoLargada: 11, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(370, CORRIDA1016, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 20, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(371, CORRIDA1016, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 17, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(372, CORRIDA1016, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 13, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(373, CORRIDA1016, LANCE_STROLL, RACING_POINT, posicaoLargada: 14, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(374, CORRIDA1016, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 16, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(375, CORRIDA1016, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 15, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(376, CORRIDA1016, PIERRE_GASLY, TORO_ROSSO, posicaoLargada: 10, posicaoChegada: 16, pontos: 0, motivoDnf: MotivoDNF.Outros),
                    new ResultadoInclusao(377, CORRIDA1016, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 18, posicaoChegada: 17, pontos: 0),
                    new ResultadoInclusao(378, CORRIDA1016, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 12, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Quebra),
                    new ResultadoInclusao(379, CORRIDA1016, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 19, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Abandono),
                    new ResultadoInclusao(380, CORRIDA1016, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 2, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Quebra)
                );

            // resultados (1017 - GP DO BRASIL - 17/11/2019)
            modelBuilder.Entity<Resultado>().HasData(
                    new ResultadoInclusao(381, CORRIDA1017, MAX_VERSTAPPEN, REDBULL, posicaoLargada: 1, posicaoChegada: 1, pontos: 25),
                    new ResultadoInclusao(382, CORRIDA1017, PIERRE_GASLY, TORO_ROSSO, posicaoLargada: 6, posicaoChegada: 2, pontos: 18),
                    new ResultadoInclusao(383, CORRIDA1017, CARLOS_SAINZ_JR, MCLAREN, posicaoLargada: 20, posicaoChegada: 3, pontos: 15),
                    new ResultadoInclusao(384, CORRIDA1017, KIMI_RAIKKONEN, ALFA_ROMEO, posicaoLargada: 8, posicaoChegada: 4, pontos: 12),
                    new ResultadoInclusao(385, CORRIDA1017, ANTONIO_GIOVANAZZI, ALFA_ROMEO, posicaoLargada: 12, posicaoChegada: 5, pontos: 10),
                    new ResultadoInclusao(386, CORRIDA1017, DANIEL_RICCARDO, RENAULT, posicaoLargada: 11, posicaoChegada: 6, pontos: 8),
                    new ResultadoInclusao(387, CORRIDA1017, LEWIS_HAMILTON, MERCEDES, posicaoLargada: 3, posicaoChegada: 7, pontos: 6), // chegou em 3o, punido 5s, caiu pra 7
                    new ResultadoInclusao(388, CORRIDA1017, LANDO_NORRIS, MCLAREN, posicaoLargada: 10, posicaoChegada: 8, pontos: 4),
                    new ResultadoInclusao(389, CORRIDA1017, SERGIO_PEREZ, RACING_POINT, posicaoLargada: 15, posicaoChegada: 9, pontos: 2),
                    new ResultadoInclusao(390, CORRIDA1017, DANIIL_KVYAT, TORO_ROSSO, posicaoLargada: 16, posicaoChegada: 10, pontos: 1),
                    new ResultadoInclusao(391, CORRIDA1017, KEVIN_MAGNUSSEN, HAAS, posicaoLargada: 9, posicaoChegada: 11, pontos: 0),
                    new ResultadoInclusao(392, CORRIDA1017, NICO_HULKENBERG, RENAULT, posicaoLargada: 13, posicaoChegada: 12, pontos: 0),
                    new ResultadoInclusao(393, CORRIDA1017, GEORGE_RUSSEL, WILLIAMS, posicaoLargada: 18, posicaoChegada: 13, pontos: 0),
                    new ResultadoInclusao(394, CORRIDA1017, ROMAIN_GROSJEAN, HAAS, posicaoLargada: 7, posicaoChegada: 14, pontos: 0),
                    new ResultadoInclusao(395, CORRIDA1017, ROBERT_KUBICA, WILLIAMS, posicaoLargada: 19, posicaoChegada: 15, pontos: 0),
                    new ResultadoInclusao(396, CORRIDA1017, ALEXANDER_ALBON, REDBULL, posicaoLargada: 5, posicaoChegada: 16, pontos: 0),
                    new ResultadoInclusao(397, CORRIDA1017, SEBASTIAN_VETTEL, FERRARI, posicaoLargada: 2, posicaoChegada: 17, pontos: 0, motivoDnf: MotivoDNF.Colisao),
                    new ResultadoInclusao(398, CORRIDA1017, LANCE_STROLL, RACING_POINT, posicaoLargada: 17, posicaoChegada: 18, pontos: 0, motivoDnf: MotivoDNF.Quebra),
                    new ResultadoInclusao(399, CORRIDA1017, CHARLES_LECLERC, FERRARI, posicaoLargada: 14, posicaoChegada: 19, pontos: 0, motivoDnf: MotivoDNF.Colisao),
                    new ResultadoInclusao(400, CORRIDA1017, VALTTERI_BOTTAS, MERCEDES, posicaoLargada: 4, posicaoChegada: 20, pontos: 0, motivoDnf: MotivoDNF.Quebra, pontoExtra: true)
                );
        }
    }
}