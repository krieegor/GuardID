﻿namespace Componentes
{
    partial class IntervaloCampoData2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnIntervaloCampos = new System.Uteis.PanelGuard(this.components);
            this.txtDtFinal = new System.Uteis.MaskedTextBoxDataGuard(this.components);
            this.txtDtInicial = new System.Uteis.MaskedTextBoxDataGuard(this.components);
            this.lbFinal = new System.Uteis.LabelGuard();
            this.lbInicial = new System.Uteis.LabelGuard();
            this.pnTitulo = new System.Uteis.PanelGuard(this.components);
            this.chkTitulo = new System.Uteis.CheckBoxGuard(this.components);
            this.pnIntervaloCampos.SuspendLayout();
            this.pnTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnIntervaloCampos
            // 
            this.pnIntervaloCampos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnIntervaloCampos.Controls.Add(this.txtDtFinal);
            this.pnIntervaloCampos.Controls.Add(this.txtDtInicial);
            this.pnIntervaloCampos.Controls.Add(this.lbFinal);
            this.pnIntervaloCampos.Controls.Add(this.lbInicial);
            this.pnIntervaloCampos.Controls.Add(this.pnTitulo);
            this.pnIntervaloCampos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnIntervaloCampos.Location = new System.Drawing.Point(0, 0);
            this.pnIntervaloCampos.Margin = new System.Windows.Forms.Padding(0);
            this.pnIntervaloCampos.Name = "pnIntervaloCampos";
            this.pnIntervaloCampos.Size = new System.Drawing.Size(136, 93);
            this.pnIntervaloCampos.TabIndex = 1;
            // 
            // txtDtFinal
            // 
            this.txtDtFinal.BackColor = System.Drawing.Color.White;
            this.txtDtFinal.Enabled = false;
            this.txtDtFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtFinal.LimpaCampo = true;
            this.txtDtFinal.Location = new System.Drawing.Point(54, 58);
            this.txtDtFinal.Mask = "00/00/0000";
            this.txtDtFinal.Name = "txtDtFinal";
            this.txtDtFinal.Size = new System.Drawing.Size(75, 21);
            this.txtDtFinal.TabIndex = 6;
            this.txtDtFinal.TipoCampo = System.Uteis.MaskedTextBoxDataGuard.CTipoCampo.Normal;
            // 
            // txtDtInicial
            // 
            this.txtDtInicial.BackColor = System.Drawing.Color.White;
            this.txtDtInicial.Enabled = false;
            this.txtDtInicial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtInicial.LimpaCampo = true;
            this.txtDtInicial.Location = new System.Drawing.Point(54, 27);
            this.txtDtInicial.Mask = "00/00/0000";
            this.txtDtInicial.Name = "txtDtInicial";
            this.txtDtInicial.Size = new System.Drawing.Size(75, 21);
            this.txtDtInicial.TabIndex = 5;
            this.txtDtInicial.TipoCampo = System.Uteis.MaskedTextBoxDataGuard.CTipoCampo.Normal;
            this.txtDtInicial.Leave += new System.EventHandler(this.txtDtInicial_Leave);
            // 
            // lbFinal
            // 
            this.lbFinal.AutoSize = true;
            this.lbFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFinal.Location = new System.Drawing.Point(9, 61);
            this.lbFinal.Name = "lbFinal";
            this.lbFinal.Size = new System.Drawing.Size(43, 13);
            this.lbFinal.TabIndex = 4;
            this.lbFinal.Text = "Final:";
            // 
            // lbInicial
            // 
            this.lbInicial.AutoSize = true;
            this.lbInicial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInicial.Location = new System.Drawing.Point(0, 30);
            this.lbInicial.Name = "lbInicial";
            this.lbInicial.Size = new System.Drawing.Size(52, 13);
            this.lbInicial.TabIndex = 2;
            this.lbInicial.Text = "Inicial:";
            // 
            // pnTitulo
            // 
            this.pnTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTitulo.Controls.Add(this.chkTitulo);
            this.pnTitulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnTitulo.Location = new System.Drawing.Point(-1, -1);
            this.pnTitulo.Name = "pnTitulo";
            this.pnTitulo.Size = new System.Drawing.Size(153, 19);
            this.pnTitulo.TabIndex = 0;
            // 
            // chkTitulo
            // 
            this.chkTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(241)))));
            this.chkTitulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTitulo.LimpaCampo = true;
            this.chkTitulo.Location = new System.Drawing.Point(2, 0);
            this.chkTitulo.Margin = new System.Windows.Forms.Padding(0);
            this.chkTitulo.Name = "chkTitulo";
            this.chkTitulo.Size = new System.Drawing.Size(133, 19);
            this.chkTitulo.TabIndex = 0;
            this.chkTitulo.Text = "Inter. Campo Dt";
            this.chkTitulo.UseVisualStyleBackColor = false;
            this.chkTitulo.CheckedChanged += new System.EventHandler(this.chkTitulo_CheckedChanged);
            // 
            // IntervaloCampoData2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.pnIntervaloCampos);
            this.Name = "IntervaloCampoData2";
            this.Size = new System.Drawing.Size(136, 93);
            this.pnIntervaloCampos.ResumeLayout(false);
            this.pnIntervaloCampos.PerformLayout();
            this.pnTitulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Uteis.PanelGuard pnIntervaloCampos;
        private System.Uteis.LabelGuard lbFinal;
        private System.Uteis.LabelGuard lbInicial;
        private System.Uteis.PanelGuard pnTitulo;
        public System.Uteis.CheckBoxGuard chkTitulo;
        public System.Uteis.MaskedTextBoxDataGuard txtDtFinal;
        public System.Uteis.MaskedTextBoxDataGuard txtDtInicial;
    }
}
