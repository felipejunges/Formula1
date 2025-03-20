using System;
using Formula1.Data.ValueObjects.CalculosPontos.Base;

namespace Formula1.Data.ValueObjects.CalculosPontos.Factories;

public static class CalculoPontosFactory
{
    public static CalculoPontos CriarCalculoPontos(int temporada, bool corridaSprint)
    {
        if (corridaSprint && temporada <= 2020) return new CalculoPontosSprint2020();
        if (corridaSprint && temporada == 2021) return new CalculoPontosSprint2021();
        if (corridaSprint && temporada >= 2022) return new CalculoPontosSprint2022();
            
        if (!corridaSprint && temporada < 2025) return new CalculoPontosGp2019();
        if (!corridaSprint && temporada >= 2025) return new CalculoPontosGp2025();

        throw new ArgumentException($"Cálculo de pontos inválido - Sprint: {corridaSprint} - Temporada: {temporada}");
    }
}