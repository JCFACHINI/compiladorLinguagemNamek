using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using compilador.classes;

namespace compilador
{
    public partial class frmPrincipal : Form
    {
        Arquivo arqEntrada;
        DataTable dttMsgs;
        Analise faseAnalise;
        Sintese faseSintese;
        List<Token> tabelaTokens;
        List<Erro> listaErros;
        bool algumaLinhaGrifada;

        public frmPrincipal()
        {
            InitializeComponent();
            inicializaTudo();
        }

        private void inicializaTudo()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            inicializaDataTableErros();
            if (arqEntrada != null && !arqEntrada.getCaminho().Equals(""))
                arqEntrada.getArq().Close();
            arqEntrada = new Arquivo();
            algumaLinhaGrifada = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                cxTexto.Font = fontDialog1.Font;
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cxTexto.Text != "")
            {
                if (arqEntrada.getCaminho() != "")
                {
                    arqEntrada.salvar(cxTexto.Text, "", false);
                }
                else
                {
                    salvarComoToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                arqEntrada.salvar(cxTexto.Text, saveFileDialog1.FileName, true);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            salvarToolStripMenuItem_Click(sender, e);
        }

        private void inicializaDataTableErros()
        {
            dttMsgs = new DataTable();
            dttMsgs.TableName = "Mensagens";
            dttMsgs.Columns.Add("nLinha");
            dttMsgs.Columns.Add("msg");
            dttMsgs.Columns.Add("tipo");
            dtgvMsgs.DataSource = dttMsgs;
        }

        private void carregaDtErros()
        {
            dttMsgs.Clear();
            foreach (Erro erro in listaErros)
            {
                DataRow linha = dttMsgs.NewRow();
                linha["nLinha"] = erro.NLinha;
                linha["msg"] = erro.Msg;
                linha["tipo"] = erro.Tipo;
                dttMsgs.Rows.Add(linha);
            }
        }

        private void listaToLista(List<Erro> l1, List<Erro> l2)
        {
            l2.Clear();
            foreach (Erro erro in l1)
                l2.Add(erro);
        }

        private void Compilar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            salvarToolStripMenuItem_Click(sender, e);

            if (cxTexto.Text != "")
            {
                faseAnalise = new Analise(cxTexto.Text + "\n");
                faseAnalise.executa();
                if (!faseAnalise.getErroLexico() && !faseAnalise.getErroSintatico() &&
                    !faseAnalise.getErroSemantico())
                {
                    dttMsgs.Clear();
                    tabelaTokens = faseAnalise.getTabelaSimbolos();
                    faseSintese = new Sintese(tabelaTokens);
                    faseSintese.executa();
                    new frmExibeSintese(faseSintese.getCodInt(), faseSintese.getCodObj()).Show();
                }
                else
                {
                    listaErros = faseAnalise.getListaErros();
                    carregaDtErros();
                    grifaErros(listaErros);
                }
            }
            else
                MessageBox.Show("Digite um código ou abra de um arquivo antes de compilar!", "Compilar o quê?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Cursor = Cursors.Default;
        }

        void grifaErros(List<Erro> erros)
        {
            foreach (Erro erro in erros)
            {
                int pos = cxTexto.GetFirstCharIndexFromLine(erro.NLinha - 1);
                String linhaErro = cxTexto.Lines[erro.NLinha - 1];
                cxTexto.Select(pos, linhaErro.Length);
                cxTexto.SelectionBackColor = Color.Red;
            }
            cxTexto.Select(0, 0);
            cxTexto.SelectionBackColor = Color.White;
            algumaLinhaGrifada = true;
        }

        public void exibeTabelaTokens()
        {
            if (tabelaTokens != null)
            {
                DataTable dtLexico = new DataTable();
                dtLexico.TableName = "Lexico";
                dtLexico.Columns.Add("Lexema");
                dtLexico.Columns.Add("Token");
                dtLexico.Columns.Add("NLinha", typeof(Int32));
                dtLexico.Columns.Add("Atributo");
                foreach (Token token in tabelaTokens)
                {
                    DataRow linha = dtLexico.NewRow();
                    linha["Lexema"] = token.getLexema();
                    linha["Token"] = token.getToken();
                    linha["NLinha"] = token.getLinha();
                    linha["Atributo"] = token.getAtributo();
                    dtLexico.Rows.Add(linha);
                }

                frmTabSimb frmLexico = new frmTabSimb(dtLexico);
                frmLexico.Show();
            }
        }

        private void listaTokens_Click(object sender, EventArgs e)
        {
            exibeTabelaTokens();
        }

        private void abriArquivo_Click(object sender, EventArgs e)
        {
            inicializaTudo();
            DialogResult abrirSemSalvar = DialogResult.Yes;
            DialogResult dr;
            if (cxTexto.Text != "")
            {
                abrirSemSalvar = MessageBox.Show("Se continuar perderá o arquivo atual, deseja continuar?", "Abrir novo sem salvar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            }
            if (abrirSemSalvar == DialogResult.Yes)
            {
                dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    arqEntrada = new Arquivo(openFileDialog1.FileName);
                    cxTexto.Text = arqEntrada.getConteudo();
                }
            }
        }

        private void cxTexto_MouseClick(object sender, MouseEventArgs e)
        {
            if (cxTexto.Text != "" && algumaLinhaGrifada)
            {
                cxTexto.SelectAll();
                cxTexto.SelectionBackColor = Color.White;
                cxTexto.Select(0, 0);
                cxTexto.SelectionBackColor = Color.White;
                algumaLinhaGrifada = false;
            }
        }
    }
}
