using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compilador.classes
{
    class Sintatica
    {
        List<Token> tabelaSimbolos;
        List<Erro> listaErros;
        int posTokenAtual;
        String tokenAtual;

        public Sintatica(List<Token> tabelaSimbolos)
        {
            this.tabelaSimbolos = tabelaSimbolos;
            listaErros = new List<Erro>();
        }

        public List<Erro> getErros()
        {
            return listaErros;
        }

        public void executar()
        {
            posTokenAtual = 0;
            tokenAtual = tabelaSimbolos[posTokenAtual].getToken();
            comeco();
        }

        private void consumirToken(String token)
        {
            if (token.Equals(tokenAtual))
            {
                if (posTokenAtual < tabelaSimbolos.Count - 1)
                    posTokenAtual++;
                tokenAtual = tabelaSimbolos[posTokenAtual].getToken();
            }
            else
                listaErros.Add(new Erro(token + " esperado", "sintático", tabelaSimbolos[posTokenAtual].getLinha()));
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * --------------------------------------------------------------------------------------------------------------------------------
        */

        void comeco()
        {
            if (tokenAtual[0] == '#')
            {
                subs();
                progPrincipal();
            }
            else
                if (tokenAtual.Equals("@principale"))
                {
                    progPrincipal();
                }
                else
                    if (tokenAtual.Equals("var"))
                    {
                        decl();
                        subs();
                        progPrincipal();
                    }
                    else
                    {
                        listaErros.Add(new Erro("Programa deve começar com: "
                            + "subrotina, @principale ou var", "sintático", tabelaSimbolos[posTokenAtual].getLinha()));
                        /*
                         * Se quiser continuar mesmo que o começo estiver errado bastaria adicionar esse código:
                         * consumirToken(tokenAtual);
                         * comeco();
                         * Obs.: Gera erros que não existem em outras partes do código!
                        */


                    }
        }

        void subs()
        {
            if (tokenAtual[0] == '#')
            {
                consumirToken(tokenAtual);
                consumirToken("inicio");
                blocoCmd();
                consumirToken("fim");
                subs();
            }
        }

        void progPrincipal()
        {
            if (tokenAtual.Equals("@principale"))
            {
                consumirToken("@principale");
                variosCmds();
                consumirToken("finale");
            }
            else
                listaErros.Add(new Erro("@principale ou subrotina esperado", "sintático", tabelaSimbolos[posTokenAtual].getLinha()));

        }

        void decl()
        {
            if (tokenAtual.Equals("var"))
            {
                consumirToken("var");
                variasDecl();
            }
        }

        void blocoCmd()
        {
            if (tokenAtual.Equals("var"))
            {
                decl();
                variosCmds();
            }
            else
                if (tokenAtual.Equals("enquanto") || tokenAtual.Equals("exibas") ||
                    tokenAtual.Equals("sepah") || tokenAtual.Contains("_CHAM") || tokenAtual.Equals("id"))
                {
                    variosCmds();
                }
        }

        void variosCmds()
        {
            if (tokenAtual.Contains("_CHAM") || tokenAtual.Equals("enquanto") || tokenAtual.Equals("exibas") ||
                tokenAtual.Equals("id") || tokenAtual.Equals("leias") || tokenAtual.Equals("sepah"))
            {
                umCmd();
                consumirToken(";");
                variosCmds();
            }
        }

        void variasDecl()
        {
            if (tokenAtual.Equals("inteiro") || tokenAtual.Equals("letra") ||
                tokenAtual.Equals("real"))
            {
                tiposBas();
                listaId();
                consumirToken(";");
                vdl();
            }
        }

        void umCmd()
        {
            if (tokenAtual.Contains("_CHAM"))
                chamadaSub();
            else
            {
                switch (tokenAtual)
                {
                    case "enquanto":
                        cmdWhile();
                        break;
                    case "exibas":
                        cmdEscrevas();
                        break;
                    case "id":
                        cmdAtrib();
                        break;
                    case "leias":
                        cmdLeias();
                        break;
                    case "sepah":
                        cmdIf();
                        break;
                }
            }
        }

        void tiposBas()
        {
            switch (tokenAtual)
            {
                case "inteiro":
                    consumirToken("inteiro");
                    break;
                case "letra":
                    consumirToken("letra");
                    break;
                case "real":
                    consumirToken("real");
                    break;
            }
        }

        void listaId()
        {
            if (tokenAtual.Equals("id"))
            {
                tiposId();
                lil();
            }
            else
                listaErros.Add(new Erro("id esperado", "sintático", tabelaSimbolos[posTokenAtual].getLinha()));
        }

        void vdl()
        {
            if (tokenAtual.Equals("letra") || tokenAtual.Equals("inteiro") ||
                tokenAtual.Equals("real"))
            {
                variasDecl();
            }
        }

        void cmdWhile()
        {
            if (tokenAtual.Equals("enquanto"))
            {
                consumirToken("enquanto");
                consumirToken("(");
                cond();
                consumirToken(")");
                consumirToken("facas");
                consumirToken("inicio");
                variosCmds();
                consumirToken("fim");
            }
        }

        void cmdEscrevas()
        {
            if (tokenAtual.Equals("exibas"))
            {
                consumirToken("exibas");
                consumirToken("(");
                vex();
            }
        }

        void cmdAtrib()
        {
            if (tokenAtual.Equals("id"))
            {
                tiposId();
                consumirToken("recebas");
                expArit();
            }
        }

        void cmdLeias()
        {
            if (tokenAtual.Equals("leias"))
            {
                consumirToken("leias");
                consumirToken("(");
                consumirToken("id");
                consumirToken(")");
            }
        }

        void cmdIf()
        {
            if (tokenAtual.Equals("sepah"))
            {
                consumirToken("sepah");
                consumirToken("(");
                cond();
                consumirToken(")");
                consumirToken("inicio");
                variosCmds();
                consumirToken("fim");
                cmdIff();
            }
        }

        void chamadaSub()
        {
            if (tokenAtual.Contains("_CHAM"))
                consumirToken(tokenAtual);
        }

        void tiposId()
        {
            if (tokenAtual.Equals("id"))
            {
                consumirToken("id");
                til();
            }
            else
                listaErros.Add(new Erro("id esperado", "sintático", tabelaSimbolos[posTokenAtual].getLinha()));
        }

        void lil()
        {
            if (tokenAtual.Equals(","))
            {
                consumirToken(",");
                listaId();
            }
        }

        void cond()
        {
            if (tokenAtual.Equals("("))
            {
                consumirToken("(");
                termo();
                opRel();
                termo();
                consumirToken(")");
                conExp();
            }
            else
                if (tokenAtual.Equals("~"))
                {
                    consumirToken("~");
                    cond();
                }
        }

        void vex()
        {
            if (tokenAtual.Equals("id"))
            {
                consumirToken("id");
                consumirToken(")");
            }
            else
                if (tokenAtual.Equals("literal"))
                {
                    consumirToken("literal");
                    consumirToken(")");
                }
        }

        void expArit()
        {
            if (tokenAtual.Equals("id") || tokenAtual.Equals("(") || tokenAtual.Equals("num_int") ||
                tokenAtual.Equals("num_real"))
            {
                contas();
            }
            else
                if (tokenAtual.Equals("literal"))
                    consumirToken("literal");
                else
                    listaErros.Add(new Erro("id ou literal esperado", "sintático", tabelaSimbolos[posTokenAtual].getLinha()));
        }

        void cmdIff()
        {
            if (tokenAtual.Equals("nem"))
            {
                consumirToken("nem");
                consumirToken("inicio");
                variosCmds();
                consumirToken("fim");
            }
        }

        void conExp()
        {
            if (tokenAtual.Equals("e") || tokenAtual.Equals("ou"))
            {
                opLogico();
                cond();
            }
        }

        void contas()
        {
            if (tokenAtual.Equals("("))
            {
                consumirToken("(");
                contas();
                consumirToken(")");
                nontas();
            }
            else
                if (tokenAtual.Equals("id") || tokenAtual.Equals("num_int") ||
                    tokenAtual.Equals("num_real"))
                {
                    termo();
                    nontas();
                }
                else
                    listaErros.Add(new Erro("id  ou número esperado", "sintático", tabelaSimbolos[posTokenAtual].getLinha()));

        }

        void nontas()
        {
            if (tokenAtual.Equals("+") || tokenAtual.Equals("-") || tokenAtual.Equals("*") ||
                tokenAtual.Equals("/"))
            {
                opArit();
                contas();
                nontas();
            }           
        }

        void opArit()
        {
            if (tokenAtual.Equals("+"))
                consumirToken("+");
            else
                if (tokenAtual.Equals("-"))
                    consumirToken("-");
                else
                    if (tokenAtual.Equals("*"))
                        consumirToken("*");
                    else
                        if (tokenAtual.Equals("/"))
                            consumirToken("/");
        }

        void opLogico()
        {
            if (tokenAtual.Equals("e"))
                consumirToken("e");
            else
                if (tokenAtual.Equals("ou"))
                    consumirToken("ou");
        }


        void opRel()
        {
            switch (tokenAtual)
            {
                case "~=":
                    consumirToken("~=");
                    break;
                case "<":
                    consumirToken("<");
                    break;
                case "<=":
                    consumirToken("<=");
                    break;
                case ">":
                    consumirToken(">");
                    break;
                case ">=":
                    consumirToken(">=");
                    break;
                case "=":
                    consumirToken("=");
                    break;
            }
        }

        void termo()
        {
            switch (tokenAtual)
            {
                case "id":
                    tiposId();
                    break;
                case "num_int":
                    consumirToken(tokenAtual);
                    break;
                case "num_real":
                    consumirToken(tokenAtual);
                    break;
                default:
                    listaErros.Add(new Erro("id esperado", "sintático", tabelaSimbolos[posTokenAtual].getLinha()));
                    break;
            }
        }

        void til()
        {
            if (tokenAtual.Equals("["))
            {
                consumirToken("[");
                consumirToken("num_int");
                consumirToken("]");
            }
        }

    }
}