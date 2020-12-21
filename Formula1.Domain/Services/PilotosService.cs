using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Pilotos;
using Formula1.Infra.Database.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class PilotosService
    {
        private readonly F1Db Db;

        public PilotosService(F1Db db)
        {
            Db = db;
        }

        public Piloto ObterPeloId(int id)
        {
            var piloto = Db.Pilotos.Find(id);

            return piloto;
        }

        public List<PilotoLista> ObterPilotosLista()
        {
            var pilotos = Db.Pilotos.OrderBy(o => o.Nome).Select(o => new PilotoLista(o)).ToList();

            return pilotos;
        }

        public List<Piloto> ObterPilotosContrato(int temporada)
        {
            var pilotos = Db.Contratos.Where(o => o.Temporada == temporada).Select(o => o.Piloto).ToList();

            return pilotos;
        }

        public List<PilotoTemporadaResultado> ObterPilotosTabela(int temporada)
        {
            var pilotos = (from pt in Db.PilotosTemporada
                           join p in Db.Pilotos on pt.Piloto equals p
                           where pt.Temporada == temporada
                           select new PilotoTemporadaResultado()
                           {
                               Id = p.Id,
                               NomeGuerra = p.NomeGuerra,
                               CorRgb = p.Contratos.Where(o => o.Temporada == temporada).OrderByDescending(o => o.Id).FirstOrDefault().Equipe.CorRgb,
                               Pontos = pt.Pontos,
                               Posicao = pt.Posicao
                           }).ToList();

            return pilotos;
        }

        public void Incluir(PilotoDados pilotoDados)
        {
            var piloto = new Piloto()
            {
                Id = 0,
                Nome = pilotoDados.Nome,
                NomeGuerra = pilotoDados.NomeGuerra,
                Sigla = pilotoDados.Sigla,
                NumeroCarro = pilotoDados.NumeroCarro.Value,
                PaisOrigem = pilotoDados.PaisOrigem
            };

            Db.Pilotos.Add(piloto);
            Db.SaveChanges();
        }

        public void Alterar(PilotoDados pilotoDados)
        {
            var piloto = ObterPeloId(pilotoDados.Id);

            piloto.Nome = pilotoDados.Nome;
            piloto.NomeGuerra = pilotoDados.NomeGuerra;
            piloto.Sigla = pilotoDados.Sigla;
            piloto.NumeroCarro = pilotoDados.NumeroCarro.Value;
            piloto.PaisOrigem = pilotoDados.PaisOrigem;

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