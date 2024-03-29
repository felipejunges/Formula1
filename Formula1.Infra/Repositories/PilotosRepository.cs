using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Pilotos;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Infra.Repositories
{
    public class PilotosRepository : IPilotosRepository
    {
        private readonly F1Db Db;

        public PilotosRepository(F1Db db)
        {
            Db = db;
        }

        public Piloto? ObterPeloId(int id)
        {
            return Db.Pilotos.Find(id);
        }

        public List<PilotoLista> ObterPilotosLista()
        {
            var pilotos = Db.Pilotos.OrderBy(o => o.Nome).Select(o => new PilotoLista(o)).ToList();

            return pilotos;
        }

        public List<Piloto> ObterPilotosAtivos()
        {
            var pilotos = Db.Pilotos.Where(o => o.Ativo).OrderBy(o => o.NomeGuerra).ToList();

            return pilotos;
        }

        public List<Piloto> ObterPilotosContrato(int temporada)
        {
            var pilotos = Db.Contratos.Where(o => o.Temporada == temporada).Select(o => o.Piloto).ToList();

            return pilotos;
        }

        public List<PilotoTemporadaResultado> ObterPilotosTabela(int temporada)
        {
            var pilotos = Db.PilotosTemporada
                            .Include(pt => pt.Piloto)
                                .ThenInclude(p => p.Contratos)
                                .ThenInclude(c => c.Equipe)
                            .Where(pt => pt.Temporada == temporada)
                            .AsEnumerable()
                            .Select(pt => new PilotoTemporadaResultado()
                            {
                                Id = pt.Piloto.Id,
                                NomeGuerra = pt.Piloto.NomeGuerra,
                                CorRgb = pt.Piloto.Contratos.Where(o => o.Temporada == temporada).OrderByDescending(o => o.Id).FirstOrDefault()?.Equipe.CorRgb ?? "#000000",
                                Pontos = pt.Pontos,
                                Posicao = pt.Posicao,
                                PosicaoMaxima = pt.PosicaoMaxima
                            })
                            .ToList();

            return pilotos;
        }

        public void Incluir(PilotoDados pilotoDados)
        {
            var piloto = new Piloto(
                id: 0,
                nome: pilotoDados.Nome,
                nomeGuerra: pilotoDados.NomeGuerra,
                sigla: pilotoDados.Sigla,
                numeroCarro: pilotoDados.NumeroCarro!.Value,
                paisOrigem: pilotoDados.PaisOrigem,
                ativo: pilotoDados.Ativo);

            Db.Pilotos.Add(piloto);
            Db.SaveChanges();
        }

        public void Alterar(PilotoDados pilotoDados)
        {
            var piloto = ObterPeloId(pilotoDados.Id);

            if (piloto is null)
                return;

            piloto.Atualizar(
                nome: pilotoDados.Nome,
                nomeGuerra: pilotoDados.NomeGuerra,
                sigla: pilotoDados.Sigla,
                numeroCarro: pilotoDados.NumeroCarro!.Value,
                paisOrigem: pilotoDados.PaisOrigem,
                ativo: pilotoDados.Ativo);

            Db.Pilotos.Update(piloto);
            Db.SaveChanges();
        }

        public void Excluir(Piloto piloto)
        {
            Db.Pilotos.Remove(piloto);
            Db.SaveChanges();
        }
    }
}