﻿using Formula1.Data.Entities;
using Formula1.Data.Models.Admin.Contratos;
using Formula1.Infra.Database;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class ContratosService
    {
        private readonly F1Db Db;

        public ContratosService(F1Db db)
        {
            Db = db;
        }

        public Contrato ObterPeloId(int id)
        {
            return Db.Contratos.Find(id);
        }

        public List<ContratoLista> ObterContratosLista(int temporada)
        {
            var contratos = Db.Contratos.Where(o => o.Temporada == temporada).OrderBy(o => o.Id).Select(o => new ContratoLista()
            {
                Id = o.Id,
                Piloto = o.Piloto.Nome,
                Equipe = o.Equipe.Nome
            }).ToList();

            return contratos;
        }

        public void Incluir(ContratoDados contratoDados)
        {
            var contrato = new Contrato()
            {
                Id = 0,
                Temporada = contratoDados.Temporada,
                PilotoId = contratoDados.PilotoId,
                EquipeId = contratoDados.EquipeId
            };

            Db.Contratos.Add(contrato);
            Db.SaveChanges();
        }

        public void Alterar(ContratoDados contratoDados)
        {
            var contrato = ObterPeloId(contratoDados.Id);

            contrato.Temporada = contratoDados.Temporada;
            contrato.PilotoId = contratoDados.PilotoId;
            contrato.EquipeId = contratoDados.EquipeId;

            Db.Contratos.Update(contrato);
            Db.SaveChanges();
        }

        public void Excluir(Contrato contrato)
        {
            Db.Contratos.Remove(contrato);
            Db.SaveChanges();
        }
    }
}