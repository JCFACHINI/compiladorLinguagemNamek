using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compilador.classes
{
    class Var
    {
        String nome, escopo, tipo;
        bool isVetor, isDecl;
        int linha;
        int dimVetor;

        public int DimVetor
        {
            get { return dimVetor; }
            set { dimVetor = value; }
        }


        public bool IsDecl
        {
            get { return isDecl; }
            set { isDecl = value; }
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public String Escopo
        {
            get { return escopo; }
            set { escopo = value; }
        }
        

        public int Linha
        {
            get { return linha; }
            set { linha = value; }
        }
        

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        

        public bool IsVetor
        {
            get { return isVetor; }
            set { isVetor = value; }
        }

        public Var(String nome, String escopo, String tipo, int linha, bool isVetor, bool isDecl, int dim)
        {
            this.nome = nome;
            this.escopo = escopo;
            this.tipo = tipo;
            this.linha = linha;
            this.isVetor = isVetor;
            this.isDecl = isDecl;
            this.dimVetor = dim;
        }

        public Var()
        {

        }
    }
}
