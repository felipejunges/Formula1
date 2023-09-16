namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoEquipePilotos
    {
        public int EquipeId { get; private set; }

        public int[] PilotosId { get; private set; }

        public ResultadoEquipePilotos(int equipeId, int[] pilotosId)
        {
            EquipeId = equipeId;
            PilotosId = pilotosId;
        }
    }
}