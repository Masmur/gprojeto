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

        public IQueryable<Sprint> GetAllSprints(int EmpresaId)
        {
            var query = from sprint in _modelSprint.Sprints
                        where sprint.EmpresaId == EmpresaId
                        select sprint;

            return query.AsQueryable();
        }

        public void DeleteASprint(int SprintID)
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

        public Sprint GetSprintById(int SprintId)
        {
            return _modelSprint.Sprints.Where(p => p.SprintId == SprintId).FirstOrDefault();
        }

        public void EditSprint(Sprint SprintEdited)
        {
            _modelSprint.Sprints.First(p => p.SprintId == SprintEdited.SprintId).Objetivo = SprintEdited.Objetivo;

            _modelSprint.SubmitChanges();
        }

        public IQueryable<vSprintBackLog> ListSprintBacklog(int SprintId)
        {
            var query = from sprintBackLog in _modelSprint.vSprintBackLogs
                        where sprintBackLog.SprintId == SprintId
                        select sprintBackLog;

            return query.AsQueryable();
        }
    }
}
