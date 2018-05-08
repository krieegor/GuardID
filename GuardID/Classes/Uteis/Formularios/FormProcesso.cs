using System.Windows.Forms;

namespace System.Uteis
{
	public partial class FormProcesso : FormBasic
    {
        public FormProcesso()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construtor com bloqueio para múltiplas instâncias do formulário
        /// </summary>
        /// <param name="frmP">Formulário principal do projeto.</param>
        public FormProcesso(Form frmP): base(frmP)
        {
            InitializeComponent();
        }

        protected void LiberaTelaPermissao()
        {
            if (string.IsNullOrEmpty(this.CodigoSeguranca))
                btnPermissao.Visible = false;
            else
                btnPermissao.Visible = true;
        }

        private void FormProcesso_Load(object sender, EventArgs e)
        {
            LiberaTelaPermissao();
        }

        private void btnPermissao_Click(object sender, EventArgs e)
        {
            frmManutencaoPermissoes frmMP = new frmManutencaoPermissoes();
            frmMP.UsuarioLogado = Globals.Usuario;
            frmMP.CodPrograma = this.CodigoSeguranca;
            frmMP.ShowDialog();
        }
    }
}
