namespace compilador
{
    partial class frmTabSimb
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
            this.dtgvLexico = new System.Windows.Forms.DataGridView();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NLinha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLexico)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvLexico
            // 
            this.dtgvLexico.AllowUserToAddRows = false;
            this.dtgvLexico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLexico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lexema,
            this.Token,
            this.NLinha,
            this.Atributo});
            this.dtgvLexico.Location = new System.Drawing.Point(0, 0);
            this.dtgvLexico.Name = "dtgvLexico";
            this.dtgvLexico.ReadOnly = true;
            this.dtgvLexico.Size = new System.Drawing.Size(595, 380);
            this.dtgvLexico.TabIndex = 0;
            // 
            // Lexema
            // 
            this.Lexema.DataPropertyName = "Lexema";
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.Name = "Lexema";
            this.Lexema.ReadOnly = true;
            // 
            // Token
            // 
            this.Token.DataPropertyName = "Token";
            this.Token.HeaderText = "Token";
            this.Token.Name = "Token";
            this.Token.ReadOnly = true;
            // 
            // NLinha
            // 
            this.NLinha.DataPropertyName = "NLinha";
            this.NLinha.HeaderText = "Nº Linha";
            this.NLinha.Name = "NLinha";
            this.NLinha.ReadOnly = true;
            // 
            // Atributo
            // 
            this.Atributo.DataPropertyName = "Atributo";
            this.Atributo.HeaderText = "Atributo";
            this.Atributo.Name = "Atributo";
            this.Atributo.ReadOnly = true;
            // 
            // frmTabSimb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 409);
            this.Controls.Add(this.dtgvLexico);
            this.MaximizeBox = false;
            this.Name = "frmTabSimb";
            this.Text = "Exibe Tabela Símbolos";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLexico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvLexico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn NLinha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Atributo;
    }
}