namespace Formula1.Data.Models;

public class ResultadoTemporadaPiloto
{
    public int PilotoId { get; set; }

    public int CorridaId { get; set; }
        
    public bool Sprint { get; set; }

    public double Pontos { get; set; }

    public bool VoltaMaisRapida { get; set; }

    public int PosicaoChegada { get; set; }

    public bool DNF { get; set; }

    public bool DSQ { get; set; }
}