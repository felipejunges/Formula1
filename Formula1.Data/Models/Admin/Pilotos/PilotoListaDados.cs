using System.Collections.Generic;

namespace Formula1.Data.Models.Admin.Pilotos
{
    public class PilotoListaDados
    {
        public PilotoDados Dados { get; set; }
        public List<PilotoLista> Pilotos { get; set; }

        public PilotoListaDados(PilotoDados dados, List<PilotoLista> pilotos)
        {
            Dados = dados;
            Pilotos = pilotos;
        }
    }
}