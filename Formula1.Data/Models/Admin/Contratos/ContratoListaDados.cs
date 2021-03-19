using System.Collections.Generic;

namespace Formula1.Data.Models.Admin.Contratos
{
    public class ContratoListaDados
    {
        public ContratoDados Dados { get; set; }
        public List<ContratoLista> Contratos { get; set; }

        public ContratoListaDados(ContratoDados dados, List<ContratoLista> contratos)
        {
            Dados = dados;
            Contratos = contratos;
        }
    }
}