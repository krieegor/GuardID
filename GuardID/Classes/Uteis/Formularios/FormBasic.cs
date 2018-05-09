using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Classes.Autenticacoes;
using Classes.Conexoes;

namespace System.Uteis
{
	public partial class FormBasic : Form
	{
        private bool _IsFormularioPrincipal;
        private string _MsgTitulo;
        private string _MsgSubTitulo;
        private string _MsgDuvidas;
        private string _MsgEquipe;
        private string _MsgGerencia;

        public FormBasic()
        {
            InitializeComponent();
            this.MdiChildActivate += new EventHandler(FormBasic_MdiChildActivate);
            this.Resize += new EventHandler(FormBasic_Resize);
            this.ResizeEnd += new EventHandler(FormBasic_Resize);
        }

        /// <summary>
        /// Construtor com bloqueio para múltiplas instâncias do formulário
        /// </summary>
        /// <param name="frmP">Formulário MDI principal do projeto.</param>
        public FormBasic(Form frmP)
        {
            this.MdiParent = frmP;
            InitializeComponent();
        }

        //Esse override impede que uma tecla ou combinação de teclas seja executada
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //No caso, o ctrl+tab será impedido dentro do formulario principal para que não haja 
            //risco de um childform ser jogado para trás do FormFundoPrincipal
            if (this._IsFormularioPrincipal && (keyData == (Keys.Control | Keys.Tab)))
            {
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        void FormBasic_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is FormFundoPrincipal)
            {
                this.ActiveMdiChild.SendToBack();
            }
        }
        void FormBasic_Resize(object sender, EventArgs e)
        {
            if (!this._IsFormularioPrincipal && this.MdiParent != null)
            {
                FormWindowState f = ((FormBasic)sender).WindowState;
                FormFundoPrincipal principal = null;
                if (f == FormWindowState.Minimized)
                {
                    foreach (Form item in this.MdiParent.MdiChildren)
                    {
                        if (item is FormFundoPrincipal)
                        {
                            principal = (FormFundoPrincipal)item;
                        }
                        else
                        {
                            item.BringToFront();
                        }
                    }
                    if (principal != null)
                        principal.SendToBack();
                }
            }
        }

        public void ConfigurarFundoFormularioPrincipal(string titulo, string subTitulo, string duvidas, string equipe, string gerencia)
        {
            this._MsgTitulo = titulo;
            this._MsgSubTitulo = subTitulo;
            this._MsgGerencia = gerencia;

            /*Caso o código do sistema estiver preenchido na classe Global
              busca os dados da equipe no banco de dados
            */
            if (Globals.Sistema > 0)
            {
                DataTable dtb = RetornaDadosEquipes(Globals.Sistema);

                if (dtb.Rows.Count > 0)
                {
                    this._MsgEquipe = dtb.Rows[0][0].ToString();
                    this._MsgDuvidas = "Dúvidas/Solicitações: " + dtb.Rows[0][2].ToString();

                    if (!string.IsNullOrEmpty(dtb.Rows[0][2].ToString()) && !string.IsNullOrEmpty(dtb.Rows[0][1].ToString()))
                        this._MsgDuvidas += " - ramal ";

                    if (!string.IsNullOrEmpty(dtb.Rows[0][1].ToString()))
                        this._MsgDuvidas += dtb.Rows[0][1].ToString();
                }
                else
                {
                    this._MsgDuvidas = duvidas;
                    this._MsgEquipe = equipe;
                }

                dtb = null;
            }
            else
            {

                this._MsgDuvidas = duvidas;
                this._MsgEquipe = equipe;
            }

            this._IsFormularioPrincipal = true;
        }

        private DataTable RetornaDadosEquipes(int sistema)
        {
            DataTable dtb = new DataTable();

            if (Globals.Sistema != 0)
            {
                if (Globals.Usuario != 0)
                {
                    try
                    {
                        //Busca o nome da equipe e ramal para preencher o label do fundo

                        StringBuilder sql = new StringBuilder();


                        sql.Append(@"");

                        Conexao dal = new Conexao(Globals.GetStringConnection(), 2);

                        dtb = dal.ExecuteQuery(sql.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dtb;
        }

        private void ExibirFundoFormularioPrincipal()
        {
            if (this._IsFormularioPrincipal)
            {
                FormFundoPrincipal frmFundo = new FormFundoPrincipal();
                frmFundo.MdiParent = this;
                frmFundo.MsgTitulo = this._MsgTitulo;
                frmFundo.MsgSubTitulo = this._MsgSubTitulo;
                frmFundo.MsgDuvidas = this._MsgDuvidas;
                frmFundo.MsgEquipe = this._MsgEquipe;
                frmFundo.MsgGerencia = this._MsgGerencia;
                frmFundo.Dock = DockStyle.Fill;
                frmFundo.Show();
            }
        }

        /// <summary>
        /// Método para retornar a instância aberta do formulário dentro dos formulários MDIChildren existentes
        /// </summary>
        /// <returns>Instância aberta do formulário chamado</returns>
        /// <remarks>Deve ser utilizado com formulários MDI. Retorna NULL caso o MDIParent não tenha sido definido</remarks>
        public Form GetInstancia()
        {
            if (this.MdiParent != null)
            {
                object tipoForm = this.GetType();
                IEnumerable<Form> resultado = this.MdiParent.MdiChildren.Where(c => c.GetType() == tipoForm);

                if (resultado.Count() > 1)
                {
                    if (WaitWindow.IsShowing)
                        WaitWindow.End();
                    resultado.First().WindowState = FormWindowState.Normal;
                    this.Dispose();
                }

                return resultado.First();
            }
            else
            {
                return null;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private string _codigoSeguranca = string.Empty;
        /// <summary>
        /// Código de Segurança do Formulário
        /// </summary>
        public string CodigoSeguranca
        {
            get { return _codigoSeguranca; }
            set { _codigoSeguranca = value; }
        }

        private Seguranca _segurancaForm = new Seguranca();
        /// <summary>
        /// Atributos da Segurança do Formulário
        /// </summary>
        public Seguranca SegurancaForm
        {
            get { return _segurancaForm; }
            set { _segurancaForm = value; }
        }

        public enum CAcaoFormulario { Nenhum, Novo, Gravar, Editar, Voltar, Excluir, Buscar, Imprimir, Auditar, Ajudar };
        private CAcaoFormulario _acaoFormulario = CAcaoFormulario.Nenhum;
        public CAcaoFormulario AcaoFormulario
        {
            get { return _acaoFormulario; }
            set { _acaoFormulario = value; }
        }

        private void FormBasic_Load(object sender, EventArgs e)
        {
            ExibirFundoFormularioPrincipal();

            ///Executa Automaticamente
            if (!string.IsNullOrEmpty(Globals.Login))
            {
                if (!string.IsNullOrEmpty(this.CodigoSeguranca))
                {
                    int usuario = Globals.Usuario;
                    string programa = this.CodigoSeguranca;

                    List<Seguranca> permissao = (from p in Globals.listaSeguranca
                                                 where p.Usuario == usuario && p.Programa == programa
                                                 select p).ToList();

                    if (permissao.Count <= 0)
                    {
                        MessageBox.Show("Você não tem permissão para acessar esta tela. \nSolicite seu acesso.", "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //Quanto é MDI não pode fechar o formulario direto
                        this.BeginInvoke(new MethodInvoker(FechaFormulario));
                    }
                    else
                    {
                        SegurancaForm = permissao.First();
                        if (!SegurancaForm.Ativo)
                        {
                            MessageBox.Show("Este formulário esta desativado!", "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //Quanto é MDI não pode fechar o formulario direto
                            this.BeginInvoke(new MethodInvoker(FechaFormulario));
                        }
                        else if (!SegurancaForm.Visualizar)
                        {
                            MessageBox.Show("Você não tem permissão para acessar esta tela. \nSolicite seu acesso.", "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //Quanto é MDI não pode fechar o formulario direto
                            this.BeginInvoke(new MethodInvoker(FechaFormulario));
                        }
                    }
                }
                else
                {
                    Seguranca seg = new Seguranca();
                    seg.Programa = "";
                    seg.Usuario = Globals.Usuario;
                    seg.Qualquer = true;
                    seg.Visualizar = true;
                    seg.Incluir = true;
                    seg.Alterar = true;
                    seg.Excluir = true;
                    SegurancaForm = seg;
                }
            }

            PreencherMensagensToolTips();
            AbrirTelasAutomaticamente();

            this.DelegateEnterFocusMaskedTextBoxGuard(this);
            this.DelegateEnterFocusMaskedTextBoxDataGuard(this);
        }

        public void AbrirFormularioOutroSistema(int codigoSistema, string nomeProjeto, string nomeFormulario, string parametros = "")
        {
            Classes.Conexoes.Conexao dal = new Classes.Conexoes.Conexao(Globals.GetStringConnection(), 2);
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
           ");
            DataTable dtSistema = dal.ExecuteQuery(sql.ToString());

            if (dtSistema.Rows.Count > 0)
            {
                string caminho = dtSistema.Rows[0][0].ToString();

                sql.Clear();
                sql.Append(@"");
                DataTable dt = dal.ExecuteQuery(sql.ToString());

                sql.Clear();
                sql.Append(@"
               ");
                dt = ExecutarSQL(sql.ToString());
                if (dt.Rows.Count == 0)
                {
                    sql.Clear();
                    sql.Append(@"");
                    dal.ExecuteNonQuery(sql.ToString());
                }

                System.Diagnostics.Process.Start(caminho);
            }
        }
        private void AbrirTelasAutomaticamente()
        {
            if (this.IsMdiContainer && Globals.Conexao != null)
            {
                //MessageBox.Show("if (this.IsMdiContainer && Globals.Conexao != null && Globals.Conexao.Equals(ACAD_TESTE))");
                try
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(@"");
                    DataTable dt = ExecutarSQL(sql.ToString());

                    if (dt.Rows.Count > 0)
                    {
                        //MessageBox.Show("dt.Rows.Count > 0");

                        this.Visible = false;

                        foreach (DataRow item in dt.Rows)
                        {
                            string projectName = item["projeto"].ToString();
                            string formName = item["formulario"].ToString();
                            List<string> propriedades = new List<string>();
                            List<string> valores = new List<string>();

                            if (!item["parametros"].ToString().Trim().Equals(""))
                            {
                                string[] parametros = item["parametros"].ToString().Split(new Char[] { ';' });

                                for (int i = 0; i < parametros.Length; i++)
                                {
                                    if (i % 2 == 0)
                                        propriedades.Add(parametros[i]);
                                    else
                                        valores.Add(parametros[i]);
                                }
                            }
                            //MessageBox.Show(propriedades.Count + "\n" + valores.Count);
                            #region Carregar Assembly
                            System.Reflection.Assembly assembly;
                            try
                            {
                                //Tenta carregar o projeto informado
                                assembly = System.Reflection.Assembly.Load(projectName);
                            }
                            catch (Exception)
                            {
                                //Caso não consiga, carrega o projeto atual
                                assembly = System.Reflection.Assembly.GetExecutingAssembly();
                            }
                            Type[] types = assembly.GetTypes();
                            #endregion

                            #region Encontrar e abrir o formulário
                            foreach (Type type in types)
                            {
                                if (!type.FullName.Equals(this.GetType().FullName))
                                {
                                    try
                                    {
                                        switch (type.BaseType.FullName)
                                        {
                                            case "System.Uteis.FormBasic":
                                                FormBasic frmGuard = (FormBasic)Activator.CreateInstance(type);
                                                if (frmGuard.Name.Equals(formName))
                                                {
                                                    PreencherPropriedades(frmGuard, propriedades, valores);
                                                    frmGuard.ShowDialog();
                                                }
                                                break;
                                            case "System.Uteis.FormCadastro":
                                                FormCadastro frmCadastro = (FormCadastro)Activator.CreateInstance(type);
                                                if (frmCadastro.Name.Equals(formName))
                                                {
                                                    PreencherPropriedades(frmCadastro, propriedades, valores);
                                                    frmCadastro.ShowDialog();
                                                }
                                                break;                                           
                                            case "System.Uteis.FormBusca":
                                                FormBusca frmBusca = (FormBusca)Activator.CreateInstance(type);
                                                if (frmBusca.Name.Equals(formName))
                                                {
                                                    PreencherPropriedades(frmBusca, propriedades, valores);
                                                    frmBusca.ShowDialog();
                                                }
                                                break;
                                            case "System.Uteis.FormConsulta":
                                                FormConsulta frmConsulta = (FormConsulta)Activator.CreateInstance(type);
                                                if (frmConsulta.Name.Equals(formName))
                                                {
                                                    PreencherPropriedades(frmConsulta, propriedades, valores);
                                                    frmConsulta.ShowDialog();
                                                }
                                                break;
                                            case "System.Uteis.FormAssistenteCadastro":
                                                FormAssistenteCadastro frmAssistenteCadastro = (FormAssistenteCadastro)Activator.CreateInstance(type);
                                                if (frmAssistenteCadastro.Name.Equals(formName))
                                                {
                                                    PreencherPropriedades(frmAssistenteCadastro, propriedades, valores);
                                                    frmAssistenteCadastro.ShowDialog();
                                                }
                                                break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        //os erros de formulários com construtores que possuem parâmetros cairão aqui e serão ignorados
                                    }
                                }
                            }
                            #endregion

                            sql.Clear();
                            sql.Append(@"");
                            new Classes.Conexoes.Conexao(Globals.GetStringConnection(), 2).ExecuteNonQuery(sql.ToString());
                        }

                        Environment.Exit(-1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message + "\nPor favor, entre em contato com a DTI", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                }
            }
        }
        private void PreencherPropriedades(FormBasic frm, List<string> propriedades, List<string> valores)
        {
            try
            {
                for (int i = 0; i < propriedades.Count; i++)
                {
                    frm.SetValorPropriedade(frm, propriedades[i], valores[i]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro durante a passagem de parâmetros para o formulário solicitado. Por favor, entre em contato com a DTI.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        //Seleciona todo o texto de um controle.
        private void SelectMaskedTextBoxGuard_Enter(object sender, System.EventArgs e)
        {
            // Executa o método de forma assíncrona - pois o MaskedTextBox já executa um
            // select no evento "Enter" do foco, que acaba desfazendo a seleção.
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (sender is UpDownBase)
                {
                    ((UpDownBase)sender).Select(0, ((UpDownBase)sender).Text.Length);
                }
                else if (sender is MaskedTextBoxGuard)
                {
                    ((MaskedTextBoxGuard)sender).SelectAll();
                }
            });
        }

        //Seleciona todo o texto de um controle.
        private void SelectMaskedTextBoxDataGuard_Enter(object sender, System.EventArgs e)
        {
            // Executa o método de forma assíncrona - pois o MaskedTextBox já executa um
            // select no evento "Enter" do foco, que acaba desfazendo a seleção.
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (sender is UpDownBase)
                {
                    ((UpDownBase)sender).Select(0, ((UpDownBase)sender).Text.Length);
                }
                else if (sender is MaskedTextBoxDataGuard)
                {
                    ((MaskedTextBoxDataGuard)sender).SelectAll();
                }
            });
        }

        //Associa o evento "SelectText_Enter" a cada um dos campos com texto
        private void DelegateEnterFocusMaskedTextBoxGuard(Control ctrl)
        {
            if ((ctrl is UpDownBase) || (ctrl is MaskedTextBoxGuard))
            {
                ctrl.Enter += SelectMaskedTextBoxGuard_Enter;
                return;
            }

            // Chamada recursiva para associar o evento a todos os controles da interface
            foreach (Control ctrlChild in ctrl.Controls)
            {
                this.DelegateEnterFocusMaskedTextBoxGuard(ctrlChild);
            }
        }

        //Associa o evento "SelectText_Enter" a cada um dos campos com texto
        private void DelegateEnterFocusMaskedTextBoxDataGuard(Control ctrl)
        {
            if ((ctrl is UpDownBase) || (ctrl is MaskedTextBoxDataGuard))
            {
                ctrl.Enter += SelectMaskedTextBoxDataGuard_Enter;
                return;
            }

            // Chamada recursiva para associar o evento a todos os controles da interface
            foreach (Control ctrlChild in ctrl.Controls)
            {
                this.DelegateEnterFocusMaskedTextBoxDataGuard(ctrlChild);
            }
        }

        //Quanto é MDI não pode fechar o formulario direto
        private void FechaFormulario()
        {
            this.Close();
        }


        protected void LimpaCampos(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                LimpaCampos(ctrl);
                LimpaCampos(ctrl.Controls);
            }
        }
        protected void LimpaCamposNaoChave(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (!EChave(ctrl))
                    LimpaCampos(ctrl);
                LimpaCamposNaoChave(ctrl.Controls);
            }
        }
        protected void LimpaCamposBloqueiaAutoIncremento(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (EAutoIncremento(ctrl))
                    BloqueiaCampo(ctrl);
                else
                    LiberaCampo(ctrl);
                LimpaCampos(ctrl);
                LimpaCamposBloqueiaAutoIncremento(ctrl.Controls);
            }
        }
        protected void LiberaChaveBloqueiaCampos(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (EChave(ctrl))
                    LiberaCampo(ctrl);
                else
                {
                    BloqueiaCampo(ctrl);
                }
                LiberaChaveBloqueiaCampos(ctrl.Controls);
            }
        }
        protected bool ValidaCamposObrigatorios(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (EObrigatorio(ctrl) && ENullOuVazio(ctrl))
                    return false;
                if (!ValidaCamposObrigatorios(ctrl.Controls))
                    return false;
            }
            return true;
        }
        protected void BloqueiaChaves(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (EChave(ctrl))
                    BloqueiaCampo(ctrl);
                BloqueiaChaves(ctrl.Controls);
            }
        }
        protected void BloqueiaChaveLiberaCampos(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                if (EChave(ctrl))
                    BloqueiaCampo(ctrl);
                else
                    LiberaCampo(ctrl);
                BloqueiaChaveLiberaCampos(ctrl.Controls);
            }
        }
        protected void LimpaCampos(Control pControle)
        {
            if (pControle is TextBoxGuard)
            {
                if (((TextBoxGuard)(pControle)).LimpaCampo)
                    ((TextBoxGuard)(pControle)).Clear();
                return;
            }
            if (pControle is MaskedTextBoxGuard)
            {
                if (((MaskedTextBoxGuard)(pControle)).LimpaCampo)
                    ((MaskedTextBoxGuard)(pControle)).Clear();
                return;
            }
            if (pControle is MaskedTextBoxDataGuard)
            {
                if (((MaskedTextBoxDataGuard)(pControle)).LimpaCampo)
                    ((MaskedTextBoxDataGuard)(pControle)).Clear();
                return;
            }
            if (pControle is RadioButtonGuard)
            {
                if (((RadioButtonGuard)(pControle)).LimpaCampo)
                    ((RadioButtonGuard)(pControle)).Checked = false;
                return;
            }
            if (pControle is DataGridViewGuard)
            {
                if (((DataGridViewGuard)(pControle)).LimpaCampo)
                {
                    DataTable dt = new DataTable();
                    if (((DataGridViewGuard)(pControle)).DataSource != null)
                    {
                        if (((DataGridViewGuard)(pControle)).DataSource.GetType() == typeof(BindingSource))
                        {
                            BindingSource bs = new BindingSource();
                            dt = (DataTable)((BindingSource)((DataGridViewGuard)(pControle)).DataSource).DataSource;
                            if (dt != null)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    dt.Clear();
                                    bs.DataSource = dt;
                                    ((DataGridViewGuard)(pControle)).DataSource = bs;
                                }
                            }
                        }
                        else
                        {
                            dt = (DataTable)((DataGridViewGuard)(pControle)).DataSource;
                            if (dt != null)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    dt.Clear();
                                    ((DataGridViewGuard)(pControle)).DataSource = dt;
                                }
                            }
                        }
                    }
                }
                return;
            }
            if (pControle is CheckBoxGuard)
            {
                if (((CheckBoxGuard)(pControle)).LimpaCampo)
                    ((CheckBoxGuard)(pControle)).Checked = false;
                return;
            }
            if (pControle is ComboBoxGuard)
            {
                if (((ComboBoxGuard)(pControle)).LimpaCampo)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)((ComboBoxGuard)(pControle)).DataSource;
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            dt.Clear();
                            ((ComboBoxGuard)(pControle)).DataSource = dt;
                        }
                    }
                    else
                    {
                        ((ComboBoxGuard)(pControle)).DataSource = null;
                        ((ComboBoxGuard)(pControle)).Items.Clear();
                    }
                    ((ComboBoxGuard)(pControle)).Text = string.Empty;
                }
                return;
            }
            if (pControle is DateTimePickerGuard)
            {
                if (((DateTimePickerGuard)(pControle)).LimpaCampo)
                    ((DateTimePickerGuard)(pControle)).Value = DateTime.Now;
                return;
            }
            if (pControle is ListBoxGuard)
            {
                if (((ListBoxGuard)(pControle)).LimpaCampo)
                {
                    ((ListBoxGuard)(pControle)).DataSource = null;
                    ((ListBoxGuard)(pControle)).Items.Clear();
                }
                return;
            }           
            if (pControle.HasChildren)
                LimpaCampos(pControle.Controls);
        }
        protected void BloqueiaCampo(Control pControle)
        {
            if (pControle is TextBoxGuard)
            {
                ((TextBoxGuard)(pControle)).Enabled = false;
                return;
            }
            if (pControle is MaskedTextBoxGuard)
            {
                ((MaskedTextBoxGuard)(pControle)).Enabled = false;
                return;
            }
            if (pControle is MaskedTextBoxDataGuard)
            {
                ((MaskedTextBoxDataGuard)(pControle)).Enabled = false;
                return;
            }
            if (pControle is CheckBoxGuard)
            {
                ((CheckBoxGuard)(pControle)).Enabled = false;
                return;
            }
            if (pControle is ComboBoxGuard)
            {
                ((ComboBoxGuard)(pControle)).Enabled = false;
                return;
            }
            if (pControle is DateTimePickerGuard)
            {
                ((DateTimePickerGuard)(pControle)).Enabled = false;
                return;
            }
            if (pControle is ListBoxGuard)
            {
                ((ListBoxGuard)(pControle)).Enabled = false;
                return;
            }
            if (pControle is GroupBoxGuard)
            {
                ((GroupBoxGuard)(pControle)).Enabled = false;
                return;
            }
            if (pControle is RadioButtonGuard)
            {
                ((RadioButtonGuard)(pControle)).Enabled = false;
                return;
            }
        }
        protected void LiberaCampo(Control pControle)
        {
            if (pControle is TextBoxGuard)
            {
                ((TextBoxGuard)(pControle)).Enabled = true;
                return;
            }
            if (pControle is MaskedTextBoxGuard)
            {
                ((MaskedTextBoxGuard)(pControle)).Enabled = true;
                return;
            }
            if (pControle is MaskedTextBoxDataGuard)
            {
                ((MaskedTextBoxDataGuard)(pControle)).Enabled = true;
                return;
            }
            if (pControle is DataGridViewGuard)
            {
                ((DataGridViewGuard)(pControle)).Enabled = true;
                return;
            }
            if (pControle is CheckBoxGuard)
            {
                ((CheckBoxGuard)(pControle)).Enabled = true;
                return;
            }
            if (pControle is ComboBoxGuard)
            {
                ((ComboBoxGuard)(pControle)).Enabled = true;
                return;
            }
            if (pControle is DateTimePickerGuard)
            {
                ((DateTimePickerGuard)(pControle)).Enabled = true;
                return;
            }
            if (pControle is ListBoxGuard)
            {
                ((ListBoxGuard)(pControle)).Enabled = true;
                return;
            }
            if (pControle is GroupBoxGuard)
            {
                ((GroupBoxGuard)(pControle)).Enabled = true;
                return;
            }
            if (pControle is RadioButtonGuard)
            {
                ((RadioButtonGuard)(pControle)).Enabled = true;
                return;
            }
        }

        protected bool EAutoIncremento(Control pControle)
        {
            if (pControle is TextBoxGuard)
            {
                if (((TextBoxGuard)(pControle)).TipoCampo == TextBoxGuard.CTipoCampo.ChaveAutoIncremento)
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxGuard)
            {
                if (((MaskedTextBoxGuard)(pControle)).TipoCampo == MaskedTextBoxGuard.CTipoCampo.ChaveAutoIncremento)
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxDataGuard)
            {
                if (((MaskedTextBoxDataGuard)(pControle)).TipoCampo == MaskedTextBoxDataGuard.CTipoCampo.ChaveAutoIncremento)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        protected bool EChave(Control pControle)
        {
            if (pControle is TextBoxGuard)
            {
                if (((TextBoxGuard)(pControle)).TipoCampo == TextBoxGuard.CTipoCampo.ChaveAutoIncremento || ((TextBoxGuard)(pControle)).TipoCampo == TextBoxGuard.CTipoCampo.Chave)
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxGuard)
            {
                if (((MaskedTextBoxGuard)(pControle)).TipoCampo == MaskedTextBoxGuard.CTipoCampo.ChaveAutoIncremento || ((MaskedTextBoxGuard)(pControle)).TipoCampo == MaskedTextBoxGuard.CTipoCampo.Chave)
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxDataGuard)
            {
                if (((MaskedTextBoxDataGuard)(pControle)).TipoCampo == MaskedTextBoxDataGuard.CTipoCampo.ChaveAutoIncremento || ((MaskedTextBoxDataGuard)(pControle)).TipoCampo == MaskedTextBoxDataGuard.CTipoCampo.Chave)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        protected bool EObrigatorio(Control pControle)
        {
            if (pControle is TextBoxGuard)
            {
                if (AcaoFormulario == CAcaoFormulario.Novo)
                {
                    if (((TextBoxGuard)(pControle)).TipoCampo == TextBoxGuard.CTipoCampo.Chave || ((TextBoxGuard)(pControle)).TipoCampo == TextBoxGuard.CTipoCampo.Obrigatorio)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (((TextBoxGuard)(pControle)).TipoCampo != TextBoxGuard.CTipoCampo.Normal)
                        return true;
                    else
                        return false;
                }
            }
            if (pControle is MaskedTextBoxGuard)
            {
                if (AcaoFormulario == CAcaoFormulario.Novo)
                {
                    if (((MaskedTextBoxGuard)(pControle)).TipoCampo == MaskedTextBoxGuard.CTipoCampo.Chave || ((MaskedTextBoxGuard)(pControle)).TipoCampo == MaskedTextBoxGuard.CTipoCampo.Obrigatorio)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (((MaskedTextBoxGuard)(pControle)).TipoCampo != MaskedTextBoxGuard.CTipoCampo.Normal)
                        return true;
                    else
                        return false;
                }
            }
            if (pControle is MaskedTextBoxDataGuard)
            {
                if (AcaoFormulario == CAcaoFormulario.Novo)
                {
                    if (((MaskedTextBoxDataGuard)(pControle)).TipoCampo == MaskedTextBoxDataGuard.CTipoCampo.Chave || ((MaskedTextBoxDataGuard)(pControle)).TipoCampo == MaskedTextBoxDataGuard.CTipoCampo.Obrigatorio)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (((MaskedTextBoxDataGuard)(pControle)).TipoCampo != MaskedTextBoxDataGuard.CTipoCampo.Normal)
                        return true;
                    else
                        return false;
                }
            }
            else
                return false;
        }
        protected bool ENullOuVazio(Control pControle)
        {
            if (pControle is TextBoxGuard)
            {
                if (string.IsNullOrEmpty(((TextBoxGuard)pControle).Text.ToString()))
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxGuard)
            {
                if (!((MaskedTextBoxGuard)pControle).MaskFull)
                    return true;
                else
                    return false;
            }
            if (pControle is MaskedTextBoxDataGuard)
            {
                if ((string.IsNullOrEmpty(((MaskedTextBoxDataGuard)pControle).Text.ToString())) || (!((MaskedTextBoxDataGuard)pControle).MaskFull))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static string nomePrograma;

        public static void MensagemSistema(string nomePrograma_)
        {
            nomePrograma = nomePrograma_;
        }

        private const string WMCLOSE = "WmClose";

        public static bool FecharFormulario()
        {
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
            foreach (System.Diagnostics.StackFrame sf in stackTrace.GetFrames())
            {
                if (sf.GetMethod().Name == WMCLOSE)
                {
                    return true;
                }
            }
            return false;
        }

        public static void RegistroNaoEncontrado(TextBoxGuard txt)
        {
            if (FecharFormulario() == true)
                return;

            MessageBox.Show("Registro não encontrado", "Validação registro não encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt.Text = "";
            txt.Focus();
        }
        public static void RegistroNaoEncontrado(MaskedTextBoxGuard txt)
        {
            if (FecharFormulario() == true)
                return;

            MessageBox.Show("Registro não encontrado", "Validação registro não encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt.Text = "";
            txt.Focus();
        }

        public static bool MensagemCampoVazio(MaskedTextBoxGuard txt, string mensagem)
        {
            if (FecharFormulario() == true)
                return false;

            if (txt.MaskFull == false)
            {
                MessageBox.Show(mensagem, "Validação campo vazio.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt.Focus();
                return false;
            }
            return true;
        }
        public static bool MensagemCampoVazio(MaskedTextBoxDataGuard txt, string mensagem)
        {
            if (FecharFormulario() == true)
                return false;

            if (txt.MaskFull == false)
            {
                MessageBox.Show(mensagem, "Validação campo vazio.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt.Focus();
                return false;
            }
            return true;
        }
        public static bool MensagemCampoVazio(TextBoxGuard txt, string mensagem)
        {
            if (FecharFormulario() == true)
                return false;

            if (string.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show(mensagem, "Validação campo vazio.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método para exibir uma mensagem que desaparece automaticamente na tela.
        /// Essa mensagem começa a desaparecer em 2 segundos, ficando gradativamente mais transparente, ate desaparecer por completo.
        /// Durante o processo de desaparecimento, caso o usuário passe o mouse por cima da mensagem, o processo é cancelado e retomado quando o cursor do mouse sai da mensagem.
        /// </summary>
        /// <param name="msg">Mensagem a ser exibida</param>
        /// <param name="icone">Imagem que será exibida ao lado da mensagem. A classe SystemIcons possui diversas opções. </param>
        /// <param name="backColor">Cor de fundo da tela da mensagem</param>
        /// <param name="foreColor">Cor do texto da mensagem</param>
        /// <param name="fonteMensagem">Fonte a ser aplicada no texto da mensagem</param>
        protected void Mensagem(string msg, Icon icone = null, Color? backColor = null, Color? foreColor = null, Font fonteMensagem = null)
        {
            FormMensagem f = new FormMensagem(msg);
            f.icone = icone;
            f.backColor = backColor;
            f.foreColor = foreColor;
            f.FonteMensagem = fonteMensagem;
            f.Show();
        }

        static List<Control> txts = new List<Control>();
        private void BuscarTextBoxs(Control.ControlCollection pControles)
        {
            foreach (Control ctrl in pControles)
            {
                BuscarTextBoxs(ctrl);
                BuscarTextBoxs(ctrl.Controls);
            }
        }
        private void BuscarTextBoxs(Control pControle)
        {
            if (pControle is TextBoxGuard)
            {
                if (((TextBoxGuard)pControle).InformacaoToolTipCaminho != null &&
                    !string.IsNullOrEmpty(((TextBoxGuard)pControle).InformacaoToolTipCaminho.Trim()) //&&
                    //((TextBoxGuard)pControle).InformacaoToolTipDescricao != null &&
                    //!string.IsNullOrEmpty(((TextBoxGuard)pControle).InformacaoToolTipDescricao.Trim())
                    )
                {
                    txts.Add(pControle);
                }
            }
        }
        public void PreencherMensagensToolTips()
        {
            BuscarTextBoxs(this.Controls);

            foreach (Control item in txts)
            {
                string[] campos = ((TextBoxGuard)item).InformacaoToolTipCaminho.Split('.');

                StringBuilder sql = new StringBuilder();
                sql.Append(@"");

                Classes.Conexoes.Conexao dal = new Classes.Conexoes.Conexao(Globals.GetStringConnection(), 2);
                DataTable dtDados = dal.ExecuteQuery(sql.ToString());

                ((TextBoxGuard)item).InformacaoToolTipDescricao = dtDados.Rows[0][0].ToString();
            }
        }

        private static int CompareTabIndex(Control c1, Control c2)
        {
            return c1.TabIndex.CompareTo(c2.TabIndex);
        }

        /// <summary>
        /// Método para preencher automaticamente os campos do formulário. Serão preenchidos todos os campos que 
        /// possuírem a propriedade NomeCampoDadosDataTable informada. Essa propriedade deve conter o respectivo 
        /// nome da coluna na DataTable,
        /// </summary>
        public void PreencherCampos(Control.ControlCollection controls, DataTable dtDados)
        {
            if (dtDados.Rows.Count > 0)
            {
                List<Control> list = new List<Control>();
                foreach (Control item in controls)
                {
                    list.Add(item);
                }
                list.Sort(new Comparison<Control>(CompareTabIndex));

                foreach (Control ctrl in list)
                {
                    try
                    {
                        //TextBox
                        if (ctrl is TextBoxGuard && !string.IsNullOrEmpty(((TextBoxGuard)ctrl).NomeCampoDadosDataTable))
                        {
                            ((TextBoxGuard)ctrl).Text = dtDados.Rows[0][((TextBoxGuard)ctrl).NomeCampoDadosDataTable].ToString();
                        }

                        //NumericUpDown
                        if (ctrl is NumericUpDownGuard && !string.IsNullOrEmpty(((NumericUpDownGuard)ctrl).NomeCampoDadosDataTable))
                        {
                            ((NumericUpDownGuard)ctrl).Value = Decimal.Parse(dtDados.Rows[0][((NumericUpDownGuard)ctrl).NomeCampoDadosDataTable].ToString());
                        }

                        //MaskedTextBox
                        if (ctrl is MaskedTextBoxGuard && !string.IsNullOrEmpty(((MaskedTextBoxGuard)ctrl).NomeCampoDadosDataTable))
                        {
                            ((MaskedTextBoxGuard)ctrl).Text = dtDados.Rows[0][((MaskedTextBoxGuard)ctrl).NomeCampoDadosDataTable].ToString();
                        }

                        //DateTimePicker
                        if (ctrl is DateTimePickerGuard && !string.IsNullOrEmpty(((DateTimePickerGuard)ctrl).NomeCampoDadosDataTable))
                        {
                            ((DateTimePickerGuard)ctrl).Text = dtDados.Rows[0][((DateTimePickerGuard)ctrl).NomeCampoDadosDataTable].ToString();
                        }

                        //TextBoxData
                        if (ctrl is MaskedTextBoxDataGuard && !string.IsNullOrEmpty(((MaskedTextBoxDataGuard)ctrl).NomeCampoDadosDataTable))
                        {
                            ((MaskedTextBoxDataGuard)ctrl).Text = dtDados.Rows[0][((MaskedTextBoxDataGuard)ctrl).NomeCampoDadosDataTable.ToString()].ToString();
                        }

                        //CheckBox
                        if (ctrl is CheckBoxGuard && !string.IsNullOrEmpty(((CheckBoxGuard)ctrl).NomeCampoDadosDataTable))
                        {
                            ((CheckBoxGuard)ctrl).Checked = (dtDados.Rows[0][((CheckBoxGuard)ctrl).NomeCampoDadosDataTable.ToString()].ToString().Trim().Equals("1") ? true : false);
                        }

                        //TextBoxTelefone
                        if (ctrl is MaskedTextBoxFoneGuard && !string.IsNullOrEmpty(((MaskedTextBoxFoneGuard)ctrl).NomeCampoDadosDataTable))
                        {
                            ((MaskedTextBoxFoneGuard)ctrl).Text = dtDados.Rows[0][((MaskedTextBoxFoneGuard)ctrl).NomeCampoDadosDataTable.ToString()].ToString();
                        }

                        //ComboBox
                        if (ctrl is ComboBoxGuard && !string.IsNullOrEmpty(((ComboBoxGuard)ctrl).NomeCampoDadosDataTable))
                        {
                            ((ComboBoxGuard)ctrl).SelectedItem = dtDados.Rows[0][((ComboBoxGuard)ctrl).NomeCampoDadosDataTable.ToString()].ToString();
                        }

                        //RadioButton
                        if (ctrl is RadioButtonGuard)
                        {
                            ((RadioButtonGuard)ctrl).Checked = (dtDados.Rows[0][((RadioButtonGuard)ctrl).NomeCampoDadosDataTable.ToString()].ToString().Equals(((RadioButtonGuard)ctrl).ValorNomeCampoDadosDataTable.ToString()) ? true : false);
                        }
                    }
                    catch (Exception)
                    {
                    }

                    //Se for um Container, executa a função novamente, passando os controles que existem dentro do container
                    if (ctrl.HasChildren)
                    {
                        PreencherCampos(ctrl.Controls, dtDados);
                    }
                }
            }
        }

        public DataTable ExecutarSQL(string sql)
        {
            DataTable dtRetorno = new DataTable();

            Classes.Conexoes.Conexao dal = new Classes.Conexoes.Conexao(Globals.GetStringConnection(), 2);
            dtRetorno = dal.ExecuteQuery(sql.ToString());

            return dtRetorno;
        }

        public List<System.Reflection.PropertyInfo> GetPropriedades()
        {
            Type myType = this.GetType();
            IList<System.Reflection.PropertyInfo> props = new List<System.Reflection.PropertyInfo>(myType.GetProperties());

            List<System.Reflection.PropertyInfo> propriedades = new List<System.Reflection.PropertyInfo>();

            foreach (System.Reflection.PropertyInfo prop in props)
            {
                //object propValue = prop.GetValue(base.frmBaseCadastroPadrao, null);
                if (prop.DeclaringType == myType)
                {
                    propriedades.Add(prop);

                }
            }

            return propriedades;
        }
        public System.Reflection.PropertyInfo GetPropriedades(string nomeDaPropriedade)
        {
            List<System.Reflection.PropertyInfo> props = GetPropriedades();

            System.Reflection.PropertyInfo p = null;

            foreach (System.Reflection.PropertyInfo item in props)
            {
                if (item.Name.ToLower().Equals(nomeDaPropriedade.ToLower()))
                {
                    p = item;
                    break;
                }
            }

            return p;
        }
        public void SetValorPropriedade(FormBasic frm, string nomeDaPropriedade, object valor)
        {
            System.Reflection.PropertyInfo prop = GetPropriedades(nomeDaPropriedade);

            prop.SetValue(frm, valor, null);
        }
        public object GetValorPropriedade(FormBasic frm, string nomeDaPropriedade)
        {
            System.Reflection.PropertyInfo prop = GetPropriedades(nomeDaPropriedade);

            object valor = prop.GetValue(frm, null);

            return valor;
        }

        private void FormBasic_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Linha abaixo é para não deixar o formulário maximizado caso o usuário feche pelo X
            //Principal problema detectado foi nos relatórios que tem o estado maximizado quando 
            //em modo de visualização de impressao
            this.WindowState = FormWindowState.Normal;
        }

        public enum _TipoPermissaoCodigoSeguranca { Visualizar, Incluir, Excluir, Alterar, ApenasVisualizar };
        public bool UsrTemPermissao(_TipoPermissaoCodigoSeguranca tipo)
        {
            return UsrTemPermissao(tipo, this.CodigoSeguranca);
        }
        public bool UsrTemPermissao(_TipoPermissaoCodigoSeguranca tipo, string codigoSeguranca)
        {
            if (codigoSeguranca.Trim().Equals(""))
            {
                return true;
            }
            else
            {

                string sql = @"";

                DataTable dt = ExecutarSQL(sql);

                bool retorno = false;
                if (tipo == _TipoPermissaoCodigoSeguranca.Visualizar)
                    retorno = dt.Rows[0]["visualizar"].ToString().Equals("1");
                else if (tipo == _TipoPermissaoCodigoSeguranca.Incluir)
                    retorno = dt.Rows[0]["incluir"].ToString().Equals("1");
                else if (tipo == _TipoPermissaoCodigoSeguranca.Excluir)
                    retorno = dt.Rows[0]["excluir"].ToString().Equals("1");
                else if (tipo == _TipoPermissaoCodigoSeguranca.Alterar)
                    retorno = dt.Rows[0]["alterar"].ToString().Equals("1");
                else if (tipo == _TipoPermissaoCodigoSeguranca.ApenasVisualizar)
                    retorno = (dt.Rows[0]["visualizar"].ToString().Equals("1") &&
                               dt.Rows[0]["incluir"].ToString().Equals("0") &&
                               dt.Rows[0]["excluir"].ToString().Equals("0") &&
                               dt.Rows[0]["alterar"].ToString().Equals("0"));

                return retorno;
            }
        }


        //Utilizar Filtros Anteriores
        private string informacoesArquivoTxt { get; set; }
        public bool comandoExecutado = false;
        public bool atribuirFiltros = false;
        public void atribuirFiltrosAnteriores()//Relatorio
        {
            atribuirFiltros = true;
            InserirLinhasArquivoCampos();
        }
        public void atribuirFiltrosAnteriores(int pSistema, int pComando, string pFiltro)//Extrator
        {
            atribuirFiltros = true;
            InserirLinhasArquivoCampos(pSistema, pComando, pFiltro);
        }
        public void CriarAlterarArquivoRelatorioFiltrosAnteriores(int pTipo) //Relatorio
        {
            //CRIANDO PASTA SE NAO EXISTIR
            string folder = @"C:\Temp\";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //{} = INICIO E FIM DO RELATORIO
            //() = VALORES DE CADA CAMPO


            FileInfo arquivo = new FileInfo(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
            string informacaoAntiga = "";

            //VERIFICANDO SE O ARQUIVO EXISTE
            if (arquivo.Exists)
            {
                informacoesArquivoTxt += "\n{@#Inicio Relatorio: " + this.ProductName + "." + this.Name;
                informacoesArquivoTxt += System.Environment.NewLine;

                System.IO.StreamReader lerArquivo = new System.IO.StreamReader(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
                string linhaTxt = "";

                PercorrerObjetos(this.Controls, pTipo);
                informacoesArquivoTxt += "Fim Relatorio: " + this.ProductName + "." + this.Name + "#@}" + System.Environment.NewLine;
                while ((linhaTxt = lerArquivo.ReadLine()) != null)
                {
                    if (linhaTxt.Contains("{@#Inicio Relatorio: " + this.ProductName + "." + this.Name))
                    {
                        while (!(linhaTxt = lerArquivo.ReadLine()).Contains("Fim Relatorio: " + this.ProductName + "." + this.Name + "#@}")) { }
                    }
                    else
                    {
                        if (linhaTxt.Length > 0)
                        {
                            if (linhaTxt.Contains("{@#Inicio Relatorio: "))
                            {
                                informacaoAntiga += linhaTxt;
                            }
                            else if (linhaTxt.Contains("Fim Relatorio: ") && linhaTxt.Substring(linhaTxt.Length - 3).Equals("#@}"))
                            {
                                informacaoAntiga += System.Environment.NewLine + linhaTxt + System.Environment.NewLine + System.Environment.NewLine;
                            }
                            else
                            {
                                informacaoAntiga += System.Environment.NewLine + linhaTxt;
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(informacaoAntiga))
                    informacaoAntiga += informacoesArquivoTxt;
                else
                    informacaoAntiga = informacoesArquivoTxt;

                lerArquivo.Dispose();

                System.IO.File.WriteAllText(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt", informacaoAntiga);
                informacoesArquivoTxt = "";
            }
            else
            {
                arquivo.Create().Close();
                CriarAlterarArquivoRelatorioFiltrosAnteriores(pTipo);
            }

        }
        public void CriarAlterarArquivoRelatorioFiltrosAnteriores(int pSistema, int pComando, string pFiltro, int pTipo) //Extrator
        {
            StringBuilder sql = new StringBuilder();

            PercorrerObjetos(this.Controls, pTipo);
            string informacao = informacoesArquivoTxt.Replace("'", "''").Replace("\r\n", "'||chr(13)||'");
            //informacao = "'" + informacao.Substring(0, informacao.Length - 3).Replace("'N'", "''N''").Replace("'S'", "''S''");
            informacao = "'" + informacao.Substring(0, informacao.Length - 3);

            sql.Append(@"");
            informacoesArquivoTxt = "";
            ExecutarSQL(sql.ToString());
        }
        public void CriarAlterarArquivoRelatorioFiltrosAnteriores(int pTipo, Control.ControlCollection controls) //Outros
        {
            //CRIANDO PASTA SE NAO EXISTIR
            string folder = @"C:\Temp\";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //{} = INICIO E FIM DO RELATORIO
            //() = VALORES DE CADA CAMPO


            FileInfo arquivo = new FileInfo(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
            string informacaoAntiga = "";

            //VERIFICANDO SE O ARQUIVO EXISTE
            if (arquivo.Exists)
            {
                informacoesArquivoTxt += "\n{@#Inicio Relatorio: " + this.ProductName + "." + this.Name;
                informacoesArquivoTxt += System.Environment.NewLine;

                System.IO.StreamReader lerArquivo = new System.IO.StreamReader(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
                string linhaTxt = "";

                PercorrerObjetos(controls, pTipo);
                informacoesArquivoTxt += "Fim Relatorio: " + this.ProductName + "." + this.Name + "#@}" + System.Environment.NewLine;
                while ((linhaTxt = lerArquivo.ReadLine()) != null)
                {
                    if (linhaTxt.Contains("{@#Inicio Relatorio: " + this.ProductName + "." + this.Name))
                    {
                        while (!(linhaTxt = lerArquivo.ReadLine()).Contains("Fim Relatorio: " + this.ProductName + "." + this.Name + "#@}")) { }
                    }
                    else
                    {
                        if (linhaTxt.Length > 0)
                        {
                            if (linhaTxt.Contains("{@#Inicio Relatorio: "))
                            {
                                informacaoAntiga += linhaTxt;
                            }
                            else if (linhaTxt.Contains("Fim Relatorio: ") && linhaTxt.Substring(linhaTxt.Length - 3).Equals("#@}"))
                            {
                                informacaoAntiga += System.Environment.NewLine + linhaTxt + System.Environment.NewLine + System.Environment.NewLine;
                            }
                            else
                            {
                                informacaoAntiga += System.Environment.NewLine + linhaTxt;
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(informacaoAntiga))
                    informacaoAntiga += informacoesArquivoTxt;
                else
                    informacaoAntiga = informacoesArquivoTxt;

                lerArquivo.Dispose();

                System.IO.File.WriteAllText(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt", informacaoAntiga);
                informacoesArquivoTxt = "";
            }
            else
            {
                arquivo.Create().Close();
                CriarAlterarArquivoRelatorioFiltrosAnteriores(pTipo);
            }

        }
        private void InserirLinhasArquivoCampos()//Relatorio
        {
            //CRIANDO PASTA SE NAO EXISTIR
            string folder = @"C:\Temp\";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }


            FileInfo arquivoAntigo = new FileInfo(@"C:\Temp\RelatorioUltimosFiltros.txt");
            if (arquivoAntigo.Exists)
            {
                arquivoAntigo.Delete();
            }

            FileInfo arquivo = new FileInfo(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
            if (arquivo.Exists)
            {
                System.IO.StreamReader lerArquivo = new System.IO.StreamReader(@"C:\Temp\RelatorioUltimosFiltrosVer2.txt");
                string linhaTxt = "";

                while ((linhaTxt = lerArquivo.ReadLine()) != null)
                {
                    if (linhaTxt.Equals("{@#Inicio Relatorio: " + this.ProductName + "." + this.Name))
                    {
                        while (!(linhaTxt = lerArquivo.ReadLine()).Equals("Fim Relatorio: " + this.ProductName + "." + this.Name + "#@}"))
                        {
                            PercorrerObjetosLinha(this.Controls, linhaTxt);
                        }
                    }
                }
                lerArquivo.Dispose();
            }
        }
        private void InserirLinhasArquivoCampos(int pSistema, int pComando, string pFiltro)//Extrator
        {
            string folder = @"C:/TEMP";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            StringBuilder sql = new StringBuilder();
            sql.Append(@"");
            sql.Append(!string.IsNullOrEmpty(pFiltro.ToString()) ? " AND EDUF.FILTRO = " + pFiltro : "");
            DataTable dt = ExecutarSQL(sql.ToString());
            string valorArquivoTemporario = "";

            if (dt.Rows.Count == 0)
            {
                return;
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!valorArquivoTemporario.Contains(dt.Rows[i]["DETALHES"].ToString()))
                        valorArquivoTemporario += dt.Rows[i]["DETALHES"].ToString() + System.Environment.NewLine;
                }

            }

            if (new FileInfo(@"C:/Temp/filtrosAnterioresTemporario.txt").Exists)
                System.IO.File.Delete(@"C:/Temp/filtrosAnterioresTemporario.txt");

            System.IO.File.WriteAllText(@"C:/Temp/filtrosAnterioresTemporario.txt", valorArquivoTemporario);

            System.IO.StreamReader lerArquivo = new System.IO.StreamReader(@"C:/Temp/filtrosAnterioresTemporario.txt");
            string linhaTxt = "";
            string linhaAnterior = "";
            try
            {
                while ((linhaTxt = lerArquivo.ReadLine()) != null)
                {
                    if (!linhaTxt.Equals(linhaAnterior))
                    {
                        PercorrerObjetosLinha(this.Controls, linhaTxt);
                    }
                    linhaAnterior = linhaTxt;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Motivo: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lerArquivo.Dispose();
        }

        private void PercorrerObjetos(Control.ControlCollection pControles, int pTipo)//PERCORRE OS COMPONENTES DA TELA E DEPOIS PEGA OS VALORES E ALTERA O TXT
        {
            foreach (Control ctrl in pControles)
            {
                InserirInformacoesVariavel(ctrl, pTipo);
                PercorrerObjetos(ctrl.Controls, pTipo);
            }
        }
        private void InserirInformacoesVariavel(Control pControle, int pTipo)//pTipo = 1 - Relatorio; 2 - Extrator;  INSERI O VALOR NA VARIAVEL USADA NO TXT
        {
            string teste = pControle.Name;
            if (pControle is TextBoxGuard && pTipo != 2)// && !camposArquivoTxt.Contains(pControle.Name + " (" + pControle.Text + ")"))
            {
                if (!string.IsNullOrEmpty(pControle.Text))
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + pControle.Text + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is MaskedTextBoxGuard)// && !camposArquivoTxt.Contains(pControle.Name + " (" + pControle.Text + ")"))
            {
                if (!string.IsNullOrEmpty(pControle.Text.Replace("/", "").Trim()))
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + pControle.Text + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is MaskedTextBoxDataGuard)// && !camposArquivoTxt.Contains(pControle.Name + " (" + pControle.Text + ")"))
            {
                if (!string.IsNullOrEmpty(pControle.Text.Replace("/", "").Trim()))
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + pControle.Text + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is RadioButtonGuard)// && !camposArquivoTxt.Contains(pControle.Name + " (" + ((RadioButtonGuard)(pControle)).Checked + ")"))
            {
                if (((RadioButtonGuard)(pControle)).Checked)
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + ((RadioButtonGuard)(pControle)).Checked + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is DataGridViewGuard)
            {
                DataTable dt = new DataTable();
                if (((DataGridViewGuard)(pControle)).DataSource != null)
                {
                    if (((DataGridViewGuard)(pControle)).DataSource.GetType() == typeof(BindingSource))
                    {
                        BindingSource bs = new BindingSource();
                        dt = (DataTable)((BindingSource)((DataGridViewGuard)(pControle)).DataSource).DataSource;
                    }
                    else
                    {
                        dt = (DataTable)((DataGridViewGuard)(pControle)).DataSource;
                    }

                    if (dt.Rows.Count > 0)
                    {
                        string aux;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            aux = "";
                            //NOME GRID {INDICDE DA COLUNA} ([COLUNA1][COLUNA2][COLUNAN])
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                aux += "{@#" + dt.Columns[j].ToString() + "#@}[@#" + dt.Rows[i][j].ToString() + "#@]";
                            }
                            informacoesArquivoTxt += pControle.Name + " (@#" + aux + "#@)" + System.Environment.NewLine;
                        }
                    }
                }
                return;
            }
            if (pControle is CheckBoxGuard)// && !camposArquivoTxt.Contains(pControle.Name + " (" + ((CheckBoxGuard)(pControle)).Checked + ")"))
            {
                informacoesArquivoTxt += pControle.Name + " (@#" + ((CheckBoxGuard)(pControle)).Checked + "#@)";
                informacoesArquivoTxt += System.Environment.NewLine;

                //if (((CheckBoxGuard)(pControle)).Checked)
                //{
                //    informacoesArquivoTxt += pControle.Name + " (@#" + ((CheckBoxGuard)(pControle)).Checked + "#@)";
                //    informacoesArquivoTxt += System.Environment.NewLine;
                //}
                return;
            }
            if (pControle is ComboBoxGuard)// && !camposArquivoTxt.Contains(pControle.Name + " (" + ((ComboBoxGuard)(pControle)).SelectedIndex + ")"))
            {
                if (((ComboBoxGuard)(pControle)).SelectedIndex != -1)
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + ((ComboBoxGuard)(pControle)).SelectedIndex + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is DateTimePickerGuard)// && !camposArquivoTxt.Contains(pControle.Name + " (" + pControle.Text + ")"))
            {
                if (!string.IsNullOrEmpty(pControle.Text) && (!((DateTimePickerGuard)(pControle)).CustomFormat.Equals("__/__/____")))
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + pControle.Text + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
                return;
            }
            if (pControle is NumericUpDownGuard)
            {
                if (!string.IsNullOrEmpty(((NumericUpDownGuard)pControle).Value.ToString()))
                {
                    informacoesArquivoTxt += pControle.Name + " (@#" + ((NumericUpDownGuard)pControle).Value.ToString() + "#@)";
                    informacoesArquivoTxt += System.Environment.NewLine;
                }
            }

        }
        private void PercorrerObjetosLinha(Control.ControlCollection pControle, string pLinhaTxt)//PERCORRE OS COMPONENTES DA TELA E DEPOIS INSERI OS VALORES
        {
            foreach (Control ctrl in pControle)
            {
                PercorrerObjetosInserindoValores(ctrl, pLinhaTxt);
                PercorrerObjetosLinha(ctrl.Controls, pLinhaTxt);
            }
        }
        private void PercorrerObjetosInserindoValores(Control pControle, string pLinhaTxt)//PERCORRE O TXT E INSERI OS VALORES NOS CAMPOS DA TELA
        {
            if (!(pLinhaTxt.Equals("{@#Inicio Relatorio: " + this.Name) && pLinhaTxt.Equals("Fim Relatorio: " + this.Name + "#@}")) && !string.IsNullOrEmpty(pLinhaTxt))
            {
                string teste = pControle.Name;
                string nomeObject = pLinhaTxt.Substring(0, pLinhaTxt.IndexOf(" "));
                string valorObject = pLinhaTxt.Substring(pLinhaTxt.IndexOf("(@#") + 3, pLinhaTxt.IndexOf("#@)") - pLinhaTxt.IndexOf("(@#") - 3);

                if (pControle is TextBoxGuard)
                {
                    if (((TextBoxGuard)(pControle)).Name.Equals(nomeObject))
                    {
                        ((TextBoxGuard)(pControle)).Text = valorObject;
                    }
                    return;
                }
                if (pControle is MaskedTextBoxGuard)
                {
                    if (((MaskedTextBoxGuard)(pControle)).Name.Equals(nomeObject))
                    {
                        ((MaskedTextBoxGuard)(pControle)).Text = valorObject;
                    }
                    return;
                }
                if (pControle is MaskedTextBoxDataGuard)
                {
                    if (((MaskedTextBoxDataGuard)(pControle)).Name.Equals(nomeObject))
                    {
                        ((MaskedTextBoxDataGuard)(pControle)).Text = valorObject;
                    }
                    return;
                }
                if (pControle is RadioButtonGuard)
                {
                    if (((RadioButtonGuard)(pControle)).Name.Equals(nomeObject))
                    {
                        ((RadioButtonGuard)(pControle)).Checked = bool.Parse(valorObject);
                    }
                    return;
                }
                if (pControle is DataGridViewGuard)
                {
                    if (((DataGridViewGuard)(pControle)).Name.Equals(nomeObject))
                    {
                        DataTable dtGrid = (DataTable)((DataGridViewGuard)(pControle)).DataSource;
                        DataRow dtRow = null;

                        if (dtGrid != null)
                        {
                            dtRow = dtGrid.NewRow();
                            //Quantidade de Colunas
                            for (int i = 0; i < 99; i++)
                            {
                                string nomeColuna = dtGrid.Columns[i].ToString();
                                dtRow[nomeColuna] = pLinhaTxt.Substring(pLinhaTxt.IndexOf("[@#") + 3, pLinhaTxt.IndexOf("#@]") - pLinhaTxt.IndexOf("[@#") - 3);
                                pLinhaTxt = pLinhaTxt.Substring(pLinhaTxt.IndexOf("#@]") + 3);

                                if (pLinhaTxt.Equals("#@)"))
                                    break;
                            }
                        }
                        else
                        {
                            dtGrid = new DataTable();

                            string[] nomeColuna = new string[999];
                            string[] valorColuna = new string[999];
                            //Quantidade de Colunas
                            for (int i = 0; i < 99; i++)
                            {
                                nomeColuna[i] = pLinhaTxt.Substring(pLinhaTxt.IndexOf("{@#") + 3, pLinhaTxt.IndexOf("#@}") - pLinhaTxt.IndexOf("{@#") - 3);
                                dtGrid.Columns.Add(nomeColuna[i].ToString());
                                valorColuna[i] = pLinhaTxt.Substring(pLinhaTxt.IndexOf("[@#") + 3, pLinhaTxt.IndexOf("#@]") - pLinhaTxt.IndexOf("[@#") - 3);

                                pLinhaTxt = pLinhaTxt.Substring(pLinhaTxt.IndexOf("#@]") + 3);

                                if (pLinhaTxt.Equals("#@)"))
                                    break;
                            }

                            dtRow = dtGrid.NewRow();
                            for (int j = 0; valorColuna[j] != null; j++)
                            {
                                dtRow[nomeColuna[j]] = valorColuna[j];
                            }
                        }

                        dtGrid.Rows.Add(dtRow);
                        ((DataGridView)(pControle)).DataSource = dtGrid;

                    }
                    return;
                }
                if (pControle is CheckBoxGuard)
                {
                    if (((CheckBoxGuard)(pControle)).Name.Equals(nomeObject))
                    {
                        ((CheckBoxGuard)(pControle)).Checked = bool.Parse(valorObject);
                    }
                    return;
                }
                if (pControle is ComboBoxGuard)
                {
                    if (((ComboBoxGuard)(pControle)).Name.Equals(nomeObject))
                    {
                        if (((ComboBoxGuard)(pControle)).Items.Count > 0)
                        {
                            ((ComboBoxGuard)(pControle)).SelectedIndex = int.Parse(valorObject);
                        }
                    }
                    return;
                }
                if (pControle is DateTimePickerGuard)
                {
                    if (((DateTimePickerGuard)(pControle)).Name.Equals(nomeObject))
                    {
                        //if (valorObject != null && !valorObject.ToString().Equals(""))
                        //{
                        //    ((DateTimePickerGuard)(pControle)).Format = DateTimePickerFormat.Short;
                        //    ((DateTimePickerGuard)(pControle)).CustomFormat = "";
                        //    ((DateTimePickerGuard)(pControle)).Value = DateTime.Parse(valorObject.ToString());
                        //}
                        //else
                        //{
                        //    ((DateTimePickerGuard)(pControle)).Format = DateTimePickerFormat.Custom;
                        //    ((DateTimePickerGuard)(pControle)).CustomFormat = "__/__/____";
                        //}
                    }
                    return;
                }
                if (pControle is NumericUpDownGuard)
                {
                    if (((NumericUpDownGuard)(pControle)).Name.Equals(nomeObject))
                    {
                        ((NumericUpDownGuard)(pControle)).Value = int.Parse(valorObject);
                    }
                }
                //if (pControle is ListBoxGuard)
                //{
                //    if (((ListBoxGuard)(pControle)).LimpaCampo)
                //    {
                //        //((ListBoxGuard)(pControle)).DataSource = null;
                //        //((ListBoxGuard)(pControle)).Items.Clear();
                //        campostxt += pControle.Name + " (" + pControle.Text + ")";
                //        campostxt += System.Environment.NewLine;
                //    }
                //    return;
                //}
            }
        }
    }
}