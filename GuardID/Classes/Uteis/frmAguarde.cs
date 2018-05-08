using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Guard;

namespace System.Windows.Forms.Guard
{
    public partial class frmAguarde : FormGuard
    {
        //private static int tempHeight = 0;
        //private static int tempWidth = 0;

        public frmAguarde(string titulo)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(titulo.ToString()))
                lbMensagem.Text = titulo.ToString();
        }
        public frmAguarde()
        {
            //Screen Srn = Screen.PrimaryScreen;

            //tempHeight = Srn.Bounds.Height;
            //tempWidth = Srn.Bounds.Width;

            //int x = tempWidth - 985;
            //int y = tempHeight - 49;

            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(100,100);

            InitializeComponent();
        }

    }
}
