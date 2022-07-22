using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Corridas;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Infra.Repositories
{
    public class CorridasRepository : ICorridasRepository
    {
        private readonly F1Db Db;

        public CorridasRepository(F1Db db)
        {
            Db = db;
        }

        public Corrida? ObterPeloId(int id)
        {
            return Db.Corridas.Find(id);
        }

        public List<CorridaTemporada> GetCorridasTabela(int temporada)
        {
            var corridas = Db.Corridas
                .Include(c => c.Resultados)
                .Where(o => o.Temporada == temporada)
                .OrderBy(o => o.DataHoraBrasil)
                .AsEnumerable() // para poder usar o construtor abaixo
                .Select(o => new CorridaTemporada(
                    id: o.Id,
                    dataHoraBrasil: o.DataHoraBrasil,
                    nomeGrandePremio: o.NomeGrandePremio,
                    temResultadosDeCorrida: o.TemResultadoDeCorrida
                ))
                .ToList();

            return corridas;
        }

        public List<CorridaLista> GetCorridasLista(int temporada)
        {
            var corridas = Db.Corridas
                .Where(o => o.Temporada == temporada)
                .OrderBy(o => o.DataHoraBrasil)
                .AsEnumerable()
                .Select(o => new CorridaLista(
                    id: o.Id,
                    numeroCorrida: o.NumeroCorrida,
                    dataHoraBrasil: o.DataHoraBrasil,
                    nomeGrandePremio: o.NomeGrandePremio,
                    circuito: o.Circuito
                ))
                .ToList();

            return corridas;
        }

        public List<Corrida> ObterCorridasRestantes(int temporada)
        {
            return Db.Corridas
                        .Include(o => o.Resultados)
                        .Where(o => o.Temporada == temporada)
                        .AsEnumerable()
                        .Where(o => !o.TemResultadoDeCorrida)
                        .ToList();
        }

        public void Incluir(CorridaDados corridaDados)
        {
            var corrida = new Corrida(
                id: 0,
                numeroCorrida: corridaDados.NumeroCorrida!.Value,
                temporada: corridaDados.Temporada,
                nomeGrandePremio: corridaDados.NomeGrandePremio,
                circuito: corridaDados.Circuito,
                dataHoraBrasil: corridaDados.DataHoraBrasil!.Value,
                corridaClassificacao: corridaDados.CorridaClassificacao,
                metadePontos: corridaDados.MetadePontos);

            Db.Corridas.Add(corrida);
            Db.SaveChanges();
        }

        public void Alterar(CorridaDados corridaDados)
        {
            var corrida = ObterPeloId(corridaDados.Id);

            if (corrida is null)
                return;

            corrida.Atualizar(
                numeroCorrida: corridaDados.NumeroCorrida!.Value,
                temporada: corridaDados.Temporada,
                nomeGrandePremio: corridaDados.NomeGrandePremio,
                circuito: corridaDados.Circuito,
                dataHoraBrasil: corridaDados.DataHoraBrasil!.Value,
                corridaClassificacao: corridaDados.CorridaClassificacao,
                metadePontos: corridaDados.MetadePontos);

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