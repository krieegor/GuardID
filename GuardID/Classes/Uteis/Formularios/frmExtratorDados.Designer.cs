namespace System.Uteis
{
    partial class frmExtratorDados
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtratorDados));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelGuard1 = new System.Uteis.LabelGuard();
            this.txtComando = new System.Uteis.TextBoxGuard();
            this.txtComandoDesc = new System.Uteis.TextBoxGuard();
            this.groupBoxGuard1 = new System.Uteis.GroupBoxGuard(this.components);
            this.txtFaixaFinal = new System.Uteis.TextBoxGuard();
            this.txtFaixaInicial = new System.Uteis.TextBoxGuard();
            this.txtValorFiltro = new System.Uteis.TextBoxGuard();
            this.txtValorFiltroDesc = new System.Uteis.TextBoxGuard();
            this.btnAdicionarFiltro = new System.Uteis.ButtonGuard();
            this.dgvFiltros = new System.Uteis.DataGridViewGuard();
            this.colFiltro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiltroDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiltroNomeCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiltroTipoFiltro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObrigatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosicaoFiltro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomeCampoFiltro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtFiltroDesc = new System.Uteis.TextBoxGuard();
            this.labelGuard4 = new System.Uteis.LabelGuard();
            this.txtFiltro = new System.Uteis.TextBoxGuard();
            this.labelGuard2 = new System.Uteis.LabelGuard();
            this.mtxtPeriodoFim = new System.Uteis.MaskedTextBoxDataGuard(this.components);
            this.lblPeriodo = new System.Uteis.LabelGuard();
            this.mtxtPeriodoInicio = new System.Uteis.MaskedTextBoxDataGuard(this.components);
            this.mtxtCompetenciaInicial = new System.Uteis.MaskedTextBoxDataGuard(this.components);
            this.mtxtCompetenciaFinal = new System.Uteis.MaskedTextBoxDataGuard(this.components);
            this.txtValorFiltroSemPesquisa = new System.Uteis.TextBoxGuard();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxGuard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltros)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(611, 2);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(468, 2);
            this.button1.Size = new System.Drawing.Size(140, 30);
            this.button1.Text = "Gerar Planilha";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxGuard1);
            this.panel1.Controls.Add(this.txtComandoDesc);
            this.panel1.Controls.Add(this.txtComando);
            this.panel1.Controls.Add(this.labelGuard1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(730, 461);
            // 
            // btCancel
            // 
            this.btCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btCancel.Location = new System.Drawing.Point(11, 2);
            this.btCancel.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Dock = System.Windows.Forms.DockStyle.None;
            this.panel2.Location = new System.Drawing.Point(0, 424);
            this.panel2.Size = new System.Drawing.Size(730, 37);
            // 
            // btnPermissao
            // 
            this.btnPermissao.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // labelGuard1
            // 
            this.labelGuard1.AutoSize = true;
            this.labelGuard1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuard1.Location = new System.Drawing.Point(11, 25);
            this.labelGuard1.Name = "labelGuard1";
            this.labelGuard1.Size = new System.Drawing.Size(71, 13);
            this.labelGuard1.TabIndex = 0;
            this.labelGuard1.Text = "Comando:";
            // 
            // txtComando
            // 
            this.txtComando._RecursosGenericosSqlF3 = null;
            this.txtComando._RecursosGenericosSqlLeave = null;
            this.txtComando.BackColor = System.Drawing.Color.White;
            this.txtComando.ExibirIconePesquisa = true;
            this.txtComando.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComando.InformacaoToolTipCaminho = null;
            this.txtComando.InformacaoToolTipDescricao = null;
            this.txtComando.LimpaCampo = true;
            this.txtComando.Location = new System.Drawing.Point(103, 22);
            this.txtComando.Name = "txtComando";
            this.txtComando.NomeCampoDadosDataTable = null;
            this.txtComando.ParteDecimal = 0;
            this.txtComando.ParteInteira = 0;
            this.txtComando.SegurancaCCusto = System.Uteis.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtComando.Size = new System.Drawing.Size(84, 21);
            this.txtComando.TabIndex = 1;
            this.txtComando.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtComando.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Numerico;
            this.txtComando.TextChanged += new System.EventHandler(this.txtComando_TextChanged);
            this.txtComando.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComando_KeyDown);
            this.txtComando.Leave += new System.EventHandler(this.txtComando_Leave);
            this.txtComando.Validating += new System.ComponentModel.CancelEventHandler(this.txtComando_Validating);
            // 
            // txtComandoDesc
            // 
            this.txtComandoDesc._RecursosGenericosSqlF3 = null;
            this.txtComandoDesc._RecursosGenericosSqlLeave = null;
            this.txtComandoDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.txtComandoDesc.ExibirIconePesquisa = false;
            this.txtComandoDesc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComandoDesc.InformacaoToolTipCaminho = null;
            this.txtComandoDesc.InformacaoToolTipDescricao = null;
            this.txtComandoDesc.LimpaCampo = true;
            this.txtComandoDesc.Location = new System.Drawing.Point(193, 22);
            this.txtComandoDesc.Name = "txtComandoDesc";
            this.txtComandoDesc.NomeCampoDadosDataTable = null;
            this.txtComandoDesc.ParteDecimal = 0;
            this.txtComandoDesc.ParteInteira = 0;
            this.txtComandoDesc.ReadOnly = true;
            this.txtComandoDesc.SegurancaCCusto = System.Uteis.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtComandoDesc.Size = new System.Drawing.Size(518, 21);
            this.txtComandoDesc.TabIndex = 2;
            this.txtComandoDesc.TabStop = false;
            this.txtComandoDesc.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtComandoDesc.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            // 
            // groupBoxGuard1
            // 
            this.groupBoxGuard1.Controls.Add(this.txtFaixaFinal);
            this.groupBoxGuard1.Controls.Add(this.txtFaixaInicial);
            this.groupBoxGuard1.Controls.Add(this.txtValorFiltro);
            this.groupBoxGuard1.Controls.Add(this.txtValorFiltroDesc);
            this.groupBoxGuard1.Controls.Add(this.btnAdicionarFiltro);
            this.groupBoxGuard1.Controls.Add(this.dgvFiltros);
            this.groupBoxGuard1.Controls.Add(this.txtFiltroDesc);
            this.groupBoxGuard1.Controls.Add(this.labelGuard4);
            this.groupBoxGuard1.Controls.Add(this.txtFiltro);
            this.groupBoxGuard1.Controls.Add(this.labelGuard2);
            this.groupBoxGuard1.Controls.Add(this.mtxtPeriodoFim);
            this.groupBoxGuard1.Controls.Add(this.lblPeriodo);
            this.groupBoxGuard1.Controls.Add(this.mtxtPeriodoInicio);
            this.groupBoxGuard1.Controls.Add(this.mtxtCompetenciaInicial);
            this.groupBoxGuard1.Controls.Add(this.mtxtCompetenciaFinal);
            this.groupBoxGuard1.Controls.Add(this.txtValorFiltroSemPesquisa);
            this.groupBoxGuard1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxGuard1.Location = new System.Drawing.Point(14, 49);
            this.groupBoxGuard1.Name = "groupBoxGuard1";
            this.groupBoxGuard1.Size = new System.Drawing.Size(703, 368);
            this.groupBoxGuard1.TabIndex = 3;
            this.groupBoxGuard1.TabStop = false;
            this.groupBoxGuard1.Text = "Filtros";
            // 
            // txtFaixaFinal
            // 
            this.txtFaixaFinal._RecursosGenericosSqlF3 = null;
            this.txtFaixaFinal._RecursosGenericosSqlLeave = null;
            this.txtFaixaFinal.BackColor = System.Drawing.Color.White;
            this.txtFaixaFinal.ExibirIconePesquisa = false;
            this.txtFaixaFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFaixaFinal.InformacaoToolTipCaminho = null;
            this.txtFaixaFinal.InformacaoToolTipDescricao = null;
            this.txtFaixaFinal.LimpaCampo = true;
            this.txtFaixaFinal.Location = new System.Drawing.Point(200, 53);
            this.txtFaixaFinal.Name = "txtFaixaFinal";
            this.txtFaixaFinal.NomeCampoDadosDataTable = null;
            this.txtFaixaFinal.ParteDecimal = 0;
            this.txtFaixaFinal.ParteInteira = 0;
            this.txtFaixaFinal.SegurancaCCusto = System.Uteis.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtFaixaFinal.Size = new System.Drawing.Size(84, 21);
            this.txtFaixaFinal.TabIndex = 10;
            this.txtFaixaFinal.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtFaixaFinal.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            this.txtFaixaFinal.Visible = false;
            // 
            // txtFaixaInicial
            // 
            this.txtFaixaInicial._RecursosGenericosSqlF3 = null;
            this.txtFaixaInicial._RecursosGenericosSqlLeave = null;
            this.txtFaixaInicial.BackColor = System.Drawing.Color.White;
            this.txtFaixaInicial.ExibirIconePesquisa = false;
            this.txtFaixaInicial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFaixaInicial.InformacaoToolTipCaminho = null;
            this.txtFaixaInicial.InformacaoToolTipDescricao = null;
            this.txtFaixaInicial.LimpaCampo = true;
            this.txtFaixaInicial.Location = new System.Drawing.Point(89, 53);
            this.txtFaixaInicial.Name = "txtFaixaInicial";
            this.txtFaixaInicial.NomeCampoDadosDataTable = null;
            this.txtFaixaInicial.ParteDecimal = 0;
            this.txtFaixaInicial.ParteInteira = 0;
            this.txtFaixaInicial.SegurancaCCusto = System.Uteis.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtFaixaInicial.Size = new System.Drawing.Size(84, 21);
            this.txtFaixaInicial.TabIndex = 9;
            this.txtFaixaInicial.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtFaixaInicial.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            this.txtFaixaInicial.Visible = false;
            // 
            // txtValorFiltro
            // 
            this.txtValorFiltro._RecursosGenericosSqlF3 = null;
            this.txtValorFiltro._RecursosGenericosSqlLeave = null;
            this.txtValorFiltro.BackColor = System.Drawing.Color.White;
            this.txtValorFiltro.ExibirIconePesquisa = true;
            this.txtValorFiltro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorFiltro.InformacaoToolTipCaminho = null;
            this.txtValorFiltro.InformacaoToolTipDescricao = null;
            this.txtValorFiltro.LimpaCampo = true;
            this.txtValorFiltro.Location = new System.Drawing.Point(89, 53);
            this.txtValorFiltro.Name = "txtValorFiltro";
            this.txtValorFiltro.NomeCampoDadosDataTable = null;
            this.txtValorFiltro.ParteDecimal = 0;
            this.txtValorFiltro.ParteInteira = 0;
            this.txtValorFiltro.SegurancaCCusto = System.Uteis.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtValorFiltro.Size = new System.Drawing.Size(84, 21);
            this.txtValorFiltro.TabIndex = 3;
            this.txtValorFiltro.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtValorFiltro.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            this.txtValorFiltro.TextChanged += new System.EventHandler(this.txtValorFiltro_TextChanged);
            this.txtValorFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorFiltro_KeyDown);
            this.txtValorFiltro.Leave += new System.EventHandler(this.txtValorFiltro_Leave);
            // 
            // txtValorFiltroDesc
            // 
            this.txtValorFiltroDesc._RecursosGenericosSqlF3 = null;
            this.txtValorFiltroDesc._RecursosGenericosSqlLeave = null;
            this.txtValorFiltroDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.txtValorFiltroDesc.ExibirIconePesquisa = false;
            this.txtValorFiltroDesc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorFiltroDesc.InformacaoToolTipCaminho = null;
            this.txtValorFiltroDesc.InformacaoToolTipDescricao = null;
            this.txtValorFiltroDesc.LimpaCampo = true;
            this.txtValorFiltroDesc.Location = new System.Drawing.Point(179, 53);
            this.txtValorFiltroDesc.Name = "txtValorFiltroDesc";
            this.txtValorFiltroDesc.NomeCampoDadosDataTable = null;
            this.txtValorFiltroDesc.ParteDecimal = 0;
            this.txtValorFiltroDesc.ParteInteira = 0;
            this.txtValorFiltroDesc.ReadOnly = true;
            this.txtValorFiltroDesc.SegurancaCCusto = System.Uteis.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtValorFiltroDesc.Size = new System.Drawing.Size(518, 21);
            this.txtValorFiltroDesc.TabIndex = 7;
            this.txtValorFiltroDesc.TabStop = false;
            this.txtValorFiltroDesc.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtValorFiltroDesc.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            // 
            // btnAdicionarFiltro
            // 
            this.btnAdicionarFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.btnAdicionarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarFiltro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarFiltro.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarFiltro.Image")));
            this.btnAdicionarFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarFiltro.Location = new System.Drawing.Point(597, 80);
            this.btnAdicionarFiltro.Name = "btnAdicionarFiltro";
            this.btnAdicionarFiltro.Size = new System.Drawing.Size(100, 23);
            this.btnAdicionarFiltro.TabIndex = 5;
            this.btnAdicionarFiltro.Text = "Adicionar";
            this.btnAdicionarFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionarFiltro.UseVisualStyleBackColor = true;
            this.btnAdicionarFiltro.Click += new System.EventHandler(this.btnAdicionarFiltro_Click);
            // 
            // dgvFiltros
            // 
            this.dgvFiltros.AllowUserToAddRows = false;
            this.dgvFiltros.AllowUserToDeleteRows = false;
            this.dgvFiltros.AllowUserToResizeRows = false;
            this.dgvFiltros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFiltros.BackgroundColor = System.Drawing.Color.White;
            this.dgvFiltros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiltros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFiltros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiltros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFiltro,
            this.colFiltroDesc,
            this.colTipoValor,
            this.colFiltroNomeCampo,
            this.colFiltroTipoFiltro,
            this.colObrigatorio,
            this.colValor,
            this.colValorDesc,
            this.colPosicaoFiltro,
            this.colNomeCampoFiltro,
            this.colExcluir});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFiltros.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvFiltros.EnableHeadersVisualStyles = false;
            this.dgvFiltros.HabilitarColunasInvisiveisExportarExcel = false;
            this.dgvFiltros.LimpaCampo = true;
            this.dgvFiltros.Location = new System.Drawing.Point(6, 107);
            this.dgvFiltros.Name = "dgvFiltros";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiltros.RowHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvFiltros.RowHeadersVisible = false;
            this.dgvFiltros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiltros.Size = new System.Drawing.Size(691, 255);
            this.dgvFiltros.TabIndex = 8;
            this.dgvFiltros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiltros_CellClick);
            // 
            // colFiltro
            // 
            this.colFiltro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFiltro.DataPropertyName = "FILTRO";
            this.colFiltro.HeaderText = "Filtro";
            this.colFiltro.Name = "colFiltro";
            this.colFiltro.ReadOnly = true;
            this.colFiltro.Visible = false;
            // 
            // colFiltroDesc
            // 
            this.colFiltroDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFiltroDesc.DataPropertyName = "FILTRO_DESC";
            this.colFiltroDesc.HeaderText = "Filtro";
            this.colFiltroDesc.Name = "colFiltroDesc";
            this.colFiltroDesc.ReadOnly = true;
            // 
            // colTipoValor
            // 
            this.colTipoValor.DataPropertyName = "TIPO_VALOR";
            this.colTipoValor.HeaderText = "Tipo Valor";
            this.colTipoValor.Name = "colTipoValor";
            this.colTipoValor.ReadOnly = true;
            this.colTipoValor.Visible = false;
            this.colTipoValor.Width = 97;
            // 
            // colFiltroNomeCampo
            // 
            this.colFiltroNomeCampo.DataPropertyName = "NOME_CAMPO";
            this.colFiltroNomeCampo.HeaderText = "Nome Campo";
            this.colFiltroNomeCampo.Name = "colFiltroNomeCampo";
            this.colFiltroNomeCampo.ReadOnly = true;
            this.colFiltroNomeCampo.Visible = false;
            this.colFiltroNomeCampo.Width = 116;
            // 
            // colFiltroTipoFiltro
            // 
            this.colFiltroTipoFiltro.DataPropertyName = "TIPO_FILTRO";
            this.colFiltroTipoFiltro.HeaderText = "Tipo Filtro";
            this.colFiltroTipoFiltro.Name = "colFiltroTipoFiltro";
            this.colFiltroTipoFiltro.ReadOnly = true;
            this.colFiltroTipoFiltro.Visible = false;
            this.colFiltroTipoFiltro.Width = 98;
            // 
            // colObrigatorio
            // 
            this.colObrigatorio.DataPropertyName = "OBRIGATORIO";
            this.colObrigatorio.HeaderText = "Obrigatorio";
            this.colObrigatorio.Name = "colObrigatorio";
            this.colObrigatorio.ReadOnly = true;
            this.colObrigatorio.Visible = false;
            this.colObrigatorio.Width = 105;
            // 
            // colValor
            // 
            this.colValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colValor.DataPropertyName = "VALOR";
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Visible = false;
            // 
            // colValorDesc
            // 
            this.colValorDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colValorDesc.DataPropertyName = "VALOR_DESC";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colValorDesc.DefaultCellStyle = dataGridViewCellStyle17;
            this.colValorDesc.HeaderText = "Valor";
            this.colValorDesc.Name = "colValorDesc";
            this.colValorDesc.ReadOnly = true;
            this.colValorDesc.Width = 65;
            // 
            // colPosicaoFiltro
            // 
            this.colPosicaoFiltro.DataPropertyName = "POSICAO_FILTRO";
            this.colPosicaoFiltro.HeaderText = "Posição Filtro";
            this.colPosicaoFiltro.Name = "colPosicaoFiltro";
            this.colPosicaoFiltro.ReadOnly = true;
            this.colPosicaoFiltro.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPosicaoFiltro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPosicaoFiltro.Visible = false;
            this.colPosicaoFiltro.Width = 101;
            // 
            // colNomeCampoFiltro
            // 
            this.colNomeCampoFiltro.DataPropertyName = "NOME_CAMPO_FILTRO";
            this.colNomeCampoFiltro.HeaderText = "Nome Campo Filtro";
            this.colNomeCampoFiltro.Name = "colNomeCampoFiltro";
            this.colNomeCampoFiltro.Visible = false;
            this.colNomeCampoFiltro.Width = 155;
            // 
            // colExcluir
            // 
            this.colExcluir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle18.NullValue")));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White;
            this.colExcluir.DefaultCellStyle = dataGridViewCellStyle18;
            this.colExcluir.HeaderText = "";
            this.colExcluir.Image = ((System.Drawing.Image)(resources.GetObject("colExcluir.Image")));
            this.colExcluir.MinimumWidth = 40;
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.ReadOnly = true;
            this.colExcluir.Width = 40;
            // 
            // txtFiltroDesc
            // 
            this.txtFiltroDesc._RecursosGenericosSqlF3 = null;
            this.txtFiltroDesc._RecursosGenericosSqlLeave = null;
            this.txtFiltroDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.txtFiltroDesc.ExibirIconePesquisa = false;
            this.txtFiltroDesc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroDesc.InformacaoToolTipCaminho = null;
            this.txtFiltroDesc.InformacaoToolTipDescricao = null;
            this.txtFiltroDesc.LimpaCampo = true;
            this.txtFiltroDesc.Location = new System.Drawing.Point(179, 26);
            this.txtFiltroDesc.Name = "txtFiltroDesc";
            this.txtFiltroDesc.NomeCampoDadosDataTable = null;
            this.txtFiltroDesc.ParteDecimal = 0;
            this.txtFiltroDesc.ParteInteira = 0;
            this.txtFiltroDesc.ReadOnly = true;
            this.txtFiltroDesc.SegurancaCCusto = System.Uteis.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtFiltroDesc.Size = new System.Drawing.Size(518, 21);
            this.txtFiltroDesc.TabIndex = 5;
            this.txtFiltroDesc.TabStop = false;
            this.txtFiltroDesc.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtFiltroDesc.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            // 
            // labelGuard4
            // 
            this.labelGuard4.AutoSize = true;
            this.labelGuard4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuard4.Location = new System.Drawing.Point(6, 29);
            this.labelGuard4.Name = "labelGuard4";
            this.labelGuard4.Size = new System.Drawing.Size(46, 13);
            this.labelGuard4.TabIndex = 4;
            this.labelGuard4.Text = "Filtro:";
            // 
            // txtFiltro
            // 
            this.txtFiltro._RecursosGenericosSqlF3 = null;
            this.txtFiltro._RecursosGenericosSqlLeave = null;
            this.txtFiltro.BackColor = System.Drawing.Color.White;
            this.txtFiltro.ExibirIconePesquisa = true;
            this.txtFiltro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.InformacaoToolTipCaminho = null;
            this.txtFiltro.InformacaoToolTipDescricao = null;
            this.txtFiltro.LimpaCampo = true;
            this.txtFiltro.Location = new System.Drawing.Point(89, 26);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.NomeCampoDadosDataTable = null;
            this.txtFiltro.ParteDecimal = 0;
            this.txtFiltro.ParteInteira = 0;
            this.txtFiltro.SegurancaCCusto = System.Uteis.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtFiltro.Size = new System.Drawing.Size(84, 21);
            this.txtFiltro.TabIndex = 2;
            this.txtFiltro.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtFiltro.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Numerico;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.Enter += new System.EventHandler(this.txtFiltro_Enter);
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            this.txtFiltro.Leave += new System.EventHandler(this.txtFiltro_Leave);
            // 
            // labelGuard2
            // 
            this.labelGuard2.AutoSize = true;
            this.labelGuard2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuard2.Location = new System.Drawing.Point(7, 56);
            this.labelGuard2.Name = "labelGuard2";
            this.labelGuard2.Size = new System.Drawing.Size(45, 13);
            this.labelGuard2.TabIndex = 0;
            this.labelGuard2.Text = "Valor:";
            // 
            // mtxtPeriodoFim
            // 
            this.mtxtPeriodoFim.BackColor = System.Drawing.Color.White;
            this.mtxtPeriodoFim.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtPeriodoFim.LimpaCampo = true;
            this.mtxtPeriodoFim.Location = new System.Drawing.Point(200, 53);
            this.mtxtPeriodoFim.Mask = "00/00/0000";
            this.mtxtPeriodoFim.Name = "mtxtPeriodoFim";
            this.mtxtPeriodoFim.NomeCampoDadosDataTable = null;
            this.mtxtPeriodoFim.Size = new System.Drawing.Size(84, 21);
            this.mtxtPeriodoFim.TabIndex = 4;
            this.mtxtPeriodoFim.TipoCampo = System.Uteis.MaskedTextBoxDataGuard.CTipoCampo.Normal;
            this.mtxtPeriodoFim.Visible = false;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.Location = new System.Drawing.Point(176, 56);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(15, 13);
            this.lblPeriodo.TabIndex = 2;
            this.lblPeriodo.Text = "a";
            this.lblPeriodo.Visible = false;
            // 
            // mtxtPeriodoInicio
            // 
            this.mtxtPeriodoInicio.BackColor = System.Drawing.Color.White;
            this.mtxtPeriodoInicio.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtPeriodoInicio.LimpaCampo = true;
            this.mtxtPeriodoInicio.Location = new System.Drawing.Point(89, 53);
            this.mtxtPeriodoInicio.Mask = "00/00/0000";
            this.mtxtPeriodoInicio.Name = "mtxtPeriodoInicio";
            this.mtxtPeriodoInicio.NomeCampoDadosDataTable = null;
            this.mtxtPeriodoInicio.Size = new System.Drawing.Size(84, 21);
            this.mtxtPeriodoInicio.TabIndex = 3;
            this.mtxtPeriodoInicio.TipoCampo = System.Uteis.MaskedTextBoxDataGuard.CTipoCampo.Normal;
            this.mtxtPeriodoInicio.Visible = false;
            // 
            // mtxtCompetenciaInicial
            // 
            this.mtxtCompetenciaInicial.BackColor = System.Drawing.Color.White;
            this.mtxtCompetenciaInicial.ExibirIconePesquisa = false;
            this.mtxtCompetenciaInicial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtCompetenciaInicial.LimpaCampo = true;
            this.mtxtCompetenciaInicial.Location = new System.Drawing.Point(89, 53);
            this.mtxtCompetenciaInicial.Mask = "00/0000";
            this.mtxtCompetenciaInicial.Name = "mtxtCompetenciaInicial";
            this.mtxtCompetenciaInicial.NomeCampoDadosDataTable = null;
            this.mtxtCompetenciaInicial.Size = new System.Drawing.Size(84, 21);
            this.mtxtCompetenciaInicial.TabIndex = 3;
            this.mtxtCompetenciaInicial.TipoCampo = System.Uteis.MaskedTextBoxDataGuard.CTipoCampo.Normal;
            this.mtxtCompetenciaInicial.Visible = false;
            // 
            // mtxtCompetenciaFinal
            // 
            this.mtxtCompetenciaFinal.BackColor = System.Drawing.Color.White;
            this.mtxtCompetenciaFinal.ExibirIconePesquisa = false;
            this.mtxtCompetenciaFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtCompetenciaFinal.LimpaCampo = true;
            this.mtxtCompetenciaFinal.Location = new System.Drawing.Point(200, 53);
            this.mtxtCompetenciaFinal.Mask = "00/0000";
            this.mtxtCompetenciaFinal.Name = "mtxtCompetenciaFinal";
            this.mtxtCompetenciaFinal.NomeCampoDadosDataTable = null;
            this.mtxtCompetenciaFinal.Size = new System.Drawing.Size(84, 21);
            this.mtxtCompetenciaFinal.TabIndex = 4;
            this.mtxtCompetenciaFinal.TipoCampo = System.Uteis.MaskedTextBoxDataGuard.CTipoCampo.Normal;
            this.mtxtCompetenciaFinal.Visible = false;
            // 
            // txtValorFiltroSemPesquisa
            // 
            this.txtValorFiltroSemPesquisa._RecursosGenericosSqlF3 = null;
            this.txtValorFiltroSemPesquisa._RecursosGenericosSqlLeave = null;
            this.txtValorFiltroSemPesquisa.BackColor = System.Drawing.Color.White;
            this.txtValorFiltroSemPesquisa.ExibirIconePesquisa = false;
            this.txtValorFiltroSemPesquisa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorFiltroSemPesquisa.InformacaoToolTipCaminho = null;
            this.txtValorFiltroSemPesquisa.InformacaoToolTipDescricao = null;
            this.txtValorFiltroSemPesquisa.LimpaCampo = true;
            this.txtValorFiltroSemPesquisa.Location = new System.Drawing.Point(89, 53);
            this.txtValorFiltroSemPesquisa.Name = "txtValorFiltroSemPesquisa";
            this.txtValorFiltroSemPesquisa.NomeCampoDadosDataTable = null;
            this.txtValorFiltroSemPesquisa.ParteDecimal = 0;
            this.txtValorFiltroSemPesquisa.ParteInteira = 0;
            this.txtValorFiltroSemPesquisa.SegurancaCCusto = System.Uteis.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtValorFiltroSemPesquisa.Size = new System.Drawing.Size(608, 21);
            this.txtValorFiltroSemPesquisa.TabIndex = 3;
            this.txtValorFiltroSemPesquisa.TabStop = false;
            this.txtValorFiltroSemPesquisa.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtValorFiltroSemPesquisa.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            this.txtValorFiltroSemPesquisa.Visible = false;
            // 
            // frmExtratorDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 461);
            this.CodigoSeguranca = "MV148";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmExtratorDados";
            this.Text = "Extrator de Dados";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBoxGuard1.ResumeLayout(false);
            this.groupBoxGuard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Uteis.TextBoxGuard txtComandoDesc;
        private System.Uteis.TextBoxGuard txtComando;
        private System.Uteis.LabelGuard labelGuard1;
        private System.Uteis.GroupBoxGuard groupBoxGuard1;
        private System.Uteis.LabelGuard labelGuard2;
        private System.Uteis.MaskedTextBoxDataGuard mtxtPeriodoFim;
        private System.Uteis.LabelGuard lblPeriodo;
        private System.Uteis.MaskedTextBoxDataGuard mtxtPeriodoInicio;
        private System.Uteis.TextBoxGuard txtFiltroDesc;
        private System.Uteis.LabelGuard labelGuard4;
        private System.Uteis.TextBoxGuard txtFiltro;
        private System.Uteis.TextBoxGuard txtValorFiltroDesc;
        private System.Uteis.TextBoxGuard txtValorFiltro;
        private System.Uteis.ButtonGuard btnAdicionarFiltro;
        private System.Uteis.DataGridViewGuard dgvFiltros;
        private System.Uteis.TextBoxGuard txtValorFiltroSemPesquisa;
        private System.Uteis.MaskedTextBoxDataGuard mtxtCompetenciaInicial;
        private System.Uteis.MaskedTextBoxDataGuard mtxtCompetenciaFinal;
        private DataGridViewTextBoxColumn colFiltro;
        private DataGridViewTextBoxColumn colFiltroDesc;
        private DataGridViewTextBoxColumn colTipoValor;
        private DataGridViewTextBoxColumn colFiltroNomeCampo;
        private DataGridViewTextBoxColumn colFiltroTipoFiltro;
        private DataGridViewTextBoxColumn colObrigatorio;
        private DataGridViewTextBoxColumn colValor;
        private DataGridViewTextBoxColumn colValorDesc;
        private DataGridViewTextBoxColumn colPosicaoFiltro;
        private DataGridViewTextBoxColumn colNomeCampoFiltro;
        private DataGridViewImageColumn colExcluir;
        private TextBoxGuard txtFaixaFinal;
        private TextBoxGuard txtFaixaInicial;
    }
}