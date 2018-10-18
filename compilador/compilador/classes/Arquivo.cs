using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace compilador.classes
{
    class Arquivo
    {
        private string caminho;
        private StreamReader arq;
        private StreamWriter arqSaida;

        public Arquivo(string caminho)
        {
            this.caminho = caminho;
            arq = new StreamReader(caminho);
        }

        public Arquivo()
        {
            caminho = "";
        }

        public StreamReader getArq()
        {
            return arq;
        }

        public string getCaminho()
        {
            return caminho;
        }

        public void setCaminho(string caminho)
        {
            this.caminho = caminho;
        }

 
        public bool isExtValida(String extDesejada, String fileName)
        {
            String[] aux = fileName.Split('.');
            int result = String.Compare(aux[aux.Length - 1], extDesejada, true);//compara ignorano cs
            if (result == 0)
                return true;
            else
                return false;
        }

        public String getExt(String fileName)
        {
            String[] aux = fileName.Split('.');
            return aux[aux.Length - 1];
        }


        public int getQtdLinha()
        {
            int cont = 0;
            StreamReader arq2 = new StreamReader(caminho); //damos new pra voltar pro começo (seek pau)
            while (!arq2.EndOfStream)
            {
                arq2.ReadLine();
                cont++;
            }
            arq2.Close();
            return cont;
        }

        public int getQtdColuna()
        {
            StreamReader arq2 = new StreamReader(caminho);
            String linha = arq2.ReadLine();
            String[] aux = linha.Split('\t');
            arq2.Close();
            return aux.Length;
        }

        public String getConteudo()
        {
            String result = "";
            StreamReader arq2 = new StreamReader(caminho);
            while (!arq2.EndOfStream)
            {
                result += arq2.ReadLine() + "\n";
            }
            arq2.Close();
            return result;
        }

        public List<String> getConteudoEmLista()
        {
            List<String> retorno = new List<String>();
            StreamReader arq2 = new StreamReader(caminho);
            while (!arq2.EndOfStream)
                retorno.Add(arq2.ReadLine());
            arq2.Close();
            return retorno;
        }

        public void salvar(String text, String caminho, bool salvarComo)
        {
            if (salvarComo)
            {
                arqSaida = new StreamWriter(caminho);
                arqSaida.WriteLine(text);
                arqSaida.Dispose();
                arq = new StreamReader(caminho);
            }
            else
            {
                arq.Close();
                arq.Dispose();
                arqSaida = new StreamWriter(this.caminho);
                arqSaida.WriteLine(text);
                arqSaida.Dispose();
                arq = new StreamReader(this.caminho);
            }
        }

      
    }
}
