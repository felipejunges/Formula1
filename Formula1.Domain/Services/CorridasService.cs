using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Corridas;
using Formula1.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class CorridasService
    {
        private const int MAXIMO_PONTOS_PILOTO_PADRAO = 26;
        private const int MAXIMO_PONTOS_PILOTO_COM_CLASSIFICACAO = 29;
        private const int MAXIMO_PONTOS_EQUIPE_PADRAO = 44;
        private const int MAXIMO_PONTOS_EQUIPE_COM_CLASSIFICACAO = 49;

        private readonly F1Db Db;

        public CorridasService(F1Db db)
        {
            Db = db;
        }

        public Corrida ObterPeloId(int id)
        {
            return Db.Corridas.Find(id);
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
                NumeroCorrida = o.NumeroCorrida,
                DataHoraBrasil = o.DataHoraBrasil,
                NomeGrandePremio = o.NomeGrandePremio,
                Circuito = o.Circuito
            }).ToList();

            return corridas;
        }

        public int GetPontosEmDisputaPilotos(int temporada)
        {
            var corridasRestantes = Db.Corridas.Include(o => o.Resultados).Where(o => o.Temporada == temporada && o.Resultados.Count() == 0); // TODO: flag "finalizada"

            return corridasRestantes.Sum(s => s.CorridaClassificacao ? MAXIMO_PONTOS_PILOTO_COM_CLASSIFICACAO : MAXIMO_PONTOS_PILOTO_PADRAO);
        }

        public int GetPontosEmDisputaEquipes(int temporada)
        {
            var corridasRestantes = Db.Corridas.Include(o => o.Resultados).Where(o => o.Temporada == temporada && o.Resultados.Count() == 0); // TODO: flag "finalizada"

            return corridasRestantes.Sum(s => s.CorridaClassificacao ? MAXIMO_PONTOS_EQUIPE_COM_CLASSIFICACAO : MAXIMO_PONTOS_EQUIPE_PADRAO);
        }

        public void Incluir(CorridaDados corridaDados)
        {
            var corrida = new Corrida()
            {
                Id = 0,
                NumeroCorrida = corridaDados.NumeroCorrida.Value,
                Temporada = corridaDados.Temporada,
                NomeGrandePremio = corridaDados.NomeGrandePremio,
                Circuito = corridaDados.Circuito,
                DataHoraBrasil = corridaDados.DataHoraBrasil.Value,
                CorridaClassificacao = corridaDados.CorridaClassificacao,
                MetadePontos = corridaDados.MetadePontos
            };

            Db.Corridas.Add(corrida);
            Db.SaveChanges();
        }

        public void Alterar(CorridaDados corridaDados)
        {
            var corrida = ObterPeloId(corridaDados.Id);

            corrida.NumeroCorrida = corridaDados.NumeroCorrida.Value;
            corrida.Temporada = corridaDados.Temporada;
            corrida.NomeGrandePremio = corridaDados.NomeGrandePremio;
            corrida.Circuito = corridaDados.Circuito;
            corrida.DataHoraBrasil = corridaDados.DataHoraBrasil.Value;
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