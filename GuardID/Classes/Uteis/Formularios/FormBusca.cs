using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Classes.Uteis;
using System.Data.OracleClient;
using Classes.Autenticacoes;
using Classes.Conexoes;

namespace System.Uteis
{
	public partial class FormBusca : FormBasic
    {
        private string _sql;
        private List<OracleParameter> _parametros;
        private string _mensagemSemRegistro;
        private bool _removerAcentuacao;
        private Globals.CBanco _banco;
        private string _orderBy;

        /// <summary>
        /// Variável para guardar quantas vezes o método PreencheGrid() foi executado. Essa informação serve para dar Dispose() somente quando for a primeira vez.
        /// </summary>
        private int _contadorPreencherGrid;

        public DataRow retorno;

        /// <summary>
        /// Formulário de Busca de Registros
        /// </summary>
        /// <param name="sql">Query a ser executada</param>
        /// <param name="autoExecutar">Executar query ao abrir o formulário</param>
        /// <param name="titulo">Título do formulário</param>
        /// <param name="colunaPrincipal">Nome da primeira coluna que aparecerá no filtro</param>
        /// <param name="filtroAutomatico">String para filtro automático</param>
        /// <param name="mensagemSemRegistro">Mensagem que aparecerá caso nenhum registro seja executado</param>
        /// <param name="removerAcentuacao">Remove acentuação do campo selecionado</param>
        /// <param name="banco">Banco de Dados (Globals.CBanco)</param>
        public FormBusca(string sql, List<OracleParameter> parametros, bool autoExecutar, string titulo, string colunaPrincipal, string filtroAutomatico, 
                         string mensagemSemRegistro, bool removerAcentuacao, Globals.CBanco banco, string orderBy)
        {
            InitializeComponent();
            _sql = sql;
            _parametros = parametros;
            _mensagemSemRegistro = mensagemSemRegistro;
            _removerAcentuacao = removerAcentuacao;
            _banco = banco;
            _orderBy = orderBy;
            retorno = null;
            PreencheTitulo(titulo);
            PreencheComboColuna(colunaPrincipal);
            PreencheCampoFiltro(filtroAutomatico);
            if (autoExecutar)
                PreencheGrid();
        }

        /// <summary>
        /// Formulário de Busca de Registros
        /// </summary>
        /// <param name="sql">Query a ser executada</param>
        /// <param name="autoExecutar">Executar query ao abrir o formulário</param>
        /// <param name="titulo">Título do formulário</param>
        /// <param name="colunaPrincipal">Nome da primeira coluna que aparecerá no filtro</param>
        /// <param name="filtroAutomatico">String para filtro automático</param>
        /// <param name="mensagemSemRegistro">Mensagem que aparecerá caso nenhum registro seja executado</param>
        public FormBusca(string sql, List<OracleParameter> parametros, bool autoExecutar, string titulo, string colunaPrincipal, string filtroAutomatico, 
                         string mensagemSemRegistro)
            : this(sql, parametros, autoExecutar, titulo, colunaPrincipal, filtroAutomatico, mensagemSemRegistro, false, Globals.CBanco.guardId, "")
        { }

        /// <summary>
        /// Formulário de Busca de Registros
        /// </summary>
        /// <param name="sql">Query a ser executada</param>
        /// <param name="autoExecutar">Executar query ao abrir o formulário</param>
        /// <param name="titulo">Título do formulário</param>
        /// <param name="colunaPrincipal">Nome da primeira coluna que aparecerá no filtro</param>
        /// <param name="filtroAutomatico">String para filtro automático</param>
        /// <param name="mensagemSemRegistro">Mensagem que aparecerá caso nenhum registro seja executado</param>
        /// <param name="removerAcentuacao">Remove acentuação do campo selecionado</param>
        public FormBusca(string sql, List<OracleParameter> parametros, bool autoExecutar, string titulo, string colunaPrincipal, string filtroAutomatico, 
                         string mensagemSemRegistro, bool removerAcentuacao)
            : this(sql, parametros, autoExecutar, titulo, colunaPrincipal, filtroAutomatico, mensagemSemRegistro, removerAcentuacao, Globals.CBanco.guardId, "")
        { }

        /// <summary>
        /// Formulário de Busca de Registros
        /// </summary>
        /// <param name="sql">Query a ser executada</param>
        /// <param name="autoExecutar">Executar query ao abrir o formulário</param>
        /// <param name="titulo">Título do formulário</param>
        /// <param name="colunaPrincipal">Nome da primeira coluna que aparecerá no filtro</param>
        /// <param name="filtroAutomatico">String para filtro automático</param>
        /// <param name="mensagemSemRegistro">Mensagem que aparecerá caso nenhum registro seja executado</param>
        /// <param name="removerAcentuacao">Remove acentuação do campo selecionado</param>
        public FormBusca(string sql, List<OracleParameter> parametros, bool autoExecutar, string titulo, string colunaPrincipal, string filtroAutomatico, 
                         string mensagemSemRegistro, Globals.CBanco banco)
            : this(sql, parametros, autoExecutar, titulo, colunaPrincipal, filtroAutomatico, mensagemSemRegistro, false, banco, "")
        { }

        /// <summary>
        /// Formulário de Busca de Registros
        /// </summary>
        /// <param name="sql">Query a ser executada</param>
        /// <param name="autoExecutar">Executar query ao abrir o formulário</param>
        /// <param name="titulo">Título do formulário</param>
        /// <param name="colunaPrincipal">Nome da primeira coluna que aparecerá no filtro</param>
        /// <param name="filtroAutomatico">String para filtro automático</param>
        /// <param name="mensagemSemRegistro">Mensagem que aparecerá caso nenhum registro seja executado</param>
        /// <param name="removerAcentuacao">Remove acentuação do campo selecionado</param>
        /// <param name="orderBy">Ordena a Consulta de acordo com as colunas passadas via parametros</param>
        public FormBusca(string sql, List<OracleParameter> parametros, bool autoExecutar, string titulo, string colunaPrincipal, string filtroAutomatico, 
                         string mensagemSemRegistro, bool removerAcentuacao, string orderBy)
            : this(sql, parametros, autoExecutar, titulo, colunaPrincipal, filtroAutomatico, mensagemSemRegistro, removerAcentuacao, Globals.CBanco.guardId, orderBy)
        { }

        /// <summary>
        /// Preenche a Combo da Colunas da Query
        /// </summary>
        /// <param name="colunaPrincipal">Coluna Principal</param>
        private void PreencheComboColuna(string colunaPrincipal)
        {
            string sql = "0 ";

            Conexao dal = new Conexao(Globals.GetStringConnection(_banco), 2);
            foreach (OracleParameter op in _parametros)
            {
                dal.AddParam(op.ParameterName, op.Value);
            }

            DataTable dt = new DataTable();
            DataTable dtColunas = new DataTable();
            DataRow dr = null;

            
            dt = dal.ExecuteQuery(sql);
            dtColunas.Columns.Add("COLUNA");
            dtColunas.Columns.Add("TIPO");
            cboColuna.DisplayMember = "COLUNA";
            cboColuna.ValueMember = "TIPO";

            colunaPrincipal = colunaPrincipal.ToUpper();
            if (!string.IsNullOrEmpty(colunaPrincipal) && !string.IsNullOrWhiteSpace(colunaPrincipal))
            {
                if (dt.Columns[colunaPrincipal] == null)
                    MessageBox.Show("Coluna '" + colunaPrincipal + "' não encontrada na Tabela", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dr = dtColunas.NewRow();
                    dr["COLUNA"] = colunaPrincipal;
                    dr["TIPO"] = dt.Columns[colunaPrincipal].DataType;
                    dtColunas.Rows.Add(dr);
                }
            }

            foreach (DataColumn dc in dt.Columns)
            {
                if (colunaPrincipal != dc.ColumnName)
                {
                    dr = dtColunas.NewRow();
                    dr["COLUNA"] = dc.ColumnName;
                    dr["TIPO"] = dt.Columns[dc.ColumnName].DataType;
                    dtColunas.Rows.Add(dr);
                }
            }
            cboColuna.DataSource = dtColunas;
        }

        /// <summary>
        /// Preenche o DataGridView de acordo com os Parametros
        /// </summary>
        private void PreencheGrid()
        {
            lblMsgBuscandoDados.Visible = true;
            Application.DoEvents();

            Conexao dal = new Conexao(Globals.GetStringConnection(_banco), 2);
            foreach (OracleParameter op in _parametros)
            {
                dal.AddParam(op.ParameterName, op.Value);
            }

            string coluna = cboColuna.Text;
            string condicao = cboCondicao.SelectedValue.ToString();
            string filtro = string.Empty;
            string filtroEntre = string.Empty;
            string where = string.Empty;

            if (cboColuna.SelectedValue.ToString() == "System.DateTime")
            {
                filtro = dtpFiltro.Value.ToShortDateString();
                filtroEntre = dtpFiltroEntre.Value.ToShortDateString();
            }
            else
            {
                if (cboCondicao.SelectedValue.ToString() == "B")
                {
                    filtro = txtFiltroEntre1.Text.ToUpper();
                    filtroEntre = txtFiltroEntre2.Text.ToUpper();
                }
                else
                    filtro = txtFiltro.Text.ToUpper();
            }

            if (!string.IsNullOrEmpty(filtro) && !string.IsNullOrWhiteSpace(filtro))
            {

                filtro = "'" + filtro + "'";
                filtroEntre = "'" + filtroEntre + "'";

                if (_removerAcentuacao)
                {
                    if (_banco == Globals.CBanco.guardId)
                    {
                        filtro = "";
                        filtroEntre = "";
                    }
                    else if (_banco == Globals.CBanco.guardId)
                    {
                        filtro = "";
                        filtroEntre = "";
                    }
                    else
                        MessageBox.Show("Opção de remover acentuação não implementada para o banco: " + _banco.ToString(), "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                switch (cboColuna.SelectedValue.ToString())
                {
                    case "System.String":
                        if (_removerAcentuacao)
                        {
                            if (_banco == Globals.CBanco.guardId)
                                where = "";
                            else if (_banco == Globals.CBanco.guardId)
                                where = "";
                        }
                        else
                            where = "";
                        break;
                    case "System.DateTime":
                        where = "";
                        break;
                    default:
                        where = "WHERE " + coluna;
                        break;
                }
                switch (cboCondicao.SelectedValue.ToString())
                {
                    case "=":
                        where += " = " + filtro;
                        break;
                    case "<>":
                        where += " <> " + filtro;
                        break;
                    case ">":
                        where += " > " + filtro;
                        break;
                    case ">=":
                        where += " >= " + filtro;
                        break;
                    case "<":
                        where += " < " + filtro;
                        break;
                    case "<=":
                        where += " <= " + filtro;
                        break;
                    case "%L":
                        where += " LIKE " + filtro.Insert(filtro.IndexOf("'") + 1, "%");
                        break;
                    case "L%":
                        where += " LIKE " + filtro.Insert(filtro.LastIndexOf("'"), "%");
                        break;
                    case "%L%":
                        where += " LIKE " + filtro.Insert(filtro.IndexOf("'") + 1, "%").Insert(filtro.LastIndexOf("'") + 1, "%");
                        break;
                    case "!%L%":
                        where += " NOT LIKE " + filtro.Insert(filtro.IndexOf("'") + 1, "%").Insert(filtro.LastIndexOf("'") + 1, "%");
                        break;
                    case "B":
                        where += " BETWEEN " + filtro + " AND " + filtroEntre;
                        break;
                    default:
                        break;
                }
            }

            string sql = "";
            //WaitWindow.Begin("Buscando Informações...");
            DataTable dt = new DataTable();
            dt = dal.ExecuteQuery(sql);
            //WaitWindow.End();
            dgvLista.DataSource = dt;

            _contadorPreencherGrid++;

            dgvLista.Refresh();
            this.Refresh();

            if (!string.IsNullOrEmpty(_mensagemSemRegistro) && !string.IsNullOrWhiteSpace(_mensagemSemRegistro) && dt.Rows.Count == 0)
            {
                lblMsgBuscandoDados.Visible = false;
                MessageBox.Show(_mensagemSemRegistro, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_contadorPreencherGrid == 1)
                    this.Dispose();
            }
            else
            {
                this.Refresh();
                dgvLista.Focus();
                lblMsgBuscandoDados.Visible = false;
                FormBusca_SizeChanged(null, null);
            }
        }

        private void FechaFormulario()
        {
            this.Close();
        }

        /// <summary>
        /// Preenche o Campo de Filtro
        /// </summary>
        /// <param name="filtroAutomatico">String para o Filtro</param>
        private void PreencheCampoFiltro(string filtroAutomatico)
        {
            if (!string.IsNullOrEmpty(filtroAutomatico) && !string.IsNullOrWhiteSpace(filtroAutomatico))
            {
                switch (cboColuna.SelectedValue.ToString())
                {
                    case "System.DateTime":
                        DateTime dtFiltro = new DateTime();
                        try
                        {
                            dtFiltro = DateTime.Parse(filtroAutomatico).Date;
                            dtpFiltro.Value = dtFiltro.Date;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Formato de Data Inválido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "System.Decimal":
                        decimal dcFiltro = new decimal();
                        try
                        {
                            dcFiltro = Decimal.Parse(filtroAutomatico);
                            txtFiltro.Text = dcFiltro.ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Formato Númerico Inválido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    default:
                        txtFiltro.Text = filtroAutomatico;
                        break;
                }
            }
        }

        /// <summary>
        /// Preenche o Título do Formulário
        /// </summary>
        /// <param name="titulo">Título</param>
        private void PreencheTitulo(string titulo)
        {
            if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrWhiteSpace(titulo))
                this.Text = titulo;
            else
                this.Text = "Busca de Registro";
        }

        /// <summary>
        /// Preenche a DataRow de Retorno
        /// </summary>
        private void PreencheRetorno()
        {
            if (dgvLista.CurrentRow != null)
            {
                DataRowView currentDataRowView = (DataRowView)dgvLista.CurrentRow.DataBoundItem;
                DataRow row = currentDataRowView.Row;
                retorno = row;
            }
            this.Dispose();
        }

#pragma warning disable CS0108 // "FormBusca.ShowDialog()" oculta o membro herdado "Form.ShowDialog()". Use a nova palavra-chave se foi pretendido ocultar.
        public DialogResult ShowDialog()
#pragma warning restore CS0108 // "FormBusca.ShowDialog()" oculta o membro herdado "Form.ShowDialog()". Use a nova palavra-chave se foi pretendido ocultar.
        {
            if (!this.IsDisposed)
            {
                return base.ShowDialog();
            }

            return DialogResult.Cancel;
        }

        private void FormBusca2_Load(object sender, EventArgs e)
        {
            txtFiltro.Focus();
            FormBusca_SizeChanged(sender, e);

            int[] usuarios = new int[] {
           };

            if (usuarios.Contains(Globals.Usuario))
            {
                toolStripBtnCopiarSQL.Visible = true;
            }
            else
            {
                toolStripBtnCopiarSQL.Visible = false;
            }
        }

        private void cboColuna_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            txtFiltroEntre1.Text = string.Empty;
            txtFiltroEntre2.Text = string.Empty;

            DataTable dtCondicao = new DataTable();
            DataRow dr = null;

            dtCondicao.Columns.Add("CONDICAO");
            dtCondicao.Columns.Add("TIPO");
            cboCondicao.DisplayMember = "CONDICAO";
            cboCondicao.ValueMember = "TIPO";

            cboCondicao.DataSource = dtCondicao;

            switch (cboColuna.SelectedValue.ToString())
            {
                case ("System.Decimal"):

                    txtFiltro.TipoValor = TextBoxGuard.CTipoValor.Numerico;
                    txtFiltroEntre1.TipoValor = TextBoxGuard.CTipoValor.Numerico;
                    txtFiltroEntre2.TipoValor = TextBoxGuard.CTipoValor.Numerico;

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É IGUAL A";
                    dr["TIPO"] = "=";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É DIFERENTE DE";
                    dr["TIPO"] = "<>";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É MAIOR DO QUE";
                    dr["TIPO"] = ">";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É MAIOR OU IGUAL A";
                    dr["TIPO"] = ">=";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É MENOR DO QUE";
                    dr["TIPO"] = "<";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É MENOR OU IGUAL A";
                    dr["TIPO"] = "<=";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "ESTÁ ENTRE";
                    dr["TIPO"] = "B";
                    dtCondicao.Rows.Add(dr);

                    break;

                case "System.DateTime":

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É IGUAL A";
                    dr["TIPO"] = "=";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É DIFERENTE DE";
                    dr["TIPO"] = "<>";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É MAIOR DO QUE";
                    dr["TIPO"] = ">";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É MAIOR OU IGUAL A";
                    dr["TIPO"] = ">=";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É MENOR DO QUE";
                    dr["TIPO"] = "<";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É MENOR OU IGUAL A";
                    dr["TIPO"] = "<=";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "ESTÁ ENTRE";
                    dr["TIPO"] = "B";
                    dtCondicao.Rows.Add(dr);

                    break;

                case "System.String":

                    txtFiltro.TipoValor = TextBoxGuard.CTipoValor.Geral;
                    txtFiltroEntre1.TipoValor = TextBoxGuard.CTipoValor.Geral;
                    txtFiltroEntre2.TipoValor = TextBoxGuard.CTipoValor.Geral;

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "COMEÇA COM";
                    dr["TIPO"] = "L%";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "TERMINA COM";
                    dr["TIPO"] = "%L";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "CONTÉM";
                    dr["TIPO"] = "%L%";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "NÃO CONTÉM";
                    dr["TIPO"] = "!%L%";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É IGUAL A";
                    dr["TIPO"] = "=";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "É DIFERENTE DE";
                    dr["TIPO"] = "<>";
                    dtCondicao.Rows.Add(dr);

                    dr = dtCondicao.NewRow();
                    dr["CONDICAO"] = "ESTÁ ENTRE";
                    dr["TIPO"] = "B";
                    dtCondicao.Rows.Add(dr);

                    break;
                default:
                    break;
            }
            cboCondicao.DataSource = dtCondicao;
            cboCondicao_SelectedIndexChanged(sender, e);
        }
        private void cboCondicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFiltro.Visible = false;
            dtpFiltroEntre.Visible = false;

            txtFiltro.Visible = false;
            txtFiltroEntre1.Visible = false;
            txtFiltroEntre2.Visible = false;

            lbEntreData.Visible = false;
            lbEntreTexto.Visible = false;

            switch (cboColuna.SelectedValue.ToString())
            {
                case ("System.Decimal"):
                    if (cboCondicao.SelectedValue.ToString() == "B")
                    {
                        txtFiltroEntre1.Visible = true;
                        txtFiltroEntre2.Visible = true;
                        lbEntreTexto.Visible = true;
                    }
                    else
                        txtFiltro.Visible = true;
                    break;
                case ("System.DateTime"):
                    dtpFiltro.Visible = true;
                    if (cboCondicao.SelectedValue.ToString() == "B")
                    {
                        dtpFiltroEntre.Visible = true;
                        lbEntreData.Visible = false;
                    }
                    break;
                case ("System.String"):
                    if (cboCondicao.SelectedValue.ToString() == "B")
                    {
                        txtFiltroEntre1.Visible = true;
                        txtFiltroEntre2.Visible = true;
                        lbEntreTexto.Visible = true;
                    }
                    else
                        txtFiltro.Visible = true;
                    break;
            }
        }

        private void toolStripBtnFiltrar_Click(object sender, EventArgs e)
        {
            PreencheGrid();
        }
        private void toolStripBtnSelecionar_Click(object sender, EventArgs e)
        {
            PreencheRetorno();
        }
        private void toolStripBtnAtualizar_Click(object sender, EventArgs e)
        {
            PreencheGrid();
        }
        private void toolStripBtnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Microsoft Excel (.xls)|*.xls|Todos Arquivos (*.*)|*.*";
            saveDialog.AddExtension = true;
            saveDialog.RestoreDirectory = true;
            saveDialog.Title = "Onde você deseja salvar o arquivos?";
            saveDialog.InitialDirectory = @"C:/";
            if (saveDialog.ShowDialog() == DialogResult.OK)
                ExportaExcel.ExportaParaExcel((DataTable)dgvLista.DataSource, saveDialog.FileName, true);
        }


        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PreencheGrid();
            }
        }
        private void dtpFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PreencheGrid();
            }
        }
        private void txtFiltroEntre1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PreencheGrid();
            }
        }
        private void txtFiltroEntre2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PreencheGrid();
            }
        }
        private void dtpFiltroEntre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PreencheGrid();
            }
        }

        private void AtualizarContagemItensGrid()
        {
            if (dgvLista.Rows.Count > 0)
            {
                lblContagemItensGrid.Visible = true;
                if (dgvLista.Rows.Count == 1)
                    lblContagemItensGrid.Text = "Resultado da busca: 01 item encontrado";
                else if ((dgvLista.Rows.Count > 1) && (dgvLista.Rows.Count < 10))
                    lblContagemItensGrid.Text = "Resultado da busca: 0" + dgvLista.Rows.Count.ToString() + " itens encontrados";
                else if ((dgvLista.Rows.Count >= 10))
                    lblContagemItensGrid.Text = "Resultado da busca: " + dgvLista.Rows.Count.ToString() + " itens encontrados";
            }
            else
            {
                lblContagemItensGrid.Visible = false;
                lblContagemItensGrid.Text = "";
            }


        }
        private void AjustarTamanhoFormulario()
        {
            int totalWidth = 150;
            int totalHeigth = 250;

            //Largura
            foreach (DataGridViewColumn item in dgvLista.Columns)
            {
                //item.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (item.Visible)
                    totalWidth += item.Width;
            }
            if (totalWidth > 1040)
                totalWidth = 1040;
            else if (totalWidth < 600)
                totalWidth = 600;

            //Altura
            foreach (DataGridViewRow item in dgvLista.Rows)
            {
                if (item.Visible)
                    totalHeigth += item.Height;
            }
            if (totalHeigth > 700)
                totalHeigth = 700;
            else if (totalHeigth < 400)
                totalHeigth = 400;


            //Centralizar o formulario após a alteração do tamanho
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - totalWidth) / 2,
                      (Screen.PrimaryScreen.WorkingArea.Height - totalHeigth) / 2);

            this.Width = totalWidth;
            this.Height = totalHeigth;
        }

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PreencheRetorno();
        }
        private void dgvLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                PreencheRetorno();
            }
        }
        private void dgvLista_DataSourceChanged(object sender, EventArgs e)
        {
            AtualizarContagemItensGrid();
        }
        private void dgvLista_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            AtualizarContagemItensGrid();
        }
        private void dgvLista_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            AtualizarContagemItensGrid();
        }
        private void dgvLista_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            AjustarTamanhoFormulario();
        }

        private void FormBusca_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > 1035)
            {
                pnlFiltros.Location = new Point(440, 2);
                pnlCondicao.Height = 35;
            }
            else
            {
                pnlFiltros.Location = new Point(3, 29);
                pnlCondicao.Height = 61;
            }
        }

        private void toolStripBtnCopiarSQL_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this._sql);
        }

    }
}