using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Corridas;
using Formula1.Infra.Database;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class CorridasService
    {
        private readonly F1Db Db;

        public CorridasService(F1Db db)
        {
            Db = db;
        }

        public Corrida ObterPeloId(int id)
        {
            var corrida = Db.Corridas.Find(id);

            return corrida;
        }

        public List<CorridaTemporada> GetCorridasTabela(int temporada)
        {
            var corridas = Db.Corridas.Where(o => o.Temporada == temporada).OrderBy(o => o.DataHoraBrasil).Select(o => new CorridaTemporada()
            {
                Id = o.Id,
                DataHoraBrasil = o.DataHoraBrasil,
                NomeGrandePremio = o.NomeGrandePremio
            }).ToList();

            return corridas;
        }

        public List<CorridaLista> GetCorridasLista(int temporada)
        {
            var corridas = Db.Corridas.Where(o => o.Temporada == temporada).OrderBy(o => o.DataHoraBrasil).Select(o => new CorridaLista()
            {
                Id = o.Id,
                DataHoraBrasil = o.DataHoraBrasil,
                NomeGrandePremio = o.NomeGrandePremio,
                Circuito = o.Circuito
            }).ToList();

            return corridas;
        }

        public void Incluir(CorridaDados corridaDados)
        {
            var corrida = new Corrida()
            {
                Id = corridaDados.Id,
                Temporada = corridaDados.Temporada,
                NomeGrandePremio = corridaDados.NomeGrandePremio,
                Circuito = corridaDados.Circuito,
                DataHoraBrasil = corridaDados.DataHoraBrasil.Value
            };

            Db.Corridas.Add(corrida);
            Db.SaveChanges();
        }

        public void Alterar(CorridaDados corridaDados)
        {
            var corrida = ObterPeloId(corridaDados.Id);

            corrida.Temporada = corridaDados.Temporada;
            corrida.NomeGrandePremio = corridaDados.NomeGrandePremio;
            corrida.Circuito = corridaDados.Circuito;
            corrida.DataHoraBrasil = corridaDados.DataHoraBrasil.Value;

            Db.Corridas.Update(corrida);
            Db.SaveChanges();
        }

        public void Excluir(Corrida corrida)
        {
            Db.Corridas.Remove(corrida);
            Db.SaveChanges();
        }
    }
}