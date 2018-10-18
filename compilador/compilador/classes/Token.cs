using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compilador.classes
{
    class Token
    {
        int linha;
        String lexema, token, atributo;

        public Token()
        {
            
        }

        public Token(int linha, String lexema, String token, String atributo)
        {
            this.linha = linha;
            this.lexema = lexema;
            this.token = token;
            this.atributo = atributo;
        }

        public void setAtributo(String atributo)
        {
            this.atributo = atributo;
        }

        public String getAtributo()
        {
            return this.atributo;
        }

        public void setLinha(int linha)
        {
            this.linha = linha;
        }

        public void setLexema(String lexema)
        {
            this.lexema = lexema;
        }

        public void setToken(String token)
        {
            this.token = token;
        }

        public int getLinha()
        {
            return linha;
        }

        public String getToken()
        {
            return token;
        }

        public String getLexema()
        {
            return lexema;
        }
    }
}
