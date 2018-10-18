namespace compilador
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.listaTokens = new System.Windows.Forms.ToolStripButton();
            this.abriArquivo = new System.Windows.Forms.ToolStripButton();
            this.Compilar = new System.Windows.Forms.ToolStripButton();
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.pcboxLateral = new System.Windows.Forms.PictureBox();
            this.cxTexto = new System.Windows.Forms.RichTextBox();
            this.dtgvMsgs = new System.Windows.Forms.DataGridView();
            this.Linha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoErro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mensagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pnlRodape = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lineNumbers_For_RichTextBox1 = new LineNumbers.LineNumbers_For_RichTextBox();
            this.pnlMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcboxLateral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMsgs)).BeginInit();
            this.pnlRodape.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.toolStrip1);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(984, 73);
            this.pnlMenu.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::compilador.Properties.Resources.logo1;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btnSalvar,
            this.listaTokens,
            this.abriArquivo,
            this.Compilar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 73);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::compilador.Properties.Resources.bold_32x32;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 70);
            this.toolStripButton1.Text = "Fonte";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(36, 70);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // listaTokens
            // 
            this.listaTokens.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.listaTokens.Image = ((System.Drawing.Image)(resources.GetObject("listaTokens.Image")));
            this.listaTokens.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.listaTokens.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.listaTokens.Name = "listaTokens";
            this.listaTokens.Size = new System.Drawing.Size(36, 70);
            this.listaTokens.Text = "tabela símbolos";
            this.listaTokens.Click += new System.EventHandler(this.listaTokens_Click);
            // 
            // abriArquivo
            // 
            this.abriArquivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abriArquivo.Image = ((System.Drawing.Image)(resources.GetObject("abriArquivo.Image")));
            this.abriArquivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.abriArquivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abriArquivo.Name = "abriArquivo";
            this.abriArquivo.Size = new System.Drawing.Size(36, 70);
            this.abriArquivo.Text = "Abrir";
            this.abriArquivo.Click += new System.EventHandler(this.abriArquivo_Click);
            // 
            // Compilar
            // 
            this.Compilar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Compilar.Image = ((System.Drawing.Image)(resources.GetObject("Compilar.Image")));
            this.Compilar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Compilar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Compilar.Name = "Compilar";
            this.Compilar.Size = new System.Drawing.Size(36, 70);
            this.Compilar.Text = "Compilar";
            this.Compilar.Click += new System.EventHandler(this.Compilar_Click);
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlConteudo.Controls.Add(this.lineNumbers_For_RichTextBox1);
            this.pnlConteudo.Controls.Add(this.pcboxLateral);
            this.pnlConteudo.Controls.Add(this.cxTexto);
            this.pnlConteudo.Controls.Add(this.dtgvMsgs);
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(0, 73);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(984, 594);
            this.pnlConteudo.TabIndex = 2;
            // 
            // pcboxLateral
            // 
            this.pcboxLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(207)))), ((int)(((byte)(194)))));
            this.pcboxLateral.Image = global::compilador.Properties.Resources.lateral;
            this.pcboxLateral.Location = new System.Drawing.Point(893, 0);
            this.pcboxLateral.Name = "pcboxLateral";
            this.pcboxLateral.Size = new System.Drawing.Size(91, 588);
            this.pcboxLateral.TabIndex = 2;
            this.pcboxLateral.TabStop = false;
            // 
            // cxTexto
            // 
            this.cxTexto.AcceptsTab = true;
            this.cxTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxTexto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cxTexto.Location = new System.Drawing.Point(26, 0);
            this.cxTexto.Name = "cxTexto";
            this.cxTexto.Size = new System.Drawing.Size(868, 501);
            this.cxTexto.TabIndex = 1;
            this.cxTexto.Text = "";
            this.cxTexto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cxTexto_MouseClick);
            // 
            // dtgvMsgs
            // 
            this.dtgvMsgs.AllowUserToAddRows = false;
            this.dtgvMsgs.AllowUserToDeleteRows = false;
            this.dtgvMsgs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvMsgs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Linha,
            this.tipoErro,
            this.Mensagem});
            this.dtgvMsgs.Location = new System.Drawing.Point(0, 499);
            this.dtgvMsgs.Name = "dtgvMsgs";
            this.dtgvMsgs.ReadOnly = true;
            this.dtgvMsgs.Size = new System.Drawing.Size(894, 95);
            this.dtgvMsgs.TabIndex = 0;
            // 
            // Linha
            // 
            this.Linha.DataPropertyName = "nLinha";
            this.Linha.HeaderText = "Linha";
            this.Linha.Name = "Linha";
            this.Linha.ReadOnly = true;
            // 
            // tipoErro
            // 
            this.tipoErro.DataPropertyName = "tipo";
            this.tipoErro.HeaderText = "Tipo do Erro";
            this.tipoErro.Name = "tipoErro";
            this.tipoErro.ReadOnly = true;
            // 
            // Mensagem
            // 
            this.Mensagem.DataPropertyName = "msg";
            this.Mensagem.HeaderText = "Mensagem";
            this.Mensagem.Name = "Mensagem";
            this.Mensagem.ReadOnly = true;
            this.Mensagem.Width = 800;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Namekis files|*.nks";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "nks";
            // 
            // pnlRodape
            // 
            this.pnlRodape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlRodape.BackgroundImage = global::compilador.Properties.Resources.bottom;
            this.pnlRodape.Controls.Add(this.label2);
            this.pnlRodape.Controls.Add(this.label1);
            this.pnlRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRodape.Location = new System.Drawing.Point(0, 667);
            this.pnlRodape.Name = "pnlRodape";
            this.pnlRodape.Size = new System.Drawing.Size(984, 45);
            this.pnlRodape.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(749, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Desenvolvido por: JC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compilador desenvolvido na disciplina de Compiladores da FIPP no ano de 2013";
            // 
            // lineNumbers_For_RichTextBox1
            // 
            this.lineNumbers_For_RichTextBox1._SeeThroughMode_ = false;
            this.lineNumbers_For_RichTextBox1.AutoSizing = true;
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue;
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lineNumbers_For_RichTextBox1.BorderLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbers_For_RichTextBox1.BorderLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.DockSide = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Left;
            this.lineNumbers_For_RichTextBox1.GridLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbers_For_RichTextBox1.GridLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lineNumbers_For_RichTextBox1.LineNrs_AntiAlias = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_AsHexadecimal = false;
            this.lineNumbers_For_RichTextBox1.LineNrs_ClippedByItemRectangle = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_LeadingZeroes = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_Offset = new System.Drawing.Size(0, 0);
            this.lineNumbers_For_RichTextBox1.Location = new System.Drawing.Point(8, 0);
            this.lineNumbers_For_RichTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.lineNumbers_For_RichTextBox1.MarginLines_Color = System.Drawing.Color.PowderBlue;
            this.lineNumbers_For_RichTextBox1.MarginLines_Side = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Right;
            this.lineNumbers_For_RichTextBox1.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineNumbers_For_RichTextBox1.MarginLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.Name = "lineNumbers_For_RichTextBox1";
            this.lineNumbers_For_RichTextBox1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lineNumbers_For_RichTextBox1.ParentRichTextBox = this.cxTexto;
            this.lineNumbers_For_RichTextBox1.Show_BackgroundGradient = true;
            this.lineNumbers_For_RichTextBox1.Show_BorderLines = true;
            this.lineNumbers_For_RichTextBox1.Show_GridLines = true;
            this.lineNumbers_For_RichTextBox1.Show_LineNrs = true;
            this.lineNumbers_For_RichTextBox1.Show_MarginLines = true;
            this.lineNumbers_For_RichTextBox1.Size = new System.Drawing.Size(17, 501);
            this.lineNumbers_For_RichTextBox1.TabIndex = 3;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 712);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlRodape);
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "Compilador da linguagem Namekis by JC";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlConteudo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcboxLateral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMsgs)).EndInit();
            this.pnlRodape.ResumeLayout(false);
            this.pnlRodape.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRodape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripButton Compilar;
        private System.Windows.Forms.DataGridView dtgvMsgs;
        private System.Windows.Forms.RichTextBox cxTexto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linha;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoErro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mensagem;
        private System.Windows.Forms.PictureBox pcboxLateral;
        private System.Windows.Forms.ToolStripButton listaTokens;
        private System.Windows.Forms.ToolStripButton abriArquivo;
        private LineNumbers.LineNumbers_For_RichTextBox lineNumbers_For_RichTextBox1;
    }
}

