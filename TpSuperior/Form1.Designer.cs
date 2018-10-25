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
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrixN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrixM)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateMatrix
            // 
            this.btnGenerateMatrix.Location = new System.Drawing.Point(713, 23);
            this.btnGenerateMatrix.Name = "btnGenerateMatrix";
            this.btnGenerateMatrix.Size = new System.Drawing.Size(75, 50);
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
            this.dgvMatrix.Location = new System.Drawing.Point(13, 92);
            this.dgvMatrix.Name = "dgvMatrix";
            this.dgvMatrix.Size = new System.Drawing.Size(775, 231);
            this.dgvMatrix.TabIndex = 3;
            this.dgvMatrix.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.matrix_CellContentClick);
            // 
            // txtMatrixN
            // 
            this.txtMatrixN.Location = new System.Drawing.Point(595, 23);
            this.txtMatrixN.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtMatrixN.Name = "txtMatrixN";
            this.txtMatrixN.Size = new System.Drawing.Size(112, 20);
            this.txtMatrixN.TabIndex = 36;
            // 
            // txtMatrixM
            // 
            this.txtMatrixM.Location = new System.Drawing.Point(595, 53);
            this.txtMatrixM.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtMatrixM.Name = "txtMatrixM";
            this.txtMatrixM.Size = new System.Drawing.Size(112, 20);
            this.txtMatrixM.TabIndex = 37;
            this.txtMatrixM.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMatrixM);
            this.Controls.Add(this.txtMatrixN);
            this.Controls.Add(this.dgvMatrix);
            this.Controls.Add(this.btnGenerateMatrix);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrixN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrixM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateMatrix;
        private System.Windows.Forms.DataGridView dgvMatrix;
        private System.Windows.Forms.NumericUpDown txtMatrixN;
        private System.Windows.Forms.NumericUpDown txtMatrixM;
    }
}

