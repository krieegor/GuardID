﻿namespace System.Uteis
{
	partial class IntervaloCampos3
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
            this.lblTitulo = new System.Uteis.LabelGuard();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbInicial = new System.Uteis.LabelGuard();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtInicial = new System.Uteis.TextBoxGuard();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lbFinal = new System.Uteis.LabelGuard();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtFinal = new System.Uteis.TextBoxGuard();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(92, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "labelGuard1";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(134, 1);
            this.panel4.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lbInicial);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(49, 30);
            this.panel9.TabIndex = 1;
            // 
            // lbInicial
            // 
            this.lbInicial.AutoSize = true;
            this.lbInicial.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbInicial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInicial.Location = new System.Drawing.Point(0, 0);
            this.lbInicial.Name = "lbInicial";
            this.lbInicial.Size = new System.Drawing.Size(52, 13);
            this.lbInicial.TabIndex = 0;
            this.lbInicial.Text = "Inicial:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtInicial);
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 14);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(134, 30);
            this.panel5.TabIndex = 3;
            // 
            // txtInicial
            // 
            this.txtInicial.BackColor = System.Drawing.Color.White;
            this.txtInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInicial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicial.LimpaCampo = true;
            this.txtInicial.Location = new System.Drawing.Point(49, 0);
            this.txtInicial.Name = "txtInicial";
            this.txtInicial.Size = new System.Drawing.Size(79, 21);
            this.txtInicial.TabIndex = 2;
            this.txtInicial.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtInicial.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            this.txtInicial.Leave += new System.EventHandler(this.txtInicial_Leave);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(128, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(6, 30);
            this.panel7.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.lbFinal);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(49, 32);
            this.panel10.TabIndex = 1;
            // 
            // lbFinal
            // 
            this.lbFinal.AutoSize = true;
            this.lbFinal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFinal.Location = new System.Drawing.Point(6, 0);
            this.lbFinal.Name = "lbFinal";
            this.lbFinal.Size = new System.Drawing.Size(43, 13);
            this.lbFinal.TabIndex = 0;
            this.lbFinal.Text = "Final:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtFinal);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 59);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(134, 32);
            this.panel6.TabIndex = 4;
            // 
            // txtFinal
            // 
            this.txtFinal.BackColor = System.Drawing.Color.White;
            this.txtFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinal.LimpaCampo = true;
            this.txtFinal.Location = new System.Drawing.Point(49, 0);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(79, 21);
            this.txtFinal.TabIndex = 2;
            this.txtFinal.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtFinal.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(128, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(6, 32);
            this.panel8.TabIndex = 0;
            // 
            // IntervaloCampos3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblTitulo);
            this.Name = "IntervaloCampos3";
            this.Size = new System.Drawing.Size(134, 91);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private LabelGuard lblTitulo;
        private Panel panel4;
        private Panel panel9;
        private LabelGuard lbInicial;
        private Panel panel5;
        public TextBoxGuard txtInicial;
        private Panel panel7;
        private Panel panel10;
        private LabelGuard lbFinal;
        private Panel panel6;
        public TextBoxGuard txtFinal;
        private Panel panel8;
	}
}
