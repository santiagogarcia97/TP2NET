namespace UI.Desktop {
    partial class MateriaDesktop {
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
            this.PlanIDLabel = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.DescLabel = new System.Windows.Forms.Label();
            this.cbPlan = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.HSSemanalesLabel = new System.Windows.Forms.Label();
            this.HSTotalesLabel = new System.Windows.Forms.Label();
            this.txtHSSemanales = new System.Windows.Forms.TextBox();
            this.txtHSTotales = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.tableLayoutPanel1.Controls.Add(this.IDLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlanIDLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.DescLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbPlan, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.HSSemanalesLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.HSTotalesLabel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHSSemanales, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHSTotales, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 115);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // IDLabel
            // 
            this.IDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(33, 7);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(18, 13);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "ID";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(87, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(282, 20);
            this.txtID.TabIndex = 11;
            // 
            // PlanIDLabel
            // 
            this.PlanIDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PlanIDLabel.AutoSize = true;
            this.PlanIDLabel.Location = new System.Drawing.Point(28, 35);
            this.PlanIDLabel.Name = "PlanIDLabel";
            this.PlanIDLabel.Size = new System.Drawing.Size(28, 13);
            this.PlanIDLabel.TabIndex = 19;
            this.PlanIDLabel.Text = "Plan";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.Location = new System.Drawing.Point(472, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(318, 20);
            this.txtDescripcion.TabIndex = 16;
            // 
            // DescLabel
            // 
            this.DescLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(385, 7);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(63, 13);
            this.DescLabel.TabIndex = 21;
            this.DescLabel.Text = "Descripcion";
            // 
            // cbPlan
            // 
            this.cbPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.Items.AddRange(new object[] {
            "Plan ejemplo 1",
            "Plan ejemplo 2",
            "Plan ejemplo 3"});
            this.cbPlan.Location = new System.Drawing.Point(87, 31);
            this.cbPlan.Name = "cbPlan";
            this.cbPlan.Size = new System.Drawing.Size(282, 21);
            this.cbPlan.TabIndex = 22;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(375, 87);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(465, 87);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // HSSemanalesLabel
            // 
            this.HSSemanalesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HSSemanalesLabel.AutoSize = true;
            this.HSSemanalesLabel.Location = new System.Drawing.Point(3, 63);
            this.HSSemanalesLabel.Name = "HSSemanalesLabel";
            this.HSSemanalesLabel.Size = new System.Drawing.Size(75, 13);
            this.HSSemanalesLabel.TabIndex = 23;
            this.HSSemanalesLabel.Text = "Hs Semanales";
            // 
            // HSTotalesLabel
            // 
            this.HSTotalesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HSTotalesLabel.AutoSize = true;
            this.HSTotalesLabel.Location = new System.Drawing.Point(388, 63);
            this.HSTotalesLabel.Name = "HSTotalesLabel";
            this.HSTotalesLabel.Size = new System.Drawing.Size(58, 13);
            this.HSTotalesLabel.TabIndex = 24;
            this.HSTotalesLabel.Text = "Hs Totales";
            // 
            // txtHSSemanales
            // 
            this.txtHSSemanales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHSSemanales.Location = new System.Drawing.Point(87, 58);
            this.txtHSSemanales.Name = "txtHSSemanales";
            this.txtHSSemanales.Size = new System.Drawing.Size(282, 20);
            this.txtHSSemanales.TabIndex = 25;
            // 
            // txtHSTotales
            // 
            this.txtHSTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHSTotales.Location = new System.Drawing.Point(465, 58);
            this.txtHSTotales.Name = "txtHSTotales";
            this.txtHSTotales.Size = new System.Drawing.Size(332, 20);
            this.txtHSTotales.TabIndex = 26;
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 115);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MateriaDesktop";
            this.Text = "MateriaDesktop";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label PlanIDLabel;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.ComboBox cbPlan;
        private System.Windows.Forms.Label HSSemanalesLabel;
        private System.Windows.Forms.Label HSTotalesLabel;
        private System.Windows.Forms.TextBox txtHSSemanales;
        private System.Windows.Forms.TextBox txtHSTotales;
    }
}