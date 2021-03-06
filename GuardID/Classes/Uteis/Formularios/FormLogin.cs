﻿using System.Windows.Forms;
using System.IO;
using Classes.Autenticacoes;

namespace System.Uteis
{
	public partial class FormLogin : FormBasic
    {
        public FormLogin()
        {
                InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtSenha.Text))
                MessageBox.Show("Usuário ou senha não preenchido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    string banco = string.Empty;
                    if (File.Exists(@"K:/cert_sis.omt"))
                    {
                        FormLoginDesenvolvedor fLoginDes = new FormLoginDesenvolvedor();
                        fLoginDes.ShowDialog();
                        banco = fLoginDes.Banco;
                    }
                    else
                        banco = "ACAD";


                    if (!Seguranca.BuscaAutenticacaoUsuario(int.Parse(txtUsuario.Text), txtSenha.Text, banco))
                    {
                        MessageBox.Show("Usuário ou Senha incorreto. ", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {                           
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao tentar conectar ao banco.\nMotivo:" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btFechar_MouseEnter(object sender, EventArgs e)
        {
            btFecharRed.Visible = true;
            btFecharRed.Focus();
        }

        private void btFecharRed_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btFecharRed_MouseLeave(object sender, EventArgs e)
        {
            btFecharRed.Visible = false;
        }

        private void btEntra_Click(object sender, EventArgs e)
        {
            btEntrar_Click(btEntra, e);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Autenticacao a = new Autenticacao();
            if (a.AutenticaTemporiaUsuario())
                this.Close();
        }
    }
}
