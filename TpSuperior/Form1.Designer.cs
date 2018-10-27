﻿namespace TpSuperior
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
            this.btnContinuar = new System.Windows.Forms.Button();
            this.cmbMetodo = new System.Windows.Forms.ComboBox();
            this.txtMetodo = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.TextBox();
            this.dgvUnknowns = new System.Windows.Forms.DataGridView();
            this.dgvInitialVector = new System.Windows.Forms.DataGridView();
            this.btnRename = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNorm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrixN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnknowns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInitialVector)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateMatrix
            // 
            this.btnGenerateMatrix.Location = new System.Drawing.Point(713, 23);
            this.btnGenerateMatrix.Name = "btnGenerateMatrix";
            this.btnGenerateMatrix.Size = new System.Drawing.Size(108, 50);
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
            this.dgvMatrix.Size = new System.Drawing.Size(576, 231);
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
            this.txtMatrixN.ValueChanged += new System.EventHandler(this.txtMatrixN_ValueChanged);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(716, 342);
            this.btnContinuar.Margin = new System.Windows.Forms.Padding(2);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(108, 48);
            this.btnContinuar.TabIndex = 40;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // cmbMetodo
            // 
            this.cmbMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodo.Location = new System.Drawing.Point(133, 20);
            this.cmbMetodo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMetodo.Name = "cmbMetodo";
            this.cmbMetodo.Size = new System.Drawing.Size(128, 21);
            this.cmbMetodo.TabIndex = 43;
            this.cmbMetodo.SelectedIndexChanged += new System.EventHandler(this.cmbMetodo_SelectedIndexChanged);
            // 
            // txtMetodo
            // 
            this.txtMetodo.AutoSize = true;
            this.txtMetodo.Location = new System.Drawing.Point(11, 23);
            this.txtMetodo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtMetodo.Name = "txtMetodo";
            this.txtMetodo.Size = new System.Drawing.Size(109, 13);
            this.txtMetodo.TabIndex = 42;
            this.txtMetodo.Text = "Seleccione el metodo";
            this.txtMetodo.Click += new System.EventHandler(this.txtMetodo_Click);
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(595, 50);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(112, 20);
            this.txtError.TabIndex = 44;
            // 
            // dgvUnknowns
            // 
            this.dgvUnknowns.AllowUserToAddRows = false;
            this.dgvUnknowns.AllowUserToDeleteRows = false;
            this.dgvUnknowns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnknowns.Location = new System.Drawing.Point(596, 92);
            this.dgvUnknowns.Name = "dgvUnknowns";
            this.dgvUnknowns.Size = new System.Drawing.Size(111, 231);
            this.dgvUnknowns.TabIndex = 45;
            this.dgvUnknowns.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgvInitialVector
            // 
            this.dgvInitialVector.AllowUserToAddRows = false;
            this.dgvInitialVector.AllowUserToDeleteRows = false;
            this.dgvInitialVector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInitialVector.Location = new System.Drawing.Point(713, 92);
            this.dgvInitialVector.Name = "dgvInitialVector";
            this.dgvInitialVector.Size = new System.Drawing.Size(111, 231);
            this.dgvInitialVector.TabIndex = 46;
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(596, 342);
            this.btnRename.Margin = new System.Windows.Forms.Padding(2);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(111, 48);
            this.btnRename.TabIndex = 47;
            this.btnRename.Text = "Renombrar incognitas";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Seleccione las dimensiones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Seleccione el error";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbNorm
            // 
            this.cmbNorm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNorm.Location = new System.Drawing.Point(133, 49);
            this.cmbNorm.Margin = new System.Windows.Forms.Padding(2);
            this.cmbNorm.Name = "cmbNorm";
            this.cmbNorm.Size = new System.Drawing.Size(128, 21);
            this.cmbNorm.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Seleccione la norma";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 402);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNorm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.dgvInitialVector);
            this.Controls.Add(this.dgvUnknowns);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.txtMetodo);
            this.Controls.Add(this.cmbMetodo);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.txtMatrixN);
            this.Controls.Add(this.dgvMatrix);
            this.Controls.Add(this.btnGenerateMatrix);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrixN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnknowns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInitialVector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateMatrix;
        private System.Windows.Forms.DataGridView dgvMatrix;
        private System.Windows.Forms.NumericUpDown txtMatrixN;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.ComboBox cmbMetodo;
        private System.Windows.Forms.Label txtMetodo;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.DataGridView dgvUnknowns;
        private System.Windows.Forms.DataGridView dgvInitialVector;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNorm;
        private System.Windows.Forms.Label label3;
    }
}

