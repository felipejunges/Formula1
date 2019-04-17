using Formula1.Data.Entities;
using System;
using System.Collections.Generic;

namespace Formula1.Infra.Database.Mock
{
    public class CorridasMock
    {
        public static List<Corrida> Corridas = new List<Corrida>
        {
            new Corrida(998, 2019, "GP da Austrália", "Circuito de Albert Park", new DateTime(2019, 3, 17, 2, 10, 0)),
            new Corrida(999, 2019, "GP do Bahrein", "Circuito Internacional do Bahrein", new DateTime(2019, 3, 31, 12, 10, 0)),
            new Corrida(1000, 2019, "GP da China", "Circuito Internacional de Xangai", new DateTime(2019, 4, 14, 03, 10, 0)),
            new Corrida(1001, 2019, "GP do Azerbaijão", "Curcuito Urbano de Baku", new DateTime(2019, 4, 28, 9, 10, 0)),
            new Corrida(1002, 2019, "GP da Espanha", "Circuito da Catalunha", new DateTime(2019, 5, 12, 10, 10, 0)),
            new Corrida(1003, 2019, "GP de Mônaco", "Circuito de Mônaco", new DateTime(2019, 5, 26, 10, 10, 0)),
            new Corrida(1004, 2019, "GP do Canadá", "Circuito Gilles Villeneuve", new DateTime(2019, 6, 9, 15, 10, 0)),
            new Corrida(1005, 2019, "GP da França", "Circuito Paul Ricard", new DateTime(2019, 6, 23, 10, 10, 0)),
            new Corrida(1006, 2019, "GP da Áustria", "Red Bull Ring", new DateTime(2019, 6, 30, 10, 10, 0)),
            new Corrida(1007, 2019, "GP da Grã-Bretanha", "Silverstone", new DateTime(2019, 7, 14, 11, 10, 0)),
            new Corrida(1008, 2019, "GP da Alemanha", "Hockenheimring", new DateTime(2019, 7, 28, 10, 10, 0)),
            new Corrida(1009, 2019, "GP da Hungria", "Hungaroring", new DateTime(2019, 8, 4, 10, 10, 0)),
            new Corrida(1010, 2019, "GP da Bélgica", "Spa-Francorchamps", new DateTime(2019, 9, 1, 10, 10, 0)),
            new Corrida(1011, 2019, "GP da Itália", "Circuito de Monza", new DateTime(2019, 9, 8, 10, 10, 0)),
            new Corrida(1012, 2019, "GP de Singapura", "Circuito Urbano de Marina Bay", new DateTime(2019, 9, 22, 9, 10, 0)),
            new Corrida(1013, 2019, "GP da Rússia", "Autódromo de Sóchi", new DateTime(2019, 9, 29, 8, 10, 0)),
            new Corrida(1014, 2019, "GP do Japão", "Circuito de Suzuka", new DateTime(2019, 10, 13, 2, 10, 0)),
            new Corrida(1015, 2019, "GP do México", "Autódromo Hermanos Rodríguez", new DateTime(2019, 10, 27, 16, 10, 0)),
            new Corrida(1016, 2019, "GP dos Estados Unidos", "Circuito das Américas", new DateTime(2019, 11, 3, 17, 10, 0)),
            new Corrida(1017, 2019, "GP do Brasil", "Autódromo José Carlos Pace", new DateTime(2019, 11, 17, 15, 10, 0)),
            new Corrida(1018, 2019, "GP do Abu Dhabi", "Circuito de Yas Marina", new DateTime(2019, 12, 1, 11, 10, 0))
        };
    }
}