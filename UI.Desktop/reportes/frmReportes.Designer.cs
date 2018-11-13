namespace UI.Desktop.reportes {
    partial class frmReportes {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dtPlanesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsEntities = new UI.Desktop.reportes.dsEntities();
            this.rvReportes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.msAdmin = new System.Windows.Forms.MenuStrip();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dtPlanesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEntities)).BeginInit();
            this.msAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtPlanesBindingSource
            // 
            this.dtPlanesBindingSource.DataMember = "dtPlanes";
            this.dtPlanesBindingSource.DataSource = this.dsEntities;
            // 
            // dsEntities
            // 
            this.dsEntities.DataSetName = "dsEntities";
            this.dsEntities.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvReportes
            // 
            this.rvReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "Planes";
            reportDataSource3.Value = this.dtPlanesBindingSource;
            this.rvReportes.LocalReport.DataSources.Add(reportDataSource3);
            this.rvReportes.LocalReport.ReportEmbeddedResource = "";
            this.rvReportes.Location = new System.Drawing.Point(0, 24);
            this.rvReportes.Name = "rvReportes";
            this.rvReportes.ServerReport.BearerToken = null;
            this.rvReportes.Size = new System.Drawing.Size(800, 426);
            this.rvReportes.TabIndex = 0;
            // 
            // msAdmin
            // 
            this.msAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planesToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.msAdmin.Location = new System.Drawing.Point(0, 0);
            this.msAdmin.Name = "msAdmin";
            this.msAdmin.Size = new System.Drawing.Size(800, 24);
            this.msAdmin.TabIndex = 1;
            this.msAdmin.Text = "menuStrip1";
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            this.planesToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.planesToolStripMenuItem.Text = "Planes";
            this.planesToolStripMenuItem.Click += new System.EventHandler(this.planesToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvReportes);
            this.Controls.Add(this.msAdmin);
            this.MainMenuStrip = this.msAdmin;
            this.Name = "frmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.dtPlanesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEntities)).EndInit();
            this.msAdmin.ResumeLayout(false);
            this.msAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReportes;
        private System.Windows.Forms.BindingSource dtPlanesBindingSource;
        private dsEntities dsEntities;
        private System.Windows.Forms.MenuStrip msAdmin;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
    }
}