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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dtPlanesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsEntities = new UI.Desktop.reportes.dsEntities();
            this.rvReportes = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dtPlanesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEntities)).BeginInit();
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
            reportDataSource1.Name = "Planes";
            reportDataSource1.Value = this.dtPlanesBindingSource;
            this.rvReportes.LocalReport.DataSources.Add(reportDataSource1);
            this.rvReportes.LocalReport.ReportEmbeddedResource = "";
            this.rvReportes.Location = new System.Drawing.Point(0, 0);
            this.rvReportes.Name = "rvReportes";
            this.rvReportes.ServerReport.BearerToken = null;
            this.rvReportes.Size = new System.Drawing.Size(800, 450);
            this.rvReportes.TabIndex = 0;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvReportes);
            this.Name = "frmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.dtPlanesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEntities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReportes;
        private System.Windows.Forms.BindingSource dtPlanesBindingSource;
        private dsEntities dsEntities;
    }
}