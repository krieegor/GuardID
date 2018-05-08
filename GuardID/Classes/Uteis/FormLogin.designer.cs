﻿namespace System.Windows.Forms.Guard
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.txtSenha = new System.Windows.Forms.Guard.TextBoxGuard();
            this.txtUsuario = new System.Windows.Forms.Guard.TextBoxGuard();
            this.btFecharRed = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btFechar = new System.Windows.Forms.PictureBox();
            this.btEntrar = new System.Windows.Forms.PictureBox();
            this.btEntra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btFecharRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEntrar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSenha
            // 
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.LimpaCampo = true;
            this.txtSenha.Location = new System.Drawing.Point(371, 284);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(124, 22);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.TipoCampo = System.Windows.Forms.Guard.TextBoxGuard.CTipoCampo.Normal;
            this.txtSenha.TipoValor = System.Windows.Forms.Guard.TextBoxGuard.CTipoValor.Geral;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.LimpaCampo = true;
            this.txtUsuario.Location = new System.Drawing.Point(371, 251);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(124, 22);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.TipoCampo = System.Windows.Forms.Guard.TextBoxGuard.CTipoCampo.Normal;
            this.txtUsuario.TipoValor = System.Windows.Forms.Guard.TextBoxGuard.CTipoValor.Numerico;
            // 
            // btFecharRed
            // 
            this.btFecharRed.Image = ((System.Drawing.Image)(resources.GetObject("btFecharRed.Image")));
            this.btFecharRed.Location = new System.Drawing.Point(767, 1);
            this.btFecharRed.Name = "btFecharRed";
            this.btFecharRed.Size = new System.Drawing.Size(32, 16);
            this.btFecharRed.TabIndex = 14;
            this.btFecharRed.TabStop = false;
            this.btFecharRed.Visible = false;
            this.btFecharRed.MouseLeave += new System.EventHandler(this.btFecharRed_MouseLeave);
            this.btFecharRed.Click += new System.EventHandler(this.btFecharRed_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(375, 373);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 14);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(746, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(23, 16);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.Location = new System.Drawing.Point(767, 1);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(32, 16);
            this.btFechar.TabIndex = 11;
            this.btFechar.TabStop = false;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            this.btFechar.MouseEnter += new System.EventHandler(this.btFechar_MouseEnter);
            // 
            // btEntrar
            // 
            this.btEntrar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btEntrar.Image = ((System.Drawing.Image)(resources.GetObject("btEntrar.Image")));
            this.btEntrar.Location = new System.Drawing.Point(387, 323);
            this.btEntrar.Name = "btEntrar";
            this.btEntrar.Size = new System.Drawing.Size(85, 28);
            this.btEntrar.TabIndex = 10;
            this.btEntrar.TabStop = false;
            this.btEntrar.Click += new System.EventHandler(this.btEntrar_Click);
            // 
            // btEntra
            // 
            this.btEntra.Location = new System.Drawing.Point(387, 323);
            this.btEntra.Name = "btEntra";
            this.btEntra.Size = new System.Drawing.Size(75, 23);
            this.btEntra.TabIndex = 15;
            this.btEntra.Text = "Enter";
            this.btEntra.UseVisualStyleBackColor = true;
            this.btEntra.Click += new System.EventHandler(this.btEntra_Click);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btEntra;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.btEntrar);
            this.Controls.Add(this.btEntra);
            this.Controls.Add(this.btFecharRed);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btFecharRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btEntrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Guard.TextBoxGuard txtSenha;
        private System.Windows.Forms.Guard.TextBoxGuard txtUsuario;
        private System.Windows.Forms.PictureBox btEntrar;
        private System.Windows.Forms.PictureBox btFechar;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btFecharRed;
        private System.Windows.Forms.Button btEntra;
    }
}