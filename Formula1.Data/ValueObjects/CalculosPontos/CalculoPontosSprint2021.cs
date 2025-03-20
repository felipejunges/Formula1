using System.Collections.Generic;

namespace Formula1.Data.ValueObjects.CalculosPontos;

public class CalculoPontosSprint2021 : Base.CalculoPontos
{
    public override Dictionary<int, double> PontosPorPosicao => new Dictionary<int, double>()
    {
        { 1, 3D },
        { 2, 2D },
        { 3, 1D }
    };

    public override bool VoltaMaisRapidaPontua => false;
}