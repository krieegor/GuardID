using Classes.Autenticacoes;
using Classes.Conexoes;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Uteis
{
	public partial class frmManutencaoPermissoesEditarGrupo : FormBasic
    {
        private int _grupo;

        public frmManutencaoPermissoesEditarGrupo(string grupo)
        {
            InitializeComponent();

            this._grupo = int.Parse(grupo);
        }

        private void PreencherGridUsuariosGrupo()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
           ");
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
            DataTable dtUsuariosGrupo = dal.ExecuteQuery(sql.ToString());

            dgvUsuariosGrupo.DataSource = dtUsuariosGrupo;
            dgvUsuariosGrupo.Refresh();
            dgvUsuariosGrupo.ClearSelection();
        }

        private void frmManutencaoPermissoesEditarGrupo_Load(object sender, EventArgs e)
        {
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
            StringBuilder sql = new StringBuilder();

            #region Verificar se o usuário é administrador do grupo
            sql.Clear();
            sql.Append(@"");
            DataTable dtUsuario = dal.ExecuteQuery(sql.ToString());

            if (!dtUsuario.Rows[0][0].ToString().Equals("1"))
            {
                MessageBox.Show("Apenas os administradores do grupo têm acesso a este recurso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            #endregion

            #region Preencher descrição do grupo
            sql.Clear();
            sql.Append(@"");
            DataTable dtGrupo = dal.ExecuteQuery(sql.ToString());

            lblCodGrupo.Text = this._grupo.ToString();
            lblDescricaoGrupo.Text = dtGrupo.Rows[0]["descricao"].ToString();
            #endregion

            PreencherGridUsuariosGrupo();
        }

        private void dgvUsuariosGrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1))
            {
                string coluna = dgvUsuariosGrupo.Columns[e.ColumnIndex].Name;
                if (dgvUsuariosGrupo.Columns[e.ColumnIndex].Name.Equals("colLog"))
                {
                    string usuario = dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colUsuario"].Value.ToString();
                    frmAuditoriaFormulario frmAuditoriaFormulario = new frmAuditoriaFormulario("USUARIOS_GRUPOS", "SEG", "GRUPO;USUARIO", this._grupo + ";'" + usuario + "'");
                    if (frmAuditoriaFormulario.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        frmAuditoriaFormulario.ShowDialog();
                    }
                }
                if (dgvUsuariosGrupo.Columns[e.ColumnIndex].Name.Equals("colExcluir"))
                {
                    if (dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colMaster"].Value.ToString().ToLower().Equals("sim".ToLower()) ||
                        dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colAdmin"].Value.ToString().ToLower().Equals("sim".ToLower()))
                    {
                        MessageBox.Show("Ação negada. Não é possível excluir um usuário Master ou Administrador.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string usuario = dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colUsuario"].Value.ToString();
                    string usuarioNome = dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colUsuarioNome"].Value.ToString();

                    if ((MessageBox.Show("Confirma a exclusão do usuário " + usuario + " - " + usuarioNome.ToUpper() + " do grupo?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
                    {
                        string sql = (@"");
                        Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
                        dal.ExecuteNonQuery(sql);

                        PreencherGridUsuariosGrupo();
                    }
                }
            }
        }
        private void dgvUsuariosGrupo_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvUsuariosGrupo.Columns[e.ColumnIndex].Name.Equals("colExcluir"))
                {
                    dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colExcluir"].Style.BackColor = Color.IndianRed;
                    dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colExcluir"].Style.SelectionBackColor = Color.IndianRed;
                }
                else if (dgvUsuariosGrupo.Columns[e.ColumnIndex].Name.Equals("colLog"))
                {
                    dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colLog"].Style.BackColor = Color.Gold;
                    dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colLog"].Style.SelectionBackColor = Color.Gold;
                }
            }
        }
        private void dgvUsuariosGrupo_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvUsuariosGrupo.Columns[e.ColumnIndex].Name.Equals("colExcluir"))
                {
                    dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colExcluir"].Style.BackColor = dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colUsuario"].Style.BackColor;
                    dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colExcluir"].Style.SelectionBackColor = dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colUsuario"].Style.SelectionBackColor;
                }
                else if (dgvUsuariosGrupo.Columns[e.ColumnIndex].Name.Equals("colLog"))
                {
                    dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colLog"].Style.BackColor = dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colUsuario"].Style.BackColor;
                    dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colLog"].Style.SelectionBackColor = dgvUsuariosGrupo.Rows[e.RowIndex].Cells["colUsuario"].Style.SelectionBackColor;
                }
            }
        }
        private void dgvUsuariosGrupo_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvUsuariosGrupo.Columns[e.ColumnIndex].Name.Equals("colLog") ||
                    dgvUsuariosGrupo.Columns[e.ColumnIndex].Name.Equals("colExcluir"))
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void dgvUsuariosGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAddUsuario_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
           ");

            FormBusca fb = new FormBusca(sql.ToString(), new List<System.Data.OracleClient.OracleParameter>(), false, "Busca por usuários", "NOME", "", "Nenhum Registro Encontrado");
            fb.ShowDialog();


            if (fb.retorno != null)
            {
                int usuario = int.Parse(fb.retorno["USUARIO"].ToString());

                try
                {
                    sql.Clear();
                    sql.Append(@"
                   ");

                    Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
                    dal.ExecuteNonQuery(sql.ToString());

                    PreencherGridUsuariosGrupo();
                    MessageBox.Show("Usuário adicionado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível gravar o registro.\nMotivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
