using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorProjeto.Models
{
    public interface IColaboradorRepository
    {
        IQueryable<Colaborador> GetAllColaboradores(long EmpresaId);
        void DeleteAColaborador(long EmpresaId);
        void AddColaborador(Colaborador NewColaborador);
        void EditColaborador(Colaborador ColaboradorEdited);
        Colaborador GetColaboradorById(long ColaboradorId);
    }
}
