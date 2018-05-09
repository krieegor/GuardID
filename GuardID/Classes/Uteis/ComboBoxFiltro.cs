using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Uteis;

namespace ComboBoxFiltroGuard
{
    public partial class ComboBoxFiltroGuard : UserControl
    {
        public ComboBoxFiltroGuard()
        {
            InitializeComponent();
            cboCampo.Enabled = false;
        }

        private string _textChk = "Campo";
        public string TextCheck
        {
            get { lblTitulo.Text = _textChk; return _textChk; }
            set { lblTitulo.Text = value; _textChk = value; }
        }

        private void chkTitulo_CheckedChanged(object sender, EventArgs e)
        {
            if (lblTitulo.Checked)
            {
                cboCampo.Enabled = true;
            }
            else
            {
                cboCampo.Enabled = false;
            }
        }

        public bool Checado()
        {
            if (lblTitulo.Checked &&  (cboCampo.SelectedIndex >= 0))
                return true;
            else
                return false;
        }

        public void SetLista(DataTable dtLista, string displayMember, string valueMember)
        {
            cboCampo.DataSource = dtLista;
            cboCampo.DisplayMember = displayMember;
            cboCampo.ValueMember = valueMember;
        }
    }
}