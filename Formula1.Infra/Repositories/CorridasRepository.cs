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
            var corrida = new Corrida()
            {
                Id = 0,
                NumeroCorrida = corridaDados.NumeroCorrida!.Value,
                Temporada = corridaDados.Temporada,
                NomeGrandePremio = corridaDados.NomeGrandePremio,
                Circuito = corridaDados.Circuito,
                DataHoraBrasil = corridaDados.DataHoraBrasil!.Value,
                CorridaClassificacao = corridaDados.CorridaClassificacao,
                MetadePontos = corridaDados.MetadePontos
            };

            Db.Corridas.Add(corrida);
            Db.SaveChanges();
        }

        public void Alterar(CorridaDados corridaDados)
        {
            var corrida = ObterPeloId(corridaDados.Id);

            if (corrida is null)
                return;

            corrida.NumeroCorrida = corridaDados.NumeroCorrida!.Value;
            corrida.Temporada = corridaDados.Temporada;
            corrida.NomeGrandePremio = corridaDados.NomeGrandePremio;
            corrida.Circuito = corridaDados.Circuito;
            corrida.DataHoraBrasil = corridaDados.DataHoraBrasil!.Value;
            corrida.CorridaClassificacao = corridaDados.CorridaClassificacao;
            corrida.MetadePontos = corridaDados.MetadePontos;

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