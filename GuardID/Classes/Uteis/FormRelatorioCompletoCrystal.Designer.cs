﻿namespace System.Windows.Forms.Guard
{
    partial class FormRelatorioCompletoCrystal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelatorioCompletoCrystal));
            this.tbcRelGuard = new System.Windows.Forms.TabControl();
            this.tbpBusca = new System.Windows.Forms.TabPage();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPermissao = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btnLimparCampos = new System.Windows.Forms.Button();
            this.btnGeraRel = new System.Windows.Forms.Button();
            this.pnlTituloFiltro = new System.Windows.Forms.Panel();
            this.labelGuard2 = new System.Windows.Forms.Guard.LabelGuard();
            this.pnlOrdenacao = new System.Windows.Forms.Panel();
            this.pnlTituloOrdenacao = new System.Windows.Forms.Panel();
            this.labelGuard1 = new System.Windows.Forms.Guard.LabelGuard();
            this.pnlModelo = new System.Windows.Forms.Panel();
            this.pnlTituloModelo = new System.Windows.Forms.Panel();
            this.lblModelo = new System.Windows.Forms.Guard.LabelGuard();
            this.tbpRelatorio = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.crystalRptGuard = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tbcRelGuard.SuspendLayout();
            this.tbpBusca.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlTituloFiltro.SuspendLayout();
            this.pnlOrdenacao.SuspendLayout();
            this.pnlTituloOrdenacao.SuspendLayout();
            this.pnlModelo.SuspendLayout();
            this.pnlTituloModelo.SuspendLayout();
            this.tbpRelatorio.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcRelGuard
            // 
            this.tbcRelGuard.Controls.Add(this.tbpBusca);
            this.tbcRelGuard.Controls.Add(this.tbpRelatorio);
            this.tbcRelGuard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcRelGuard.Location = new System.Drawing.Point(0, 0);
            this.tbcRelGuard.Name = "tbcRelGuard";
            this.tbcRelGuard.SelectedIndex = 0;
            this.tbcRelGuard.Size = new System.Drawing.Size(749, 475);
            this.tbcRelGuard.TabIndex = 0;
            // 
            // tbpBusca
            // 
            this.tbpBusca.BackColor = System.Drawing.Color.GhostWhite;
            this.tbpBusca.Controls.Add(this.pnlFiltro);
            this.tbpBusca.Controls.Add(this.pnlOrdenacao);
            this.tbpBusca.Controls.Add(this.pnlModelo);
            this.tbpBusca.Location = new System.Drawing.Point(4, 22);
            this.tbpBusca.Name = "tbpBusca";
            this.tbpBusca.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBusca.Size = new System.Drawing.Size(741, 449);
            this.tbpBusca.TabIndex = 0;
            this.tbpBusca.Text = "Pesquisa Relatorio";
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlFiltro.Controls.Add(this.panel3);
            this.pnlFiltro.Controls.Add(this.pnlTituloFiltro);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltro.Location = new System.Drawing.Point(3, 111);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(735, 335);
            this.pnlFiltro.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnPermissao);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.btnLimparCampos);
            this.panel3.Controls.Add(this.btnGeraRel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 298);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(735, 37);
            this.panel3.TabIndex = 14;
            // 
            // btnPermissao
            // 
            this.btnPermissao.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPermissao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPermissao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermissao.Image = ((System.Drawing.Image)(resources.GetObject("btnPermissao.Image")));
            this.btnPermissao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPermissao.Location = new System.Drawing.Point(2, 2);
            this.btnPermissao.Name = "btnPermissao";
            this.btnPermissao.Size = new System.Drawing.Size(44, 30);
            this.btnPermissao.TabIndex = 6;
            this.btnPermissao.UseVisualStyleBackColor = true;
            this.btnPermissao.Click += new System.EventHandler(this.btnPermissao_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(625, 2);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(106, 30);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "     Cancelar";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Visible = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnLimparCampos
            // 
            this.btnLimparCampos.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLimparCampos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparCampos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCampos.Image = ((System.Drawing.Image)(resources.GetObject("btnLimparCampos.Image")));
            this.btnLimparCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparCampos.Location = new System.Drawing.Point(509, 2);
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.Size = new System.Drawing.Size(114, 30);
            this.btnLimparCampos.TabIndex = 4;
            this.btnLimparCampos.Text = "Limpar";
            this.btnLimparCampos.UseVisualStyleBackColor = true;
            this.btnLimparCampos.Click += new System.EventHandler(this.btnLimparCampos_Click);
            // 
            // btnGeraRel
            // 
            this.btnGeraRel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGeraRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeraRel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeraRel.Image = ((System.Drawing.Image)(resources.GetObject("btnGeraRel.Image")));
            this.btnGeraRel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeraRel.Location = new System.Drawing.Point(392, 2);
            this.btnGeraRel.Name = "btnGeraRel";
            this.btnGeraRel.Size = new System.Drawing.Size(114, 30);
            this.btnGeraRel.TabIndex = 3;
            this.btnGeraRel.Text = "Emitir";
            this.btnGeraRel.UseVisualStyleBackColor = true;
            // 
            // pnlTituloFiltro
            // 
            this.pnlTituloFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.pnlTituloFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTituloFiltro.Controls.Add(this.labelGuard2);
            this.pnlTituloFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloFiltro.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloFiltro.Name = "pnlTituloFiltro";
            this.pnlTituloFiltro.Size = new System.Drawing.Size(735, 18);
            this.pnlTituloFiltro.TabIndex = 3;
            // 
            // labelGuard2
            // 
            this.labelGuard2.AutoSize = true;
            this.labelGuard2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuard2.Location = new System.Drawing.Point(3, 2);
            this.labelGuard2.Name = "labelGuard2";
            this.labelGuard2.Size = new System.Drawing.Size(49, 13);
            this.labelGuard2.TabIndex = 0;
            this.labelGuard2.Text = "Filtros";
            // 
            // pnlOrdenacao
            // 
            this.pnlOrdenacao.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlOrdenacao.Controls.Add(this.pnlTituloOrdenacao);
            this.pnlOrdenacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrdenacao.Location = new System.Drawing.Point(3, 57);
            this.pnlOrdenacao.Name = "pnlOrdenacao";
            this.pnlOrdenacao.Size = new System.Drawing.Size(735, 54);
            this.pnlOrdenacao.TabIndex = 5;
            // 
            // pnlTituloOrdenacao
            // 
            this.pnlTituloOrdenacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.pnlTituloOrdenacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTituloOrdenacao.Controls.Add(this.labelGuard1);
            this.pnlTituloOrdenacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloOrdenacao.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloOrdenacao.Name = "pnlTituloOrdenacao";
            this.pnlTituloOrdenacao.Size = new System.Drawing.Size(735, 18);
            this.pnlTituloOrdenacao.TabIndex = 2;
            // 
            // labelGuard1
            // 
            this.labelGuard1.AutoSize = true;
            this.labelGuard1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuard1.Location = new System.Drawing.Point(3, 2);
            this.labelGuard1.Name = "labelGuard1";
            this.labelGuard1.Size = new System.Drawing.Size(148, 13);
            this.labelGuard1.TabIndex = 0;
            this.labelGuard1.Text = "Opções de Ordenação";
            // 
            // pnlModelo
            // 
            this.pnlModelo.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlModelo.Controls.Add(this.pnlTituloModelo);
            this.pnlModelo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlModelo.Location = new System.Drawing.Point(3, 3);
            this.pnlModelo.Name = "pnlModelo";
            this.pnlModelo.Size = new System.Drawing.Size(735, 54);
            this.pnlModelo.TabIndex = 4;
            // 
            // pnlTituloModelo
            // 
            this.pnlTituloModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.pnlTituloModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTituloModelo.Controls.Add(this.lblModelo);
            this.pnlTituloModelo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloModelo.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloModelo.Name = "pnlTituloModelo";
            this.pnlTituloModelo.Size = new System.Drawing.Size(735, 18);
            this.pnlTituloModelo.TabIndex = 1;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(3, 2);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(136, 13);
            this.lblModelo.TabIndex = 0;
            this.lblModelo.Text = "Modelo do Relatório";
            // 
            // tbpRelatorio
            // 
            this.tbpRelatorio.Controls.Add(this.panel1);
            this.tbpRelatorio.Location = new System.Drawing.Point(4, 22);
            this.tbpRelatorio.Name = "tbpRelatorio";
            this.tbpRelatorio.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRelatorio.Size = new System.Drawing.Size(741, 449);
            this.tbpRelatorio.TabIndex = 1;
            this.tbpRelatorio.Text = "Visualizar Relatorio";
            this.tbpRelatorio.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crystalRptGuard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 443);
            this.panel1.TabIndex = 9;
            // 
            // crystalRptGuard
            // 
            this.crystalRptGuard.ActiveViewIndex = -1;
            this.crystalRptGuard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalRptGuard.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalRptGuard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalRptGuard.Location = new System.Drawing.Point(0, 0);
            this.crystalRptGuard.Name = "crystalRptGuard";
            this.crystalRptGuard.ShowCloseButton = false;
            this.crystalRptGuard.ShowCopyButton = false;
            this.crystalRptGuard.ShowExportButton = false;
            this.crystalRptGuard.ShowGroupTreeButton = false;
            this.crystalRptGuard.ShowLogo = false;
            this.crystalRptGuard.ShowParameterPanelButton = false;
            this.crystalRptGuard.ShowPrintButton = false;
            this.crystalRptGuard.ShowRefreshButton = false;
            this.crystalRptGuard.Size = new System.Drawing.Size(735, 443);
            this.crystalRptGuard.TabIndex = 0;
            this.crystalRptGuard.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormRelatorioCompletoCrystal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 475);
            this.Controls.Add(this.tbcRelGuard);
            this.Name = "FormRelatorioCompletoCrystal";
            this.Text = "FormRelatorioCompleto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRelatorioCompleto_FormClosed);
            this.Load += new System.EventHandler(this.FormRelatorioCompleto_Load);
            this.tbcRelGuard.ResumeLayout(false);
            this.tbpBusca.ResumeLayout(false);
            this.pnlFiltro.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnlTituloFiltro.ResumeLayout(false);
            this.pnlTituloFiltro.PerformLayout();
            this.pnlOrdenacao.ResumeLayout(false);
            this.pnlTituloOrdenacao.ResumeLayout(false);
            this.pnlTituloOrdenacao.PerformLayout();
            this.pnlModelo.ResumeLayout(false);
            this.pnlTituloModelo.ResumeLayout(false);
            this.pnlTituloModelo.PerformLayout();
            this.tbpRelatorio.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tbcRelGuard;
        private TabPage tbpRelatorio;
        public TabPage tbpBusca;
        public Panel pnlTituloModelo;
        public LabelGuard lblModelo;
        public Panel pnlModelo;
        public Panel pnlFiltro;
        public Panel pnlTituloFiltro;
        public LabelGuard labelGuard2;
        public Panel pnlOrdenacao;
        public Panel pnlTituloOrdenacao;
        public LabelGuard labelGuard1;
        public Panel panel3;
        public Button btnLimparCampos;
        public Button btnGeraRel;
        public Button btCancel;
        public Button btnPermissao;
#pragma warning disable CS0246 // O nome do tipo ou do namespace "CrystalDecisions" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
        protected CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRptGuard;        
#pragma warning restore CS0246 // O nome do tipo ou do namespace "CrystalDecisions" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
        private Panel panel1;
    }
}