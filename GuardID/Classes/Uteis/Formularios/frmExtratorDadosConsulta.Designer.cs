namespace System.Uteis
{
    partial class frmExtratorDadosConsulta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtratorDadosConsulta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtComandoDesc = new System.Uteis.TextBoxGuard();
            this.txtComando = new System.Uteis.TextBoxGuard();
            this.labelGuard1 = new System.Uteis.LabelGuard();
            this.txtFinalidade = new System.Uteis.TextBoxGuard();
            this.labelGuard2 = new System.Uteis.LabelGuard();
            this.groupBoxGuard1 = new System.Uteis.GroupBoxGuard(this.components);
            this.btnFiltrar = new System.Uteis.ButtonGuard();
            this.dgvComandos = new System.Uteis.DataGridViewGuard();
            this.labelGuard3 = new System.Uteis.LabelGuard();
            this.txtFiltro = new System.Uteis.TextBoxGuard();
            this.btnUtilizarComando = new System.Uteis.ButtonGuard();
            this.colArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComando = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComandoDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSQL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinalidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnGrid.SuspendLayout();
            this.groupBoxGuard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComandos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnGrid
            // 
            this.pnGrid.Controls.Add(this.groupBoxGuard1);
            this.pnGrid.Controls.Add(this.btnUtilizarComando);
            this.pnGrid.Controls.Add(this.labelGuard1);
            this.pnGrid.Controls.Add(this.txtFinalidade);
            this.pnGrid.Controls.Add(this.txtComando);
            this.pnGrid.Controls.Add(this.labelGuard2);
            this.pnGrid.Controls.Add(this.txtComandoDesc);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(0, 31);
            this.pnGrid.Size = new System.Drawing.Size(845, 440);
            this.pnGrid.Controls.SetChildIndex(this.txtComandoDesc, 0);
            this.pnGrid.Controls.SetChildIndex(this.labelGuard2, 0);
            this.pnGrid.Controls.SetChildIndex(this.txtTotais, 0);
            this.pnGrid.Controls.SetChildIndex(this.txtComando, 0);
            this.pnGrid.Controls.SetChildIndex(this.txtFinalidade, 0);
            this.pnGrid.Controls.SetChildIndex(this.labelGuard1, 0);
            this.pnGrid.Controls.SetChildIndex(this.btnUtilizarComando, 0);
            this.pnGrid.Controls.SetChildIndex(this.groupBoxGuard1, 0);
            // 
            // pnFiltros
            // 
            this.pnFiltros.Location = new System.Drawing.Point(-99, 33);
            this.pnFiltros.Size = new System.Drawing.Size(84, 43);
            this.pnFiltros.Visible = false;
            // 
            // txtTotais
            // 
            this.txtTotais.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTotais.Location = new System.Drawing.Point(0, 416);
            this.txtTotais.Size = new System.Drawing.Size(843, 22);
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
            this.txtComandoDesc.Location = new System.Drawing.Point(193, 12);
            this.txtComandoDesc.Name = "txtComandoDesc";
            this.txtComandoDesc.NomeCampoDadosDataTable = null;
            this.txtComandoDesc.ParteDecimal = 0;
            this.txtComandoDesc.ParteInteira = 0;
            this.txtComandoDesc.ReadOnly = true;
            this.txtComandoDesc.Size = new System.Drawing.Size(476, 21);
            this.txtComandoDesc.TabIndex = 69;
            this.txtComandoDesc.TabStop = false;
            this.txtComandoDesc.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtComandoDesc.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            // 
            // txtComando
            // 
            this.txtComando._RecursosGenericosSqlF3 = null;
            this.txtComando._RecursosGenericosSqlLeave = null;
            this.txtComando.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.txtComando.ExibirIconePesquisa = false;
            this.txtComando.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComando.InformacaoToolTipCaminho = null;
            this.txtComando.InformacaoToolTipDescricao = null;
            this.txtComando.LimpaCampo = true;
            this.txtComando.Location = new System.Drawing.Point(103, 12);
            this.txtComando.Name = "txtComando";
            this.txtComando.NomeCampoDadosDataTable = null;
            this.txtComando.ParteDecimal = 0;
            this.txtComando.ParteInteira = 0;
            this.txtComando.ReadOnly = true;
            this.txtComando.Size = new System.Drawing.Size(84, 21);
            this.txtComando.TabIndex = 68;
            this.txtComando.TabStop = false;
            this.txtComando.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtComando.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Numerico;
            // 
            // labelGuard1
            // 
            this.labelGuard1.AutoSize = true;
            this.labelGuard1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuard1.Location = new System.Drawing.Point(11, 15);
            this.labelGuard1.Name = "labelGuard1";
            this.labelGuard1.Size = new System.Drawing.Size(71, 13);
            this.labelGuard1.TabIndex = 67;
            this.labelGuard1.Text = "Comando:";
            // 
            // txtFinalidade
            // 
            this.txtFinalidade._RecursosGenericosSqlF3 = null;
            this.txtFinalidade._RecursosGenericosSqlLeave = null;
            this.txtFinalidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.txtFinalidade.ExibirIconePesquisa = false;
            this.txtFinalidade.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinalidade.InformacaoToolTipCaminho = null;
            this.txtFinalidade.InformacaoToolTipDescricao = null;
            this.txtFinalidade.LimpaCampo = true;
            this.txtFinalidade.Location = new System.Drawing.Point(103, 39);
            this.txtFinalidade.Multiline = true;
            this.txtFinalidade.Name = "txtFinalidade";
            this.txtFinalidade.NomeCampoDadosDataTable = null;
            this.txtFinalidade.ParteDecimal = 0;
            this.txtFinalidade.ParteInteira = 0;
            this.txtFinalidade.ReadOnly = true;
            this.txtFinalidade.Size = new System.Drawing.Size(729, 96);
            this.txtFinalidade.TabIndex = 71;
            this.txtFinalidade.TabStop = false;
            this.txtFinalidade.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtFinalidade.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            // 
            // labelGuard2
            // 
            this.labelGuard2.AutoSize = true;
            this.labelGuard2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuard2.Location = new System.Drawing.Point(11, 42);
            this.labelGuard2.Name = "labelGuard2";
            this.labelGuard2.Size = new System.Drawing.Size(79, 13);
            this.labelGuard2.TabIndex = 70;
            this.labelGuard2.Text = "Finalidade:";
            // 
            // groupBoxGuard1
            // 
            this.groupBoxGuard1.Controls.Add(this.btnFiltrar);
            this.groupBoxGuard1.Controls.Add(this.dgvComandos);
            this.groupBoxGuard1.Controls.Add(this.labelGuard3);
            this.groupBoxGuard1.Controls.Add(this.txtFiltro);
            this.groupBoxGuard1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxGuard1.Location = new System.Drawing.Point(11, 141);
            this.groupBoxGuard1.Name = "groupBoxGuard1";
            this.groupBoxGuard1.Size = new System.Drawing.Size(821, 269);
            this.groupBoxGuard1.TabIndex = 72;
            this.groupBoxGuard1.TabStop = false;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.Image = global::System.Uteis.Properties.Resources.iBusca16;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(664, 12);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(151, 23);
            this.btnFiltrar.TabIndex = 76;
            this.btnFiltrar.Text = "Filtrar Comandos";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvComandos
            // 
            this.dgvComandos.AllowUserToAddRows = false;
            this.dgvComandos.AllowUserToDeleteRows = false;
            this.dgvComandos.AllowUserToResizeRows = false;
            this.dgvComandos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvComandos.BackgroundColor = System.Drawing.Color.White;
            this.dgvComandos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComandos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComandos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComandos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArea,
            this.colComando,
            this.colComandoDesc,
            this.colSQL,
            this.colFinalidade});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComandos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvComandos.EnableHeadersVisualStyles = false;
            this.dgvComandos.HabilitarColunasInvisiveisExportarExcel = false;
            this.dgvComandos.LimpaCampo = true;
            this.dgvComandos.Location = new System.Drawing.Point(9, 41);
            this.dgvComandos.MultiSelect = false;
            this.dgvComandos.Name = "dgvComandos";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComandos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvComandos.RowHeadersVisible = false;
            this.dgvComandos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComandos.Size = new System.Drawing.Size(806, 221);
            this.dgvComandos.TabIndex = 75;
            this.dgvComandos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComandos_CellDoubleClick);
            this.dgvComandos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComandos_RowEnter);
            this.dgvComandos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvComandos_RowsAdded);
            this.dgvComandos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvComandos_RowsRemoved);
            // 
            // labelGuard3
            // 
            this.labelGuard3.AutoSize = true;
            this.labelGuard3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuard3.Location = new System.Drawing.Point(6, 17);
            this.labelGuard3.Name = "labelGuard3";
            this.labelGuard3.Size = new System.Drawing.Size(52, 13);
            this.labelGuard3.TabIndex = 73;
            this.labelGuard3.Text = "Filtrar:";
            // 
            // txtFiltro
            // 
            this.txtFiltro._RecursosGenericosSqlF3 = null;
            this.txtFiltro._RecursosGenericosSqlLeave = null;
            this.txtFiltro.BackColor = System.Drawing.Color.White;
            this.txtFiltro.ExibirIconePesquisa = false;
            this.txtFiltro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.InformacaoToolTipCaminho = null;
            this.txtFiltro.InformacaoToolTipDescricao = null;
            this.txtFiltro.LimpaCampo = true;
            this.txtFiltro.Location = new System.Drawing.Point(92, 14);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.NomeCampoDadosDataTable = null;
            this.txtFiltro.ParteDecimal = 0;
            this.txtFiltro.ParteInteira = 0;
            this.txtFiltro.Size = new System.Drawing.Size(566, 21);
            this.txtFiltro.TabIndex = 74;
            this.txtFiltro.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtFiltro.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // btnUtilizarComando
            // 
            this.btnUtilizarComando.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.btnUtilizarComando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUtilizarComando.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUtilizarComando.Image = ((System.Drawing.Image)(resources.GetObject("btnUtilizarComando.Image")));
            this.btnUtilizarComando.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUtilizarComando.Location = new System.Drawing.Point(681, 10);
            this.btnUtilizarComando.Name = "btnUtilizarComando";
            this.btnUtilizarComando.Size = new System.Drawing.Size(151, 23);
            this.btnUtilizarComando.TabIndex = 77;
            this.btnUtilizarComando.TabStop = false;
            this.btnUtilizarComando.Text = "Utilizar Comando";
            this.btnUtilizarComando.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUtilizarComando.UseVisualStyleBackColor = true;
            this.btnUtilizarComando.Click += new System.EventHandler(this.btnUtilizarComando_Click);
            // 
            // colArea
            // 
            this.colArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colArea.DataPropertyName = "AREA";
            this.colArea.HeaderText = "Área";
            this.colArea.Name = "colArea";
            this.colArea.ReadOnly = true;
            this.colArea.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colArea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colArea.Width = 43;
            // 
            // colComando
            // 
            this.colComando.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colComando.DataPropertyName = "COMANDO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colComando.DefaultCellStyle = dataGridViewCellStyle2;
            this.colComando.HeaderText = "Comando";
            this.colComando.Name = "colComando";
            this.colComando.ReadOnly = true;
            this.colComando.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colComando.Width = 72;
            // 
            // colComandoDesc
            // 
            this.colComandoDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colComandoDesc.DataPropertyName = "COMANDO_DESC";
            this.colComandoDesc.HeaderText = "Descrição";
            this.colComandoDesc.Name = "colComandoDesc";
            this.colComandoDesc.ReadOnly = true;
            this.colComandoDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSQL
            // 
            this.colSQL.DataPropertyName = "SQL";
            this.colSQL.HeaderText = "SQL";
            this.colSQL.Name = "colSQL";
            this.colSQL.ReadOnly = true;
            this.colSQL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSQL.Visible = false;
            this.colSQL.Width = 36;
            // 
            // colFinalidade
            // 
            this.colFinalidade.DataPropertyName = "FINALIDADE";
            this.colFinalidade.HeaderText = "Finalidade";
            this.colFinalidade.Name = "colFinalidade";
            this.colFinalidade.ReadOnly = true;
            this.colFinalidade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFinalidade.Visible = false;
            this.colFinalidade.Width = 80;
            // 
            // frmExtratorDadosConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 471);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExtratorDadosConsulta";
            this.Text = "Extrator de Dados - Consulta de Comandos";
            this.Load += new System.EventHandler(this.frmExtratorDadosConsulta_Load);
            this.pnGrid.ResumeLayout(false);
            this.pnGrid.PerformLayout();
            this.groupBoxGuard1.ResumeLayout(false);
            this.groupBoxGuard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComandos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Uteis.TextBoxGuard txtComandoDesc;
        private System.Uteis.TextBoxGuard txtComando;
        private System.Uteis.LabelGuard labelGuard1;
        private System.Uteis.TextBoxGuard txtFinalidade;
        private System.Uteis.LabelGuard labelGuard2;
        private System.Uteis.GroupBoxGuard groupBoxGuard1;
        private System.Uteis.LabelGuard labelGuard3;
        private System.Uteis.TextBoxGuard txtFiltro;
        private System.Uteis.DataGridViewGuard dgvComandos;
        private System.Uteis.ButtonGuard btnFiltrar;
        private System.Uteis.ButtonGuard btnUtilizarComando;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComando;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComandoDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSQL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinalidade;

    }
}