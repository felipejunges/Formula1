namespace Formula1.Data.Models;

public class ResultadoTemporadaEquipe
{
    public int EquipeId { get; set; }

    public int CorridaId { get; set; }
        
    public bool Sprint { get; set; }

    public int MelhorPosicaoChegada { get; set; }
    
    public double PontosTotais { get; set; }

    public bool VoltaMaisRapida { get; set; }
}