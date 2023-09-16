using Formula1.Data.Entities;
using Formula1.Data.Models.Admin.Contratos;
using Formula1.Data.Models.Admin.Resultados;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Infra.Database;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Infra.Repositories
{
    public class ContratosRepository : IContratosRepository
    {
        private readonly F1Db Db;

        public ContratosRepository(F1Db db)
        {
            Db = db;
        }

        public Contrato? ObterPeloId(int id)
        {
            return Db.Contratos.Find(id);
        }

        public List<ContratoLista> ObterContratosLista(int temporada)
        {
            var contratos = Db.Contratos.Where(o => o.Temporada == temporada).OrderBy(o => o.Equipe.Nome).ThenBy(o => o.Piloto.Nome).Select(o => new ContratoLista()
            {
                Id = o.Id,
                Piloto = o.Piloto.Nome,
                Equipe = o.Equipe.Nome
            }).ToList();

            return contratos;
        }

        public List<ResultadoEquipePilotos> ObterResultadoEquipesPilotos(int temporada)
        {
            var equipesPilotosList = Db.Contratos
                .Where(o => o.Temporada == temporada)
                .Select(o => new { o.EquipeId, o.PilotoId })
                .ToList();

            return equipesPilotosList
                .GroupBy(o => o.EquipeId)
                .Select(o =>
                    new ResultadoEquipePilotos(
                        o.Key,
                        o.Select(o => o.PilotoId).ToArray()
                    )
                )
                .ToList();
        }

        public void Incluir(ContratoDados contratoDados)
        {
            var contrato = new Contrato(
                temporada: contratoDados.Temporada,
                pilotoId: contratoDados.PilotoId,
                equipeId: contratoDados.EquipeId);

            Db.Contratos.Add(contrato);
            Db.SaveChanges();
        }

        public void Alterar(ContratoDados contratoDados)
        {
            var contrato = ObterPeloId(contratoDados.Id);

            if (contrato is null)
                return;

            contrato.Atualizar(contratoDados.Temporada, contratoDados.PilotoId, contratoDados.EquipeId);

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