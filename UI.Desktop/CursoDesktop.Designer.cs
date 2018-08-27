namespace UI.Desktop
{
    partial class CursoDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.IDLabel = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.MateriaIDLabel = new System.Windows.Forms.Label();
            this.cbMateria = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.AnioLabel = new System.Windows.Forms.Label();
            this.CupoLabel = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.ComisionIDLabel = new System.Windows.Forms.Label();
            this.cbComision = new System.Windows.Forms.ComboBox();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 346F));
            this.tableLayoutPanel1.Controls.Add(this.IDLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.MateriaIDLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbMateria, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.AnioLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CupoLabel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAnio, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCupo, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.ComisionIDLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbComision, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 113);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // IDLabel
            // 
            this.IDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(31, 6);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(18, 13);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "ID";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(84, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(276, 20);
            this.txtID.TabIndex = 11;
            // 
            // MateriaIDLabel
            // 
            this.MateriaIDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MateriaIDLabel.AutoSize = true;
            this.MateriaIDLabel.Location = new System.Drawing.Point(19, 33);
            this.MateriaIDLabel.Name = "MateriaIDLabel";
            this.MateriaIDLabel.Size = new System.Drawing.Size(42, 13);
            this.MateriaIDLabel.TabIndex = 19;
            this.MateriaIDLabel.Text = "Materia";
            // 
            // cbMateria
            // 
            this.cbMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMateria.FormattingEnabled = true;
            this.cbMateria.Location = new System.Drawing.Point(84, 29);
            this.cbMateria.Name = "cbMateria";
            this.cbMateria.Size = new System.Drawing.Size(276, 21);
            this.cbMateria.TabIndex = 22;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(366, 85);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(456, 85);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // AnioLabel
            // 
            this.AnioLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AnioLabel.AutoSize = true;
            this.AnioLabel.Location = new System.Drawing.Point(27, 61);
            this.AnioLabel.Name = "AnioLabel";
            this.AnioLabel.Size = new System.Drawing.Size(26, 13);
            this.AnioLabel.TabIndex = 23;
            this.AnioLabel.Text = "Año";
            // 
            // CupoLabel
            // 
            this.CupoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CupoLabel.AutoSize = true;
            this.CupoLabel.Location = new System.Drawing.Point(392, 61);
            this.CupoLabel.Name = "CupoLabel";
            this.CupoLabel.Size = new System.Drawing.Size(32, 13);
            this.CupoLabel.TabIndex = 24;
            this.CupoLabel.Text = "Cupo";
            // 
            // txtAnio
            // 
            this.txtAnio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnio.Location = new System.Drawing.Point(84, 56);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(276, 20);
            this.txtAnio.TabIndex = 25;
            // 
            // txtCupo
            // 
            this.txtCupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCupo.Location = new System.Drawing.Point(456, 56);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(341, 20);
            this.txtCupo.TabIndex = 26;
            // 
            // ComisionIDLabel
            // 
            this.ComisionIDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ComisionIDLabel.AutoSize = true;
            this.ComisionIDLabel.Location = new System.Drawing.Point(383, 33);
            this.ComisionIDLabel.Name = "ComisionIDLabel";
            this.ComisionIDLabel.Size = new System.Drawing.Size(49, 13);
            this.ComisionIDLabel.TabIndex = 27;
            this.ComisionIDLabel.Text = "Comisión";
            // 
            // cbComision
            // 
            this.cbComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbComision.FormattingEnabled = true;
            this.cbComision.Location = new System.Drawing.Point(456, 29);
            this.cbComision.Name = "cbComision";
            this.cbComision.Size = new System.Drawing.Size(341, 21);
            this.cbComision.TabIndex = 28;
            // 
            // CursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 113);
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
        private System.Windows.Forms.Label MateriaIDLabel;
        private System.Windows.Forms.ComboBox cbMateria;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label AnioLabel;
        private System.Windows.Forms.Label CupoLabel;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.Label ComisionIDLabel;
        private System.Windows.Forms.ComboBox cbComision;
    }
}