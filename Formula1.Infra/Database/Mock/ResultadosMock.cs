using Formula1.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Infra.Database.Mock
{
    public class ResultadosMock
    {
        public static ICollection<Corrida> PreencherResultados998(ICollection<Corrida> corridas)
        {
            var corrida998 = corridas.Where(o => o.Id == 998).FirstOrDefault();
            if (corrida998 != null)
            {
                corrida998.Resultados.Add(new Resultado(1, corrida998, PilotosMock.VALTTERI_BOTTAS, EquipesMock.MERCEDES, 2, 1, 26));
                corrida998.Resultados.Add(new Resultado(2, corrida998, PilotosMock.LEWIS_HAMILTON, EquipesMock.MERCEDES, 1, 2, 18));
                corrida998.Resultados.Add(new Resultado(3, corrida998, PilotosMock.MAX_VERSTAPPEN, EquipesMock.REDBULL, 4, 3, 15));
                corrida998.Resultados.Add(new Resultado(4, corrida998, PilotosMock.SEBASTIAN_VETTEL, EquipesMock.FERRARI, 3, 4, 12));
                corrida998.Resultados.Add(new Resultado(5, corrida998, PilotosMock.CHARLES_LECLERC, EquipesMock.FERRARI, 5, 5, 10));
                corrida998.Resultados.Add(new Resultado(6, corrida998, PilotosMock.KEVIN_MAGNUSSEN, EquipesMock.HAAS, 7, 6, 8));
                corrida998.Resultados.Add(new Resultado(7, corrida998, PilotosMock.NICO_HULKENBERG, EquipesMock.RENAULT, 11, 7, 6));
                corrida998.Resultados.Add(new Resultado(8, corrida998, PilotosMock.KIMI_RAIKKONEN, EquipesMock.ALFA_ROMEO, 9, 8, 4));
                corrida998.Resultados.Add(new Resultado(9, corrida998, PilotosMock.LANCE_STROLL, EquipesMock.RACING_POINT, 16, 9, 2));
                corrida998.Resultados.Add(new Resultado(10, corrida998, PilotosMock.DANIIL_KVYAT, EquipesMock.TORO_ROSSO, 15, 10, 1));
                corrida998.Resultados.Add(new Resultado(11, corrida998, PilotosMock.PIERRE_GASLY, EquipesMock.REDBULL, 17, 11, 0));
                corrida998.Resultados.Add(new Resultado(12, corrida998, PilotosMock.LANDO_NORRIS, EquipesMock.MCLAREN, 8, 12, 0));
                corrida998.Resultados.Add(new Resultado(13, corrida998, PilotosMock.SERGIO_PEREZ, EquipesMock.RACING_POINT, 10, 13, 0));
                corrida998.Resultados.Add(new Resultado(14, corrida998, PilotosMock.ALEXANDER_ALBON, EquipesMock.TORO_ROSSO, 13, 14, 0));
                corrida998.Resultados.Add(new Resultado(15, corrida998, PilotosMock.ANTONIO_GIOVANAZZI, EquipesMock.ALFA_ROMEO, 14, 15, 0));
                corrida998.Resultados.Add(new Resultado(16, corrida998, PilotosMock.GEORGE_RUSSEL, EquipesMock.WILLIAMS, 19, 16, 0));
                corrida998.Resultados.Add(new Resultado(17, corrida998, PilotosMock.ROBERT_KUBICA, EquipesMock.WILLIAMS, 20, 17, 0));
                corrida998.Resultados.Add(new Resultado(18, corrida998, PilotosMock.ROMAIN_GROSJEAN, EquipesMock.HAAS, 6, 18, 0, MotivoDNF.Pneu));
                corrida998.Resultados.Add(new Resultado(19, corrida998, PilotosMock.DANIEL_RICCARDO, EquipesMock.RENAULT, 12, 19, 0, MotivoDNF.Colisao));
                corrida998.Resultados.Add(new Resultado(20, corrida998, PilotosMock.CARLOS_SAINZ_JR, EquipesMock.MCLAREN, 18, 20, 0, MotivoDNF.Motor));
            }

            return corridas;
        }

        public static ICollection<Corrida> PreencherResultados999(ICollection<Corrida> corridas)
        {
            var corrida999 = corridas.Where(o => o.Id == 999).FirstOrDefault();
            if (corrida999 != null)
            {
                corrida999.Resultados.Add(new Resultado(21, corrida999, PilotosMock.LEWIS_HAMILTON, EquipesMock.MERCEDES, 3, 1, 25));
                corrida999.Resultados.Add(new Resultado(22, corrida999, PilotosMock.VALTTERI_BOTTAS, EquipesMock.MERCEDES, 4, 2, 18));
                corrida999.Resultados.Add(new Resultado(23, corrida999, PilotosMock.CHARLES_LECLERC, EquipesMock.FERRARI, 1, 3, 16));
                corrida999.Resultados.Add(new Resultado(24, corrida999, PilotosMock.MAX_VERSTAPPEN, EquipesMock.REDBULL, 5, 4, 12));
                corrida999.Resultados.Add(new Resultado(25, corrida999, PilotosMock.SEBASTIAN_VETTEL, EquipesMock.FERRARI, 2, 5, 10));
                corrida999.Resultados.Add(new Resultado(26, corrida999, PilotosMock.LANDO_NORRIS, EquipesMock.MCLAREN, 9, 6, 8));
                corrida999.Resultados.Add(new Resultado(27, corrida999, PilotosMock.KIMI_RAIKKONEN, EquipesMock.ALFA_ROMEO, 8, 7, 6));
                corrida999.Resultados.Add(new Resultado(28, corrida999, PilotosMock.PIERRE_GASLY, EquipesMock.REDBULL, 13, 8, 4));
                corrida999.Resultados.Add(new Resultado(29, corrida999, PilotosMock.ALEXANDER_ALBON, EquipesMock.TORO_ROSSO, 12, 9, 2));
                corrida999.Resultados.Add(new Resultado(30, corrida999, PilotosMock.SERGIO_PEREZ, EquipesMock.RACING_POINT, 14, 10, 1));
                corrida999.Resultados.Add(new Resultado(31, corrida999, PilotosMock.ANTONIO_GIOVANAZZI, EquipesMock.ALFA_ROMEO, 16, 11, 0));
                corrida999.Resultados.Add(new Resultado(32, corrida999, PilotosMock.DANIIL_KVYAT, EquipesMock.TORO_ROSSO, 15, 12, 0));
                corrida999.Resultados.Add(new Resultado(33, corrida999, PilotosMock.KEVIN_MAGNUSSEN, EquipesMock.HAAS, 6, 13, 0));
                corrida999.Resultados.Add(new Resultado(34, corrida999, PilotosMock.LANCE_STROLL, EquipesMock.RACING_POINT, 18, 14, 0));
                corrida999.Resultados.Add(new Resultado(35, corrida999, PilotosMock.GEORGE_RUSSEL, EquipesMock.WILLIAMS, 19, 15, 0));
                corrida999.Resultados.Add(new Resultado(36, corrida999, PilotosMock.ROBERT_KUBICA, EquipesMock.WILLIAMS, 20, 16, 0));
                corrida999.Resultados.Add(new Resultado(37, corrida999, PilotosMock.NICO_HULKENBERG, EquipesMock.RENAULT, 17, 17, 6));
                corrida999.Resultados.Add(new Resultado(38, corrida999, PilotosMock.DANIEL_RICCARDO, EquipesMock.RENAULT, 10, 18, 0));
                corrida999.Resultados.Add(new Resultado(39, corrida999, PilotosMock.CARLOS_SAINZ_JR, EquipesMock.MCLAREN, 7, 19, 0));
                corrida999.Resultados.Add(new Resultado(40, corrida999, PilotosMock.ROMAIN_GROSJEAN, EquipesMock.HAAS, 11, 20, 0, MotivoDNF.Danos));

            }

            return corridas;
        }

        public static ICollection<Corrida> PreencherResultados1000(ICollection<Corrida> corridas)
        {
            var corrida1000 = corridas.Where(o => o.Id == 1000).FirstOrDefault();
            if (corrida1000 != null)
            {
                corrida1000.Resultados.Add(new Resultado(41, corrida1000, PilotosMock.LEWIS_HAMILTON, EquipesMock.MERCEDES, 2, 1, 25));
                corrida1000.Resultados.Add(new Resultado(42, corrida1000, PilotosMock.VALTTERI_BOTTAS, EquipesMock.MERCEDES, 1, 2, 18));
                corrida1000.Resultados.Add(new Resultado(43, corrida1000, PilotosMock.SEBASTIAN_VETTEL, EquipesMock.FERRARI, 3, 3, 15));
                corrida1000.Resultados.Add(new Resultado(44, corrida1000, PilotosMock.MAX_VERSTAPPEN, EquipesMock.REDBULL, 5, 4, 12));
                corrida1000.Resultados.Add(new Resultado(45, corrida1000, PilotosMock.CHARLES_LECLERC, EquipesMock.FERRARI, 4, 5, 10));
                corrida1000.Resultados.Add(new Resultado(46, corrida1000, PilotosMock.PIERRE_GASLY, EquipesMock.REDBULL, 6, 6, 9));
                corrida1000.Resultados.Add(new Resultado(47, corrida1000, PilotosMock.DANIEL_RICCARDO, EquipesMock.RENAULT, 7, 7, 6));
                corrida1000.Resultados.Add(new Resultado(48, corrida1000, PilotosMock.SERGIO_PEREZ, EquipesMock.RACING_POINT, 12, 8, 4));
                corrida1000.Resultados.Add(new Resultado(49, corrida1000, PilotosMock.KIMI_RAIKKONEN, EquipesMock.ALFA_ROMEO, 13, 9, 2));
                corrida1000.Resultados.Add(new Resultado(50, corrida1000, PilotosMock.ALEXANDER_ALBON, EquipesMock.TORO_ROSSO, 0, 10, 1)); // PL
                corrida1000.Resultados.Add(new Resultado(51, corrida1000, PilotosMock.ROMAIN_GROSJEAN, EquipesMock.HAAS, 10, 11, 0));
                corrida1000.Resultados.Add(new Resultado(52, corrida1000, PilotosMock.LANCE_STROLL, EquipesMock.RACING_POINT, 16, 12, 0));
                corrida1000.Resultados.Add(new Resultado(53, corrida1000, PilotosMock.KEVIN_MAGNUSSEN, EquipesMock.HAAS, 9, 13, 0));
                corrida1000.Resultados.Add(new Resultado(54, corrida1000, PilotosMock.CARLOS_SAINZ_JR, EquipesMock.MCLAREN, 14, 14, 0));
                corrida1000.Resultados.Add(new Resultado(55, corrida1000, PilotosMock.ANTONIO_GIOVANAZZI, EquipesMock.ALFA_ROMEO, 0, 15, 0)); // PL
                corrida1000.Resultados.Add(new Resultado(56, corrida1000, PilotosMock.GEORGE_RUSSEL, EquipesMock.WILLIAMS, 17, 16, 0));
                corrida1000.Resultados.Add(new Resultado(57, corrida1000, PilotosMock.ROBERT_KUBICA, EquipesMock.WILLIAMS, 18, 17, 0));
                corrida1000.Resultados.Add(new Resultado(58, corrida1000, PilotosMock.LANDO_NORRIS, EquipesMock.MCLAREN, 15, 18, 8, MotivoDNF.Danos));
                corrida1000.Resultados.Add(new Resultado(59, corrida1000, PilotosMock.DANIIL_KVYAT, EquipesMock.TORO_ROSSO, 11, 19, 0, MotivoDNF.Danos));
                corrida1000.Resultados.Add(new Resultado(60, corrida1000, PilotosMock.NICO_HULKENBERG, EquipesMock.RENAULT, 8, 20, 0, MotivoDNF.Motor));
            }

            return corridas;
        }
    }
}