using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorProjeto.Models
{
    public interface ISprintRepository
    {
        IQueryable<Sprint> GetAllSprints(int EmpresaId);
        void DeleteASprint(int SprintId);
        void AddSprint(Sprint NewSprint);
        void EditSprint(Sprint SprintEdited);
        Sprint GetSprintById(int SprintId);
        IQueryable<vSprintBackLog> ListSprintBacklog(int SprintId);
    }
}
