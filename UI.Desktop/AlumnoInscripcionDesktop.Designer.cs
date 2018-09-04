namespace UI.Desktop {
    partial class AlumnoInscripcionDesktop {
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
            this.cbCondicion = new System.Windows.Forms.ComboBox();
            this.cbCurso = new System.Windows.Forms.ComboBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.CursoIDLabel = new System.Windows.Forms.Label();
            this.labelCondicion = new System.Windows.Forms.Label();
            this.NotaLabel = new System.Windows.Forms.Label();
            this.labelAlumno = new System.Windows.Forms.Label();
            this.nudNota = new System.Windows.Forms.NumericUpDown();
            this.cbAlumno = new System.Windows.Forms.ComboBox();
            this.labelID = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNota)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.IDLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelAlumno, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbAlumno, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudNota, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.NotaLabel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelCondicion, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.CursoIDLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbCondicion, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbCurso, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 4, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 172);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // cbCondicion
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbCondicion, 2);
            this.cbCondicion.FormattingEnabled = true;
            this.cbCondicion.Location = new System.Drawing.Point(97, 93);
            this.cbCondicion.Name = "cbCondicion";
            this.cbCondicion.Size = new System.Drawing.Size(212, 21);
            this.cbCondicion.TabIndex = 31;
            // 
            // cbCurso
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbCurso, 2);
            this.cbCurso.FormattingEnabled = true;
            this.cbCurso.Location = new System.Drawing.Point(97, 68);
            this.cbCurso.Name = "cbCurso";
            this.cbCurso.Size = new System.Drawing.Size(212, 21);
            this.cbCurso.TabIndex = 22;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDLabel.Location = new System.Drawing.Point(12, 15);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(70, 25);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "ID";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CursoIDLabel
            // 
            this.CursoIDLabel.AutoSize = true;
            this.CursoIDLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CursoIDLabel.Location = new System.Drawing.Point(12, 65);
            this.CursoIDLabel.Name = "CursoIDLabel";
            this.CursoIDLabel.Size = new System.Drawing.Size(70, 25);
            this.CursoIDLabel.TabIndex = 19;
            this.CursoIDLabel.Text = "Curso";
            this.CursoIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCondicion
            // 
            this.labelCondicion.AutoSize = true;
            this.labelCondicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCondicion.Location = new System.Drawing.Point(12, 90);
            this.labelCondicion.Name = "labelCondicion";
            this.labelCondicion.Size = new System.Drawing.Size(70, 25);
            this.labelCondicion.TabIndex = 30;
            this.labelCondicion.Text = "Condición";
            this.labelCondicion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NotaLabel
            // 
            this.NotaLabel.AutoSize = true;
            this.NotaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotaLabel.Location = new System.Drawing.Point(12, 115);
            this.NotaLabel.Name = "NotaLabel";
            this.NotaLabel.Size = new System.Drawing.Size(70, 25);
            this.NotaLabel.TabIndex = 21;
            this.NotaLabel.Text = "Nota";
            this.NotaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAlumno
            // 
            this.labelAlumno.AutoSize = true;
            this.labelAlumno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAlumno.Location = new System.Drawing.Point(12, 40);
            this.labelAlumno.Name = "labelAlumno";
            this.labelAlumno.Size = new System.Drawing.Size(70, 25);
            this.labelAlumno.TabIndex = 28;
            this.labelAlumno.Text = "Alumno";
            this.labelAlumno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudNota
            // 
            this.nudNota.Location = new System.Drawing.Point(97, 118);
            this.nudNota.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNota.Name = "nudNota";
            this.nudNota.Size = new System.Drawing.Size(103, 20);
            this.nudNota.TabIndex = 27;
            // 
            // cbAlumno
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbAlumno, 2);
            this.cbAlumno.FormattingEnabled = true;
            this.cbAlumno.Location = new System.Drawing.Point(97, 43);
            this.cbAlumno.Name = "cbAlumno";
            this.cbAlumno.Size = new System.Drawing.Size(212, 21);
            this.cbAlumno.TabIndex = 29;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelID.Location = new System.Drawing.Point(97, 15);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(103, 25);
            this.labelID.TabIndex = 32;
            this.labelID.Text = "label1";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(234, 143);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // AlumnoInscripcionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 172);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AlumnoInscripcionDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AlumnoInscripcionDesktop";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label CursoIDLabel;
        private System.Windows.Forms.Label NotaLabel;
        private System.Windows.Forms.ComboBox cbCurso;
        private System.Windows.Forms.NumericUpDown nudNota;
        private System.Windows.Forms.Label labelAlumno;
        private System.Windows.Forms.ComboBox cbAlumno;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label labelCondicion;
        private System.Windows.Forms.ComboBox cbCondicion;
        private System.Windows.Forms.Label labelID;
    }
}