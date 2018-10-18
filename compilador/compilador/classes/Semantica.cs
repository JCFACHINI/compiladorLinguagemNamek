using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compilador.classes
{
    class Semantica
    {
        List<Token> tabelaSimbolos;
        List<Erro> listaErros;
        List<Var> listaVar;
        List<Sub> listaSub;

        public Semantica(List<Token> tabelaSimbolos)
        {
            this.tabelaSimbolos = tabelaSimbolos;
            this.listaErros = new List<Erro>();
        }

        public List<Erro> getErros()
        {
            return listaErros;
        }
       
        /*
         * Devido ao léxico ter uma lista de subrotinas para poder identificar
         * quando se trata de nomeSub ou de id, o sintático acaba
         * reconhecendo a chamada de uma sub não declarada como erro,
         * ou seja, o erro é semântico mas acabou sendo tratado no sintático
        */
        public void executar()
        {
            listaSub = montaTabelaSub();
            montaTabelaVar(); //monta tabela de variáveis e já verifica declaração
            duplicidade();
            verificaTipos();
        }

        private void verificaTipos()
        {
            for (int i = 0; i < tabelaSimbolos.Count; i++)
            {
                if (tabelaSimbolos[i].getToken().Equals("recebas"))
                {
                    Var v1, v2;
                    if (tabelaSimbolos[i - 1].getLexema().Equals("]"))
                    {
                        int indice;
                        indice = Convert.ToInt32(tabelaSimbolos[i - 2].getLexema());
                        v1 = getVarLinha(tabelaSimbolos[i - 4].getLinha(), tabelaSimbolos[i - 4].getLexema());
                        if (indice >= v1.DimVetor)
                            listaErros.Add(new Erro("Acesso a posição inválida do vetor!", "Semântico", v1.Linha)); 
                        if(v1.Tipo.Equals("letra") && tabelaSimbolos[i+1].getLexema().Length > 3)
                            listaErros.Add(new Erro("Vetor literal aceita apenas uma letra por posição!", "Semântico", v1.Linha)); 
                    }
                    else
                        v1 = getVarLinha(tabelaSimbolos[i - 1].getLinha(), tabelaSimbolos[i - 1].getLexema());
                    v2 = getVarLinha(tabelaSimbolos[i + 1].getLinha(), tabelaSimbolos[i + 1].getLexema());
                    if (tabelaSimbolos[i + 2].getLexema().Equals("["))
                    {
                        int indice;
                        indice = Convert.ToInt32(tabelaSimbolos[i + 3].getLexema());
                        if(indice >= v2.DimVetor)
                            listaErros.Add(new Erro("Acesso a posição inválida do vetor!", "Semântico", v2.Linha)); 
                    }
                    if (v1 != null)
                    {
                        if (v2 != null) //var recebendo var
                        {
                            if (!v1.Tipo.Equals(v2.Tipo))
                                listaErros.Add(new Erro("Tipos incopatíveis! Variável " + v1.Nome + " é do tipo " +
                            v1.Tipo + " e a variável " + v2.Nome + " é do tipo " + v2.Tipo, "Semântico", v1.Linha));
                        }
                        else //variavel recebendo literal ou uma expressão qualquer
                        {
                            if (v1.Tipo.Equals("letra") && tabelaSimbolos[i + 1].getToken().Equals("literal")) //trata literais
                            {
                                if (v1.DimVetor < getLengthLiteral(tabelaSimbolos[i + 1].getLexema()))
                                    listaErros.Add(new Erro("Estouro de capacidade! A variável " + v1.Nome +
                                        " é do tipo literal e possui capacidade máxima de " + v1.DimVetor + " letras",
                                        "Semântico", v1.Linha));
                            }
                            else //expressão
                            {
                                bool isReal, isLetra;
                                isLetra = false;
                                isReal = false;
                                int j = i + 1;
                                while (!tabelaSimbolos[j].getLexema().Equals(";") && !isLetra) //chegou no ; acabou a expressão
                                {
                                    if (tabelaSimbolos[j].getToken().Equals("id"))
                                    {
                                        Var var = getVarLinha(tabelaSimbolos[j].getLinha(), tabelaSimbolos[j].getLexema());
                                        if (var.Tipo.Equals("letra"))
                                            isLetra = true;
                                        if (var.Tipo.Equals("real"))
                                            isReal = true;
                                    }
                                    if (tabelaSimbolos[j].getToken().Equals("num_real") || tabelaSimbolos[j].getToken().Equals("/"))
                                        isReal = true;
                                    j++;
                                }
                                if (isLetra)
                                {
                                    listaErros.Add(new Erro("Tipos incopatíveis! A variável " + v1.Nome + " é do tipo " + v1.Tipo +
                                                " e está recebendo um valor literal!", "Semântico", v1.Linha));
                                }
                                else
                                {
                                    if (isReal)
                                    {
                                        if (!v1.Tipo.Equals("real"))
                                            listaErros.Add(new Erro("Tipos incopatíveis! A variável " + v1.Nome + " é do tipo " + v1.Tipo +
                                                " e está recebendo um valor real!", "Semântico", v1.Linha));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void duplicidade()
        {
            for (int i = 0; i < listaVar.Count - 1; i++)
                for (int j = i + 1; j < listaVar.Count; j++)
                {
                    if (listaVar[i].IsDecl && listaVar[j].IsDecl &&
                        listaVar[i].Escopo.Equals(listaVar[j].Escopo) &&
                        listaVar[i].Nome.Equals(listaVar[j].Nome))
                    {
                        listaErros.Add(new Erro("Variável: " + listaVar[j].Nome + " já declarada!",
                                "Semântico", listaVar[j].Linha));
                    }
                }
        }

        private int getLengthLiteral(String literal)
        {
            return literal.Length - 2;
        }

        private bool isVetor(int pos, ref int dim)
        {
            if (tabelaSimbolos[pos + 1].getLexema().Equals("["))
            {
                try
                {
                    dim = Convert.ToInt32(tabelaSimbolos[pos + 2].getLexema());
                }
                catch
                {
                    dim = 0;
                }
                return true;
            }
            return false;
        }

        private bool isDeclVar(int pos, ref String tipo)
        {
            Token tkAnt = tabelaSimbolos[pos - 1];
            int i = pos - 1;
            if (tkAnt.getLexema() == "," || tkAnt.getLexema() == "real" ||
                tkAnt.getLexema() == "letra" || tkAnt.getLexema() == "inteiro")
            {
                if (tkAnt.getLexema() == ",")
                {
                    while (!tkAnt.getLexema().Equals("real") &&
                        !tkAnt.getLexema().Equals("letra") &&
                        !tkAnt.getLexema().Equals("inteiro"))
                    {
                        tkAnt = tabelaSimbolos[i--];
                    }
                }
                tipo = tkAnt.getLexema();
                return true;
            }
            return false;
        }

        private Var getVarLinha(int nLinha, String nome)
        {
            Var result = null;
            for (int i = 0; i < listaVar.Count; i++)
            {
                if (listaVar[i].Linha == nLinha && listaVar[i].Nome.Equals(nome))
                {
                    result = listaVar[i];
                    break;
                }
            }
            return result;
        }

        private bool isDeclSub(int pos)
        {
            Token tkAtual = tabelaSimbolos[pos];
            if (tkAtual.getLexema()[0] == '#')
                return true;
            return false;
        }

        private bool isChamSub(int pos)
        {
            Token tkAtual = tabelaSimbolos[pos];
            if (tkAtual.getToken().Contains("_CHAM"))
                return true;
            return false;
        }

        private String getEscopo(int linhaVar)
        {
            foreach (Sub s in listaSub)
            {
                if (linhaVar >= s.LInicio && linhaVar <= s.LFim)
                    return s.Nome;
            }
            return "global";
        }

        private void montaTabelaVar()
        {
            listaVar = new List<Var>();

            for (int i = 0; i < tabelaSimbolos.Count; i++)
            {
                Token tkAtual = tabelaSimbolos[i];
                if (tkAtual.getToken().Equals("id"))
                {
                    String tipo = "";
                    String escopo = "";
                    int dim = 1;
                    bool isVet;
                    bool isDecl = isDeclVar(i, ref tipo);
                    if (isDecl)
                    {
                        escopo = getEscopo(tkAtual.getLinha());
                        isVet = isVetor(i, ref dim);
                        listaVar.Add(new Var(tkAtual.getLexema(), escopo, tipo,
                        tkAtual.getLinha(), isVet, isDecl, dim));
                    }
                    else //uso de var
                    {
                        Var v = null;
                        verificaEscopoLocal(i, ref v);
                        if (v != null)
                        {
                            listaVar.Add(v);
                        }
                        else
                        {
                            verificaEscopoGlobal(i, ref v);
                            if (v != null)
                            {
                                listaVar.Add(v);
                            }
                            else
                                listaErros.Add(new Erro("Variável: " + tabelaSimbolos[i].getLexema() + " não foi declarada!",
                                "Semântico", tabelaSimbolos[i].getLinha()));
                        }
                    }
                }
            }
        }


        /*
         * Além de gerar tabela de declaração de subrotinas,
         * verificar duplicidade de declaração(insere erros)
        */
        private List<Sub> montaTabelaSub()
        {
            List<Sub> lista = new List<Sub>();

            for (int i = 0; i < tabelaSimbolos.Count; i++)
            {
                Token tkAtual = tabelaSimbolos[i];
                if (tkAtual.getToken().Contains("_DECL"))
                {
                    //verifica duplicidade decl de sub
                    if (listContensSub(lista, tkAtual.getLexema()))
                        listaErros.Add(new Erro("SubRotina: " + tkAtual.getLexema() + " ,já declarada!",
                            "Semântico", tkAtual.getLinha()));
                    Sub sub = new Sub();
                    int paridade = 1;
                    int linhaAtual = i + 2; //pula primeiro inicio
                    while (paridade != 0)
                    {
                        if (tabelaSimbolos[linhaAtual].getLexema().Equals("inicio"))
                            paridade++;
                        if (tabelaSimbolos[linhaAtual].getLexema().Equals("fim"))
                            paridade--;
                        if (paridade != 0) //pula ultimo incremento
                            linhaAtual++;
                    }
                    //adiciona sub na tabela
                    sub.LInicio = tabelaSimbolos[i].getLinha();
                    sub.LFim = tabelaSimbolos[linhaAtual].getLinha();
                    sub.Nome = tkAtual.getLexema();
                    lista.Add(sub);
                }
            }
            return lista;
        }

        private bool listContensSub(List<Sub> l, String nomeSub)
        {
            foreach (Sub s in l)
            {
                if (s.Nome.Equals(nomeSub))
                    return true;
            }
            return false;
        }

        private void verificaEscopoGlobal(int posVar, ref Var var)
        {
            String nomeVar = tabelaSimbolos[posVar].getLexema();
            int i = 0;
            while (i < listaVar.Count && listaVar[i].Escopo.Equals("global"))
            {
                if (listaVar[i].Nome.Equals(nomeVar))
                {
                    var = new Var(nomeVar, "global", listaVar[i].Tipo, tabelaSimbolos[posVar].getLinha(), listaVar[i].IsVetor,
                        false, listaVar[i].DimVetor);
                }
                i++;
            }
        }

        private void verificaEscopoLocal(int posVar, ref Var var)
        {
            int linhaVar = tabelaSimbolos[posVar].getLinha();
            String whereSubUsada = "";
            foreach (Sub s in listaSub)
            {
                if (linhaVar > s.LInicio && linhaVar < s.LFim)
                {
                    whereSubUsada = s.Nome;
                    break;
                }
            }
            String nomeVar = tabelaSimbolos[posVar].getLexema();
            foreach (Var v in listaVar)
            {
                if (v.Nome.Equals(nomeVar) && v.Escopo.Equals(whereSubUsada))
                {
                    var = new Var(v.Nome, whereSubUsada, v.Tipo, linhaVar, v.IsVetor, false, v.DimVetor);
                    break;
                }
            }
        }

        
        private int getInicioSub(String nomeSub)
        {
            for (int i = 0; i < listaSub.Count; i++)
            {
                if (listaSub[i].Nome.Equals(nomeSub))
                    return listaSub[i].LInicio;
            }
            return -1;
        }

        private bool isGlobal(String nomeSub)
        {
            for (int i = 0; i < listaVar.Count; i++)
            {
                if (listaVar[i].Nome.Equals(nomeSub) && listaVar[i].Escopo.Equals("global"))
                    return true;
            }
            return false;
        }

        private int getFimSub(String nomeSub)
        {
            for (int i = 0; i < listaSub.Count; i++)
            {
                if (listaSub[i].Nome.Equals(nomeSub))
                    return listaSub[i].LFim;
            }
            return -1;
        }
    }
}
