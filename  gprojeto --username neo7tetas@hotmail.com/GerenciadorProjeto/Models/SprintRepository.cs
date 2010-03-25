using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorProjeto.Models
{
    public class SprintRepository : ISprintRepository
    {
        //Cria o contexto do banco.
        private ModelDataContext _modelSprint;

        public SprintRepository()
        {
            _modelSprint = new ModelDataContext();
        }

        public IQueryable<Sprint> GetAllSprints(long EmpresaId)
        {
            var query = from sprint in _modelSprint.Sprints
                        where sprint.EmpresaId == EmpresaId
                        select sprint;

            return query.AsQueryable();
        }

        public void DeleteASprint(long SprintID)
        {
            var query = from sprint in _modelSprint.Sprints
                        where sprint.SprintId == SprintID
                        select sprint;
            _modelSprint.Sprints.DeleteOnSubmit(query.FirstOrDefault());

            _modelSprint.SubmitChanges();
        }

        public void AddSprint(Sprint newSprint)
        {
            _modelSprint.Sprints.InsertOnSubmit(newSprint);
            _modelSprint.SubmitChanges();
        }

        public void AddToSprint(long SprintId, long BacklogItemId)
        {
            SprintBackLog newSprintBacklotItem = new SprintBackLog();
            newSprintBacklotItem.BacklogItemId = BacklogItemId;
            newSprintBacklotItem.SprintId = SprintId;

            _modelSprint.SprintBackLogs.InsertOnSubmit(newSprintBacklotItem);

            _modelSprint.SubmitChanges();
        }

        public Sprint GetSprintById(long SprintId)
        {
            return _modelSprint.Sprints.Where(p => p.SprintId == SprintId).FirstOrDefault();
        }

        public void EditSprint(Sprint SprintEdited)
        {
            _modelSprint.Sprints.First(p => p.SprintId == SprintEdited.SprintId).Objetivo = SprintEdited.Objetivo;

            _modelSprint.SubmitChanges();
        }

        public IQueryable<vSprintBackLog> ListSprintBacklog(long SprintId)
        {
            var query = from sprintBackLog in _modelSprint.vSprintBackLogs
                        where sprintBackLog.SprintId == SprintId
                        select sprintBackLog;

            return query.AsQueryable();
        }

        public IQueryable<vBackLogProduto> ListProdutoBacklog(long ProdutoId)
        {
            var query = from produtoBackLog in _modelSprint.vBackLogProdutos
                        where produtoBackLog.ProdutoId == ProdutoId
                        select produtoBackLog;

            return query.AsQueryable();
        }

        public IQueryable<vListProdutoSprint> GetAllProdutos(long EmpresaId)
        {
            var query = from ProdutoSprint in _modelSprint.vListProdutoSprints
                        where ProdutoSprint.EmpresaId == EmpresaId
                        select ProdutoSprint;

            return query.AsQueryable();
        }

        public void RemoveBackLogItem(long BacklogItemId)
        {
            var query = from sprintBackLog in _modelSprint.SprintBackLogs
                        where sprintBackLog.BacklogItemId == BacklogItemId
                        select sprintBackLog;

            _modelSprint.SprintBackLogs.DeleteOnSubmit(query.FirstOrDefault());

            _modelSprint.SubmitChanges();
        }
    }
}
