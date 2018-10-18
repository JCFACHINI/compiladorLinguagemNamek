using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace compilador.classes
{
    class Analise
    {
        List<Token> tabelaSimbolos;
        List<Erro> listaErros;
        String codigoEntrada; //conteúdo do código sem tratamento algum
        bool erroLexico, erroSintatico, erroSemantico;
        
        public Analise(String codigoEntrada)
        {
            this.codigoEntrada = codigoEntrada;
            erroLexico = false;
            erroSintatico = false;
            erroSemantico = false;
        }

        public List<Token> getTabelaSimbolos()
        {
            return tabelaSimbolos;
        }

        public List<Erro> getListaErros()
        {
            return listaErros;
        }

        public bool getErroLexico()
        {
            return erroLexico;
        }

        public bool getErroSintatico()
        {
            return erroSintatico;
        }

        public bool getErroSemantico()
        {
            return erroSemantico;
        }

        public void executa()
        {
            Lexica analiseLexica = new Lexica(codigoEntrada);
            analiseLexica.executar();
            listaErros = analiseLexica.getErros();
            if (listaErros.Count == 0)
            {
                tabelaSimbolos = analiseLexica.getTabelaSimb();
                Sintatica analiseSintatica = new Sintatica(tabelaSimbolos);
                analiseSintatica.executar();
                listaErros = analiseSintatica.getErros();
                if (listaErros.Count == 0)
                {
                    Semantica analiseSemantica = new Semantica(tabelaSimbolos);
                    analiseSemantica.executar();
                    listaErros = analiseSemantica.getErros();
                    if (listaErros.Count != 0)
                        erroSemantico = true;
                }
                else
                    erroSintatico = true;
            }
            else
                erroLexico = true;
        }
       
    }
}
