using System.Data;
using System.Text;
using System.Windows.Forms;
#pragma warning disable CS0234 // O nome de tipo ou namespace "Reporting" não existe no namespace "Microsoft" (você está sem uma referência de assembly?)
#pragma warning restore CS0234 // O nome de tipo ou namespace "Reporting" não existe no namespace "Microsoft" (você está sem uma referência de assembly?)
using System.Diagnostics;
using System.Threading;
using System.IO;


namespace System.Uteis
{
	public partial class FormRelatorioOld : FormBasic
    {
        public FormRelatorioOld()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construtor com bloqueio para múltiplas instâncias do formulário
        /// </summary>
        /// <param name="frmP">Formulário principal do projeto.</param>
        public FormRelatorioOld(Form frmP): base(frmP)
        {
            InitializeComponent();
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

        private bool PrintLayout = true;

        #region Declaração Varivaeis Globais
        int PgNavegacao = 1;
        int pgContTotal = 0;
        int pgBusca = 0;
        //bool valid = true;
        bool valid2 = true;
        int numberOfPages = 0;
        Thread threadContPaginaRel;

        #endregion

        #region Evento FormLoad
        private void FormRelatorio_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Evento RenderingComplete
#pragma warning disable CS0234 // O nome de tipo ou namespace "Reporting" não existe no namespace "Microsoft" (você está sem uma referência de assembly?)
        private void relGuard_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
#pragma warning restore CS0234 // O nome de tipo ou namespace "Reporting" não existe no namespace "Microsoft" (você está sem uma referência de assembly?)
        {
            if (valid2 == true)
            {
                valid2 = false;
                rptGuard.SetDisplayMode(DisplayMode.PrintLayout);
                rptGuard.ZoomMode = ZoomMode.PageWidth;

                ThreadStart contPaginaRel = new ThreadStart(contaPaginaAcessoTela);
                threadContPaginaRel = new Thread(contPaginaRel);
                threadContPaginaRel.Start();
            }
        }

        private void contapagina()
        {
            this.Invoke(new MethodInvoker(AlimentarTela));
        }

        private void contaPaginaAcessoTela()
        {
            LocalReport report = rptGuard.LocalReport;
            if (_tipoRelatorio == CTipoRelatorio.Retrato)
            {
                if (_tipoFolha == CTipoFolha.A3)
                    Count(report, "29,7cm", "42cm", "1.5cm", "0.5cm", "0.5cm", "1.5cm");
                if (_tipoFolha == CTipoFolha.A4)
                    Count(report, "21cm", "29.7cm", "1.5cm", "0.5cm", "0.5cm", "1.5cm");
                if (_tipoFolha == CTipoFolha.A5)
                    Count(report, "14,8cm", "21cm", "1.5cm", "0.5cm", "0.5cm", "1.5cm");
                if (_tipoFolha == CTipoFolha.Carta)
                    Count(report, "21,59cm", "27,94cm", "1.5cm", "0.5cm", "0.5cm", "1.5cm");
                if (_tipoFolha == CTipoFolha.Oficio)
                    Count(report, "21,59cm", "35,56cm", "1.5cm", "0.5cm", "0.5cm", "1.5cm");
            }
            else
            {
                if (_tipoFolha == CTipoFolha.A3)
                    Count(report, "42cm", "29,7cm", "1cm", "0.5cm", "0.5cm", "1cm");
                if (_tipoFolha == CTipoFolha.A4)
                    Count(report, "29.7cm", "21cm", "1cm", "0.5cm", "0.5cm", "1cm");
                if (_tipoFolha == CTipoFolha.A5)
                    Count(report, "21cm", "14,8cm", "1cm", "0.5cm", "0.5cm", "1cm");
                if (_tipoFolha == CTipoFolha.Carta)
                    Count(report, "27,94cm", "21,59cm", "1cm", "0.5cm", "0.5cm", "1cm");
                if (_tipoFolha == CTipoFolha.Carta)
                    Count(report, "35,56cm", "21,59cm", "1cm", "0.5cm", "0.5cm", "1cm");
            }
            contapagina();
        }

        private void AlimentarTela()
        {
            toolStriptxtPg.Enabled = true;
            toolStripBtnPriviewPrint.Enabled = true;
            toolStripButtonUltimo.Enabled = true;
            toolStriplblPg.Text = "de " + numberOfPages.ToString();
            pgContTotal = numberOfPages;
            //toolStriptxtPg.Text = "1";

            if (numberOfPages == 1)
            {
                toolStripBtnAnterior.Enabled = false;
                toolStripBtnInicio.Enabled = false;
                toolStripBtnProximo.Enabled = false;
                toolStripButtonUltimo.Enabled = false;
            }
            else
            {
                toolStripBtnAnterior.Enabled = false;
                toolStripBtnInicio.Enabled = false;
                toolStripBtnProximo.Enabled = true;
                toolStripButtonUltimo.Enabled = true; 
            }

            if (rptGuard.CurrentPage != 1)
            {
                toolStripBtnAnterior.Enabled = true;
                toolStripBtnInicio.Enabled = true;
            }

        }
        #endregion

        #region Button Proximo
        private void toolStripBtnProximo_Click(object sender, EventArgs e)
        {
            ModoImpressao();
            try
            {
                rptGuard.CurrentPage = rptGuard.CurrentPage + 1;
                toolStriptxtPg.Text = rptGuard.CurrentPage.ToString();
                toolStripBtnAnterior.Enabled = true;
                toolStripBtnInicio.Enabled = true;
            }
            catch
            {
                toolStripBtnProximo.Enabled = false;
                toolStripBtnAnterior.Enabled = true;
                toolStripBtnInicio.Enabled = true;
                if (numberOfPages != 0)
                {
                    toolStripButtonUltimo.Enabled = true;
                }
            }
        }

        private void ModoImpressao()
        {
            if (PrintLayout == false)
            {
                rptGuard.SetDisplayMode(DisplayMode.PrintLayout);
                rptGuard.ZoomMode = ZoomMode.PageWidth;
                PrintLayout = true;
                toolStripTxtPesquisa.Text = "";
                EnabledOpcoesPesquisa(false);
            }
        }
        #endregion

        #region Button Ultimo
        private void toolStripButtonUltimo_Click(object sender, EventArgs e)
        {
            /*Posiciona o cursor na ultima pagina do relatorio*/
            ModoImpressao();
            if (numberOfPages != 0)
            {
                pgContTotal = numberOfPages;
                toolStripBtnProximo.Enabled = false;
                toolStripButtonUltimo.Enabled = false;
                PgNavegacao = pgContTotal;
                toolStriptxtPg.Text = pgContTotal.ToString();
                rptGuard.CurrentPage = pgContTotal;
                toolStripBtnAnterior.Enabled = true;
                toolStripBtnInicio.Enabled = true;
            }
           
        }
        #endregion

        #region Button Anterior
        private void toolStripBtnAnterior_Click(object sender, EventArgs e)
        {
            ModoImpressao();
            try
            {
                rptGuard.CurrentPage = rptGuard.CurrentPage - 1;
                toolStriptxtPg.Text = rptGuard.CurrentPage.ToString();
                toolStripBtnProximo.Enabled = true;
                if (numberOfPages != 0)
                {
                    toolStripButtonUltimo.Enabled = true;
                }
                if (rptGuard.CurrentPage == 1)
                {
                    toolStripBtnAnterior.Enabled = false;
                    toolStripBtnInicio.Enabled = false;
                    toolStripBtnProximo.Enabled = true;
                }
            }
            catch
            {
                toolStripBtnAnterior.Enabled = false;
                toolStripBtnInicio.Enabled = false;
                toolStripBtnProximo.Enabled = true;
                if (numberOfPages != 0)
                {
                    toolStripButtonUltimo.Enabled = true;
                }
            }
        }
        #endregion

        #region Button Inicio
        private void toolStripBtnInicio_Click(object sender, EventArgs e)
        {
            /*Posiona o curso na primeira pagina do relatorio*/
            ModoImpressao();
            toolStripBtnAnterior.Enabled = false;
            toolStripBtnInicio.Enabled = false;
            toolStriptxtPg.Text = "1";
            rptGuard.CurrentPage = 1;
            PgNavegacao = 1;
            toolStripBtnProximo.Enabled = true;
            if (numberOfPages != 0)
            {
                toolStripButtonUltimo.Enabled = true;
            }
            if (rptGuard.CurrentPage == 1)
            {
                toolStripBtnAnterior.Enabled = false;
                toolStripBtnInicio.Enabled = false;
                toolStripBtnProximo.Enabled = true;
            }
        }
        #endregion

        #region ExportaPDF
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
                LocalReport report = rptGuard.LocalReport;
                ExportarReport(report, rptFormat.PDF, fileName);
                Process.Start(fileName);
            }
        }
        #endregion

        #region Exporta Imagem
        private void toolStripBtnImagem_Click(object sender, EventArgs e)
        {
            // Abre janela para usuÃ¡rio escolher o PDF

            SaveFileDialog vAbreArq = new SaveFileDialog();


            // Verifica se o usuÃ¡rio clicou em ok ou cancelar na janela de seleÃ§Ã£o da pasta

            vAbreArq.Filter = "JPG|*.jpg";
            String fileName = "";

            vAbreArq.Title = "Selecione o Arquivo";
            if (vAbreArq.ShowDialog() == DialogResult.OK)
            {
                // Caminho do arquivo
                fileName = vAbreArq.FileName;
            }

            if (fileName != "")
            {
                LocalReport report = rptGuard.LocalReport;
                ExportarReport(report, rptFormat.Image, fileName);
                Process.Start(fileName);
            }
        }
        #endregion

        #region Imprime Relatorio
        private void toolStripBtnImpressora_Click(object sender, EventArgs e)
        {
            /*Comando aciona o PrintDialog*/

            rptGuard.PrintDialog();
        }
        #endregion

        #region Evento onChanged txtPg
        private void toolStriptxtPg_TextChanged(object sender, EventArgs e)
        {
            bool success;
            string s1 = toolStriptxtPg.Text;
            int result = 0;

            //Verifica se o valor digitado e numero (Retorna Verdadeiro ou Falso)
            success = Int32.TryParse(s1, out result);

            if (success == false)
            {
                toolStriptxtPg.Text = "";
            }
        }
        #endregion

        #region Eventon KeyDown txtPg
        private void toolStriptxtPg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (toolStriptxtPg.Text != "")
                {
                    pgBusca = Convert.ToInt32(toolStriptxtPg.Text);

                    if (pgBusca <= 1)
                    {
                        toolStriptxtPg.Text = "1";
                        rptGuard.CurrentPage = 1;
                        toolStripBtnProximo.Enabled = true;
                        toolStripButtonUltimo.Enabled = true;
                        toolStripBtnAnterior.Enabled = false;
                        toolStripBtnInicio.Enabled = false;
                    }
                    else
                    {

                        if (pgBusca >= pgContTotal)
                        {

                            toolStripBtnProximo.Enabled = false;
                            toolStripButtonUltimo.Enabled = false;
                            toolStriptxtPg.Text = pgContTotal.ToString();
                            rptGuard.CurrentPage = pgContTotal;
                            toolStripBtnAnterior.Enabled = true;
                            toolStripBtnInicio.Enabled = true;
                        }
                        else
                        {
                            rptGuard.CurrentPage = pgBusca;
                            toolStripBtnAnterior.Enabled = true;
                            toolStripBtnInicio.Enabled = true;
                            toolStripBtnProximo.Enabled = true;
                            toolStripButtonUltimo.Enabled = true;
                        }
                    }
                }
                else
                {
                    toolStriptxtPg.Text = "";
                }
            }
        }
        #endregion

        private void toolStripButtonZoomMore_Click(object sender, EventArgs e)
        {
            if (rptGuard.ZoomPercent < 500)
            {
                rptGuard.ZoomMode = ZoomMode.Percent;
                rptGuard.ZoomPercent += 25;
                toolStripComboBoxZoom.Text = rptGuard.ZoomPercent.ToString() + "%";
            }
        }

        private void toolStripButtonZoomLess_Click(object sender, EventArgs e)
        {
            if (rptGuard.ZoomPercent > 25)
            {
                if (toolStripComboBoxZoom.Text == "Página Inteira")
                {
                    rptGuard.ZoomMode = ZoomMode.Percent;
                    rptGuard.ZoomPercent = 25;
                    toolStripComboBoxZoom.Text = rptGuard.ZoomPercent.ToString() + "%";
                }
                else
                {
                    rptGuard.ZoomMode = ZoomMode.Percent;
                    rptGuard.ZoomPercent -= 25;
                    toolStripComboBoxZoom.Text = rptGuard.ZoomPercent.ToString() + "%";
                }
            }
        }

        private void toolStripComboBoxZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valorSelecionado = toolStripComboBoxZoom.SelectedItem.ToString();

            if ((valorSelecionado != "Largura da Página") && (valorSelecionado != "Página Inteira"))
            {
                rptGuard.ZoomMode = ZoomMode.Percent;
                rptGuard.ZoomPercent = int.Parse(toolStripComboBoxZoom.SelectedItem.ToString().PadLeft(4, '0').Substring(0, 3));
            }
            else
            {
                if (valorSelecionado == "Largura da Página")
                {
                    rptGuard.ZoomMode = ZoomMode.PageWidth;
                }
                else
                {
                    rptGuard.ZoomMode = ZoomMode.FullPage;
                }
            }
        }

        private void toolStripbtnPesq_Click(object sender, EventArgs e)
        {
            try
            {
                if (toolStripTxtPesquisa.Text != "")
                {
                    toolStripbtnPesqProximo.Enabled = true;
                    this.rptGuard.Find(toolStripTxtPesquisa.Text, 1);
                }
                else
                {
                    MessageBox.Show("Campos de busca se encontra vazio");
                }
            }
            catch
            {
                MessageBox.Show("Pesquisa concluida no documento. Não foi encontrada nenhuma ocorrência.");
            }
        }

        private void toolStripbtnPesqProximo_Click(object sender, EventArgs e)
        {
            try
            {
                rptGuard.FindNext();
                toolStriptxtPg.Text = rptGuard.CurrentPage.ToString();
            }
            catch
            {
                MessageBox.Show("Pesquisa concluida no documento. Não foi encontrada mais nenhuma ocorrência.");
            }
        }

        private void toolStripTxtPesquisa_TextChanged(object sender, EventArgs e)
        {
            toolStripbtnPesqProximo.Enabled = false;
        }

        private void toolStripBtnPriviewPrint_Click(object sender, EventArgs e)
        {
            if (PrintLayout == true)
            {
                rptGuard.SetDisplayMode(DisplayMode.Normal);
                rptGuard.ZoomMode = ZoomMode.PageWidth;
                PrintLayout = false;
                toolStripTxtPesquisa.Text = "";
                EnabledOpcoesPesquisa(true);
            }
            else
            {
                rptGuard.SetDisplayMode(DisplayMode.PrintLayout);
                rptGuard.ZoomMode = ZoomMode.PageWidth;
                PrintLayout = true;
                toolStripbtnPesqProximo.Enabled = false;
                toolStripTxtPesquisa.Text = "";
                EnabledOpcoesPesquisa(false);
                toolStripComboBoxZoom.Text = "Largura da Página";
            }
        }

        private void EnabledOpcoesPesquisa(bool flag)
        {
            toolStripTxtPesquisa.Enabled = flag;
            toolStriptxtBusca.Enabled = flag;
        }

#pragma warning disable CS0246 // O nome do tipo ou do namespace "LocalReport" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
        public void Count(LocalReport report, string PageWidth, string PageHeight, string MarginTop, string MarginLeft, string MarginRight, string MarginBottom)
#pragma warning restore CS0246 // O nome do tipo ou do namespace "LocalReport" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
        {
            try
            {
                string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>" + PageWidth + "</PageWidth>" +
              "  <PageHeight>" + PageHeight + "</PageHeight>" +
              "  <MarginTop>" + MarginTop + "</MarginTop>" +
              "  <MarginLeft>" + MarginLeft + "</MarginLeft>" +
              "  <MarginRight>" + MarginRight + "</MarginRight>" +
              "  <MarginBottom>" + MarginBottom + "</MarginBottom>" +
              "</DeviceInfo>";
                Warning[] warnings;
                report.Render("Image", deviceInfo, CreateStream, out warnings);
            }
            catch (Exception)
            {
                report.Dispose();
            }
        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            MemoryStream stream = new MemoryStream();
            numberOfPages++;
            this.Invoke(new MethodInvoker(AlimentarTela));
            return stream;
        }
        
        private void toolStripTxtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (toolStripTxtPesquisa.Text != "")
                {
                    toolStripbtnPesq_Click(toolStripTxtPesquisa, e);
                }
            }
        }

#pragma warning disable CS0246 // O nome do tipo ou do namespace "PageNavigationEventArgs" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
        private void rptGuard_PageNavigation(object sender, PageNavigationEventArgs e)
#pragma warning restore CS0246 // O nome do tipo ou do namespace "PageNavigationEventArgs" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
        {
            ModoImpressao();
            rptGuard.CurrentPage = e.NewPage;
            toolStriptxtPg.Text = rptGuard.CurrentPage.ToString();

            if (rptGuard.CurrentPage == 1)
            {
                toolStripBtnAnterior.Enabled = false;
                toolStripBtnInicio.Enabled = false;
            }
            else
            {
                toolStripBtnAnterior.Enabled = true;
                toolStripBtnInicio.Enabled = true;
            }

            if (numberOfPages != 0)
            {
                if (rptGuard.CurrentPage == numberOfPages)
                {
                    toolStripBtnProximo.Enabled = false;
                    toolStripButtonUltimo.Enabled = false;
                }
                else
                {
                    toolStripBtnProximo.Enabled = true;
                    toolStripButtonUltimo.Enabled = true;
                }
            }
        }

        private void FormRelatorio_FormClosed(object sender, FormClosedEventArgs e)
        {
            LocalReport report = rptGuard.LocalReport;
            report.Dispose();
            rptGuard.Reset();
            rptGuard.Dispose();
            if (threadContPaginaRel != null)
            {
                if (threadContPaginaRel.IsAlive)
                {
                    threadContPaginaRel.Abort();
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
        private void toolStripBtnExcel_Click(object sender, EventArgs e)
        {
            // Abre janela para usuario escolher onde salvar o PDF

            SaveFileDialog vAbreArq = new SaveFileDialog();

            // Definição do tipo de Arquivo

            vAbreArq.Filter = "XLS|*.xls";
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
                /*Chamada da classe que exporta para Excel*/

                LocalReport report = rptGuard.LocalReport;
                ExportarReport(report, rptFormat.Excel, fileName);
                Process.Start(fileName);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int tamanho = toolStriplblPg.Text.Length;

            if (tamanho == 13 || tamanho == 22)
            {
                if (toolStriplblPg.Text == "Carregando...")
                {
                    toolStriplblPg.Text = "                      ";
                }
                else
                {
                    toolStriplblPg.Text = "Carregando...";
                }
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void toolStripBtnExcelDados_Click(object sender, EventArgs e)
        {
            // Abre janela para usuario escolher onde salvar o Excel

            SaveFileDialog vAbreArq = new SaveFileDialog();

            // Definição do tipo de Arquivo

            vAbreArq.Filter = "Excel|*.xls";
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
                DataTable dtexportaExcelDados = (DataTable)rptGuard.LocalReport.DataSources[0].Value;
                Classes.Uteis.ExportaExcel.ExportaParaExcel(dtexportaExcelDados, fileName, true);
            }
        }
    }
}
