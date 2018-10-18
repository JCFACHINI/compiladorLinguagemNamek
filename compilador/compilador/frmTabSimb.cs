using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace compilador
{
    public partial class frmTabSimb : Form
    {
        public frmTabSimb(DataTable dtLexico)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            dtgvLexico.DataSource = dtLexico;
        }
    }
}
