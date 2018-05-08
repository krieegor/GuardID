using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Uteis;

namespace System.Uteis
{
    internal partial class frmExtratorDadosConsulta : FormConsulta
    {
        public string Comando = "";
        private int Sistema;
        private bool trazerClob;

        public frmExtratorDadosConsulta(int pSistema, bool trazerClob)
        {
            InitializeComponent();

            this.toolStripBtnBusca.Visible = false;
            this.toolStripBtnDetalhar.Visible = false;
            this.toolStripBtnExcel.Visible = false;
            this.toolStripBtnLimpar.Visible = false;
            this.toolStripSeparatorOpcoes.Visible = false;

            this.Sistema = pSistema;
            this.trazerClob = trazerClob;
        }

        private void dgvComandos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            txtTotais.Text = "Total: " + dgvComandos.Rows.Count + " registros.";
        }
        private void dgvComandos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtTotais.Text = "Total: " + dgvComandos.Rows.Count + " registros.";
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            dgvComandos.DataSource = BuscaExtratorDadosComandoConsulta(txtFiltro.Text, this.Sistema, this.trazerClob);
        }

        private void dgvComandos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvComandos.SelectedRows != null && dgvComandos.SelectedRows.Count > 0)
            {
                txtComando.Text = dgvComandos.SelectedRows[0].Cells["colComando"].Value.ToString();
                txtComandoDesc.Text = dgvComandos.SelectedRows[0].Cells["colComandoDesc"].Value.ToString();
                
                string[] vet = dgvComandos.SelectedRows[0].Cells["colFinalidade"].Value.ToString().Split('$');
                string finalidade = "";
                foreach (string a in vet)
                    finalidade += a + Environment.NewLine;

                txtFinalidade.Text = finalidade;

            }
        }

        private void btnUtilizarComando_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtComando.Text))
            {
                this.Comando = txtComando.Text;

                this.Dispose();
            }
            else
            {
                MessageBox.Show("Selecione um Comando para utilizá-lo.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmExtratorDadosConsulta_Load(object sender, EventArgs e)
        {
            btnFiltrar_Click(null, null);

            txtFiltro.Focus();
        }

        private void dgvComandos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.Comando = dgvComandos.SelectedRows[0].Cells["colComando"].Value.ToString();

                this.Dispose();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                btnFiltrar_Click(null, null);
        }

        private static DataTable BuscaExtratorDadosComandoConsulta(string pFiltroLike, int pSistema, bool buscaSQL)
        {
            ClassesConexoes.Conexao dal = new ClassesConexoes.Conexao(Classes.Entity.Globals.GetStringConnection(), 2);

            dal.AddParam("pSistema", pSistema);
            StringBuilder sql;

            if (pSistema == 129)
            {
                sql = new StringBuilder(@"");
            }
            else
            {
                sql = new StringBuilder(@"");
            }

            return dal.ExecuteQuery(sql.ToString());
        }

    }
}
