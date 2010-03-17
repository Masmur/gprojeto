using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorProjeto.Models
{
    public class BacklogTaskRepository : IBacklogTaskRepository
    {
        //Cria o contexto do banco.
        private ModelDataContext _modelBacklogTask;

        public BacklogTaskRepository()
        {
            _modelBacklogTask = new ModelDataContext();
        }

        public IQueryable<BacklogTask> GetAllBacklogTasks(long BacklogItemId)
        {
            var query = from backlogTask in _modelBacklogTask.BacklogTasks
                        where backlogTask.BacklogItemId == BacklogItemId
                        select backlogTask;

            return query.AsQueryable();
        }

        public void DeleteABacklogTask(long BacklogTaskId, long BacklogItemId)
        {
            var query = from backlogTask in _modelBacklogTask.BacklogTasks
                        where backlogTask.BacklogTaskId == BacklogTaskId
                        select backlogTask;

            _modelBacklogTask.BacklogTasks.DeleteOnSubmit(query.FirstOrDefault());

            _modelBacklogTask.SubmitChanges();
        }

        public void AddBacklogTask(BacklogTask NewBacklogTask)
        {
            _modelBacklogTask.BacklogTasks.InsertOnSubmit(NewBacklogTask);
            _modelBacklogTask.SubmitChanges();
        }

        public void EditBacklogTask(BacklogTask BacklogTaskEdited)
        {
            _modelBacklogTask.BacklogTasks.First(p => p.BacklogItemId == BacklogTaskEdited.BacklogItemId).Nome = BacklogTaskEdited.Nome;
            _modelBacklogTask.BacklogTasks.First(p => p.BacklogItemId == BacklogTaskEdited.BacklogItemId).Estimativa = BacklogTaskEdited.Estimativa;

            _modelBacklogTask.SubmitChanges();
        }

        public BacklogTask GetBaklogTaskById(long BacklogTaskId)
        {
            return _modelBacklogTask.BacklogTasks.Where(p => p.BacklogItemId == BacklogTaskId).FirstOrDefault();
        }

        public BacklogItem GetBaklogItemById(long BacklogItemId)
        {
            return _modelBacklogTask.BacklogItems.Where(p => p.BacklogItemId == BacklogItemId).FirstOrDefault();
        }

    }
}
