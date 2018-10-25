namespace TpSuperior
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerateMatrix = new System.Windows.Forms.Button();
            this.dgvMatrix = new System.Windows.Forms.DataGridView();
            this.txtMatrixN = new System.Windows.Forms.NumericUpDown();
            this.txtMatrixM = new System.Windows.Forms.NumericUpDown();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.cmbMetodo = new System.Windows.Forms.ComboBox();
            this.txtMetodo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrixN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrixM)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateMatrix
            // 
            this.btnGenerateMatrix.Location = new System.Drawing.Point(951, 28);
            this.btnGenerateMatrix.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateMatrix.Name = "btnGenerateMatrix";
            this.btnGenerateMatrix.Size = new System.Drawing.Size(100, 62);
            this.btnGenerateMatrix.TabIndex = 0;
            this.btnGenerateMatrix.Text = "Generar matriz";
            this.btnGenerateMatrix.UseVisualStyleBackColor = true;
            this.btnGenerateMatrix.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvMatrix
            // 
            this.dgvMatrix.AllowUserToAddRows = false;
            this.dgvMatrix.AllowUserToDeleteRows = false;
            this.dgvMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrix.Location = new System.Drawing.Point(17, 113);
            this.dgvMatrix.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMatrix.Name = "dgvMatrix";
            this.dgvMatrix.Size = new System.Drawing.Size(1033, 284);
            this.dgvMatrix.TabIndex = 3;
            this.dgvMatrix.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.matrix_CellContentClick);
            // 
            // txtMatrixN
            // 
            this.txtMatrixN.Location = new System.Drawing.Point(793, 28);
            this.txtMatrixN.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatrixN.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtMatrixN.Name = "txtMatrixN";
            this.txtMatrixN.Size = new System.Drawing.Size(149, 22);
            this.txtMatrixN.TabIndex = 36;
            // 
            // txtMatrixM
            // 
            this.txtMatrixM.Location = new System.Drawing.Point(793, 65);
            this.txtMatrixM.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatrixM.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtMatrixM.Name = "txtMatrixM";
            this.txtMatrixM.Size = new System.Drawing.Size(149, 22);
            this.txtMatrixM.TabIndex = 37;
            this.txtMatrixM.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Enabled = false;
            this.btnContinuar.Location = new System.Drawing.Point(951, 461);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(99, 59);
            this.btnContinuar.TabIndex = 40;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // cmbMetodo
            // 
            this.cmbMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodo.Location = new System.Drawing.Point(599, 28);
            this.cmbMetodo.Name = "cmbMetodo";
            this.cmbMetodo.Size = new System.Drawing.Size(169, 24);
            this.cmbMetodo.TabIndex = 43;
            this.cmbMetodo.SelectedIndexChanged += new System.EventHandler(this.cmbMetodo_SelectedIndexChanged);
            // 
            // txtMetodo
            // 
            this.txtMetodo.AutoSize = true;
            this.txtMetodo.Location = new System.Drawing.Point(438, 28);
            this.txtMetodo.Name = "txtMetodo";
            this.txtMetodo.Size = new System.Drawing.Size(143, 17);
            this.txtMetodo.TabIndex = 42;
            this.txtMetodo.Text = "Seleccione el metodo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.txtMetodo);
            this.Controls.Add(this.cmbMetodo);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.txtMatrixM);
            this.Controls.Add(this.txtMatrixN);
            this.Controls.Add(this.dgvMatrix);
            this.Controls.Add(this.btnGenerateMatrix);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrixN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrixM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateMatrix;
        private System.Windows.Forms.DataGridView dgvMatrix;
        private System.Windows.Forms.NumericUpDown txtMatrixN;
        private System.Windows.Forms.NumericUpDown txtMatrixM;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.ComboBox cmbMetodo;
        private System.Windows.Forms.Label txtMetodo;
    }
}

