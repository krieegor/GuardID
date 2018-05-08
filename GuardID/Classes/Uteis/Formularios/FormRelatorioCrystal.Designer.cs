namespace System.Uteis
{
    partial class FormRelatorioCrystal
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.crystalRptGuard = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // crystalRptGuard
            // 
            this.crystalRptGuard.ActiveViewIndex = -1;
            this.crystalRptGuard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalRptGuard.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalRptGuard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalRptGuard.Location = new System.Drawing.Point(0, 0);
            this.crystalRptGuard.Name = "crystalRptGuard";
            this.crystalRptGuard.ShowCloseButton = false;
            this.crystalRptGuard.ShowCopyButton = false;
            this.crystalRptGuard.ShowExportButton = false;
            this.crystalRptGuard.ShowGroupTreeButton = false;
            this.crystalRptGuard.ShowLogo = false;
            this.crystalRptGuard.ShowParameterPanelButton = false;
            this.crystalRptGuard.ShowPrintButton = false;
            this.crystalRptGuard.ShowRefreshButton = false;
            this.crystalRptGuard.Size = new System.Drawing.Size(765, 487);
            this.crystalRptGuard.TabIndex = 0;
            this.crystalRptGuard.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormRelatorioCrystal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 487);
            this.Controls.Add(this.crystalRptGuard);
            this.Name = "FormRelatorioCrystal";
            this.Text = "";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRelatorio_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private Timer timer1;
#pragma warning disable CS0246 // O nome do tipo ou do namespace "CrystalDecisions" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
        protected CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRptGuard;
#pragma warning restore CS0246 // O nome do tipo ou do namespace "CrystalDecisions" não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)
    }
}