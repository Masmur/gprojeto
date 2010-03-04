using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorProjeto.Classes
{
    public class Calendario
    {
        private int _ano;
        private List<Dia> _dias = new List<Dia> { };
        private int[] _dias_semana = new int[7]{1,2,3,4,5,6,7};

        public int[] dias_semana
        {
            get { return this._dias_semana; }
        }

        public int ano
        {
            get { return this._ano; }
            set { this._ano = value; }
        }

        public List<Dia> dias
        {
            get { return this._dias; }
            set { this._dias = value; }
        }

        public void Adddia(int dia, String dia_semana)
        {
            Dia d = new Dia();

            d.dia = dia;
            d.dia_semana = dia_semana;

            this._dias.Add(d);
        }
    }

    public class Dia
    {
        private int _dia;
        private String _dia_semana;

        public int dia
        {
            get { return this._dia; }
            set { this._dia = value; }
        }

        public String dia_semana
        {
            get { return this._dia_semana; }
            set { this._dia_semana = value; }
        }
    }

}
