using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compilador.classes
{
    class Sub
    {
        int lInicio, lFim;
        String nome;

        public Sub()
        {

        }
        public Sub(int lInicio, int lFim, String nome)
        {
            this.lInicio = lInicio;
            this.lFim = lFim;
            this.nome = nome;
        }

        public int LFim
        {
            get { return lFim; }
            set { lFim = value; }
        }

        public int LInicio
        {
            get { return lInicio; }
            set { lInicio = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
    }
}
