namespace IntervaloCampos
{
    partial class IntervaloCampos2
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
            this.panelGuard1 = new System.Uteis.PanelGuard(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelGuard2 = new System.Uteis.PanelGuard(this.components);
            this.chkTitulo = new System.Uteis.CheckBoxGuard(this.components);
            this.txtFinal = new System.Uteis.TextBoxGuard();
            this.labelGuard2 = new System.Uteis.LabelGuard();
            this.txtInicial = new System.Uteis.TextBoxGuard();
            this.labelGuard1 = new System.Uteis.LabelGuard();
            this.panelGuard1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGuard1
            // 
            this.panelGuard1.BackColor = System.Drawing.Color.GhostWhite;
            this.panelGuard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGuard1.Controls.Add(this.panel1);
            this.panelGuard1.Controls.Add(this.txtFinal);
            this.panelGuard1.Controls.Add(this.labelGuard2);
            this.panelGuard1.Controls.Add(this.txtInicial);
            this.panelGuard1.Controls.Add(this.labelGuard1);
            this.panelGuard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGuard1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelGuard1.Location = new System.Drawing.Point(0, 0);
            this.panelGuard1.Name = "panelGuard1";
            this.panelGuard1.Size = new System.Drawing.Size(182, 62);
            this.panelGuard1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.panelGuard2);
            this.panel1.Controls.Add(this.chkTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 20);
            this.panel1.TabIndex = 9;
            // 
            // panelGuard2
            // 
            this.panelGuard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGuard2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelGuard2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelGuard2.Location = new System.Drawing.Point(0, 19);
            this.panelGuard2.Name = "panelGuard2";
            this.panelGuard2.Size = new System.Drawing.Size(180, 1);
            this.panelGuard2.TabIndex = 11;
            // 
            // chkTitulo
            // 
            this.chkTitulo.AutoSize = true;
            this.chkTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTitulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTitulo.LimpaCampo = true;
            this.chkTitulo.Location = new System.Drawing.Point(0, 0);
            this.chkTitulo.Name = "chkTitulo";
            this.chkTitulo.Size = new System.Drawing.Size(180, 20);
            this.chkTitulo.TabIndex = 1;
            this.chkTitulo.Text = "Inter. Campos";
            this.chkTitulo.UseVisualStyleBackColor = true;
            this.chkTitulo.CheckedChanged += new System.EventHandler(this.chkTitulo_CheckedChanged);
            // 
            // txtFinal
            // 
            this.txtFinal.BackColor = System.Drawing.Color.White;
            this.txtFinal.Enabled = false;
            this.txtFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinal.LimpaCampo = true;
            this.txtFinal.Location = new System.Drawing.Point(107, 28);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(56, 21);
            this.txtFinal.TabIndex = 8;
            this.txtFinal.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtFinal.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            // 
            // labelGuard2
            // 
            this.labelGuard2.AutoSize = true;
            this.labelGuard2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuard2.Location = new System.Drawing.Point(88, 31);
            this.labelGuard2.Name = "labelGuard2";
            this.labelGuard2.Size = new System.Drawing.Size(15, 13);
            this.labelGuard2.TabIndex = 7;
            this.labelGuard2.Text = "a";
            // 
            // txtInicial
            // 
            this.txtInicial.BackColor = System.Drawing.Color.White;
            this.txtInicial.Enabled = false;
            this.txtInicial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicial.LimpaCampo = true;
            this.txtInicial.Location = new System.Drawing.Point(29, 28);
            this.txtInicial.Name = "txtInicial";
            this.txtInicial.Size = new System.Drawing.Size(56, 21);
            this.txtInicial.TabIndex = 6;
            this.txtInicial.TipoCampo = System.Uteis.TextBoxGuard.CTipoCampo.Normal;
            this.txtInicial.TipoValor = System.Uteis.TextBoxGuard.CTipoValor.Geral;
            this.txtInicial.TextChanged += new System.EventHandler(this.txtInicial_TextChanged);
            this.txtInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInicial_KeyDown);
            this.txtInicial.Leave += new System.EventHandler(this.txtInicial_Leave);
            // 
            // labelGuard1
            // 
            this.labelGuard1.AutoSize = true;
            this.labelGuard1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuard1.Location = new System.Drawing.Point(3, 31);
            this.labelGuard1.Name = "labelGuard1";
            this.labelGuard1.Size = new System.Drawing.Size(23, 13);
            this.labelGuard1.TabIndex = 5;
            this.labelGuard1.Text = "de";
            // 
            // IntervaloCampos2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelGuard1);
            this.Name = "IntervaloCampos2";
            this.Size = new System.Drawing.Size(182, 62);
            this.panelGuard1.ResumeLayout(false);
            this.panelGuard1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Uteis.PanelGuard panelGuard1;
        private System.Uteis.LabelGuard labelGuard2;
        private System.Uteis.LabelGuard labelGuard1;
        public System.Uteis.TextBoxGuard txtFinal;
        public System.Uteis.TextBoxGuard txtInicial;
        private System.Windows.Forms.Panel panel1;
        private System.Uteis.PanelGuard panelGuard2;
        public System.Uteis.CheckBoxGuard chkTitulo;
    }
}
