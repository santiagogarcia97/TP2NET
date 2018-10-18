namespace UI.Desktop {
    partial class ABMDocentesCurso {
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
            this.dgvDocenteCurso = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDDocente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcAlumnoInscripciones = new System.Windows.Forms.ToolStripContainer();
            this.tlAlumnoInscripciones = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tsAlumnoInscripciones = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocenteCurso)).BeginInit();
            this.tcAlumnoInscripciones.ContentPanel.SuspendLayout();
            this.tcAlumnoInscripciones.TopToolStripPanel.SuspendLayout();
            this.tcAlumnoInscripciones.SuspendLayout();
            this.tlAlumnoInscripciones.SuspendLayout();
            this.tsAlumnoInscripciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDocenteCurso
            // 
            this.dgvDocenteCurso.AllowUserToAddRows = false;
            this.dgvDocenteCurso.AllowUserToDeleteRows = false;
            this.dgvDocenteCurso.AllowUserToResizeRows = false;
            this.dgvDocenteCurso.BackgroundColor = System.Drawing.Color.White;
            this.dgvDocenteCurso.ColumnHeadersHeight = 21;
            this.dgvDocenteCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDocenteCurso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.IDCurso,
            this.IDDocente,
            this.Cargo});
            this.tlAlumnoInscripciones.SetColumnSpan(this.dgvDocenteCurso, 2);
            this.dgvDocenteCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocenteCurso.Location = new System.Drawing.Point(3, 3);
            this.dgvDocenteCurso.MultiSelect = false;
            this.dgvDocenteCurso.Name = "dgvDocenteCurso";
            this.dgvDocenteCurso.ReadOnly = true;
            this.dgvDocenteCurso.RowHeadersVisible = false;
            this.dgvDocenteCurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocenteCurso.Size = new System.Drawing.Size(794, 390);
            this.dgvDocenteCurso.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID Dictado";
            this.id.MinimumWidth = 100;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // IDCurso
            // 
            this.IDCurso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDCurso.DataPropertyName = "IDCurso";
            this.IDCurso.HeaderText = "ID Curso";
            this.IDCurso.MinimumWidth = 130;
            this.IDCurso.Name = "IDCurso";
            this.IDCurso.ReadOnly = true;
            // 
            // IDDocente
            // 
            this.IDDocente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDDocente.DataPropertyName = "IDDocente";
            this.IDDocente.HeaderText = "ID Docente";
            this.IDDocente.MinimumWidth = 130;
            this.IDDocente.Name = "IDDocente";
            this.IDDocente.ReadOnly = true;
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "Cargo";
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.MinimumWidth = 50;
            this.Cargo.Name = "Cargo";
            this.Cargo.ReadOnly = true;
            this.Cargo.Width = 50;
            // 
            // tcAlumnoInscripciones
            // 
            // 
            // tcAlumnoInscripciones.ContentPanel
            // 
            this.tcAlumnoInscripciones.ContentPanel.Controls.Add(this.tlAlumnoInscripciones);
            this.tcAlumnoInscripciones.ContentPanel.Size = new System.Drawing.Size(800, 425);
            this.tcAlumnoInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAlumnoInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tcAlumnoInscripciones.Name = "tcAlumnoInscripciones";
            this.tcAlumnoInscripciones.Size = new System.Drawing.Size(800, 450);
            this.tcAlumnoInscripciones.TabIndex = 3;
            this.tcAlumnoInscripciones.Text = "toolStripContainer1";
            // 
            // tcAlumnoInscripciones.TopToolStripPanel
            // 
            this.tcAlumnoInscripciones.TopToolStripPanel.Controls.Add(this.tsAlumnoInscripciones);
            // 
            // tlAlumnoInscripciones
            // 
            this.tlAlumnoInscripciones.ColumnCount = 2;
            this.tlAlumnoInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnoInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlAlumnoInscripciones.Controls.Add(this.dgvDocenteCurso, 0, 0);
            this.tlAlumnoInscripciones.Controls.Add(this.btnSalir, 1, 1);
            this.tlAlumnoInscripciones.Controls.Add(this.btnActualizar, 0, 1);
            this.tlAlumnoInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAlumnoInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tlAlumnoInscripciones.Name = "tlAlumnoInscripciones";
            this.tlAlumnoInscripciones.RowCount = 2;
            this.tlAlumnoInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnoInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnoInscripciones.Size = new System.Drawing.Size(800, 425);
            this.tlAlumnoInscripciones.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(722, 399);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(641, 399);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.DocenteCurso_Load);
            // 
            // tsAlumnoInscripciones
            // 
            this.tsAlumnoInscripciones.Dock = System.Windows.Forms.DockStyle.None;
            this.tsAlumnoInscripciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEliminar});
            this.tsAlumnoInscripciones.Location = new System.Drawing.Point(3, 0);
            this.tsAlumnoInscripciones.Name = "tsAlumnoInscripciones";
            this.tsAlumnoInscripciones.Size = new System.Drawing.Size(89, 25);
            this.tsAlumnoInscripciones.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = global::UI.Desktop.Properties.Resources.image18;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = global::UI.Desktop.Properties.Resources.delete;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "toolStripButton1";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // DocentesCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcAlumnoInscripciones);
            this.Name = "DocentesCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Docentes - Cursos";
            this.Load += new System.EventHandler(this.DocenteCurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocenteCurso)).EndInit();
            this.tcAlumnoInscripciones.ContentPanel.ResumeLayout(false);
            this.tcAlumnoInscripciones.TopToolStripPanel.ResumeLayout(false);
            this.tcAlumnoInscripciones.TopToolStripPanel.PerformLayout();
            this.tcAlumnoInscripciones.ResumeLayout(false);
            this.tcAlumnoInscripciones.PerformLayout();
            this.tlAlumnoInscripciones.ResumeLayout(false);
            this.tsAlumnoInscripciones.ResumeLayout(false);
            this.tsAlumnoInscripciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocenteCurso;
        private System.Windows.Forms.TableLayoutPanel tlAlumnoInscripciones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStripContainer tcAlumnoInscripciones;
        private System.Windows.Forms.ToolStrip tsAlumnoInscripciones;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDocente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
    }
}