using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compilador.classes
{
    class Erro
    {
        String msg, tipo; //tipos: léxico, sintático, semântico
        int nLinha;

        

        public Erro(String msg, String tipo, int nLinha)
        {
            this.msg = msg;
            this.tipo = tipo;
            this.nLinha = nLinha;
        }

        public Erro()
        {
            this.msg = "";
            this.tipo = "";
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public String Msg
        {
            get { return msg; }
            set { msg = value; }
        }

        public int NLinha
        {
            get { return nLinha; }
            set { nLinha = value; }
        }
    }
}
