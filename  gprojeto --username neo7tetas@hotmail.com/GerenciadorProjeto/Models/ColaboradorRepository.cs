using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorProjeto.Models
{
    public class ColaboradorRepository :IColaboradorRepository
    {
        //Cria o contexto do banco.
        private ModelDataContext _modelColaborador;

        public ColaboradorRepository()
        {
            _modelColaborador = new ModelDataContext();
        }

        public IQueryable<Colaborador> GetAllColaboradores(long EmpresaId)
        {
            var query = from colaborador in _modelColaborador.Colaboradors
                        where colaborador.EmpresaId == EmpresaId
                        select colaborador;

            return query.AsQueryable();
        }

        public void DeleteAColaborador(long ColaboradorId)
        {
            var query = from colaborador in _modelColaborador.Colaboradors
                        where colaborador.ColaboradorId == ColaboradorId
                        select colaborador;
            _modelColaborador.Colaboradors.DeleteOnSubmit(query.FirstOrDefault());

            _modelColaborador.SubmitChanges();

        }

        public void AddColaborador(Colaborador NewColaborador)
        {
            _modelColaborador.Colaboradors.InsertOnSubmit(NewColaborador);
            _modelColaborador.SubmitChanges();
        }

        public void EditColaborador(Colaborador ColaboradorEdited)
        {
            _modelColaborador.Colaboradors.First(p => p.ColaboradorId == ColaboradorEdited.ColaboradorId).Nome = ColaboradorEdited.Nome;

            _modelColaborador.SubmitChanges();
        }

        public Colaborador GetColaboradorById(long ColaboradorId)
        {
            return _modelColaborador.Colaboradors.Where(p => p.ColaboradorId == ColaboradorId).FirstOrDefault();
        }

    }
}
