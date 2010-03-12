using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorProjeto.Models
{
    public interface ISprintRepository
    {
        IQueryable<Sprint> GetAllSprints(long EmpresaId);
        void DeleteASprint(long SprintId);
        void AddSprint(Sprint NewSprint);
        void EditSprint(Sprint SprintEdited);
        Sprint GetSprintById(long SprintId);
        IQueryable<vSprintBackLog> ListSprintBacklog(long SprintId);
    }
}
