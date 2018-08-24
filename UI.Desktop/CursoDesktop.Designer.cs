namespace UI.Desktop {
    partial class CursoDesktop {
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
            this.IDLabel = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.labelComisión = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.DescLabel = new System.Windows.Forms.Label();
            this.cbComision = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtAnio = new System.Windows.Forms.Label();
            this.labelCupo = new System.Windows.Forms.Label();
            this.txtHSSemanales = new System.Windows.Forms.TextBox();
            this.txtHSTotales = new System.Windows.Forms.TextBox();
            this.labelMateria = new System.Windows.Forms.Label();
            this.cbMateria = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.52011F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.4799F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel1.Controls.Add(this.IDLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelComisión, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.DescLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbComision, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtAnio, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCupo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHSSemanales, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHSTotales, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelMateria, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbMateria, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 111);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // IDLabel
            // 
            this.IDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(32, 5);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(18, 13);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "ID";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(86, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(280, 20);
            this.txtID.TabIndex = 11;
            // 
            // labelComisión
            // 
            this.labelComisión.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelComisión.AutoSize = true;
            this.labelComisión.Location = new System.Drawing.Point(17, 31);
            this.labelComisión.Name = "labelComisión";
            this.labelComisión.Size = new System.Drawing.Size(49, 13);
            this.labelComisión.TabIndex = 19;
            this.labelComisión.Text = "Comisión";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Location = new System.Drawing.Point(462, 3);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(335, 20);
            this.txtDescripcion.TabIndex = 16;
            // 
            // DescLabel
            // 
            this.DescLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(382, 5);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(63, 13);
            this.DescLabel.TabIndex = 21;
            this.DescLabel.Text = "Descripcion";
            // 
            // cbComision
            // 
            this.cbComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbComision.FormattingEnabled = true;
            this.cbComision.Location = new System.Drawing.Point(86, 27);
            this.cbComision.Name = "cbComision";
            this.cbComision.Size = new System.Drawing.Size(280, 21);
            this.cbComision.TabIndex = 22;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(372, 83);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(462, 83);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtAnio
            // 
            this.txtAnio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAnio.AutoSize = true;
            this.txtAnio.Location = new System.Drawing.Point(28, 59);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(26, 13);
            this.txtAnio.TabIndex = 23;
            this.txtAnio.Text = "Año";
            // 
            // labelCupo
            // 
            this.labelCupo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCupo.AutoSize = true;
            this.labelCupo.Location = new System.Drawing.Point(398, 59);
            this.labelCupo.Name = "labelCupo";
            this.labelCupo.Size = new System.Drawing.Size(32, 13);
            this.labelCupo.TabIndex = 24;
            this.labelCupo.Text = "Cupo";
            // 
            // txtHSSemanales
            // 
            this.txtHSSemanales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHSSemanales.Location = new System.Drawing.Point(86, 54);
            this.txtHSSemanales.Name = "txtHSSemanales";
            this.txtHSSemanales.Size = new System.Drawing.Size(280, 20);
            this.txtHSSemanales.TabIndex = 25;
            // 
            // txtHSTotales
            // 
            this.txtHSTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHSTotales.Location = new System.Drawing.Point(462, 54);
            this.txtHSTotales.Name = "txtHSTotales";
            this.txtHSTotales.Size = new System.Drawing.Size(335, 20);
            this.txtHSTotales.TabIndex = 26;
            // 
            // labelMateria
            // 
            this.labelMateria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMateria.AutoSize = true;
            this.labelMateria.Location = new System.Drawing.Point(393, 31);
            this.labelMateria.Name = "labelMateria";
            this.labelMateria.Size = new System.Drawing.Size(42, 13);
            this.labelMateria.TabIndex = 27;
            this.labelMateria.Text = "Materia";
            // 
            // cbMateria
            // 
            this.cbMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMateria.FormattingEnabled = true;
            this.cbMateria.Location = new System.Drawing.Point(462, 27);
            this.cbMateria.Name = "cbMateria";
            this.cbMateria.Size = new System.Drawing.Size(335, 21);
            this.cbMateria.TabIndex = 28;
            // 
            // CursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 111);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CursoDesktop";
            this.Text = "CursoDesktop";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label labelComisión;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.ComboBox cbComision;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label txtAnio;
        private System.Windows.Forms.Label labelCupo;
        private System.Windows.Forms.TextBox txtHSSemanales;
        private System.Windows.Forms.TextBox txtHSTotales;
        private System.Windows.Forms.Label labelMateria;
        private System.Windows.Forms.ComboBox cbMateria;
    }
}