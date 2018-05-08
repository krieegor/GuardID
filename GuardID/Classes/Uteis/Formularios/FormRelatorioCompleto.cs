﻿using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
#pragma warning disable CS0234 // O nome de tipo ou namespace "Reporting" não existe no namespace "Microsoft" (você está sem uma referência de assembly?)
#pragma warning restore CS0234 // O nome de tipo ou namespace "Reporting" não existe no namespace "Microsoft" (você está sem uma referência de assembly?)
using System.Diagnostics;
using System.IO;
using Classes.Autenticacoes;

namespace System.Uteis
{
	public partial class FormRelatorioCompleto : FormBasic
    {
        public FormRelatorioCompleto()
        {
            InitializeComponent();
            ChangeToolBar();
            _filtrosUtilizados = new List<string>();
        }

        /// <summary>
        /// Construtor com bloqueio para múltiplas instâncias do formulário
        /// </summary>
        /// <param name="frmP">Formulário principal do projeto.</param>
        public FormRelatorioCompleto(Form frmP)
            : base(frmP)
        {
            InitializeComponent();
            ChangeToolBar();
        }

        public enum CTipoFolha { A3, A4, A5, Carta, Oficio };
        private CTipoFolha _tipoFolha = CTipoFolha.A4;

        public CTipoFolha TipoFolha
        {
            get { return _tipoFolha; }
            set { _tipoFolha = value; }
        }

        public enum CTipoRelatorio { Retrato, Paisagem };
        private CTipoRelatorio _tipoRelatorio = CTipoRelatorio.Retrato;

        public CTipoRelatorio TipoRelatorio
        {
            get { return _tipoRelatorio; }
            set { _tipoRelatorio = value; }
        }

        #region Atalhos do teclado e setas direcionais
        /// <summary>
        /// Flag para impedir que esse relatório utilize os direcionais para mudança de página
        /// </summary>
        public bool _CancelarDirecionais = false;
        /// <summary>
        /// Flag para impedir que esse relatório utilize os atalhos
        /// </summary>
        public bool _CancelarAtalhos = false;
        /// <summary>
        /// Habilita os direcionais para mudança de páginas nesse relatório
        /// </summary>
        public bool _HabDirecionalIndividual = false;
        /// <summary>
        /// Habilita os atalhos apenas para esse relatório
        /// </summary>
        public bool _HabAtalhosIndividual = false;
        /// <summary>
        /// Lista de Keys permitidas para utilizar os direcionais para mudar páginas
        /// </summary>
        private List<Keys> _TDirecionais = new List<Keys>() { (Keys.Control | Keys.Right), (Keys.Control | Keys.Left), Keys.Right, Keys.Left };
        /// <summary>
        /// Lista de Keys permitidas para utilizar atalhos no relatório (imprimir, salvar, exportar, voltar)
        /// </summary>
        private List<Keys> _Atalhos = new List<Keys>() { (Keys.Control | Keys.P), (Keys.Control | Keys.E), (Keys.Control | Keys.S), (Keys.Control | Keys.B) };
        #endregion

        #region Declaração Varivaeis Globais

        protected bool PrintLayout = true;

        //int contPgRelatorio = 1; /*Variavel que server como contador de paginas*/
        //int pgBusca = 0; /*Receber valor TextBox que usuario digita e posiciona a pgina no valor digitado*/
        //int pgContTotal = 0; /*Receber a quantidade de paginas que o relatorio tem*/
        TabPage TabBuscaRelatorio;
        TabPage TabVisualizarRelatorio;
        //int numberOfPages = 0;
        bool valid = true;
        //int PgNavegacao = 1;

        //Thread threadContPaginaRel;
        #endregion

        //private void toolStripBtnProximo_Click(object sender, EventArgs e)
        //{
        //    ModoImpressao();
        //    try
        //    {
        //        rptGuard.CurrentPage = rptGuard.CurrentPage + 1;
        //        toolStriptxtPg.Text = rptGuard.CurrentPage.ToString();
        //        toolStripBtnAnterior.Enabled = true;
        //        toolStripBtnInicio.Enabled = true;
        //    }
        //    catch
        //    {
        //        toolStripBtnProximo.Enabled = false;
        //        toolStripBtnAnterior.Enabled = true;
        //        toolStripBtnInicio.Enabled = true;
        //        if (numberOfPages != 0)
        //        {
        //            toolStripButtonUltimo.Enabled = true;
        //        }
        //    }
        //}

        private void ModoImpressao()
        {
            if (PrintLayout == false)
            {
                rptGuard.SetDisplayMode(DisplayMode.PrintLayout);
                rptGuard.ZoomMode = ZoomMode.PageWidth;
                PrintLayout = true;
                //toolStripTxtPesquisa.Text = "";
                //EnabledOpcoesPesquisa(false);
            }
        }

        private void FormRelatorioCompleto_Load(object sender, EventArgs e)
        {
            LiberaTelaPermissao();
            toolStripBtnExcel.ToolTipText = "Modo Folha de Dados" + (((Globals._UtilizarAtalhosRel && !_CancelarAtalhos) || (_HabAtalhosIndividual && !_CancelarAtalhos)) ? " (Ctrl+E)" : "");
            toolStripBtnPDF.ToolTipText = "PDF" + (((Globals._UtilizarAtalhosRel && !_CancelarAtalhos) || (_HabAtalhosIndividual && !_CancelarAtalhos)) ? " (Ctrl+S)" : "");
            toolStripBtnImpressora.ToolTipText = "Imprimir" + (((Globals._UtilizarAtalhosRel && !_CancelarAtalhos) || (_HabAtalhosIndividual && !_CancelarAtalhos)) ? " (Ctrl+P)" : "");
            toolStripBtnVoltar.ToolTipText = "Voltar" + (((Globals._UtilizarAtalhosRel && !_CancelarAtalhos) || (_HabAtalhosIndividual && !_CancelarAtalhos)) ? " (Ctrl+B)" : "");
        }

        public void DesabilitarGuias()
        {
            /*Armazenando todas guia em variaveis globais, pois apos remover a guia perde sua referencia*/
            TabVisualizarRelatorio = tbpRelatorio;
            this.tbcRelGuard.TabPages.Remove(tbpRelatorio);
        }

        public void HabilitarPreviewRelatorio()
        {
            TabBuscaRelatorio = tbpBusca;
            this.tbcRelGuard.TabPages.Remove(tbpBusca);

            this.tbcRelGuard.TabPages.Add(tbpRelatorio);

            //toolStripOpcoes.Dock = DockStyle.Top;
            rptGuard.Dock = DockStyle.Fill;
        }

        public void HabilitarBuscaRelatorio()
        {
            TabVisualizarRelatorio = tbpRelatorio;
            this.tbcRelGuard.TabPages.Remove(tbpRelatorio);

            this.tbcRelGuard.TabPages.Add(tbpBusca);
        }

        //private void toolStripButtonUltimo_Click(object sender, EventArgs e)
        //{
        //    /*Posiciona o cursor na ultima pagina do relatorio*/
        //    ModoImpressao();
        //    if (numberOfPages != 0)
        //    {
        //        pgContTotal = numberOfPages;
        //        toolStripBtnProximo.Enabled = false;
        //        toolStripButtonUltimo.Enabled = false;
        //        PgNavegacao = pgContTotal;
        //        toolStriptxtPg.Text = pgContTotal.ToString();
        //        rptGuard.CurrentPage = pgContTotal;
        //        toolStripBtnAnterior.Enabled = true;
        //        toolStripBtnInicio.Enabled = true;
        //    }
        //}

        //private void toolStripBtnAnterior_Click(object sender, EventArgs e)
        //{
        //    ModoImpressao();
        //    try
        //    {
        //        rptGuard.CurrentPage = rptGuard.CurrentPage - 1;
        //        toolStriptxtPg.Text = rptGuard.CurrentPage.ToString();
        //        toolStripBtnProximo.Enabled = true;
        //        if (numberOfPages != 0)
        //        {
        //            toolStripButtonUltimo.Enabled = true;
        //        }
        //        if (rptGuard.CurrentPage == 1)
        //        {
        //            toolStripBtnAnterior.Enabled = false;
        //            toolStripBtnInicio.Enabled = false;
        //            toolStripBtnProximo.Enabled = true;
        //        }
        //    }
        //    catch
        //    {
        //        toolStripBtnAnterior.Enabled = false;
        //        toolStripBtnInicio.Enabled = false;
        //        toolStripBtnProximo.Enabled = true;
        //        if (numberOfPages != 0)
        //        {
        //            toolStripButtonUltimo.Enabled = true;
        //        }
        //    }
        //}

        //private void toolStripBtnInicio_Click(object sender, EventArgs e)
        //{
        //    /*Posiona o curso na primeira pagina do relatorio*/
        //    ModoImpressao();
        //    toolStripBtnAnterior.Enabled = false;
        //    toolStripBtnInicio.Enabled = false;
        //    toolStriptxtPg.Text = "1";
        //    rptGuard.CurrentPage = 1;
        //    PgNavegacao = 1;
        //    toolStripBtnProximo.Enabled = true;
        //    if (numberOfPages != 0)
        //    {
        //        toolStripButtonUltimo.Enabled = true;
        //    }
        //    if (rptGuard.CurrentPage == 1)
        //    {
        //        toolStripBtnAnterior.Enabled = false;
        //        toolStripBtnInicio.Enabled = false;
        //        toolStripBtnProximo.Enabled = true;
        //    }
        //}

        //private void toolStripBtnImagem_Click(object sender, EventArgs e)
        //{
        //    // Abre janela para usuÃ¡rio escolher o PDF

        //    SaveFileDialog vAbreArq = new SaveFileDialog();


        //    // Verifica se o usuÃ¡rio clicou em ok ou cancelar na janela de seleÃ§Ã£o da pasta

        //    vAbreArq.Filter = "JPG|*.jpg";
        //    String fileName = "";

        //    vAbreArq.Title = "Selecione o Arquivo";
        //    if (vAbreArq.ShowDialog() == DialogResult.OK)
        //    {
        //        // Caminho do arquivo
        //        fileName = vAbreArq.FileName;
        //    }

        //    if (fileName != "")
        //    {
        //        LocalReport report = rptGuard.LocalReport;
        //        ExportarReport(report, rptFormat.Image, fileName);
        //        Process.Start(fileName);
        //    }
        //}

        private void toolStripBtnPDF_Click(object sender, EventArgs e)
        {
            // Abre janela para usuario escolher onde salvar o PDF

            SaveFileDialog vAbreArq = new SaveFileDialog();

            // Definição do tipo de Arquivo

            vAbreArq.Filter = "PDF|*.pdf";
            String fileName = "";

            vAbreArq.Title = "Salvar como";
            if (vAbreArq.ShowDialog() == DialogResult.OK)
            {
                // Caminho do arquivo
                fileName = vAbreArq.FileName;
            }

            // Verfica se o valor que retorno e diferente de vazio 
            if (fileName != "")
            {
                /*Chamada da classe que exporta para PDF*/
                try
                {
                    WaitWindow.Begin("Gerando arquivo PDF. Por favor, aguarde.");
                    LocalReport report = rptGuard.LocalReport;
                    ExportarReport(report, rptFormat.PDF, fileName);
                    Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível gerar o PDF.\nMotivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    WaitWindow.End();
                }
            }
        }

        public enum rptFormat
        {
            Excel,
            PDF,
            Image,
        }

        private rptFormat _tipoExportacao;

        public rptFormat TipoExportacao
        {
            get { return _tipoExportacao; }
            set { _tipoExportacao = value; }
        }

#pragma warning disable CS0246 // O nome do tipo ou do namespace "LocalReport" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
        public void ExportarReport(LocalReport report, rptFormat rptFormat, string filePath)
#pragma warning restore CS0246 // O nome do tipo ou do namespace "LocalReport" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
        {
            Warning[] warnings = null;
            string[] streamids = null;
            string mimeType;
            string encoding;
            string extension;


            byte[] bytes = report.Render(rptFormat.ToString(), null, out mimeType, out encoding, out extension, out streamids, out warnings);

            switch (rptFormat)
            {
                case rptFormat.Excel:
                    filePath = Path.ChangeExtension(filePath, "xls");
                    break;
                case rptFormat.Image:
                    filePath = Path.ChangeExtension(filePath, "jpg");
                    break;
                case rptFormat.PDF:
                    filePath = Path.ChangeExtension(filePath, "pdf");
                    break;
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }

            bytes = null;
        }

        //private void toolStripBtnExcel_Click(object sender, EventArgs e)
        //{
        //    // Abre janela para usuario escolher onde salvar o PDF

        //    SaveFileDialog vAbreArq = new SaveFileDialog();

        //    // Definição do tipo de Arquivo

        //    vAbreArq.Filter = "XLS|*.xls";
        //    String fileName = "";

        //    vAbreArq.Title = "Salvar como";
        //    if (vAbreArq.ShowDialog() == DialogResult.OK)
        //    {
        //        // Caminho do arquivo
        //        fileName = vAbreArq.FileName;
        //    }

        //    // Verfica se o valor que retorno e diferente de vazio 
        //    if (fileName != "")
        //    {
        //        /*Chamada da classe que exporta para Excel*/

        //        LocalReport report = rptGuard.LocalReport;
        //        ExportarReport(report, rptFormat.Excel, fileName);
        //        Process.Start(fileName);
        //    }
        //}

        private void toolStripBtnImpressora_Click(object sender, EventArgs e)
        {
            /*Comando aciona o PrintDialog*/

            rptGuard.PrintDialog();
        }

        //private void toolStriptxtPg_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (toolStriptxtPg.Text != "")
        //        {
        //            pgBusca = Convert.ToInt32(toolStriptxtPg.Text);

        //            if (pgBusca <= 1)
        //            {
        //                toolStriptxtPg.Text = "1";
        //                contPgRelatorio = 1;
        //                rptGuard.CurrentPage = 1;
        //                toolStripBtnProximo.Enabled = true;
        //                toolStripButtonUltimo.Enabled = true;
        //                toolStripBtnAnterior.Enabled = false;
        //                toolStripBtnInicio.Enabled = false;
        //            }
        //            else
        //            {

        //                if (pgBusca >= pgContTotal)
        //                {

        //                    toolStripBtnProximo.Enabled = false;
        //                    toolStripButtonUltimo.Enabled = false;
        //                    contPgRelatorio = pgContTotal;
        //                    toolStriptxtPg.Text = pgContTotal.ToString();
        //                    rptGuard.CurrentPage = pgContTotal;
        //                    toolStripBtnAnterior.Enabled = true;
        //                    toolStripBtnInicio.Enabled = true;
        //                }
        //                else
        //                {
        //                    contPgRelatorio = pgBusca;
        //                    rptGuard.CurrentPage = contPgRelatorio;
        //                    toolStripBtnAnterior.Enabled = true;
        //                    toolStripBtnInicio.Enabled = true;
        //                    toolStripBtnProximo.Enabled = true;
        //                    toolStripButtonUltimo.Enabled = true;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            toolStriptxtPg.Text = "";
        //        }
        //    }
        //}

        //private void toolStriptxtPg_TextChanged(object sender, EventArgs e)
        //{
        //    bool success;
        //    string s1 = toolStriptxtPg.Text;
        //    int result = 0;

        //    //Verifica se o valor digitado e numero (Retorna Verdadeiro ou Falso)
        //    success = Int32.TryParse(s1, out result);

        //    if (success == false)
        //    {
        //        toolStriptxtPg.Text = "";
        //    }
        //}

#pragma warning disable CS0246 // O nome do tipo ou do namespace "RenderingCompleteEventArgs" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
        private void rptGuard_RenderingComplete(object sender, RenderingCompleteEventArgs e)
#pragma warning restore CS0246 // O nome do tipo ou do namespace "RenderingCompleteEventArgs" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
        {
            /*Preenche variaveis com o valor da quantidade de paginas do formulario*/

            if (valid == true)
            {
                valid = false;
                if (PrintLayout)
                    rptGuard.SetDisplayMode(DisplayMode.PrintLayout);
                rptGuard.ZoomMode = ZoomMode.PageWidth;
                //ThreadStart contPaginaRel = new ThreadStart(contaPaginaAcessoTela);
                //threadContPaginaRel = new Thread(contPaginaRel);
                //threadContPaginaRel.Start();
            }

            //Altera o tooltip dos botões padrões
            ToolStrip ts = new ToolStrip();
            ts = FindToolStrip<ToolStrip>(this.rptGuard);
            foreach (ToolStripItem item in ts.Items)
            {
                if (item.Name.Equals("firstPage"))
                    item.ToolTipText = "Primeira página" + (((Globals._UtilizarAtalhosRel && !_CancelarAtalhos) || (_HabAtalhosIndividual && !_CancelarAtalhos)) ? " (Ctrl + ←) [Dica: Utilize também a seta no teclado]" : "");
                else if (item.Name.Equals("previousPage"))
                    item.ToolTipText = "Página anterior" + (((Globals._UtilizarAtalhosRel && !_CancelarAtalhos) || (_HabAtalhosIndividual && !_CancelarAtalhos)) ? " (←) [Dica: Utilize também a seta no teclado]" : "");
                else if (item.Name.Equals("nextPage"))
                    item.ToolTipText = "Próxima página" + (((Globals._UtilizarAtalhosRel && !_CancelarAtalhos) || (_HabAtalhosIndividual && !_CancelarAtalhos)) ? " (→) [Dica: Utilize também a seta no teclado]" : "");
                else if (item.Name.Equals("lastPage"))
                    item.ToolTipText = "Última página" + (((Globals._UtilizarAtalhosRel && !_CancelarAtalhos) || (_HabAtalhosIndividual && !_CancelarAtalhos)) ? " (Ctrl + →) [Dica: Utilize também a seta no teclado]" : "");
            }
        }

        //private void contapagina()
        //{
        //    this.Invoke(new MethodInvoker(AlimentarTela));
        //}

        //private void contaPaginaAcessoTela()
        //{
        //    LocalReport report = rptGuard.LocalReport;
        //    if (_tipoRelatorio == CTipoRelatorio.Retrato)
        //    {
        //        if (_tipoFolha == CTipoFolha.A3)
        //            Count(report, "29,7cm", "42cm", "1.5cm", "0.5cm", "0.5cm", "1.5cm");
        //        if (_tipoFolha == CTipoFolha.A4)
        //            Count(report, "21cm", "29.7cm", "1.5cm", "0.5cm", "0.5cm", "1.5cm");
        //        if (_tipoFolha == CTipoFolha.A5)
        //            Count(report, "14,8cm", "21cm", "1.5cm", "0.5cm", "0.5cm", "1.5cm");
        //        if (_tipoFolha == CTipoFolha.Carta)
        //            Count(report, "21,59cm", "27,94cm", "1.5cm", "0.5cm", "0.5cm", "1.5cm");
        //        if (_tipoFolha == CTipoFolha.Oficio)
        //            Count(report, "21,59cm", "35,56cm", "1.5cm", "0.5cm", "0.5cm", "1.5cm");
        //    }
        //    else
        //    {
        //        if (_tipoFolha == CTipoFolha.A3)
        //            Count(report, "42cm", "29,7cm", "1cm", "0.5cm", "0.5cm", "1cm");
        //        if (_tipoFolha == CTipoFolha.A4)
        //            Count(report, "29.7cm", "21cm", "1cm", "0.5cm", "0.5cm", "1cm");
        //        if (_tipoFolha == CTipoFolha.A5)
        //            Count(report, "21cm", "14,8cm", "1cm", "0.5cm", "0.5cm", "1cm");
        //        if (_tipoFolha == CTipoFolha.Carta)
        //            Count(report, "27,94cm", "21,59cm", "1cm", "0.5cm", "0.5cm", "1cm");
        //        if (_tipoFolha == CTipoFolha.Carta)
        //            Count(report, "35,56cm", "21,59cm", "1cm", "0.5cm", "0.5cm", "1cm");
        //    }

        //    contapagina();
        //}

        //private void AlimentarTela()
        //{
        //    toolStriptxtPg.Enabled = true;
        //    toolStripBtnPriviewPrint.Enabled = true;
        //    toolStripButtonUltimo.Enabled = true;
        //    toolStriplblPg.Text = "de " + numberOfPages.ToString();
        //    pgContTotal = numberOfPages;
        //    //toolStriptxtPg.Text = "1";

        //    if (numberOfPages == 1)
        //    {
        //        toolStripBtnAnterior.Enabled = false;
        //        toolStripBtnInicio.Enabled = false;
        //        toolStripBtnProximo.Enabled = false;
        //        toolStripButtonUltimo.Enabled = false;
        //    }
        //    else
        //    {
        //        toolStripBtnAnterior.Enabled = false;
        //        toolStripBtnInicio.Enabled = false;
        //        toolStripBtnProximo.Enabled = true;
        //        toolStripButtonUltimo.Enabled = true;
        //    }

        //    if (rptGuard.CurrentPage != 1)
        //    {
        //        toolStripBtnAnterior.Enabled = true;
        //        toolStripBtnInicio.Enabled = true;
        //    }
        //}

        //private void btnGeraRel_Click(object sender, EventArgs e)
        //{
        //    toolStriptxtPg.Text = "1";
        //}

        private void toolStripButtonVoltar_Click(object sender, EventArgs e)
        {
            HabilitarBuscaRelatorio();
            WindowState = FormWindowState.Normal;
            valid = false;
            rptGuard.Reset();
            //AlimentarTela();
            rptGuard.Refresh();
            rptGuard.RefreshReport();
            //contPgRelatorio = 1; /*Variavel que server como contador de paginas*/
            //pgBusca = 0; /*Receber valor TextBox que usuario digita e posiciona a pgina no valor digitado*/
            //pgContTotal = 0; /*Receber a quantidade de paginas que o relatorio tem*/
            //numberOfPages = 0;
            valid = true;
            //PgNavegacao = 1;
        }

        //private void toolStripButtonZoomMore_Click(object sender, EventArgs e)
        //{
        //    if (rptGuard.ZoomPercent < 500)
        //    {
        //        rptGuard.ZoomMode = ZoomMode.Percent;
        //        rptGuard.ZoomPercent += 25;
        //        toolStripComboBoxZoom.Text = rptGuard.ZoomPercent.ToString() + "%";
        //    }
        //}

        //private void toolStripComboBoxZoom_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string valorSelecionado = toolStripComboBoxZoom.SelectedItem.ToString();

        //    if ((valorSelecionado != "Largura da Página") && (valorSelecionado != "Página Inteira"))
        //    {
        //        rptGuard.ZoomMode = ZoomMode.Percent;
        //        rptGuard.ZoomPercent = int.Parse(toolStripComboBoxZoom.SelectedItem.ToString().PadLeft(4, '0').Substring(0, 3));
        //    }
        //    else
        //    {
        //        if (valorSelecionado == "Largura da Página")
        //        {
        //            rptGuard.ZoomMode = ZoomMode.PageWidth;
        //        }
        //        else
        //        {
        //            rptGuard.ZoomMode = ZoomMode.FullPage;
        //        }
        //    }
        //}

        //private void toolStripButton3_Click(object sender, EventArgs e)
        //{

        //}

        //private void toolStripTxtPesquisa_TextChanged(object sender, EventArgs e)
        //{
        //    toolStripbtnPesqProximo.Enabled = false;
        //}

        private void toolStripBtnPriviewPrint_Click(object sender, EventArgs e)
        {
            if (PrintLayout == true)
            {
                rptGuard.SetDisplayMode(DisplayMode.Normal);
                rptGuard.ZoomMode = ZoomMode.PageWidth;
                PrintLayout = false;
            }
            else
            {
                rptGuard.SetDisplayMode(DisplayMode.PrintLayout);
                rptGuard.ZoomMode = ZoomMode.PageWidth;
                PrintLayout = true;
            }
        }

        //private void EnabledOpcoesPesquisa(bool flag)
        //{
        //    toolStripTxtPesquisa.Enabled = flag;
        //    toolStriptxtBusca.Enabled = flag;
        //}

        //private void toolStripButtonZoomLess_Click(object sender, EventArgs e)
        //{
        //    if (rptGuard.ZoomPercent > 25)
        //    {
        //        if (toolStripComboBoxZoom.Text == "Página Inteira")
        //        {
        //            rptGuard.ZoomMode = ZoomMode.Percent;
        //            rptGuard.ZoomPercent = 25;
        //            toolStripComboBoxZoom.Text = rptGuard.ZoomPercent.ToString() + "%";
        //        }
        //        else
        //        {
        //            rptGuard.ZoomMode = ZoomMode.Percent;
        //            rptGuard.ZoomPercent -= 25;
        //            toolStripComboBoxZoom.Text = rptGuard.ZoomPercent.ToString() + "%";
        //        }
        //    }
        //}

        //private void toolStriptxtBusca_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (toolStripTxtPesquisa.Text != "")
        //        {
        //            toolStripbtnPesqProximo.Enabled = true;
        //            this.rptGuard.Find(toolStripTxtPesquisa.Text, 1);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Campos de busca se encontra vazio");
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Pesquisa concluida no documento. Não foi encontrada mais nenhuma ocorrência.");
        //    }
        //}

        //private void toolStripbtnPesqProximo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        rptGuard.FindNext();
        //        toolStriptxtPg.Text = rptGuard.CurrentPage.ToString();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Pesquisa concluida no documento. Não foi encontrada nenhuma ocorrência.");
        //    }
        //}

        //public void Count(LocalReport report, string PageWidth, string PageHeight, string MarginTop, string MarginLeft, string MarginRight, string MarginBottom)
        //{
        //    try
        //    {
        //        string deviceInfo =
        //      "<DeviceInfo>" +
        //      "  <OutputFormat>EMF</OutputFormat>" +
        //      "  <PageWidth>" + PageWidth + "</PageWidth>" +
        //      "  <PageHeight>" + PageHeight + "</PageHeight>" +
        //      "  <MarginTop>" + MarginTop + "</MarginTop>" +
        //      "  <MarginLeft>" + MarginLeft + "</MarginLeft>" +
        //      "  <MarginRight>" + MarginRight + "</MarginRight>" +
        //      "  <MarginBottom>" + MarginBottom + "</MarginBottom>" +
        //      "</DeviceInfo>";
        //        Warning[] warnings;
        //        report.Render("Image", deviceInfo, CreateStream, out warnings);
        //    }
        //    catch (Exception)
        //    {
        //        report.Dispose();
        //    }
        //}

        //private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        //{
        //    MemoryStream stream = new MemoryStream();
        //    numberOfPages++;
        //    this.Invoke(new MethodInvoker(AlimentarTela));
        //    return stream;
        //}

        //private void toolStripTxtPesquisa_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (toolStripTxtPesquisa.Text != "")
        //        {
        //            toolStriptxtBusca_Click(toolStripTxtPesquisa, e);
        //        }
        //    }

        //}

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimpaCampos(this.Controls);
        }

        //private void rptGuard_PageNavigation(object sender, PageNavigationEventArgs e)
        //{
        //    ModoImpressao();
        //    rptGuard.CurrentPage = e.NewPage;
        //    toolStriptxtPg.Text = rptGuard.CurrentPage.ToString();
        //    if (rptGuard.CurrentPage == 1)
        //    {
        //        toolStripBtnAnterior.Enabled = false;
        //        toolStripBtnInicio.Enabled = false;
        //    }
        //    else
        //    {
        //        toolStripBtnAnterior.Enabled = true;
        //        toolStripBtnInicio.Enabled = true;
        //    }

        //    if (numberOfPages != 0)
        //    {
        //        if (rptGuard.CurrentPage == numberOfPages)
        //        {
        //            toolStripBtnProximo.Enabled = false;
        //            toolStripButtonUltimo.Enabled = false;
        //        }
        //        else
        //        {
        //            toolStripBtnProximo.Enabled = true;
        //            toolStripButtonUltimo.Enabled = true;
        //        }
        //    }
        //}

        private void FormRelatorioCompleto_FormClosed(object sender, FormClosedEventArgs e)
        {
            LocalReport report = rptGuard.LocalReport;
            report.Dispose();
            rptGuard.Reset();
            rptGuard.Dispose();
            //if (threadContPaginaRel != null)
            //{
            //    if (threadContPaginaRel.IsAlive)
            //    {
            //        threadContPaginaRel.Abort();
            //    }
            //}


        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    int tamanho = toolStriplblPg.Text.Length;

        //    if (tamanho == 13 || tamanho == 22)
        //    {
        //        if (toolStriplblPg.Text == "Carregando...")
        //        {
        //            toolStriplblPg.Text = "                      ";
        //        }
        //        else
        //        {
        //            toolStriplblPg.Text = "Carregando...";
        //        }
        //    }
        //    else
        //    {
        //        timer1.Enabled = false;
        //    }

        //}

        private void btCancel_Click(object sender, EventArgs e)
        {
            FormRelatorioCompleto FormRelatorioCompleto = new FormRelatorioCompleto();
            FormRelatorioCompleto.Close();
        }

        private void toolStripBtnExcelDados_Click(object sender, EventArgs e)
        {
            // Abre janela para usuario escolher onde salvar o Excel

            SaveFileDialog vAbreArq = new SaveFileDialog();

            // Definição do tipo de Arquivo

            vAbreArq.Filter = "Excel|*.xls|Pasta de Trabalho do Excel|*.xlsx";
            String fileName = "";

            vAbreArq.Title = "Salvar como";
            if (vAbreArq.ShowDialog() == DialogResult.OK)
            {
                // Caminho do arquivo
                fileName = vAbreArq.FileName;
            }

            // Verfica se o valor que retorno e diferente de vazio 
            if (fileName != "")
            {
                try
                {
                    WaitWindow.Begin("Gerando arquivo Excel. Por favor, aguarde.");
                    DataTable dtexportaExcelDados = (DataTable)rptGuard.LocalReport.DataSources[0].Value;
                    Classes.Uteis.ExportaExcel.ExportaParaExcel(dtexportaExcelDados, fileName, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível gerar o Excel.\nMotivo: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    WaitWindow.End();
                }
            }
        }

        protected void LiberaTelaPermissao()
        {
            if (string.IsNullOrEmpty(this.CodigoSeguranca))
                btnPermissao.Visible = false;
            else
                btnPermissao.Visible = true;
        }

        private void btnPermissao_Click(object sender, EventArgs e)
        {
            frmManutencaoPermissoes frmMP = new frmManutencaoPermissoes();
            frmMP.UsuarioLogado = Globals.Usuario;
            frmMP.CodPrograma = this.CodigoSeguranca;
            frmMP.ShowDialog();
        }

        protected ToolStripButton toolStripBtnExcel = new ToolStripButton();
        protected ToolStripButton toolStripBtnPDF = new ToolStripButton();
        protected ToolStripButton toolStripBtnImpressora = new ToolStripButton();
        protected ToolStripButton toolStripBtnPreviewer = new ToolStripButton();
        protected ToolStripButton toolStripBtnVoltar = new ToolStripButton();
        private void ChangeToolBar()
        {
            Image img;
            //EXCEL
            img = Image.FromFile("S:\\Sistemas dotNet\\Figuras\\iExcelDados22.png");
            toolStripBtnExcel = new ToolStripButton("", img, toolStripBtnExcelDados_Click);
            toolStripBtnExcel.Visible = true;
            toolStripBtnExcel.Enabled = true;
            toolStripBtnExcel.ImageAlign = ContentAlignment.MiddleCenter;
            toolStripBtnExcel.ImageScaling = ToolStripItemImageScaling.None;
            toolStripBtnExcel.AutoSize = true;
            toolStripBtnExcel.Height = img.Height;
            toolStripBtnExcel.Width = img.Width;
            toolStripBtnExcel.Alignment = ToolStripItemAlignment.Left;
            toolStripBtnExcel.ToolTipText = "Modo Folha de Dados";

            //PDF
            img = Image.FromFile("S:\\Sistemas dotNet\\Figuras\\iPdf22.png");
            toolStripBtnPDF = new ToolStripButton("", img, toolStripBtnPDF_Click);
            toolStripBtnPDF.Visible = true;
            toolStripBtnPDF.Enabled = true;
            toolStripBtnPDF.ImageAlign = ContentAlignment.MiddleCenter;
            toolStripBtnPDF.ImageScaling = ToolStripItemImageScaling.None;
            toolStripBtnPDF.AutoSize = true;
            toolStripBtnPDF.Height = img.Height;
            toolStripBtnPDF.Width = img.Width;
            toolStripBtnPDF.Alignment = ToolStripItemAlignment.Left;
            toolStripBtnPDF.ToolTipText = "PDF";

            //IMPRESSORA
            img = Image.FromFile("S:\\Sistemas dotNet\\Figuras\\iImprimir22.png");
            toolStripBtnImpressora = new ToolStripButton("", img, toolStripBtnImpressora_Click);
            toolStripBtnImpressora.Visible = true;
            toolStripBtnImpressora.Enabled = true;
            toolStripBtnImpressora.ImageAlign = ContentAlignment.MiddleCenter;
            toolStripBtnImpressora.ImageScaling = ToolStripItemImageScaling.None;
            toolStripBtnImpressora.AutoSize = true;
            toolStripBtnImpressora.Height = img.Height;
            toolStripBtnImpressora.Width = img.Width;
            toolStripBtnImpressora.Alignment = ToolStripItemAlignment.Left;
            toolStripBtnImpressora.ToolTipText = "Imprimir";

            //VISUALIZAR IMPRESSAO
            img = Image.FromFile("S:\\Sistemas dotNet\\Figuras\\iPreview24.png");
            toolStripBtnPreviewer = new ToolStripButton("", img, toolStripBtnPriviewPrint_Click);
            toolStripBtnPreviewer.Visible = true;
            toolStripBtnPreviewer.Enabled = true;
            toolStripBtnPreviewer.ImageAlign = ContentAlignment.MiddleCenter;
            toolStripBtnPreviewer.ImageScaling = ToolStripItemImageScaling.None;
            toolStripBtnPreviewer.AutoSize = true;
            toolStripBtnPreviewer.Height = img.Height;
            toolStripBtnPreviewer.Width = img.Width;
            toolStripBtnPreviewer.Alignment = ToolStripItemAlignment.Left;
            toolStripBtnPreviewer.ToolTipText = "Visualizar impressão";

            //VOLTAR
            img = Image.FromFile("S:\\Sistemas dotNet\\Figuras\\iVoltar24.png");
            toolStripBtnVoltar = new ToolStripButton("", img, toolStripButtonVoltar_Click);
            toolStripBtnVoltar.Visible = true;
            toolStripBtnVoltar.Enabled = true;
            toolStripBtnVoltar.ImageAlign = ContentAlignment.MiddleCenter;
            toolStripBtnVoltar.ImageScaling = ToolStripItemImageScaling.None;
            toolStripBtnVoltar.AutoSize = true;
            toolStripBtnVoltar.Height = img.Height;
            toolStripBtnVoltar.Width = img.Width;
            toolStripBtnVoltar.Alignment = ToolStripItemAlignment.Right;
            toolStripBtnVoltar.ToolTipText = "Voltar";

            //Adiciona novos botões e altera ordem da barra de menu          
            ToolStrip ts = new ToolStrip();
            ts = FindToolStrip<ToolStrip>(this.rptGuard);

            int index = 0;
            ToolStripItem[] listOptions = new ToolStripItem[ts.Items.Count + 8];
            listOptions[index++] = toolStripBtnImpressora;
            listOptions[index++] = new ToolStripSeparator();
            listOptions[index++] = toolStripBtnExcel;
            listOptions[index++] = toolStripBtnPDF;
            listOptions[index++] = new ToolStripSeparator();

            for (int i = 0; i < ts.Items.Count; i++)
            {
                listOptions[index++] = ts.Items[i];
            }

            listOptions[index++] = toolStripBtnPreviewer;
            listOptions[index++] = new ToolStripSeparator();
            listOptions[index++] = toolStripBtnVoltar;

            ts.Items.Clear();
            ts.Items.AddRange(listOptions);
        }

        private T FindToolStrip<T>(Control control) where T : System.Windows.Forms.Control
        {
            if (control == null)
            {
                return null;
            }
            else if (control is T)
            {
                //muda a cor da barra
                control.BackColor = Color.FromArgb(195, 217, 241);
                return (T)control;
            }
            else
            {
                T result = null;

                foreach (Control embedded in control.Controls)
                {
                    if (result == null)
                    {
                        result = FindToolStrip<T>(embedded);
                    }
                }

                return result;
            }
        }

        private List<string> _filtrosUtilizados;
        public string MontarFiltros(Control.ControlCollection pControles)
        {
            IEnumerable<Control> controlesOrdenados = pControles.OfType<Control>().OrderBy(w => w.TabIndex);

            string s = "";
            foreach (Control c in controlesOrdenados)
            {
                s += c.TabIndex + " " + c.Name + Environment.NewLine;
            }

            foreach (Control ctrl in controlesOrdenados)
            {
                //Tratamento do TextBox
                if (ctrl is TextBoxGuard && ((TextBoxGuard)ctrl).Tag != null &&
                    !string.IsNullOrEmpty(((TextBoxGuard)ctrl).Tag.ToString()) &&
                    !string.IsNullOrEmpty(((TextBoxGuard)ctrl).Text.ToString()) &&
                    !(((TextBoxGuard)ctrl).Parent.Parent is RecursosGenericos.Intervalo1))
                {
                    _filtrosUtilizados.Add(((TextBoxGuard)ctrl).Tag + ": " + ((TextBoxGuard)ctrl).Text);
                }

                //Tratamento do List Campos
                if (ctrl is System.Uteis.ListaCampos && ((System.Uteis.ListaCampos)ctrl).Checado())
                {
                    _filtrosUtilizados.Add(((System.Uteis.ListaCampos)ctrl).TextCheck + ": " + ((System.Uteis.ListaCampos)ctrl).RetornaLista().Replace("'", "").Replace(",", ", "));
                }

                //Tratamento do List Campos recursos genéricos
                if (ctrl is Uteis.ListaCampos1 && ((Uteis.ListaCampos1)ctrl).Checado())
                    _filtrosUtilizados.Add(((Uteis.ListaCampos1)ctrl).TextCheck + ": " + ((Uteis.ListaCampos1)ctrl).RetornaLista().Replace("'", "").Replace(",", ", "));

                //Tratamento do ComboBox
                if (ctrl is ComboBoxGuard && ((ComboBoxGuard)ctrl).SelectedIndex != -1 && !((ComboBoxGuard)ctrl).SelectedItem.ToString().Trim().Equals(""))
                {
                    _filtrosUtilizados.Add(((ComboBoxGuard)ctrl).Tag + ": " + ((ComboBoxGuard)ctrl).SelectedItem);
                }

                //Tratamento do Intervalo de Campos
                if (ctrl is IntervaloCampos.IntervaloCampos && ((IntervaloCampos.IntervaloCampos)ctrl).Checado())
                {
                    _filtrosUtilizados.Add(((IntervaloCampos.IntervaloCampos)ctrl).lblTitulo.Text + " Inicial: " + ((IntervaloCampos.IntervaloCampos)ctrl).txtInicial.Text);
                    _filtrosUtilizados.Add(((IntervaloCampos.IntervaloCampos)ctrl).lblTitulo.Text + " Final: " + ((IntervaloCampos.IntervaloCampos)ctrl).txtFinal.Text);
                }

                //Tratamento do Intervalo de Campos dos Recursos Genéricos
                if (ctrl is RecursosGenericos.Intervalo1 && ((Intervalo1)ctrl).Preenchido())
                {
                    string tagInicial = ((RecursosGenericos.Intervalo1)ctrl).txtInicial.Tag.ToString();
                    string tagFinal = ((RecursosGenericos.Intervalo1)ctrl).txtFinal.Tag.ToString();

                    _filtrosUtilizados.Add(((RecursosGenericos.Intervalo1)ctrl).chkTitulo.Text + " Inicial: " + ((RecursosGenericos.Intervalo1)ctrl).txtInicial.Text + (tagInicial.Equals("") ? "" : " - " + tagInicial));
                    _filtrosUtilizados.Add(((RecursosGenericos.Intervalo1)ctrl).chkTitulo.Text + " Final: " + ((RecursosGenericos.Intervalo1)ctrl).txtFinal.Text + (tagFinal.Equals("") ? "" : " - " + tagFinal));
                }

                //Tratamento do Intervalo de Datas dos Recursos Genéricos
                if (ctrl is RecursosGenericos.IntervaloData1 && ((RecursosGenericos.IntervaloData1)ctrl).Preenchido())
                {
                    _filtrosUtilizados.Add(((RecursosGenericos.IntervaloData1)ctrl).chkTitulo.Text + " entre " + ((RecursosGenericos.IntervaloData1)ctrl).txtInicial.Text + " e " + ((RecursosGenericos.IntervaloData1)ctrl).txtFinal.Text);
                }

                //Tratamento do Intervalo de Campos dos Recursos Genéricos
                if (ctrl is RecursosGenericos.Intervalo2 && ((RecursosGenericos.Intervalo2)ctrl).Preenchido())
                {
                    _filtrosUtilizados.Add(((RecursosGenericos.Intervalo2)ctrl).chkTitulo.Text + " entre " + ((RecursosGenericos.Intervalo2)ctrl).txtInicial.Text + " e " + ((RecursosGenericos.Intervalo2)ctrl).txtFinal.Text);
                }

                //Tratamento do Intervalo de datas
                if (ctrl is Componentes.IntervaloCampoData && ((Componentes.IntervaloCampoData)ctrl).chkTitulo.Checked)
                {
                    _filtrosUtilizados.Add(((Componentes.IntervaloCampoData)ctrl).chkTitulo.Text + " entre " + ((Componentes.IntervaloCampoData)ctrl).dtpInicial.Text + " e " + ((Componentes.IntervaloCampoData)ctrl).dtpFinal.Text);
                }

                //Tratamento do CheckBox
                if (ctrl is CheckBoxGuard &&
                    ((CheckBoxGuard)ctrl).Checked &&
                    !(((CheckBoxGuard)ctrl).Parent is GroupBoxGuard) && //Caso o CheckBox esteja dentro de um GroupBox, ele será tratado de outra forma
                    !(((CheckBoxGuard)ctrl).Parent.Parent is RecursosGenericos.Intervalo1) &&
                    !(((CheckBoxGuard)ctrl).Parent.Parent.Parent is ListaCampos1))
                {
                    _filtrosUtilizados.Add(((CheckBoxGuard)ctrl).Text);
                }

                //Tratamento do RadioButton
                if (ctrl is RadioButtonGuard &&
                    ((RadioButtonGuard)ctrl).Checked &&
                    !(((RadioButtonGuard)ctrl).Parent is GroupBoxGuard) //Caso o RadioButton esteja dentro de um GroupBox, ele será tratado de outra forma
                    )
                {
                    _filtrosUtilizados.Add(((RadioButtonGuard)ctrl).Text);
                }

                //Tratamento do GroupBox
                if (ctrl is GroupBoxGuard)
                {
                    string nomeComponente = "";
                    bool encontrouSomenteUmTipoComponente = true;
                    foreach (Control item in ((GroupBoxGuard)ctrl).Controls)
                    {
                        if (!(item is RadioButtonGuard) && !(item is CheckBoxGuard) && !(item is LabelGuard))
                        {
                            //encontrouSomenteUmTipoComponente = false;
                        }

                        if (encontrouSomenteUmTipoComponente && item is RadioButtonGuard && ((RadioButtonGuard)item).Checked && !((RadioButtonGuard)item).OcultarFiltro)
                        {
                            nomeComponente = ((RadioButtonGuard)item).Text;
                        }
                        else if (encontrouSomenteUmTipoComponente && item is CheckBoxGuard && ((CheckBoxGuard)item).Checked)
                        {
                            nomeComponente += ((CheckBoxGuard)item).Text + "; ";
                        }
                    }
                    //Excluir o ultimo ponto-e-virgula
                    if (nomeComponente.Length > 2 &&
                        nomeComponente.Substring(nomeComponente.Length - 2, 2).Equals("; "))
                        nomeComponente = nomeComponente.Substring(0, nomeComponente.Length - 2);

                    if (!nomeComponente.Trim().Equals(""))
                    {
                        string nomeContainer = ((GroupBoxGuard)ctrl).Text;
                        if (nomeContainer.Trim().Equals("") && ((GroupBoxGuard)ctrl).Tag != null)
                        {
                            nomeContainer = ((GroupBoxGuard)ctrl).Tag.ToString();
                        }
                        else if (nomeContainer.Trim().Equals(""))
                        {
                            nomeContainer = "Filtro";
                        }

                        _filtrosUtilizados.Add(nomeContainer + ": " + nomeComponente);
                    }
                }

                //Se for um Container, executa a função novamente, passando os controles que existem dentro do Panel
                if (ctrl.HasChildren && !(ctrl is IntervaloCampos.IntervaloCampos) && !(ctrl is RecursosGenericos.IntervaloData1) && !(ctrl is RecursosGenericos.Intervalo2) && !(ctrl is Componentes.IntervaloCampoData))
                {
                    MontarFiltros(ctrl.Controls);
                }
            }

            _filtrosUtilizados.Sort();
            _filtrosUtilizados.Reverse();

            string filtrosUtilizados = "Filtros Utilizados: " + Environment.NewLine;
            int i = 1;
            foreach (string item in _filtrosUtilizados)
            {
                filtrosUtilizados += i.ToString().PadLeft(2, '0') + ". " + item + Environment.NewLine;
                i++;
            }

            if (_filtrosUtilizados.Count == 0)
            {
                filtrosUtilizados += "Nenhum";
            }

            return filtrosUtilizados;
        }

        private void btnGeraRel_Click(object sender, EventArgs e)
        {
            _filtrosUtilizados = new List<string>();
            comandoExecutado = true;

            if (comandoExecutado && atribuirFiltros)
            {
                //HabilitarBuscaRelatorio();
                CriarAlterarArquivoRelatorioFiltrosAnteriores(1);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!valid)
            {
                if (_Atalhos.Contains(keyData) && ((Globals._UtilizarAtalhosRel && !_CancelarAtalhos) || (_HabAtalhosIndividual && !_CancelarAtalhos)))
                {
                    if (keyData == (Keys.Control | Keys.P))
                        toolStripBtnImpressora.PerformClick();
                    else if (keyData == (Keys.Control | Keys.E))
                        toolStripBtnExcel.PerformClick();
                    else if (keyData == (Keys.Control | Keys.S))
                        toolStripBtnPDF.PerformClick();
                    else if (keyData == (Keys.Control | Keys.B))
                        toolStripBtnVoltar.PerformClick();
                    return true;
                }
                else if (_TDirecionais.Contains(keyData) && ((Globals._UtilizarDirecionaisRel && !_CancelarDirecionais) || _HabDirecionalIndividual))
                {
                    if (keyData == (Keys.Control | Keys.Right))
                    {
                        if (rptGuard.CurrentPage != rptGuard.GetTotalPages())
                            rptGuard.CurrentPage = rptGuard.GetTotalPages();
                    }
                    else if (keyData == (Keys.Control | Keys.Left))
                    {
                        if (rptGuard.CurrentPage != 1)
                            rptGuard.CurrentPage = 1;
                    }
                    else if (keyData == Keys.Right)
                    {
                        if (rptGuard.CurrentPage != rptGuard.GetTotalPages())
                            rptGuard.CurrentPage += 1;
                    }
                    else if (keyData == Keys.Left)
                    {
                        if (rptGuard.CurrentPage != 1)
                            rptGuard.CurrentPage -= 1;
                    }
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
