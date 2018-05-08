﻿namespace System.Windows.Forms.Guard
{
    partial class frmAuditoriaFormulario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnTitulo = new System.Windows.Forms.Panel();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbTabela = new System.Windows.Forms.Guard.LabelGuard();
            this.lbChave = new System.Windows.Forms.Guard.LabelGuard();
            this.lbTabelaDescricao = new System.Windows.Forms.Guard.LabelGuard();
            this.dgvLog = new System.Windows.Forms.Guard.DataGridViewGuard();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomeAcao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetalhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLogDetalhe = new System.Windows.Forms.Guard.DataGridViewGuard();
            this.lbDetalheCampos = new System.Windows.Forms.Guard.LabelGuard();
            this.txtChaveDescricao = new System.Windows.Forms.Guard.TextBoxGuard();
            this.lbExemplo = new System.Windows.Forms.Guard.LabelGuard();
            this.labelGuard2 = new System.Windows.Forms.Guard.LabelGuard();
            this.pnTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogDetalhe)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitulo
            // 
            this.pnTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.pnTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTitulo.Controls.Add(this.lbTitulo);
            this.pnTitulo.Location = new System.Drawing.Point(12, 3);
            this.pnTitulo.Name = "pnTitulo";
            this.pnTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnTitulo.Size = new System.Drawing.Size(575, 31);
            this.pnTitulo.TabIndex = 113;
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.Black;
            this.lbTitulo.Location = new System.Drawing.Point(182, 2);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(208, 24);
            this.lbTitulo.TabIndex = 1;
            this.lbTitulo.Text = "Auditoria de Alterações";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbTabela
            // 
            this.lbTabela.AutoSize = true;
            this.lbTabela.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTabela.Location = new System.Drawing.Point(12, 46);
            this.lbTabela.Name = "lbTabela";
            this.lbTabela.Size = new System.Drawing.Size(55, 13);
            this.lbTabela.TabIndex = 114;
            this.lbTabela.Text = "Tabela:";
            // 
            // lbChave
            // 
            this.lbChave.AutoSize = true;
            this.lbChave.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChave.Location = new System.Drawing.Point(16, 67);
            this.lbChave.Name = "lbChave";
            this.lbChave.Size = new System.Drawing.Size(51, 13);
            this.lbChave.TabIndex = 115;
            this.lbChave.Text = "Chave:";
            // 
            // lbTabelaDescricao
            // 
            this.lbTabelaDescricao.AutoSize = true;
            this.lbTabelaDescricao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTabelaDescricao.ForeColor = System.Drawing.Color.CadetBlue;
            this.lbTabelaDescricao.Location = new System.Drawing.Point(73, 46);
            this.lbTabelaDescricao.Name = "lbTabelaDescricao";
            this.lbTabelaDescricao.Size = new System.Drawing.Size(51, 13);
            this.lbTabelaDescricao.TabIndex = 116;
            this.lbTabelaDescricao.Text = "Tabela";
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToResizeColumns = false;
            this.dgvLog.AllowUserToResizeRows = false;
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUsuario,
            this.colNome,
            this.colData,
            this.colAcao,
            this.colNomeAcao,
            this.colDetalhe});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLog.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvLog.EnableHeadersVisualStyles = false;
            this.dgvLog.LimpaCampo = true;
            this.dgvLog.Location = new System.Drawing.Point(12, 104);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(575, 150);
            this.dgvLog.TabIndex = 118;
            this.dgvLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLog_CellClick);
            this.dgvLog.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLog_CellFormatting);
            this.dgvLog.SelectionChanged += new System.EventHandler(this.dgvLog_SelectionChanged);
            this.dgvLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLog_KeyDown);
            // 
            // colUsuario
            // 
            this.colUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colUsuario.DataPropertyName = "USUARIO";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUsuario.DefaultCellStyle = dataGridViewCellStyle12;
            this.colUsuario.Frozen = true;
            this.colUsuario.HeaderText = "Usuário";
            this.colUsuario.MinimumWidth = 20;
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            this.colUsuario.Width = 70;
            // 
            // colNome
            // 
            this.colNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colNome.DataPropertyName = "NOME";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNome.DefaultCellStyle = dataGridViewCellStyle13;
            this.colNome.Frozen = true;
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 236;
            // 
            // colData
            // 
            this.colData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colData.DataPropertyName = "DATA";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.colData.DefaultCellStyle = dataGridViewCellStyle14;
            this.colData.FillWeight = 200F;
            this.colData.Frozen = true;
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 171;
            // 
            // colAcao
            // 
            this.colAcao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAcao.DataPropertyName = "NOMEACAO";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAcao.DefaultCellStyle = dataGridViewCellStyle15;
            this.colAcao.Frozen = true;
            this.colAcao.HeaderText = "Ação";
            this.colAcao.Name = "colAcao";
            this.colAcao.ReadOnly = true;
            this.colAcao.Width = 95;
            // 
            // colNomeAcao
            // 
            this.colNomeAcao.DataPropertyName = "ACAO";
            this.colNomeAcao.Frozen = true;
            this.colNomeAcao.HeaderText = "ACAO";
            this.colNomeAcao.Name = "colNomeAcao";
            this.colNomeAcao.ReadOnly = true;
            this.colNomeAcao.Visible = false;
            this.colNomeAcao.Width = 66;
            // 
            // colDetalhe
            // 
            this.colDetalhe.DataPropertyName = "DETALHE";
            this.colDetalhe.Frozen = true;
            this.colDetalhe.HeaderText = "Detalhe";
            this.colDetalhe.Name = "colDetalhe";
            this.colDetalhe.ReadOnly = true;
            this.colDetalhe.Visible = false;
            this.colDetalhe.Width = 81;
            // 
            // dgvLogDetalhe
            // 
            this.dgvLogDetalhe.AllowUserToAddRows = false;
            this.dgvLogDetalhe.AllowUserToDeleteRows = false;
            this.dgvLogDetalhe.AllowUserToResizeColumns = false;
            this.dgvLogDetalhe.AllowUserToResizeRows = false;
            this.dgvLogDetalhe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLogDetalhe.BackgroundColor = System.Drawing.Color.White;
            this.dgvLogDetalhe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogDetalhe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvLogDetalhe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLogDetalhe.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgvLogDetalhe.EnableHeadersVisualStyles = false;
            this.dgvLogDetalhe.LimpaCampo = true;
            this.dgvLogDetalhe.Location = new System.Drawing.Point(12, 273);
            this.dgvLogDetalhe.Name = "dgvLogDetalhe";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogDetalhe.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvLogDetalhe.RowHeadersVisible = false;
            this.dgvLogDetalhe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvLogDetalhe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogDetalhe.Size = new System.Drawing.Size(575, 182);
            this.dgvLogDetalhe.TabIndex = 119;
            this.dgvLogDetalhe.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLogDetalhe_CellFormatting);
            // 
            // lbDetalheCampos
            // 
            this.lbDetalheCampos.AutoSize = true;
            this.lbDetalheCampos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetalheCampos.Location = new System.Drawing.Point(16, 257);
            this.lbDetalheCampos.Name = "lbDetalheCampos";
            this.lbDetalheCampos.Size = new System.Drawing.Size(120, 13);
            this.lbDetalheCampos.TabIndex = 120;
            this.lbDetalheCampos.Text = "Detalhe/Campos:";
            // 
            // txtChaveDescricao
            // 
            this.txtChaveDescricao.BackColor = System.Drawing.Color.White;
            this.txtChaveDescricao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChaveDescricao.LimpaCampo = true;
            this.txtChaveDescricao.Location = new System.Drawing.Point(73, 64);
            this.txtChaveDescricao.Name = "txtChaveDescricao";
            this.txtChaveDescricao.Size = new System.Drawing.Size(514, 21);
            this.txtChaveDescricao.TabIndex = 0;
            this.txtChaveDescricao.TipoCampo = System.Windows.Forms.Guard.TextBoxGuard.CTipoCampo.Normal;
            this.txtChaveDescricao.TipoValor = System.Windows.Forms.Guard.TextBoxGuard.CTipoValor.Geral;
            this.txtChaveDescricao.TextChanged += new System.EventHandler(this.txtChaveDescricao_TextChanged);
            this.txtChaveDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChaveDescricao_KeyDown);
            this.txtChaveDescricao.Validating += new System.ComponentModel.CancelEventHandler(this.txtChaveDescricao_Validating);
            // 
            // lbExemplo
            // 
            this.lbExemplo.AutoSize = true;
            this.lbExemplo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExemplo.ForeColor = System.Drawing.Color.CadetBlue;
            this.lbExemplo.Location = new System.Drawing.Point(70, 86);
            this.lbExemplo.Name = "lbExemplo";
            this.lbExemplo.Size = new System.Drawing.Size(63, 13);
            this.lbExemplo.TabIndex = 122;
            this.lbExemplo.Text = "Exemplo";
            // 
            // labelGuard2
            // 
            this.labelGuard2.AutoSize = true;
            this.labelGuard2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuard2.Location = new System.Drawing.Point(16, 85);
            this.labelGuard2.Name = "labelGuard2";
            this.labelGuard2.Size = new System.Drawing.Size(0, 13);
            this.labelGuard2.TabIndex = 121;
            // 
            // frmAuditoriaFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(598, 465);
            this.Controls.Add(this.lbExemplo);
            this.Controls.Add(this.labelGuard2);
            this.Controls.Add(this.txtChaveDescricao);
            this.Controls.Add(this.lbDetalheCampos);
            this.Controls.Add(this.dgvLogDetalhe);
            this.Controls.Add(this.dgvLog);
            this.Controls.Add(this.lbTabelaDescricao);
            this.Controls.Add(this.lbChave);
            this.Controls.Add(this.lbTabela);
            this.Controls.Add(this.pnTitulo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAuditoriaFormulario";
            this.Text = "Auditoria de Alterações";
            this.Load += new System.EventHandler(this.frm_auditoria_formulario_Load);
            this.pnTitulo.ResumeLayout(false);
            this.pnTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogDetalhe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnTitulo;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Guard.LabelGuard lbTabela;
        private System.Windows.Forms.Guard.LabelGuard lbChave;
        private System.Windows.Forms.Guard.LabelGuard lbTabelaDescricao;
        private System.Windows.Forms.Guard.DataGridViewGuard dgvLog;
        private System.Windows.Forms.Guard.DataGridViewGuard dgvLogDetalhe;
        private System.Windows.Forms.Guard.LabelGuard lbDetalheCampos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeAcao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetalhe;
        private System.Windows.Forms.Guard.TextBoxGuard txtChaveDescricao;
        private System.Windows.Forms.Guard.LabelGuard lbExemplo;
        private System.Windows.Forms.Guard.LabelGuard labelGuard2;
    }
}