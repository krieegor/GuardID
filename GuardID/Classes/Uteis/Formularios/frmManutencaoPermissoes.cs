﻿using Classes.Autenticacoes;
using Classes.Conexoes;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace System.Uteis
{
	public partial class frmManutencaoPermissoes : FormBasic
    {
        private string _codPrograma;
        public string CodPrograma
        {
            get { return _codPrograma; }
            set
            {
                _codPrograma = value;
                this.lblCodPrograma.Text = value;
            }
        }

        private int _usuarioLogado;
        public int UsuarioLogado
        {
            get { return _usuarioLogado; }
            set { _usuarioLogado = value; }
        }

        private bool usuarioAdmin { get; set; }

        public frmManutencaoPermissoes()
        {
            InitializeComponent();
        }

        private DataTable retornaDataTable(StringBuilder sql)
        {
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
            return dal.ExecuteQuery(sql.ToString());
        }

        private void LimparGrid(DataGridView dgv)
        {
            if (dgv.RowCount > 0)
            {
                //limpa a grid, caso tenha registros nela
                DataTable dt = (DataTable)dgv.DataSource;
                dt.Clear();
                dgv.DataSource = dt;
            }
        }

        private void BuscarInformacoesPrograma()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"");
            DataTable dtPrograma = this.retornaDataTable(sql);

            if (dtPrograma.Rows.Count == 1)
            {
                this.lblDescricaoPrograma.Text = dtPrograma.Rows[0]["NM_PROGRAMA"].ToString();
                this.lblCodPrograma.Text = this.CodPrograma;
            }
            else
            {
                MessageBox.Show("Erro em BuscarInformacoesPrograma()");
            }
        }
        private void BuscarInformacoesUsuario()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"");
            DataTable dtUsuario = this.retornaDataTable(sql);

            if (dtUsuario.Rows.Count == 1)
            {
                if (dtUsuario.Rows[0][0].ToString().Equals("1"))
                {
                    this.usuarioAdmin = true;
                }
                else
                {
                    this.usuarioAdmin = false;
                }
            }
        }

        private void PreencherGruposAcesso()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"");
            DataTable dtGruposAcesso = this.retornaDataTable(sql);

            if (dtGruposAcesso.Rows.Count > 0)
            {
                DataTable dtGrid = new DataTable();
                dtGrid.Columns.Add("GRUPOS_GRUPO", typeof(string));
                dtGrid.Columns.Add("GRUPOS_DESCRICAO", typeof(string));
                dtGrid.Columns.Add("GRUPOS_PARTICIPANTES", typeof(string));
                dtGrid.Columns.Add("GRUPOS_INSERIR", typeof(bool));
                dtGrid.Columns.Add("GRUPOS_ALTERAR", typeof(bool));
                dtGrid.Columns.Add("GRUPOS_EXCLUIR", typeof(bool));

                DataRow dtRows = dtGrid.NewRow();

                foreach (DataRow item in dtGruposAcesso.Rows)
                {
                    dtRows["GRUPOS_GRUPO"] = item["GRUPO"].ToString();
                    dtRows["GRUPOS_DESCRICAO"] = item["DESCRICAO"].ToString();
                    dtRows["GRUPOS_PARTICIPANTES"] = item["PARTICIPANTES"].ToString();
                    dtRows["GRUPOS_INSERIR"] = item["INCLUIR"].ToString().Equals("1") ? true : false;
                    dtRows["GRUPOS_ALTERAR"] = item["ALTERAR"].ToString().Equals("1") ? true : false;
                    dtRows["GRUPOS_EXCLUIR"] = item["EXCLUIR"].ToString().Equals("1") ? true : false;

                    dtGrid.Rows.Add(dtRows);
                    dtRows = dtGrid.NewRow();
                }

                dgvGruposAcesso.DataSource = dtGrid;
                dgvGruposAcesso.Refresh();
            }
            else
            {
                this.LimparGrid(dgvGruposAcesso);
            }
        }
        private void PreencherUsuariosGrupo(string grupo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
                        ");
            DataTable dtUsuariosGrupo = this.retornaDataTable(sql);

            if (dtUsuariosGrupo.Rows.Count > 0)
            {
                DataTable dtGrid = new DataTable();
                dtGrid.Columns.Add("GRUPOS_USUARIOS_USUARIO", typeof(string));
                dtGrid.Columns.Add("GRUPOS_USUARIOS_NOME", typeof(string));
                dtGrid.Columns.Add("GRUPOS_USUARIOS_CENTROCUSTO", typeof(string));
                dtGrid.Columns.Add("GRUPOS_USUARIOS_MASTER", typeof(string));
                dtGrid.Columns.Add("GRUPOS_USUARIOS_ADM_GRUPO", typeof(string));
                dtGrid.Columns.Add("GRUPOS_USUARIOS_HERANCA", typeof(string));
                dtGrid.Columns.Add("GRUPOS_SITUACAO", typeof(string));

                DataRow dtRows = dtGrid.NewRow();

                foreach (DataRow item in dtUsuariosGrupo.Rows)
                {
                    dtRows["GRUPOS_USUARIOS_USUARIO"] = item["USUARIO"].ToString();
                    dtRows["GRUPOS_USUARIOS_NOME"] = item["NOME"].ToString().Replace("  ", ""); //Remove o excesso de espaços em branco no final do nome
                    dtRows["GRUPOS_USUARIOS_CENTROCUSTO"] = item["CENTRO_CUSTO"].ToString();
                    dtRows["GRUPOS_USUARIOS_MASTER"] = item["MASTER"].ToString();
                    dtRows["GRUPOS_USUARIOS_ADM_GRUPO"] = item["ADMIN_GRUPO"].ToString();
                    dtRows["GRUPOS_USUARIOS_HERANCA"] = item["HERANCA"].ToString();
                    dtRows["GRUPOS_SITUACAO"] = item["SITUACAO"].ToString();

                    dtGrid.Rows.Add(dtRows);
                    dtRows = dtGrid.NewRow();
                }

                dgvUsuariosGrupo.DataSource = dtGrid;
                dgvUsuariosGrupo.Refresh();

                //Colorir células
                foreach (DataGridViewRow item in dgvUsuariosGrupo.Rows)
                {
                    if (item.Cells["GRUPOS_SITUACAO"].Value.ToString().Equals("0")) // Demitido
                    {
                        item.DefaultCellStyle.BackColor = Color.Salmon;
                    }
                    else if (item.Cells["GRUPOS_SITUACAO"].Value.ToString().Equals("2")) // Licenciado
                    {
                        item.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                    }
                    else if (item.Cells["GRUPOS_USUARIOS_MASTER"].Value.ToString().Equals("1"))
                    {
                        item.DefaultCellStyle.BackColor = Color.FromArgb(255, 227, 215);
                    }
                    else if (item.Cells["GRUPOS_USUARIOS_ADM_GRUPO"].Value.ToString().Equals("1"))
                    {
                        item.DefaultCellStyle.BackColor = Color.FromArgb(205, 205, 254);
                    }
                    else if (item.Cells["GRUPOS_USUARIOS_HERANCA"].Value.ToString().Equals("1"))
                    {
                        item.DefaultCellStyle.BackColor = Color.FromArgb(165, 209, 209);
                    }
                }

                dgvUsuariosGrupo.ClearSelection();
            }
            else
            {
                this.LimparGrid(dgvUsuariosGrupo);
            }
        }
        private void PreencherAcessoUsuarios()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"");
            DataTable dtUsuariosPrograma = this.retornaDataTable(sql);

            if (dtUsuariosPrograma.Rows.Count > 0)
            {
                DataTable dtGrid = new DataTable();
                dtGrid.Columns.Add("USUARIOS_USUARIO", typeof(string));
                dtGrid.Columns.Add("USUARIOS_NOME", typeof(string));
                dtGrid.Columns.Add("USUARIOS_GRUPO", typeof(string));
                dtGrid.Columns.Add("USUARIOS_VISUALIZAR", typeof(string));
                dtGrid.Columns.Add("USUARIOS_INSERIR", typeof(string));
                dtGrid.Columns.Add("USUARIOS_ALTERAR", typeof(string));
                dtGrid.Columns.Add("USUARIOS_EXCLUIR", typeof(string));
                dtGrid.Columns.Add("USUARIOS_ADM", typeof(string));
                dtGrid.Columns.Add("USUARIOS_MASTER", typeof(string));
                dtGrid.Columns.Add("USUARIOS_HERDAR_PERMISSOES_GRUPO", typeof(Image));
                dtGrid.Columns.Add("USUARIOS_CENTROCUSTO", typeof(string));
                dtGrid.Columns.Add("USUARIOS_SITUACAO", typeof(string));

                dtGrid.Columns.Add("USUARIOS_HERANCA", typeof(string));


                DataRow dtRows = dtGrid.NewRow();

                foreach (DataRow item in dtUsuariosPrograma.Rows)
                {
                    dtRows["USUARIOS_USUARIO"] = item["USUARIO"].ToString();
                    dtRows["USUARIOS_NOME"] = item["NOME"].ToString();
                    dtRows["USUARIOS_GRUPO"] = item["GRUPO"].ToString();
                    dtRows["USUARIOS_VISUALIZAR"] = item["VISUALIZAR"].ToString().Equals("1") ? true : false;
                    dtRows["USUARIOS_INSERIR"] = item["INCLUIR"].ToString().Equals("1") ? true : false;
                    dtRows["USUARIOS_ALTERAR"] = item["ALTERAR"].ToString().Equals("1") ? true : false;
                    dtRows["USUARIOS_EXCLUIR"] = item["EXCLUIR"].ToString().Equals("1") ? true : false;
                    dtRows["USUARIOS_ADM"] = item["ADMIN"].ToString().Equals("1") ? true : false;
                    dtRows["USUARIOS_MASTER"] = item["MASTER"].ToString();
                    dtRows["USUARIOS_CENTROCUSTO"] = item["CENTRO_CUSTO"].ToString();
                    dtRows["USUARIOS_SITUACAO"] = item["SITUACAO"].ToString();

                    dtRows["USUARIOS_HERANCA"] = item["HERANCA"].ToString();

                    if ((item["HERANCA"].ToString().Equals("0") || item["ADMIN"].ToString().Equals("1")) && item["MASTER"].ToString().Equals("0"))
                    {
                        dtRows["USUARIOS_HERDAR_PERMISSOES_GRUPO"] = new Bitmap(@"Group.png");
                    }
                    else
                    {
                        dtRows["USUARIOS_HERDAR_PERMISSOES_GRUPO"] = new Bitmap(@"ImagemVazia.png");
                    }

                    dtGrid.Rows.Add(dtRows);
                    dtRows = dtGrid.NewRow();
                }

                dgvAcessosUsuarios.DataSource = dtGrid;
                dgvAcessosUsuarios.Refresh();
            }
            else
            {
                this.LimparGrid(dgvAcessosUsuarios);
            }
        }

        private void ColorirGridAcessosUsuarios()
        {
            //Colorir grid de Acesso por usuário
            foreach (DataGridViewRow item in dgvAcessosUsuarios.Rows)
            {
                if (item.Cells["USUARIOS_SITUACAO"].Value.ToString().Equals("0")) // Demitido
                {
                    item.DefaultCellStyle.BackColor = Color.Salmon;
                }
                else if (item.Cells["USUARIOS_SITUACAO"].Value.ToString().Equals("2")) // Licenciado
                {
                    item.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                }
                else if (item.Cells["USUARIOS_MASTER"].Value.ToString().Equals("1"))
                {
                    item.DefaultCellStyle.BackColor = Color.FromArgb(255, 227, 215);
                }
                else if (item.Cells["USUARIOS_ADM"].Value.ToString().Equals("1") || item.Cells["USUARIOS_ADM"].Value.ToString().Equals("True"))
                {
                    item.DefaultCellStyle.BackColor = Color.FromArgb(205, 205, 254);
                }
                else if (item.Cells["USUARIOS_HERANCA"].Value.ToString().Equals("0"))
                {
                    item.DefaultCellStyle.BackColor = Color.FromArgb(165, 209, 209);
                }
            }

            dgvAcessosUsuarios.ClearSelection();


        }

        private void frmManutencaoPermissoes_Load(object sender, EventArgs e)
        {
            BuscarInformacoesPrograma();
            BuscarInformacoesUsuario();
            PreencherGruposAcesso();
            if (dgvGruposAcesso.Rows.Count > 0)
            {
                PreencherUsuariosGrupo(dgvGruposAcesso.Rows[0].Cells["GRUPOS_GRUPO"].Value.ToString());
            }


            //1-Manutencao; 2-Relatorio; 3-Processo; 4-CONSULTA
            if (!this.usuarioAdmin)
            {
                btnAddGrupo.Enabled = false;
                btnAddUsuario.Enabled = false;

                //Grid de grupos
                dgvGruposAcesso.Columns["GRUPOS_INSERIR"].ReadOnly = true;
                dgvGruposAcesso.Columns["GRUPOS_ALTERAR"].ReadOnly = true;
                dgvGruposAcesso.Columns["GRUPOS_EXCLUIR"].ReadOnly = true;

                //Grid de acesso por usuários
                dgvAcessosUsuarios.Columns["USUARIOS_HERDAR_PERMISSOES_GRUPO"].ReadOnly = true;
                dgvAcessosUsuarios.Columns["USUARIOS_INSERIR"].ReadOnly = true;
                dgvAcessosUsuarios.Columns["USUARIOS_ALTERAR"].ReadOnly = true;
                dgvAcessosUsuarios.Columns["USUARIOS_EXCLUIR"].ReadOnly = true;
                dgvAcessosUsuarios.Columns["USUARIOS_ADM"].ReadOnly = true;
                dgvAcessosUsuarios.Columns["USUARIOS_VISUALIZAR"].ReadOnly = true;
            }
        }

        private void btnAddGrupo_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
                   ");

            FormBusca fb = new FormBusca(sql.ToString(), new List<System.Data.OracleClient.OracleParameter>(), true, "Busca por grupos", "DESCRICAO", "", "Nenhum Registro Encontrado");
            fb.ShowDialog();

            if (fb.retorno != null)
            {
                int cod_grupo = int.Parse(fb.retorno["GRUPO"].ToString());

                try
                {
                    sql.Clear();
                    sql.Append(@"
                                ");

                    Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
                    dal.ExecuteNonQuery(sql.ToString());

                    PreencherGruposAcesso();
                    dgvGruposAcesso.ClearSelection();
                    this.LimparGrid(dgvUsuariosGrupo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível gravar o registro.\nMotivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                int cod_usuario = int.Parse(fb.retorno["USUARIO"].ToString());

                try
                {
                    sql.Clear();
                    sql.Append(@"
                               
                                    ");

                    Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
                    dal.ExecuteNonQuery(sql.ToString());

                    PreencherAcessoUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível gravar o registro.\nMotivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tabAcessoPorUsuarios_Paint(object sender, PaintEventArgs e)
        {
            //ja testei, executa apenas uma vez
            PreencherAcessoUsuarios();
        }

        private void dgvGruposAcesso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1))
            {
                string grupoSelecionado = dgvGruposAcesso.Rows[e.RowIndex].Cells["GRUPOS_GRUPO"].Value.ToString();

                //Impede o click nas outras colunas
                string coluna = dgvGruposAcesso.Columns[e.ColumnIndex].Name;
                if (!(coluna.Equals("GRUPOS_INSERIR") ||
                    coluna.Equals("GRUPOS_ALTERAR") ||
                    coluna.Equals("GRUPOS_EXCLUIR") ||
                    coluna.Equals("GRUPOS_EXCLUIR_GRUPO") ||
                    coluna.Equals("colGruposEditar")))
                {
                    dgvGruposAcesso.Columns[e.ColumnIndex].ReadOnly = true;
                }
                else if (this.usuarioAdmin)
                {
                    #region Alterar as permissões do grupo

                    string update_set = "";

                   

                    if (!string.IsNullOrEmpty(update_set))
                    {
                        string sql = "";
                        sql = (@"");
                        Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
                        dal.ExecuteNonQuery(sql);

                        int index = dgvGruposAcesso.SelectedRows[0].Index;
                        PreencherGruposAcesso();
                        dgvGruposAcesso.Rows[index].Selected = true;
                    }
                    #endregion
                }
                else if (coluna.Equals("colGruposEditar"))
                {
                    #region Verificar se o usuário é administrador do grupo para permitir ou não editar
                    StringBuilder sql = new StringBuilder();
                    sql.Append(@"");
                    Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
                    DataTable dtUsuario = dal.ExecuteQuery(sql.ToString());

                    if (dtUsuario.Rows.Count == 1)
                    {
                        if (!dtUsuario.Rows[0][0].ToString().Equals("1"))
                        {
                            MessageBox.Show("Apenas os administradores do grupo têm acesso a este recurso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            frmManutencaoPermissoesEditarGrupo frm = new frmManutencaoPermissoesEditarGrupo(grupoSelecionado);
                            frm.ShowInTaskbar = false;
                            frm.ShowDialog();
                        }
                    }
                    #endregion
                }
            }
            else
            {
                this.LimparGrid(dgvUsuariosGrupo);
            }
        }
        private void dgvGruposAcesso_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                e.ColumnIndex >= 0 &&
                (dgvGruposAcesso.Columns[e.ColumnIndex].Name.Equals("GRUPOS_EXCLUIR_GRUPO") ||
                dgvGruposAcesso.Columns[e.ColumnIndex].Name.Equals("colGruposEditar")))
            {
                this.Cursor = Cursors.Hand;
            }
            else
                this.Cursor = Cursors.Default;
        }
        private void dgvGruposAcesso_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && dgvGruposAcesso.Columns[e.ColumnIndex].Name.Equals("GRUPOS_EXCLUIR_GRUPO"))
            {
                dgvGruposAcesso.Rows[e.RowIndex].Cells["GRUPOS_EXCLUIR_GRUPO"].Style.BackColor = Color.IndianRed;
                dgvGruposAcesso.Rows[e.RowIndex].Cells["GRUPOS_EXCLUIR_GRUPO"].Style.SelectionBackColor = Color.IndianRed;
            }
            else if (e.RowIndex != -1 && dgvGruposAcesso.Columns[e.ColumnIndex].Name.Equals("colGruposEditar"))
            {
                dgvGruposAcesso.Rows[e.RowIndex].Cells["colGruposEditar"].Style.BackColor = Color.Wheat;
                dgvGruposAcesso.Rows[e.RowIndex].Cells["colGruposEditar"].Style.SelectionBackColor = Color.Wheat;
            }
        }
        private void dgvGruposAcesso_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && dgvGruposAcesso.Columns[e.ColumnIndex].Name.Equals("GRUPOS_EXCLUIR_GRUPO"))
            {
                dgvGruposAcesso.Rows[e.RowIndex].Cells["GRUPOS_EXCLUIR_GRUPO"].Style.BackColor = dgvGruposAcesso.Rows[e.RowIndex].Cells["GRUPOS_GRUPO"].Style.BackColor;
                dgvGruposAcesso.Rows[e.RowIndex].Cells["GRUPOS_EXCLUIR_GRUPO"].Style.SelectionBackColor = dgvGruposAcesso.Rows[e.RowIndex].Cells["GRUPOS_GRUPO"].Style.SelectionBackColor;
            }
            else if (e.RowIndex != -1 && dgvGruposAcesso.Columns[e.ColumnIndex].Name.Equals("colGruposEditar"))
            {
                dgvGruposAcesso.Rows[e.RowIndex].Cells["colGruposEditar"].Style.BackColor = dgvGruposAcesso.Rows[e.RowIndex].Cells["GRUPOS_GRUPO"].Style.BackColor;
                dgvGruposAcesso.Rows[e.RowIndex].Cells["colGruposEditar"].Style.SelectionBackColor = dgvGruposAcesso.Rows[e.RowIndex].Cells["GRUPOS_GRUPO"].Style.SelectionBackColor;
            }
        }
        private void dgvGruposAcesso_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGruposAcesso.SelectedRows.Count == 1)
            {
                string grupoSelecionado = dgvGruposAcesso.SelectedRows[0].Cells["GRUPOS_GRUPO"].Value.ToString();
                PreencherUsuariosGrupo(grupoSelecionado);
            }
        }
        private void dgvGruposAcesso_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dgvUsuariosGrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1))
            {
                string coluna = dgvUsuariosGrupo.Columns[e.ColumnIndex].Name;
                if (coluna.Equals("GRUPOS_USUARIOS_LOG"))
                {
                    string usuario = dgvUsuariosGrupo.Rows[e.RowIndex].Cells["GRUPOS_USUARIOS_USUARIO"].Value.ToString();
                    frmAuditoriaFormulario frmAuditoriaFormulario = new frmAuditoriaFormulario("USUARIOS_PERMISSOES", "SEG", "USUARIO;PROGRAMA", usuario + ";'" + this.CodPrograma + "'");
                    if (frmAuditoriaFormulario.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        frmAuditoriaFormulario.ShowDialog();
                    }
                }

            }

        }
        private void dgvUsuariosGrupo_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                e.ColumnIndex >= 0 &&
                dgvUsuariosGrupo.Columns[e.ColumnIndex].Name.Equals("GRUPOS_USUARIOS_LOG"))
            {
                this.Cursor = Cursors.Hand;
            }
            else
                this.Cursor = Cursors.Default;
        }
        private void dgvUsuariosGrupo_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && dgvUsuariosGrupo.Columns[e.ColumnIndex].Name.Equals("GRUPOS_USUARIOS_LOG"))
            {
                dgvUsuariosGrupo.Rows[e.RowIndex].Cells["GRUPOS_USUARIOS_LOG"].Style.BackColor = Color.Gold;
                dgvUsuariosGrupo.Rows[e.RowIndex].Cells["GRUPOS_USUARIOS_LOG"].Style.SelectionBackColor = Color.Gold;
            }
        }
        private void dgvUsuariosGrupo_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && dgvUsuariosGrupo.Columns[e.ColumnIndex].Name.Equals("GRUPOS_USUARIOS_LOG"))
            {
                dgvUsuariosGrupo.Rows[e.RowIndex].Cells["GRUPOS_USUARIOS_LOG"].Style.BackColor = dgvUsuariosGrupo.Rows[e.RowIndex].Cells["GRUPOS_USUARIOS_USUARIO"].Style.BackColor;
                dgvUsuariosGrupo.Rows[e.RowIndex].Cells["GRUPOS_USUARIOS_LOG"].Style.SelectionBackColor = dgvUsuariosGrupo.Rows[e.RowIndex].Cells["GRUPOS_USUARIOS_USUARIO"].Style.SelectionBackColor;
            }
        }
        private void dgvUsuariosGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dgvAcessosUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex == -1))
            {
                //Impede o click nas outras colunas
                string coluna = dgvAcessosUsuarios.Columns[e.ColumnIndex].Name;
                if (!(coluna.Equals("USUARIOS_LOG") ||
                    coluna.Equals("USUARIOS_VISUALIZAR") ||
                    coluna.Equals("USUARIOS_INSERIR") ||
                    coluna.Equals("USUARIOS_ALTERAR") ||
                    coluna.Equals("USUARIOS_EXCLUIR") ||
                    coluna.Equals("USUARIOS_ADM") ||
                    coluna.Equals("USUARIOS_HERDAR_PERMISSOES_GRUPO")))
                {
                    dgvAcessosUsuarios.Columns[e.ColumnIndex].ReadOnly = true;
                }
                else if (coluna.Equals("USUARIOS_LOG"))
                {
                    string usuario = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_USUARIO"].Value.ToString();
                    frmAuditoriaFormulario frmAuditoriaFormulario = new frmAuditoriaFormulario("USUARIOS_PERMISSOES", "SEG", "USUARIO;PROGRAMA", usuario + ";'" + this.CodPrograma + "'");
                    if (frmAuditoriaFormulario.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        frmAuditoriaFormulario.ShowDialog();
                    }
                }
                else if (this.usuarioAdmin)
                {
                    if (coluna.Equals("USUARIOS_HERDAR_PERMISSOES_GRUPO"))
                    {
                        #region Atribuir as permissoes do grupo ao usuário

                        //Proibir o click quando nao tiver o icone de grupo (usuario ja com as permissoes do grupo)
                        if (dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_HERDAR_PERMISSOES_GRUPO"].Style.BackColor != Color.LimeGreen)
                        {
                            return;
                        }

                        string usuario = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_USUARIO"].Value.ToString();
                        bool permissaoIndividual = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_HERANCA"].Value.ToString().Equals("0") ? true : false;

                        //Proibir um usuário admin de tirar sua própria função de admin)
                        if (usuario.Equals(Globals.Usuario.ToString()))
                        {
                            dgvAcessosUsuarios.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                            dgvAcessosUsuarios.ClearSelection();
                            return;
                        }
                        else
                        {
                            if (permissaoIndividual)
                            {
                                if ((MessageBox.Show("Confirma a atribuição das permissões do grupo ao usuário " + usuario + "?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
                                {
                                    string sql = @" ";
                                    Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
                                    dal.ExecuteNonQuery(sql);

                                    PreencherAcessoUsuarios();
                                }
                            }
                            else
                            {
                                MessageBox.Show("O usuário " + usuario + " já possui as permissões do grupo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region Alterar as permissões do usuário
                        string usuario = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_USUARIO"].Value.ToString();

                        string update_set = "";
                        string insert_values = "";

                        string inserir = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_INSERIR"].Value.ToString().Equals("True") ? "1" : "0";
                        string excluir = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_EXCLUIR"].Value.ToString().Equals("True") ? "1" : "0";
                        string alterar = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ALTERAR"].Value.ToString().Equals("True") ? "1" : "0";
                        string visualizar = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_VISUALIZAR"].Value.ToString().Equals("True") ? "1" : "0";
                        string admin = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ADM"].Value.ToString().Equals("True") ? "1" : "0";


                        bool permissaoIndividual = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_HERANCA"].Value.ToString().Equals("0") ? true : false;

                        if (coluna.Equals("USUARIOS_INSERIR"))
                        {
                            string valor = (inserir.Equals("0") ? "1" : "0").ToString();

                            if (permissaoIndividual)
                            {
                                update_set = "SET UP.INCLUIR = " + valor;
                            }
                            else
                            {
                                insert_values = (valor + "," + excluir + "," + alterar + "," + visualizar + "," + admin);
                            }
                        }
                        else if (coluna.Equals("USUARIOS_EXCLUIR"))
                        {
                            string valor = (excluir.Equals("0") ? "1" : "0").ToString();

                            if (permissaoIndividual)
                            {
                                update_set = "SET UP.EXCLUIR = " + valor;
                            }
                            else
                            {
                                insert_values = (inserir + "," + valor + "," + alterar + "," + visualizar + "," + admin);
                            }
                        }
                        else if (coluna.Equals("USUARIOS_ALTERAR"))
                        {
                            string valor = (alterar.Equals("0") ? "1" : "0").ToString();

                            if (permissaoIndividual)
                            {
                                update_set = "SET UP.ALTERAR = " + valor;
                            }
                            else
                            {
                                insert_values = (inserir + "," + excluir + "," + valor + "," + visualizar + "," + admin);
                            }
                        }
                        else if (coluna.Equals("USUARIOS_VISUALIZAR"))
                        {
                            string valor = (visualizar.Equals("0") ? "1" : "0").ToString();

                            if (permissaoIndividual)
                                update_set = "SET UP.VISUALIZAR = " + valor;

                            else
                            {
                                insert_values = (inserir + "," + excluir + "," + alterar + "," + valor + "," + admin);
                            }
                        }
                        else if (coluna.Equals("USUARIOS_ADM"))
                        {
                            //Proibir um usuário admin de tirar sua própria função de admin)
                            if (usuario.Equals(Globals.Usuario.ToString()))
                            {
                                dgvAcessosUsuarios.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;

                                if (dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ADM"].Value.ToString().Equals("0"))
                                    dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ADM"].Value = 1;
                                else
                                    dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ADM"].Value = 0;

                                dgvAcessosUsuarios.ClearSelection();
                                return;
                            }
                            else
                            {
                                string valor = (admin.Equals("0") ? "1" : "0").ToString();

                                if (permissaoIndividual)
                                {
                                    update_set = "SET UP.ADMIN = " + valor;
                                }
                                else
                                {
                                    insert_values = (inserir + "," + excluir + "," + alterar + "," + visualizar + "," + valor);
                                }
                            }
                        }

                        string sql = "";

                        //Usuários com permissão individual
                        if (permissaoIndividual)
                        {
                            sql = (@"");
                        }
                        //Usuários com permissão do grupo (inserir registro em seg.usuarios_permissoes)
                        else
                        {
                            sql = (@"  ");
                        }

                        Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
                        dal.ExecuteNonQuery(sql);

                        PreencherAcessoUsuarios();

                        #endregion
                    }
                }
            }
        }
        private void dgvAcessosUsuarios_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string heranca = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_HERANCA"].Value.ToString();
                string master = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_MASTER"].Value.ToString();
                string admin = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ADM"].Value.ToString();

                if (dgvAcessosUsuarios.Columns[e.ColumnIndex].Name.Equals("USUARIOS_HERDAR_PERMISSOES_GRUPO") &&
                    (((heranca.Equals("0") || admin.Equals("1")) && master.Equals("0"))))
                {
                    this.Cursor = Cursors.Hand;
                }
                else if (dgvAcessosUsuarios.Columns[e.ColumnIndex].Name.Equals("USUARIOS_LOG"))
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
                this.Cursor = Cursors.Default;
        }
        private void dgvAcessosUsuarios_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string heranca = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_HERANCA"].Value.ToString();
                string master = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_MASTER"].Value.ToString();
                string admin = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ADM"].Value.ToString();


                if (dgvAcessosUsuarios.Columns[e.ColumnIndex].Name.Equals("USUARIOS_HERDAR_PERMISSOES_GRUPO") &&
                    (((heranca.Equals("0") || admin.Equals("1")) && master.Equals("0"))))
                {
                    dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_HERDAR_PERMISSOES_GRUPO"].Style.BackColor = Color.LimeGreen;
                    dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_HERDAR_PERMISSOES_GRUPO"].Style.SelectionBackColor = Color.LimeGreen;
                }
                else if (dgvAcessosUsuarios.Columns[e.ColumnIndex].Name.Equals("USUARIOS_LOG"))
                {
                    dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_LOG"].Style.BackColor = Color.Gold;
                    dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_LOG"].Style.SelectionBackColor = Color.Gold;
                }
            }
        }
        private void dgvAcessosUsuarios_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string heranca = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_HERANCA"].Value.ToString();
                string master = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_MASTER"].Value.ToString();
                string admin = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ADM"].Value.ToString();


                if (dgvAcessosUsuarios.Columns[e.ColumnIndex].Name.Equals("USUARIOS_HERDAR_PERMISSOES_GRUPO") &&
                    (((heranca.Equals("0") || admin.Equals("1")) && master.Equals("0"))))
                {
                    dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_HERDAR_PERMISSOES_GRUPO"].Style.BackColor = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_USUARIO"].Style.BackColor;
                    dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_HERDAR_PERMISSOES_GRUPO"].Style.SelectionBackColor = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_USUARIO"].Style.SelectionBackColor;
                }
                else if (dgvAcessosUsuarios.Columns[e.ColumnIndex].Name.Equals("USUARIOS_LOG"))
                {
                    dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_LOG"].Style.BackColor = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_USUARIO"].Style.BackColor;
                    dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_LOG"].Style.SelectionBackColor = dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_USUARIO"].Style.SelectionBackColor;
                }
            }
        }
        private void dgvAcessosUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ColorirGridAcessosUsuarios();
        }
        private void dgvAcessosUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.usuarioAdmin)
            {
                var ck = new DataGridViewCheckBoxCell();

                if (dgvAcessosUsuarios.Columns[e.ColumnIndex].Name.Equals("USUARIOS_VISUALIZAR"))
                {
                    ck = (DataGridViewCheckBoxCell)dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_VISUALIZAR"];

                    if (ck.Value.ToString().Equals("0"))
                        dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_VISUALIZAR"].Value = 1;

                    else
                        dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_VISUALIZAR"].Value = 0;

                    dgvAcessosUsuarios.RefreshEdit();
                }

                else if (dgvAcessosUsuarios.Columns[e.ColumnIndex].Name.Equals("USUARIOS_INSERIR"))
                {
                    ck = (DataGridViewCheckBoxCell)dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_INSERIR"];

                    if (ck.Value.ToString().Equals("0"))
                        dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_INSERIR"].Value = 1;

                    else
                        dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_INSERIR"].Value = 0;

                    dgvAcessosUsuarios.RefreshEdit();
                }

                else if (dgvAcessosUsuarios.Columns[e.ColumnIndex].Name.Equals("USUARIOS_ALTERAR"))
                {
                    ck = (DataGridViewCheckBoxCell)dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ALTERAR"];

                    if (ck.Value.ToString().Equals("0"))
                        dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ALTERAR"].Value = 1;

                    else
                        dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ALTERAR"].Value = 0;

                    dgvAcessosUsuarios.RefreshEdit();
                }

                else if (dgvAcessosUsuarios.Columns[e.ColumnIndex].Name.Equals("USUARIOS_EXCLUIR"))
                {
                    ck = (DataGridViewCheckBoxCell)dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_EXCLUIR"];

                    if (ck.Value.ToString().Equals("0"))
                        dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_EXCLUIR"].Value = 1;

                    else
                        dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_EXCLUIR"].Value = 0;

                    dgvAcessosUsuarios.RefreshEdit();
                }

                else if (dgvAcessosUsuarios.Columns[e.ColumnIndex].Name.Equals("USUARIOS_ADM"))
                {
                    ck = (DataGridViewCheckBoxCell)dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ADM"];

                    if (ck.Value.ToString().Equals("0"))
                        dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ADM"].Value = 1;

                    else
                        dgvAcessosUsuarios.Rows[e.RowIndex].Cells["USUARIOS_ADM"].Value = 0;

                    dgvAcessosUsuarios.RefreshEdit();
                }
            }
        }
        private void dgvAcessosUsuarios_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
