using System.Collections.Generic;

namespace Formula1.Data.ValueObjects.CalculosPontos.Base;

public abstract class CalculoPontos
{
    public abstract Dictionary<int, double> PontosPorPosicao { get; }
    
    public abstract bool VoltaMaisRapidaPontua { get; }
    
    public double CalcularPontos(int posicaoChegada, bool voltaMaisRapida)
    {
        var pontos = PontosPorPosicao.ContainsKey(posicaoChegada) ? PontosPorPosicao[posicaoChegada] : 0;
        
        int pontoExtra = VoltaMaisRapidaPontua && voltaMaisRapida && posicaoChegada <= 10 ? 1 : 0;
        
        return pontos + pontoExtra;
    }

    public double MaximoPontosPiloto => BuscarPontosPelaPosicao(1) + (VoltaMaisRapidaPontua ? 1 : 0);
    
    public double MaximoPontosEquipe => BuscarPontosPelaPosicao(1) + BuscarPontosPelaPosicao(2) + (VoltaMaisRapidaPontua ? 1 : 0);

    private double BuscarPontosPelaPosicao(int posicao)
    {
        return PontosPorPosicao.ContainsKey(posicao) ? PontosPorPosicao[posicao] : 0;
    }
}