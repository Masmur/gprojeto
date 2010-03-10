using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorProjeto.Models
{
    public class ColaboradorRepository
    {
        //Cria o contexto do banco.
        private ModelDataContext _modelColaborador;

        public ColaboradorRepository()
        {
            _modelColaborador = new ModelDataContext();
        }
    }
}
