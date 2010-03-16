using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorProjeto.Models
{
    public interface ISprintRepository
    {
        IQueryable<Sprint> GetAllSprints(long EmpresaId);
        IQueryable<Produto> GetAllProdutos(long EmpresaId);
        void DeleteASprint(long SprintId);
        void RemoveBackLogItem(long BacklogItemId);
        void AddSprint(Sprint NewSprint);
        void AddToSprint(long SprintId, long BacklogItemId);
        void EditSprint(Sprint SprintEdited);
        Sprint GetSprintById(long SprintId);
        IQueryable<vSprintBackLog> ListSprintBacklog(long SprintId);
        IQueryable<vBackLogProduto> ListProdutoBacklog(long EmpresaId);
    }
}
