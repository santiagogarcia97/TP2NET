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
            this.IDLabel = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.CursoIDLabel = new System.Windows.Forms.Label();
            this.NotaLabel = new System.Windows.Forms.Label();
            this.cbCurso = new System.Windows.Forms.ComboBox();
            this.nudNota = new System.Windows.Forms.NumericUpDown();
            this.labelAlumno = new System.Windows.Forms.Label();
            this.cbAlumno = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelCondicion = new System.Windows.Forms.Label();
            this.cbCondicion = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNota)).BeginInit();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.tableLayoutPanel1.Controls.Add(this.IDLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CursoIDLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NotaLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbCurso, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudNota, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelAlumno, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbAlumno, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelCondicion, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbCondicion, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(736, 137);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // IDLabel
            // 
            this.IDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(24, 19);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(18, 13);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "ID";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(69, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(224, 20);
            this.txtID.TabIndex = 11;
            // 
            // CursoIDLabel
            // 
            this.CursoIDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CursoIDLabel.AutoSize = true;
            this.CursoIDLabel.Location = new System.Drawing.Point(16, 58);
            this.CursoIDLabel.Name = "CursoIDLabel";
            this.CursoIDLabel.Size = new System.Drawing.Size(34, 13);
            this.CursoIDLabel.TabIndex = 19;
            this.CursoIDLabel.Text = "Curso";
            // 
            // NotaLabel
            // 
            this.NotaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NotaLabel.AutoSize = true;
            this.NotaLabel.Location = new System.Drawing.Point(326, 19);
            this.NotaLabel.Name = "NotaLabel";
            this.NotaLabel.Size = new System.Drawing.Size(30, 13);
            this.NotaLabel.TabIndex = 21;
            this.NotaLabel.Text = "Nota";
            // 
            // cbCurso
            // 
            this.cbCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCurso.FormattingEnabled = true;
            this.cbCurso.Location = new System.Drawing.Point(69, 54);
            this.cbCurso.Name = "cbCurso";
            this.cbCurso.Size = new System.Drawing.Size(224, 21);
            this.cbCurso.TabIndex = 22;
            // 
            // nudNota
            // 
            this.nudNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudNota.Location = new System.Drawing.Point(389, 3);
            this.nudNota.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNota.Name = "nudNota";
            this.nudNota.Size = new System.Drawing.Size(344, 20);
            this.nudNota.TabIndex = 27;
            // 
            // labelAlumno
            // 
            this.labelAlumno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAlumno.AutoSize = true;
            this.labelAlumno.Location = new System.Drawing.Point(320, 58);
            this.labelAlumno.Name = "labelAlumno";
            this.labelAlumno.Size = new System.Drawing.Size(42, 13);
            this.labelAlumno.TabIndex = 28;
            this.labelAlumno.Text = "Alumno";
            // 
            // cbAlumno
            // 
            this.cbAlumno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAlumno.FormattingEnabled = true;
            this.cbAlumno.Location = new System.Drawing.Point(389, 54);
            this.cbAlumno.Name = "cbAlumno";
            this.cbAlumno.Size = new System.Drawing.Size(344, 21);
            this.cbAlumno.TabIndex = 29;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(299, 109);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(389, 109);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // labelCondicion
            // 
            this.labelCondicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCondicion.AutoSize = true;
            this.labelCondicion.Location = new System.Drawing.Point(6, 85);
            this.labelCondicion.Name = "labelCondicion";
            this.labelCondicion.Size = new System.Drawing.Size(54, 13);
            this.labelCondicion.TabIndex = 30;
            this.labelCondicion.Text = "Condición";
            // 
            // cbCondicion
            // 
            this.cbCondicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCondicion.FormattingEnabled = true;
            this.cbCondicion.Location = new System.Drawing.Point(69, 81);
            this.cbCondicion.Name = "cbCondicion";
            this.cbCondicion.Size = new System.Drawing.Size(224, 21);
            this.cbCondicion.TabIndex = 31;
            // 
            // AlumnoInscripcionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 137);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AlumnoInscripcionDesktop";
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
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label CursoIDLabel;
        private System.Windows.Forms.Label NotaLabel;
        private System.Windows.Forms.ComboBox cbCurso;
        private System.Windows.Forms.NumericUpDown nudNota;
        private System.Windows.Forms.Label labelAlumno;
        private System.Windows.Forms.ComboBox cbAlumno;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label labelCondicion;
        private System.Windows.Forms.ComboBox cbCondicion;
    }
}