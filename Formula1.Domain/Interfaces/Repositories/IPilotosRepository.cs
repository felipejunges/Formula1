using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Pilotos;
using System.Collections.Generic;

namespace Formula1.Domain.Interfaces.Repositories
{
    public interface IPilotosRepository
    {
        Piloto? ObterPeloId(int id);

        List<PilotoLista> ObterPilotosLista();

        List<Piloto> ObterPilotosAtivos();

        List<Piloto> ObterPilotosContrato(int temporada);

        List<PilotoTemporadaResultado> ObterPilotosTabela(int temporada);

        void Incluir(PilotoDados pilotoDados);

        void Alterar(PilotoDados pilotoDados);

        void Excluir(Piloto piloto);
    }
}