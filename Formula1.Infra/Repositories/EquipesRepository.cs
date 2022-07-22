using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Equipes;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Infra.Database;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Infra.Repositories
{
    public class EquipesRepository : IEquipesRepository
    {
        private readonly F1Db Db;

        public EquipesRepository(F1Db db)
        {
            Db = db;
        }

        public Equipe? ObterPeloId(int id)
        {
            return Db.Equipes.Find(id);
        }

        public List<EquipeLista> ObterEquipesLista()
        {
            var equipes = Db.Equipes.OrderBy(o => o.Nome).Select(o => new EquipeLista(o)).ToList();

            return equipes;
        }

        public List<Equipe> ObterEquipesAtivas()
        {
            var equipes = Db.Equipes.Where(o => o.Ativo).OrderBy(o => o.Nome).ToList();

            return equipes;
        }

        public List<Equipe> ObterEquipesContrato(int temporada)
        {
            var equipes = this.Db.Contratos.Where(o => o.Temporada == temporada).Select(o => o.Equipe).ToList().GroupBy(o => o).Select(o => o.Key).ToList();

            return equipes;
        }

        public List<EquipeTemporadaResultado> ObterEquipesTabela(int temporada)
        {
            var equipes = (from et in Db.EquipesTemporada
                           join e in Db.Equipes on et.Equipe equals e
                           where et.Temporada == temporada
                           select new EquipeTemporadaResultado()
                           {
                               Id = e.Id,
                               Nome = e.Nome,
                               CorRgb = e.CorRgb,
                               Pontos = et.Pontos,
                               Posicao = et.Posicao,
                               PosicaoMaxima = et.PosicaoMaxima
                           }).ToList();

            return equipes;
        }

        public void Incluir(EquipeDados equipeDados)
        {
            var equipe = new Equipe(
                id: 0,
                nome: equipeDados.Nome,
                corRgb: equipeDados.CorRgb,
                ativo: equipeDados.Ativo);

            Db.Equipes.Add(equipe);
            Db.SaveChanges();
        }

        public void Alterar(EquipeDados equipeDados)
        {
            var equipe = ObterPeloId(equipeDados.Id);

            if (equipe is null)
                return;

            equipe.Atualizar(equipeDados.Nome, equipeDados.CorRgb, equipeDados.Ativo);

            Db.Equipes.Update(equipe);
            Db.SaveChanges();
        }

        public void Excluir(Equipe equipe)
        {
            Db.Equipes.Remove(equipe);
            Db.SaveChanges();
        }
    }
}