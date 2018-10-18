using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compilador.classes
{
    class Lexica
    {
        List<Token> tabelaSimb;
        List<Erro> listaErros;
        List<String> reservadas;
        List<String> listaFuncoes;
        String nomeSubAtual; //usada para definir escopo de variáveis
        String codigoEntrada;

        public Lexica(String codigoEntrada)
        {
            tabelaSimb = new List<Token>();
            listaErros = new List<Erro>();
            listaFuncoes = new List<String>();
            this.codigoEntrada = codigoEntrada;
            nomeSubAtual = "global";
            inicializaReservadas();
        }

        public List<Token> getTabelaSimb()
        {
            return tabelaSimb;
        }

        public List<Erro> getErros()
        {
            return listaErros;
        }

        private void inicializaReservadas()
        {
            reservadas = new List<String>();
            reservadas.Add("inteiro");
            reservadas.Add("real");
            reservadas.Add("letra");
            reservadas.Add("inicio");
            reservadas.Add("fim");
            reservadas.Add("finale");
            reservadas.Add("recebas");
            reservadas.Add("sepah");
            reservadas.Add("nem");
            reservadas.Add("enquanto");
            reservadas.Add("facas");
            reservadas.Add("faças");
            reservadas.Add("leias");
            reservadas.Add("exibas");
            reservadas.Add("e");
            reservadas.Add("ou");
            reservadas.Add("~=");
            reservadas.Add("<=");
            reservadas.Add(">=");
            reservadas.Add("var");
        }

        /*
         *-----------------------------------------------------Tratamentos em geral--------------------------------------------------------------
         *-------------------------------------------------------Inicio--------------------------------------------------------------------------
        */
        private bool contemApenasLetras(String palavra)
        {
            if (palavra.Where(c => char.IsLetter(c)).Count() == palavra.Count())
                return true;
            return false;
        }

        private bool isSeparador(char l)
        {
            if (l == '(' || l == ')' || l == ',' || l == ';' || l == '='
                || l == '<' || l == '>' || l == '*' || l == '/' || l == '-' || l == '+' || l == '~' || l == '[' || l == ']')
                return true;
            else
                return false;
        }

        private bool isSeparador(String l)
        {
            if (l.Equals("(") || l.Equals(")") || l.Equals(",") || l.Equals(";") || l.Equals("=")
                || l.Equals("<") || l.Equals(">") || l.Equals("*") || l.Equals("/")
                 || l.Equals("-") || l.Equals("+") || l.Equals("~") || l.Equals("[") || l.Equals("]"))
                return true;
            else
                return false;
        }

        private bool contemLetras(string texto)
        {
            if (texto.Where(c => char.IsLetter(c)).Count() > 0)
                return true;
            else
                return false;
        }

        private bool isNumero(char l)
        {
            if ((int)l >= 48 && (int)l <= 57)
                return true;
            return false;
        }

        private bool isNumero(String palavra)
        {
            bool result;
            try
            {
                Convert.ToInt32(palavra);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private bool isVetor(String var)
        {
            return false;
        }

        private bool isNumReal(String possivelNum)
        {
            bool result;
            try
            {
                Convert.ToDecimal(possivelNum);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /*
        *-----------------------------------------------------Tratamentos em geral--------------------------------------------------------------
        *-------------------------------------------------------Fim--------------------------------------------------------------------------
       */


        private void classificaTokens(ref Token token, ref Erro erro)
        {
            if (reservadas.Contains(token.getLexema()) || isSeparador(token.getLexema())) //classifica reservadas e separadores
                token.setToken(token.getLexema());
            else
            {
                if (token.getLexema().Equals("var"))//declaração global
                {
                    nomeSubAtual = "global";
                }
                if (token.getLexema()[0] == '#')
                    if (token.getLexema().Length > 1)
                    {
                        nomeSubAtual = token.getLexema();
                        token.setToken(token.getLexema()+"_DECL");
                        listaFuncoes.Add(nomeSubAtual);
                    }
                    else
                    {
                        erro.NLinha = token.getLinha();
                        erro.Tipo = "léxico";
                        erro.Msg = "Símbolo não reconhecido!";
                    }
                else
                    if (token.getLexema().Equals("@principale"))
                    {
                        token.setToken("@principale");
                    }
                    else
                        if (token.getLexema()[0] == '$') //classifica literais
                            token.setToken("literal");
                        else
                        {
                            if (isNumero(token.getLexema())) //classifica numeros inteiros
                            {
                                token.setToken("num_int");
                            }
                            else
                                if (token.getLexema().Contains('.')) //possivel numero real
                                {
                                    String possivelNumReal = token.getLexema().Replace('.', ',');
                                    if (isNumReal(possivelNumReal))
                                    {
                                        token.setToken("num_real");
                                    }
                                    else
                                    {
                                        erro.NLinha = token.getLinha();
                                        erro.Tipo = "léxico";
                                        erro.Msg = "Símbolo não reconhecido!";
                                    }
                                }
                                else
                                {
                                    if (contemApenasLetras(token.getLexema())) //contem apenas letras?
                                    {
                                        if (!listaFuncoes.Contains("#" + token.getLexema()))
                                        {
                                            token.setToken("id");
                                            token.setAtributo(nomeSubAtual);
                                        }
                                        else //chamada subRotina
                                            token.setToken(token.getLexema() + "_CHAM");
                                     
                                    }
                                    else
                                    {
                                        if (isVetor(token.getLexema()))
                                        {
                                            token.setToken("vetor");
                                        }
                                        else
                                        {
                                            erro.NLinha = token.getLinha();
                                            erro.Tipo = "léxico";
                                            erro.Msg = "Símbolo não reconhecido!";
                                        }
                                    }
                                }
                        }
            }
        }



        private void addItemTabelaTokens(int nLinha, ref String palavra)
        {
            if (!palavra.Equals(""))
            {
                Token token = new Token(nLinha, palavra, "", "");
                Erro erro = new Erro();
                classificaTokens(ref token, ref erro);
                tabelaSimb.Add(token);
                if (!erro.Msg.Equals(""))
                    listaErros.Add(erro);
                palavra = "";
            }
        }

        public void executar()
        {
            int nLinha = 1;
            bool comentario = false;
            String palavra = "";

            for (int i = 0; i < codigoEntrada.Length; i++)
            {
                if (codigoEntrada[i].Equals('{'))
                {
                    comentario = true;
                    if (!palavra.Equals("")) //se antes do comentario tiver uma palavra add na tabela lexica
                        addItemTabelaTokens(nLinha, ref palavra);
                }
                if (codigoEntrada[i].Equals('}'))
                {
                    comentario = false;
                    i++; //pula o }
                }

                if (!comentario)
                {
                    if (i < codigoEntrada.Length) //impede estouro de indice, necessário por causa do i++ quando termina comentario
                    {
                        String literal = "";
                        if (codigoEntrada[i].Equals('$')) //trata literais
                        {
                            literal += codigoEntrada[i];
                            i++;
                            while (i < codigoEntrada.Length && !codigoEntrada[i].Equals('$'))
                            {
                                if (palavra != "")//se houver uma palavra antes do $, adiciona na tabela
                                    addItemTabelaTokens(nLinha, ref palavra);
                                literal += codigoEntrada[i];
                                i++;
                            }
                            if (i < codigoEntrada.Length)
                            {
                                literal += codigoEntrada[i];
                                i++;
                            }
                            addItemTabelaTokens(nLinha, ref literal);
                        }

                        if (i < codigoEntrada.Length)
                        {
                            if (isSeparador(codigoEntrada[i]) || codigoEntrada[i].Equals('\n')
                                || codigoEntrada[i].Equals(' ') || codigoEntrada[i].Equals('\t')) //fim de palavra
                            {
                                if (isSeparador(codigoEntrada[i]))
                                {
                                    if (palavra != "") //se houver uma palavra antes do separador, adiciona na tabela
                                        addItemTabelaTokens(nLinha, ref palavra);

                                    if ((codigoEntrada[i].Equals('>') || codigoEntrada[i].Equals('<') || codigoEntrada[i].Equals('~'))
                                        && codigoEntrada[i + 1].Equals('='))
                                    {
                                        palavra = "" + codigoEntrada[i] + codigoEntrada[i + 1];
                                        addItemTabelaTokens(nLinha, ref palavra);
                                        i++; //não deixa adicionar o = na lista de novo
                                    }
                                    else//separador de apenas um caracter
                                    {
                                        palavra = "" + codigoEntrada[i];
                                        addItemTabelaTokens(nLinha, ref palavra);
                                    }
                                }
                                else //id ou comandos ou \n
                                {
                                    addItemTabelaTokens(nLinha, ref palavra);
                                    if (codigoEntrada[i].Equals('\n'))
                                        nLinha++;
                                }
                            }
                            else //palavra ainda não completa
                            {
                                palavra += codigoEntrada[i];
                            }
                        }
                    }
                }
                else //se for comentário continuar contando linhas
                {
                    if (codigoEntrada[i].Equals('\n'))
                        nLinha++;
                }
            }
        }

    }
}
