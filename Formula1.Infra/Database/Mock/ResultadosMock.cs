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

        public static ICollection<Corrida> PreencherResultados1000(ICollection<Corrida> corridas)
        {
            var corrida1000 = corridas.Where(o => o.Id == 1000).FirstOrDefault();
            if (corrida1000 != null)
            {
                corrida1000.Resultados.Add(new Resultado(1, corrida1000, PilotosMock.VALTTERI_BOTTAS, EquipesMock.MERCEDES, 1, 2, 18));
            }

            return corridas;
        }
    }
}