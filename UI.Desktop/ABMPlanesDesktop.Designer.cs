namespace UI.Desktop {
    partial class ABMPlanesDesktop {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.EspecialidadIDLabel = new System.Windows.Forms.Label();
            this.DescLabel = new System.Windows.Forms.Label();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblDescRed = new System.Windows.Forms.Label();
            this.lblEspRed = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.030303F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.30303F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.030303F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.29293F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.29293F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.050505F));
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.IDLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.EspecialidadIDLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.DescLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbEspecialidad, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDescRed, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblEspRed, 5, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 136);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescripcion, 2);
            this.txtDescripcion.Location = new System.Drawing.Point(106, 43);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(162, 20);
            this.txtDescripcion.TabIndex = 16;
            // 
            // txtID
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtID, 2);
            this.txtID.Location = new System.Drawing.Point(106, 18);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(162, 20);
            this.txtID.TabIndex = 11;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDLabel.Location = new System.Drawing.Point(11, 15);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(81, 25);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "ID";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EspecialidadIDLabel
            // 
            this.EspecialidadIDLabel.AutoSize = true;
            this.EspecialidadIDLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EspecialidadIDLabel.Location = new System.Drawing.Point(11, 65);
            this.EspecialidadIDLabel.Name = "EspecialidadIDLabel";
            this.EspecialidadIDLabel.Size = new System.Drawing.Size(81, 25);
            this.EspecialidadIDLabel.TabIndex = 19;
            this.EspecialidadIDLabel.Text = "Especialidad";
            this.EspecialidadIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescLabel.Location = new System.Drawing.Point(11, 40);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(81, 25);
            this.DescLabel.TabIndex = 21;
            this.DescLabel.Text = "Descripcion";
            this.DescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbEspecialidad
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbEspecialidad, 2);
            this.cbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspecialidad.FormattingEnabled = true;
            this.cbEspecialidad.Location = new System.Drawing.Point(106, 68);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(162, 21);
            this.cbEspecialidad.TabIndex = 22;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAceptar.Location = new System.Drawing.Point(190, 108);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(78, 25);
            this.btnAceptar.TabIndex = 30;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblDescRed
            // 
            this.lblDescRed.AutoSize = true;
            this.lblDescRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescRed.ForeColor = System.Drawing.Color.Red;
            this.lblDescRed.Location = new System.Drawing.Point(274, 40);
            this.lblDescRed.Name = "lblDescRed";
            this.lblDescRed.Size = new System.Drawing.Size(13, 25);
            this.lblDescRed.TabIndex = 31;
            this.lblDescRed.Text = "*";
            this.lblDescRed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDescRed.Visible = false;
            // 
            // lblEspRed
            // 
            this.lblEspRed.AutoSize = true;
            this.lblEspRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEspRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspRed.ForeColor = System.Drawing.Color.Red;
            this.lblEspRed.Location = new System.Drawing.Point(274, 65);
            this.lblEspRed.Name = "lblEspRed";
            this.lblEspRed.Size = new System.Drawing.Size(13, 25);
            this.lblEspRed.TabIndex = 32;
            this.lblEspRed.Text = "*";
            this.lblEspRed.Visible = false;
            // 
            // ABMPlanDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 136);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ABMPlanDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PlanDesktop";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label EspecialidadIDLabel;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.ComboBox cbEspecialidad;
        private System.Windows.Forms.Label lblDescRed;
        private System.Windows.Forms.Label lblEspRed;
    }
}