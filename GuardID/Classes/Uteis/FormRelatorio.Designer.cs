namespace System.Windows.Forms.Guard
{
    partial class FormRelatorio
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
            this.components = new System.ComponentModel.Container();
            this.rptGuard = new Microsoft.Reporting.WinForms.ReportViewer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // rptGuard
            // 
            this.rptGuard.AutoScroll = true;
            this.rptGuard.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.rptGuard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rptGuard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptGuard.Location = new System.Drawing.Point(0, 0);
            this.rptGuard.Name = "rptGuard";
            this.rptGuard.ShowBackButton = false;
            this.rptGuard.ShowContextMenu = false;
            this.rptGuard.ShowCredentialPrompts = false;
            this.rptGuard.ShowDocumentMapButton = false;
            this.rptGuard.ShowExportButton = false;
            this.rptGuard.ShowParameterPrompts = false;
            this.rptGuard.ShowPrintButton = false;
            this.rptGuard.ShowPromptAreaButton = false;
            this.rptGuard.ShowRefreshButton = false;
            this.rptGuard.ShowStopButton = false;
            this.rptGuard.Size = new System.Drawing.Size(765, 487);
            this.rptGuard.TabIndex = 7;
            this.rptGuard.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            this.rptGuard.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.relGuard_RenderingComplete);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // FormRelatorioNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 487);
            this.Controls.Add(this.rptGuard);
            this.Name = "FormRelatorioNew";
            this.Text = "";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRelatorio_FormClosed);
            this.Load += new System.EventHandler(this.FormRelatorio_Load);
            this.ResumeLayout(false);

        }

        #endregion

#pragma warning disable CS0234 // O nome de tipo ou namespace "Reporting" não existe no namespace "Microsoft" (você está sem uma referência de assembly?)
        public Microsoft.Reporting.WinForms.ReportViewer rptGuard;
#pragma warning restore CS0234 // O nome de tipo ou namespace "Reporting" não existe no namespace "Microsoft" (você está sem uma referência de assembly?)
        private Timer timer1;
    }
}