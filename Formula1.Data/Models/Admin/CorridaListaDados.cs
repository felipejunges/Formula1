using System.Collections.Generic;

namespace Formula1.Data.Models.Admin
{
    public class CorridaListaDados
    {
        public CorridaDados Dados { get; set; }
        public List<CorridaLista> Corridas { get; set; }

        public CorridaListaDados(CorridaDados dados, List<CorridaLista> corridas)
        {
            Dados = dados;
            Corridas = corridas;
        }
    }
}