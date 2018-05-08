using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Uteis
{
    public partial class frmOpcoes : Form
    {
        public string pTitulo { get; set; }
        public List<string> pBotoes { get; set; }
        public string retorno { get; set; }

        public frmOpcoes()
        {
            InitializeComponent();
            this.Text = pTitulo;
        }

        public void CriarControles()
        {
            int tamanho = panel1.Size.Width;
            Point location = new Point(5,5);
            //pBotoes.Add("Exit");
            for (int i = 0; i < pBotoes.Count(); i++)
            {
                
                Button b = new Button();
                b.Name = pBotoes[i];
                b.Text = b.Name ;
                b.BackColor = Color.FromArgb(195, 217, 241);
                b.ForeColor = Color.Black;
                b.FlatStyle = FlatStyle.Flat;
                b.AutoSize = true;   
                b.Tag = i;
                                       
                //b.FontFamily = new FontFamily("Verdana");

                b.Font = new Font(new FontFamily("Verdana"), 8.0F);                           

                b.Click += new EventHandler(b_Click);
                this.Controls.Add(b);
                b.BringToFront();

                location.X = (tamanho / 2) - (b.Width / 2);
                b.Location = location;
                location.Y += 30;
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Text.ToUpper() == "Exit".ToUpper())
                this.Close();

            retorno = b.Text;
            this.Close();
        }

#pragma warning disable CS0108 // "frmOpcoes.ShowDialog()" oculta o membro herdado "Form.ShowDialog()". Use a nova palavra-chave se foi pretendido ocultar.
        public DialogResult ShowDialog()
#pragma warning restore CS0108 // "frmOpcoes.ShowDialog()" oculta o membro herdado "Form.ShowDialog()". Use a nova palavra-chave se foi pretendido ocultar.
        {
            if (!this.IsDisposed)
            {
                return base.ShowDialog();
            }

            return DialogResult.Cancel;
        }
    }
}
