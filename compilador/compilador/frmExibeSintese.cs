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
    public partial class frmExibeSintese : Form
    {
        public frmExibeSintese(List<String> codInt, List<String> codObj)
        {
            InitializeComponent();
            foreach (String linha in codInt)
            {
                ttbInt.Text += linha;
                ttbInt.Text += "\n";
            }
            foreach (String linha in codObj)
            {
                ttbCodObj.Text += linha;
                ttbCodObj.Text += "\n";
            }
        }
    }
}
