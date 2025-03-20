using System.Collections.Generic;

namespace Formula1.Data.ValueObjects.CalculosPontos;

public class CalculoPontosSprint2022 : Base.CalculoPontos
{
    public override Dictionary<int, double> PontosPorPosicao => new Dictionary<int, double>()
    {
        { 1, 8D },
        { 2, 7D },
        { 3, 6D },
        { 4, 5D },
        { 5, 4D },
        { 6, 3D },
        { 7, 2D },
        { 8, 1D }
    };

    public override bool VoltaMaisRapidaPontua => false;
}