using System.Collections.Generic;

namespace Formula1.Data.ValueObjects.CalculosPontos;

public class CalculoPontosSprint2020 : Base.CalculoPontos
{
    public override Dictionary<int, double> PontosPorPosicao => new Dictionary<int, double>();

    public override bool VoltaMaisRapidaPontua => false;
}