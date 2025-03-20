using System.Collections.Generic;

namespace Formula1.Data.ValueObjects.CalculosPontos;

public class CalculoPontosGp2019 : Base.CalculoPontos
{
    public override Dictionary<int, double> PontosPorPosicao => new Dictionary<int, double>()
    {
        { 1, 25D },
        { 2, 18D },
        { 3, 15D },
        { 4, 12D },
        { 5, 10D },
        { 6, 8D },
        { 7, 6D },
        { 8, 4D },
        { 9, 2D },
        { 10, 1D },
    };

    public override bool VoltaMaisRapidaPontua => true;
}