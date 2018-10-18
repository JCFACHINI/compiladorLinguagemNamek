namespace compilador
{
    partial class frmExibeSintese
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
            this.label1 = new System.Windows.Forms.Label();
            this.ttbInt = new System.Windows.Forms.RichTextBox();
            this.ttbCodObj = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código Intermediário";
            // 
            // ttbInt
            // 
            this.ttbInt.Location = new System.Drawing.Point(64, 62);
            this.ttbInt.Name = "ttbInt";
            this.ttbInt.Size = new System.Drawing.Size(400, 400);
            this.ttbInt.TabIndex = 2;
            this.ttbInt.Text = "";
            // 
            // ttbCodObj
            // 
            this.ttbCodObj.Location = new System.Drawing.Point(574, 62);
            this.ttbCodObj.Name = "ttbCodObj";
            this.ttbCodObj.Size = new System.Drawing.Size(400, 400);
            this.ttbCodObj.TabIndex = 4;
            this.ttbCodObj.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(748, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Código Objeto";
            // 
            // frmExibeSintese
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.ttbCodObj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ttbInt);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmExibeSintese";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exibe síntese";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox ttbInt;
        private System.Windows.Forms.RichTextBox ttbCodObj;
        private System.Windows.Forms.Label label2;
    }
}