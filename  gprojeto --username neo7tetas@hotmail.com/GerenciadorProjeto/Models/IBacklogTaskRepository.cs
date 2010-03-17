using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorProjeto.Models
{
    public interface IBacklogTaskRepository
    {
        IQueryable<BacklogTask> GetAllBacklogTasks(long BacklogItemId);
        void DeleteABacklogTask(long BacklogTaskId, long BacklogItemId);
        void AddBacklogTask(BacklogTask NewBacklogTask);
        void EditBacklogTask(BacklogTask BacklogTaskEdited);
        BacklogTask GetBaklogTaskById(long BacklogTaskId);
        BacklogItem GetBaklogItemById(long BacklogItemId);
    }
}
