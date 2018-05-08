﻿using System.Windows.Forms;
using System.Windows.Forms.Guard;
namespace System.Windows.Forms.Guard
{
    partial class FormBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripOpcoes = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSelecionar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnAtualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorOpcoes = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnExcel = new System.Windows.Forms.ToolStripButton();
            this.lblMsgBuscandoDados = new System.Windows.Forms.ToolStripLabel();
            this.toolStripBtnCopiarSQL = new System.Windows.Forms.ToolStripButton();
            this.pnlCondicao = new System.Windows.Forms.Panel();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.txtFiltroEntre2 = new System.Windows.Forms.Guard.TextBoxGuard();
            this.dtpFiltro = new System.Windows.Forms.DateTimePicker();
            this.lbEntreData = new System.Windows.Forms.Label();
            this.txtFiltroEntre1 = new System.Windows.Forms.Guard.TextBoxGuard();
            this.lbEntreTexto = new System.Windows.Forms.Label();
            this.dtpFiltroEntre = new System.Windows.Forms.DateTimePicker();
            this.txtFiltro = new System.Windows.Forms.Guard.TextBoxGuard();
            this.lblColuna = new System.Windows.Forms.Label();
            this.cboColuna = new System.Windows.Forms.ComboBox();
            this.lblCondicao = new System.Windows.Forms.Label();
            this.cboCondicao = new System.Windows.Forms.ComboBox();
            this.dgvLista = new System.Windows.Forms.Guard.DataGridViewGuard();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblContagemItensGrid = new System.Windows.Forms.Guard.LabelGuard();
            this.toolStripOpcoes.SuspendLayout();
            this.pnlCondicao.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripOpcoes
            // 
            this.toolStripOpcoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.toolStripOpcoes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripOpcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnFiltrar,
            this.toolStripBtnSelecionar,
            this.toolStripBtnAtualizar,
            this.toolStripSeparatorOpcoes,
            this.toolStripBtnExcel,
            this.lblMsgBuscandoDados,
            this.toolStripBtnCopiarSQL});
            this.toolStripOpcoes.Location = new System.Drawing.Point(0, 0);
            this.toolStripOpcoes.Name = "toolStripOpcoes";
            this.toolStripOpcoes.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripOpcoes.Size = new System.Drawing.Size(584, 31);
            this.toolStripOpcoes.Stretch = true;
            this.toolStripOpcoes.TabIndex = 2;
            this.toolStripOpcoes.Text = "toolStripOpcoes";
            // 
            // toolStripBtnFiltrar
            // 
            this.toolStripBtnFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnFiltrar.Image")));
            this.toolStripBtnFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnFiltrar.ImageTransparentColor = System.Drawing.Color.Maroon;
            this.toolStripBtnFiltrar.Name = "toolStripBtnFiltrar";
            this.toolStripBtnFiltrar.Size = new System.Drawing.Size(28, 28);
            this.toolStripBtnFiltrar.ToolTipText = "Filtar de Acordo com a Condição";
            this.toolStripBtnFiltrar.Click += new System.EventHandler(this.toolStripBtnFiltrar_Click);
            // 
            // toolStripBtnSelecionar
            // 
            this.toolStripBtnSelecionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSelecionar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSelecionar.Image")));
            this.toolStripBtnSelecionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSelecionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSelecionar.Name = "toolStripBtnSelecionar";
            this.toolStripBtnSelecionar.Size = new System.Drawing.Size(28, 28);
            this.toolStripBtnSelecionar.ToolTipText = "Confirma Linha Selecionada";
            this.toolStripBtnSelecionar.Click += new System.EventHandler(this.toolStripBtnSelecionar_Click);
            // 
            // toolStripBtnAtualizar
            // 
            this.toolStripBtnAtualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAtualizar.Image")));
            this.toolStripBtnAtualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAtualizar.Name = "toolStripBtnAtualizar";
            this.toolStripBtnAtualizar.Size = new System.Drawing.Size(26, 28);
            this.toolStripBtnAtualizar.ToolTipText = "Atualizar de Acordo com a Condição";
            this.toolStripBtnAtualizar.Click += new System.EventHandler(this.toolStripBtnAtualizar_Click);
            // 
            // toolStripSeparatorOpcoes
            // 
            this.toolStripSeparatorOpcoes.Name = "toolStripSeparatorOpcoes";
            this.toolStripSeparatorOpcoes.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripBtnExcel
            // 
            this.toolStripBtnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnExcel.Image")));
            this.toolStripBtnExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnExcel.Name = "toolStripBtnExcel";
            this.toolStripBtnExcel.Size = new System.Drawing.Size(26, 28);
            this.toolStripBtnExcel.ToolTipText = "Exportar Lista no Formato Microsoft Excel";
            this.toolStripBtnExcel.Click += new System.EventHandler(this.toolStripBtnExcel_Click);
            // 
            // lblMsgBuscandoDados
            // 
            this.lblMsgBuscandoDados.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblMsgBuscandoDados.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgBuscandoDados.Name = "lblMsgBuscandoDados";
            this.lblMsgBuscandoDados.Size = new System.Drawing.Size(145, 28);
            this.lblMsgBuscandoDados.Text = "Buscando dados...";
            this.lblMsgBuscandoDados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMsgBuscandoDados.Visible = false;
            // 
            // toolStripBtnCopiarSQL
            // 
            this.toolStripBtnCopiarSQL.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCopiarSQL.Image")));
            this.toolStripBtnCopiarSQL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnCopiarSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCopiarSQL.Name = "toolStripBtnCopiarSQL";
            this.toolStripBtnCopiarSQL.Size = new System.Drawing.Size(237, 28);
            this.toolStripBtnCopiarSQL.Text = "Copiar SQL para Área de Transferência";
            this.toolStripBtnCopiarSQL.Visible = false;
            this.toolStripBtnCopiarSQL.Click += new System.EventHandler(this.toolStripBtnCopiarSQL_Click);
            // 
            // pnlCondicao
            // 
            this.pnlCondicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCondicao.Controls.Add(this.pnlFiltros);
            this.pnlCondicao.Controls.Add(this.lblColuna);
            this.pnlCondicao.Controls.Add(this.cboColuna);
            this.pnlCondicao.Controls.Add(this.lblCondicao);
            this.pnlCondicao.Controls.Add(this.cboCondicao);
            this.pnlCondicao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCondicao.Location = new System.Drawing.Point(5, 36);
            this.pnlCondicao.Name = "pnlCondicao";
            this.pnlCondicao.Size = new System.Drawing.Size(574, 61);
            this.pnlCondicao.TabIndex = 0;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.lblFiltro);
            this.pnlFiltros.Controls.Add(this.txtFiltroEntre2);
            this.pnlFiltros.Controls.Add(this.dtpFiltro);
            this.pnlFiltros.Controls.Add(this.lbEntreData);
            this.pnlFiltros.Controls.Add(this.txtFiltroEntre1);
            this.pnlFiltros.Controls.Add(this.lbEntreTexto);
            this.pnlFiltros.Controls.Add(this.dtpFiltroEntre);
            this.pnlFiltros.Controls.Add(this.txtFiltro);
            this.pnlFiltros.Location = new System.Drawing.Point(5, 27);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(564, 29);
            this.pnlFiltros.TabIndex = 45;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(4, 6);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(46, 13);
            this.lblFiltro.TabIndex = 36;
            this.lblFiltro.Text = "Filtro:";
            // 
            // txtFiltroEntre2
            // 
            this.txtFiltroEntre2._RecursosGenericosSqlF3 = null;
            this.txtFiltroEntre2._RecursosGenericosSqlLeave = null;
            this.txtFiltroEntre2.BackColor = System.Drawing.Color.White;
            this.txtFiltroEntre2.ExibirIconePesquisa = false;
            this.txtFiltroEntre2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroEntre2.InformacaoToolTipCaminho = null;
            this.txtFiltroEntre2.InformacaoToolTipDescricao = null;
            this.txtFiltroEntre2.LimpaCampo = true;
            this.txtFiltroEntre2.Location = new System.Drawing.Point(312, 3);
            this.txtFiltroEntre2.Name = "txtFiltroEntre2";
            this.txtFiltroEntre2.NomeCampoDadosDataTable = null;
            this.txtFiltroEntre2.ParteDecimal = 0;
            this.txtFiltroEntre2.ParteInteira = 0;
            this.txtFiltroEntre2.SegurancaCCusto = System.Windows.Forms.Guard.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtFiltroEntre2.Size = new System.Drawing.Size(246, 21);
            this.txtFiltroEntre2.TabIndex = 2;
            this.txtFiltroEntre2.TipoCampo = System.Windows.Forms.Guard.TextBoxGuard.CTipoCampo.Normal;
            this.txtFiltroEntre2.TipoValor = System.Windows.Forms.Guard.TextBoxGuard.CTipoValor.Geral;
            this.txtFiltroEntre2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltroEntre2_KeyPress);
            // 
            // dtpFiltro
            // 
            this.dtpFiltro.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltro.Location = new System.Drawing.Point(52, 3);
            this.dtpFiltro.Name = "dtpFiltro";
            this.dtpFiltro.Size = new System.Drawing.Size(123, 21);
            this.dtpFiltro.TabIndex = 3;
            this.dtpFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFiltro_KeyPress);
            // 
            // lbEntreData
            // 
            this.lbEntreData.AutoSize = true;
            this.lbEntreData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEntreData.Location = new System.Drawing.Point(181, 6);
            this.lbEntreData.Name = "lbEntreData";
            this.lbEntreData.Size = new System.Drawing.Size(15, 13);
            this.lbEntreData.TabIndex = 44;
            this.lbEntreData.Text = "a";
            // 
            // txtFiltroEntre1
            // 
            this.txtFiltroEntre1._RecursosGenericosSqlF3 = null;
            this.txtFiltroEntre1._RecursosGenericosSqlLeave = null;
            this.txtFiltroEntre1.BackColor = System.Drawing.Color.White;
            this.txtFiltroEntre1.ExibirIconePesquisa = false;
            this.txtFiltroEntre1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroEntre1.InformacaoToolTipCaminho = null;
            this.txtFiltroEntre1.InformacaoToolTipDescricao = null;
            this.txtFiltroEntre1.LimpaCampo = true;
            this.txtFiltroEntre1.Location = new System.Drawing.Point(52, 3);
            this.txtFiltroEntre1.Name = "txtFiltroEntre1";
            this.txtFiltroEntre1.NomeCampoDadosDataTable = null;
            this.txtFiltroEntre1.ParteDecimal = 0;
            this.txtFiltroEntre1.ParteInteira = 0;
            this.txtFiltroEntre1.SegurancaCCusto = System.Windows.Forms.Guard.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtFiltroEntre1.Size = new System.Drawing.Size(233, 21);
            this.txtFiltroEntre1.TabIndex = 1;
            this.txtFiltroEntre1.TipoCampo = System.Windows.Forms.Guard.TextBoxGuard.CTipoCampo.Normal;
            this.txtFiltroEntre1.TipoValor = System.Windows.Forms.Guard.TextBoxGuard.CTipoValor.Geral;
            this.txtFiltroEntre1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltroEntre1_KeyPress);
            // 
            // lbEntreTexto
            // 
            this.lbEntreTexto.AutoSize = true;
            this.lbEntreTexto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEntreTexto.Location = new System.Drawing.Point(291, 6);
            this.lbEntreTexto.Name = "lbEntreTexto";
            this.lbEntreTexto.Size = new System.Drawing.Size(15, 13);
            this.lbEntreTexto.TabIndex = 41;
            this.lbEntreTexto.Text = "a";
            // 
            // dtpFiltroEntre
            // 
            this.dtpFiltroEntre.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltroEntre.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltroEntre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroEntre.Location = new System.Drawing.Point(201, 3);
            this.dtpFiltroEntre.Name = "dtpFiltroEntre";
            this.dtpFiltroEntre.Size = new System.Drawing.Size(123, 21);
            this.dtpFiltroEntre.TabIndex = 4;
            this.dtpFiltroEntre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFiltroEntre_KeyPress);
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
            this.txtFiltro.Location = new System.Drawing.Point(52, 3);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.NomeCampoDadosDataTable = null;
            this.txtFiltro.ParteDecimal = 0;
            this.txtFiltro.ParteInteira = 0;
            this.txtFiltro.SegurancaCCusto = System.Windows.Forms.Guard.TextBoxGuard.CSegurancaCentroCusto.NaoUtilizado;
            this.txtFiltro.Size = new System.Drawing.Size(506, 21);
            this.txtFiltro.TabIndex = 0;
            this.txtFiltro.TipoCampo = System.Windows.Forms.Guard.TextBoxGuard.CTipoCampo.Normal;
            this.txtFiltro.TipoValor = System.Windows.Forms.Guard.TextBoxGuard.CTipoValor.Geral;
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // lblColuna
            // 
            this.lblColuna.AutoSize = true;
            this.lblColuna.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColuna.Location = new System.Drawing.Point(0, 8);
            this.lblColuna.Name = "lblColuna";
            this.lblColuna.Size = new System.Drawing.Size(55, 13);
            this.lblColuna.TabIndex = 39;
            this.lblColuna.Text = "Coluna:";
            // 
            // cboColuna
            // 
            this.cboColuna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColuna.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColuna.FormattingEnabled = true;
            this.cboColuna.Location = new System.Drawing.Point(57, 5);
            this.cboColuna.Name = "cboColuna";
            this.cboColuna.Size = new System.Drawing.Size(155, 21);
            this.cboColuna.TabIndex = 1;
            this.cboColuna.SelectedIndexChanged += new System.EventHandler(this.cboColuna_SelectedIndexChanged);
            // 
            // lblCondicao
            // 
            this.lblCondicao.AutoSize = true;
            this.lblCondicao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondicao.Location = new System.Drawing.Point(216, 8);
            this.lblCondicao.Name = "lblCondicao";
            this.lblCondicao.Size = new System.Drawing.Size(70, 13);
            this.lblCondicao.TabIndex = 35;
            this.lblCondicao.Text = "Condição:";
            // 
            // cboCondicao
            // 
            this.cboCondicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCondicao.FormattingEnabled = true;
            this.cboCondicao.Location = new System.Drawing.Point(288, 5);
            this.cboCondicao.Name = "cboCondicao";
            this.cboCondicao.Size = new System.Drawing.Size(151, 21);
            this.cboCondicao.TabIndex = 2;
            this.cboCondicao.SelectedIndexChanged += new System.EventHandler(this.cboCondicao_SelectedIndexChanged);
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AllowUserToResizeRows = false;
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLista.BackgroundColor = System.Drawing.Color.White;
            this.dgvLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.EnableHeadersVisualStyles = false;
            this.dgvLista.HabilitarColunasInvisiveisExportarExcel = false;
            this.dgvLista.LimpaCampo = true;
            this.dgvLista.Location = new System.Drawing.Point(5, 115);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(574, 242);
            this.dgvLista.TabIndex = 1;
            this.dgvLista.DataSourceChanged += new System.EventHandler(this.dgvLista_DataSourceChanged);
            this.dgvLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellDoubleClick);
            this.dgvLista.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvLista_ColumnWidthChanged);
            this.dgvLista.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvLista_RowsAdded);
            this.dgvLista.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvLista_RowsRemoved);
            this.dgvLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLista_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 5);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 357);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(584, 5);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(579, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 321);
            this.panel4.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 36);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 321);
            this.panel5.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(5, 97);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(574, 18);
            this.panel6.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblContagemItensGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 18);
            this.panel1.TabIndex = 1098;
            // 
            // lblContagemItensGrid
            // 
            this.lblContagemItensGrid.AutoSize = true;
            this.lblContagemItensGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblContagemItensGrid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContagemItensGrid.Location = new System.Drawing.Point(0, 5);
            this.lblContagemItensGrid.Name = "lblContagemItensGrid";
            this.lblContagemItensGrid.Size = new System.Drawing.Size(136, 13);
            this.lblContagemItensGrid.TabIndex = 1088;
            this.lblContagemItensGrid.Text = "Total de itens: 9999";
            this.lblContagemItensGrid.Visible = false;
            // 
            // FormBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.pnlCondicao);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStripOpcoes);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FormBusca";
            this.ShowInTaskbar = false;
            this.Text = "";
            this.Load += new System.EventHandler(this.FormBusca2_Load);
            this.SizeChanged += new System.EventHandler(this.FormBusca_SizeChanged);
            this.toolStripOpcoes.ResumeLayout(false);
            this.toolStripOpcoes.PerformLayout();
            this.pnlCondicao.ResumeLayout(false);
            this.pnlCondicao.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ToolStripButton toolStripBtnFiltrar;
        private ToolStripButton toolStripBtnSelecionar;
        private ToolStripButton toolStripBtnAtualizar;
        private ToolStripSeparator toolStripSeparatorOpcoes;
        private ToolStripButton toolStripBtnExcel;
        private Panel pnlCondicao;
        private Label lblColuna;
        private ComboBox cboColuna;
        private Label lblCondicao;
        private ComboBox cboCondicao;
        private Label lblFiltro;
        private DataGridViewGuard dgvLista;
        public ToolStrip toolStripOpcoes;
        private DateTimePicker dtpFiltro;
        private TextBoxGuard txtFiltro;
        private Label lbEntreData;
        private DateTimePicker dtpFiltroEntre;
        private TextBoxGuard txtFiltroEntre2;
        private Label lbEntreTexto;
        private TextBoxGuard txtFiltroEntre1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private ToolStripLabel lblMsgBuscandoDados;
        public Panel panel1;
        public LabelGuard lblContagemItensGrid;
        private Panel pnlFiltros;
        private ToolStripButton toolStripBtnCopiarSQL;
    }
}