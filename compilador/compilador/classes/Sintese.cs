using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compilador.classes
{
    class Sintese
    {
        List<Token> tabelaSimb;
        List<String> codigoInt;
        List<String> codigoObj;
        int nLinha;
        public Sintese(List<Token> tabelaSimb)
        {
            this.tabelaSimb = tabelaSimb;
            nLinha = 1;
            codigoInt = new List<String>();
            codigoObj = new List<String>();
        }

        public List<String> getCodInt()
        {
            return codigoInt;
        }

        public List<String> getCodObj()
        {
            return codigoObj;
        }

        public void executa()
        {
        //    gerCodInt();
       //     gerCodObj();
        }

        private void gerCodInt()
        {
            String linha = "";
            bool fechouLinha = false;
            for (int i = 0; i < tabelaSimb.Count; i++)
            {
                if (tabelaSimb[i].getLinha() != nLinha)
                    fechouLinha = true;
                if (fechouLinha) //gera cod int para essa linha
                {
                    fechouLinha = false;

                    if (linha.Contains("recebas"))
                    {
                        List<String> linhas = trataAtrib(linha);
                        foreach (String s in linhas)
                            addLinhaCodInt(s);
                    }
                    else
                    {
                        addLinhaCodInt(linha);
                        linha = "";
                    }
                }
                linha += tabelaSimb[i].getLexema() + " ";
                  
            }
        }

        private List<String> trataAtrib(String linha)
        {
            List<String> linhas = new List<String>();
            int posValorAtrib = 0;
            int posValorReceb = 0;
            bool isAtrib = false;
            for (int i = 0; i < linha.Length; i++)
            {
                if (linha[i] == 'r' && linha[i + 1] == 'e' && linha[i + 2] == 'c' &&
                    linha[i + 3] == 'e' && linha[i + 4] == 'b' &&
                    linha[i + 5] == 'a' && linha[i + 6] == 's')
                {
                    isAtrib = true;
                    posValorAtrib = i + 7;
                    posValorReceb = i - 1;
                }
            }
            if (isAtrib)
            {
                String valorQueEstaRecebendo = linha.Substring(0, posValorReceb);
                String valorAtrib = linha.Substring(posValorAtrib);
                String valorAtribSEspacos = removeEspacos(valorAtrib);
                valorAtribSEspacos = valorAtribSEspacos.Remove(valorAtribSEspacos.Length - 1);
                if (valorAtribSEspacos[0] != '$')
                {
                    String expPosFixada = infixToPosfix(valorAtribSEspacos);
                    if (expPosFixada.Length > 2) //não apenas um valor
                        linhas = geraCod3End(expPosFixada);
                    else
                        linhas.Add(expPosFixada);
                    String ultimoT = "";
                    String[] aux = linhas[linhas.Count - 1].Split('=');
                    ultimoT = aux[0];
                    linhas.Add(valorQueEstaRecebendo + "=" + ultimoT);
                }
            }
            return linhas;
        }

        private List<String> geraCod3End(String codNormal) //recebe exp posfixada
        {
            List<String> codigo3end = new List<String>();
            int indice = 0; //t1, t2....
            String t = "t";
            bool completouCodigo = false;
            for (int i = 0; i < codNormal.Length; i++)
            {
                if (codNormal[i] != '+' && codNormal[i] != '-' &&
                    codNormal[i] != '*' && codNormal[i] != '/')
                    codigo3end[i] += codNormal[i];
            }



            return codigo3end;

        }
       
        private String removeEspacos(String s)
        {
            String aux = "";
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] != ' ')
                    aux += s[i];
            }
            return aux;
        }
        private void addLinhaCodInt(String linha)
        {
            codigoInt.Add("" + nLinha + ": " + linha);
            nLinha++;
        }

        private void gerCodObj()
        {
            for (int i = 0; i < codigoInt.Count; i++)
            {
            }
        }


        /*
         * Criamos uma pilha vazia
        - Lemos cada caractere da expressão infix da esquerda para a direita
        -- Se o caractere lido for um operando (número, por exemplo) adicionamo-lo na string postfix.
        -- Se for um operador (+ - * /) e a pilha estiver vazia, empurramo-lo para a pilha.
        -- Se for um operador e a pilha não estiver vazia, retiramos da pilha todos os operadores com prioridade maior do que o caractere lido e jogamo-los na string postfix. Finalmente, jogamos o caractere lido na pilha.
        -- Se for um '(', apenas empurramo-lo na pilha.
        -- Se for um ')', retiramos da pilha todos os elementos até encontrar um '(' e jogamo-los na string postfix.
        - é possível que tenham restado operadores na pilha. Tiramo-los dela e jogamos na string postfix.
        - Retornamos postfix.
        */
        private String infixToPosfix(String infix)
        {
            String posFix = "";
            Stack<char> pilha = new Stack<char>();

            foreach (char c in infix)
            {
                if (Char.IsDigit(c) || Char.IsLetter(c)) //operando
                    posFix += " " + c;
                if (isOperador(c))
                {
                    if (pilha.Count == 0)
                        pilha.Push(c);
                    else
                    {
                        if (getPrioridade(pilha.Peek()) > getPrioridade(c))
                        {
                            posFix += " " + pilha.Pop();
                            pilha.Push(c);
                        }
                        else
                            pilha.Push(c);
                    }
                }
                if (c == '(')
                    pilha.Push(c);
                if(c == ')')
                {
                    while (pilha.Count != 0 && pilha.Peek() != '(')
                    {
                        posFix += " " + pilha.Pop();
                    }
                    if (pilha.Peek() == '(')
                        pilha.Pop();
                }
            }
            while (pilha.Count != 0)
                posFix += " " + pilha.Pop();

            return posFix;
        }

        private bool isOperador(char c)
        {
            if (c == '+' || c == '-' || c == '/' || c == '*')
                return true;
            return false;
        }

        private int getPrioridade(char operador)
        {
            if (operador == '+' || operador == '-')
                return 1;
            if (operador == '/' || operador == '*')
                return 2;
            return -1;
        }
    }
}
