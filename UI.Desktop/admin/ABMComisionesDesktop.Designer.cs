namespace UI.Desktop.admin
{
    partial class ABMComisionesDesktop {
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
            this.cbEsp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.DescLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRedDesc = new System.Windows.Forms.Label();
            this.lblRedPlan = new System.Windows.Forms.Label();
            this.cbPlan = new System.Windows.Forms.ComboBox();
            this.labelID = new System.Windows.Forms.Label();
            this.nudAnio = new System.Windows.Forms.NumericUpDown();
            this.lblRedAnio = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // cbEsp
            // 
            this.cbEsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEsp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEsp.FormattingEnabled = true;
            this.cbEsp.Location = new System.Drawing.Point(93, 93);
            this.cbEsp.Name = "cbEsp";
            this.cbEsp.Size = new System.Drawing.Size(98, 21);
            this.cbEsp.TabIndex = 18;
            this.cbEsp.SelectedValueChanged += new System.EventHandler(this.cbEsp_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Plan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Año";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAceptar.Location = new System.Drawing.Point(197, 133);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(98, 24);
            this.btnAceptar.TabIndex = 23;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtDescripcion
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescripcion, 2);
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Location = new System.Drawing.Point(93, 43);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(202, 20);
            this.txtDescripcion.TabIndex = 13;
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescLabel.Location = new System.Drawing.Point(12, 40);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(66, 25);
            this.DescLabel.TabIndex = 12;
            this.DescLabel.Text = "Descripcion";
            this.DescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDLabel.Location = new System.Drawing.Point(12, 15);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(66, 25);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "ID";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.tableLayoutPanel1.Controls.Add(this.DescLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.IDLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbEsp, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblRedDesc, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblRedPlan, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbPlan, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudAnio, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblRedAnio, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(316, 160);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblRedDesc
            // 
            this.lblRedDesc.AutoSize = true;
            this.lblRedDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRedDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedDesc.ForeColor = System.Drawing.Color.Red;
            this.lblRedDesc.Location = new System.Drawing.Point(301, 40);
            this.lblRedDesc.Name = "lblRedDesc";
            this.lblRedDesc.Size = new System.Drawing.Size(12, 25);
            this.lblRedDesc.TabIndex = 20;
            this.lblRedDesc.Text = "*";
            this.lblRedDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRedPlan
            // 
            this.lblRedPlan.AutoSize = true;
            this.lblRedPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRedPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedPlan.ForeColor = System.Drawing.Color.Red;
            this.lblRedPlan.Location = new System.Drawing.Point(301, 90);
            this.lblRedPlan.Name = "lblRedPlan";
            this.lblRedPlan.Size = new System.Drawing.Size(12, 25);
            this.lblRedPlan.TabIndex = 21;
            this.lblRedPlan.Text = "*";
            this.lblRedPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbPlan
            // 
            this.cbPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.Location = new System.Drawing.Point(197, 93);
            this.cbPlan.Name = "cbPlan";
            this.cbPlan.Size = new System.Drawing.Size(98, 21);
            this.cbPlan.TabIndex = 22;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelID.Location = new System.Drawing.Point(93, 15);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(98, 25);
            this.labelID.TabIndex = 23;
            this.labelID.Text = "-";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudAnio
            // 
            this.nudAnio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudAnio.Location = new System.Drawing.Point(93, 68);
            this.nudAnio.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudAnio.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(98, 20);
            this.nudAnio.TabIndex = 14;
            this.nudAnio.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // lblRedAnio
            // 
            this.lblRedAnio.AutoSize = true;
            this.lblRedAnio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRedAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedAnio.ForeColor = System.Drawing.Color.Red;
            this.lblRedAnio.Location = new System.Drawing.Point(197, 65);
            this.lblRedAnio.Name = "lblRedAnio";
            this.lblRedAnio.Size = new System.Drawing.Size(98, 25);
            this.lblRedAnio.TabIndex = 19;
            this.lblRedAnio.Text = "*";
            this.lblRedAnio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ABMComisionesDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 160);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ABMComisionesDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ComisionDesktop";
            this.Load += new System.EventHandler(this.ComisionDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEsp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRedDesc;
        private System.Windows.Forms.Label lblRedPlan;
        private System.Windows.Forms.Label lblRedAnio;
        private System.Windows.Forms.ComboBox cbPlan;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.NumericUpDown nudAnio;
    }
}