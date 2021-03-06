﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace TpSuperior
{
    public partial class Form1 : Form
    {
        string method = "Jacobi";
        string matrixType = "diagonal";
        string norm = "2";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbMetodo.Items.Add("Jacobi");
            cmbMetodo.Items.Add("Gauss-Seidel");
            cmbMetodo.SelectedItem = "Jacobi";
            cmbNorm.Items.Add("1");
            cmbNorm.Items.Add("2");
            cmbNorm.Items.Add("Infinito");
            cmbNorm.SelectedItem = "2";
            cmbDiagonal.Items.Add("Diagonalmente dominante");
            cmbDiagonal.Items.Add("Estrictamente diagonalmente dominante");
            cmbDiagonal.SelectedItem = "Diagonalmente dominante";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            clearDgvs();
            decimal n = txtMatrixN.Value;
            dgvUnknowns.Columns.Add("I", "Incognitas");
            dgvInitialVector.Columns.Add("VI", "Vector inicial");
            for (int i = 0; i < n; ++i)
            {
                dgvUnknowns.Rows.Add("X" + dgvMatrix.Columns.Count, "X" + dgvMatrix.Columns.Count);
                dgvMatrix.Columns.Add("X" + dgvMatrix.Columns.Count, "X" + dgvMatrix.Columns.Count);
                dgvMatrix.Rows.Add();
                dgvInitialVector.Rows.Add("0");
            }
            dgvMatrix.Columns.Add("TI" ,"Terminos independientes");
        }

        private void matrix_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void txtMatrixN_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            Matrix<double> T, r, lr, C, m;
            double error;
            bool firstTry = true;
            txtError.Text = txtError.Text.Replace(".", ",");
            normalizeMatrixValues();

            if (!validError())
                return;

            if (matrixFullAndDiagonal() && validInitialVector())
            {
                initializeProcedureMatrix();
                r = getInitialVector();
                lr = Matrix<double>.Build.Dense(dgvMatrix.RowCount, 1);
                error = Convert.ToDouble(txtError.Text);

                if (error <= 0)
                {
                    MessageBox.Show("Ingrese un error mayor a 0");
                    return;
                }

                m = buildMatrix();
                if (method == "Jacobi")
                {
                    T = jacobiTMatrix(m);
                    C = jacobiCMatrix(m);
                }
                else
                {
                    T = GSTMatrix(m);
                    C = GSCMatrix(m);
                }
                double tNorm = selectedNorm(T);
                if (tNorm >= 1)
                {
                    MessageBox.Show("La norma de la matriz T es: " + selectedNorm(T) + ", no se puede asegurar la convergencia del metodo.");
                    return;
                }
                MessageBox.Show("La norma de la matriz T es: " + selectedNorm(T));
                while ((r - lr).L2Norm() > error || firstTry)
                {
                   firstTry = false;
                    lr = r;
                    r = T * r + C;
                    printStep(r, (r - lr).L2Norm());
                }
                mostrarResultado(r);
            }
        }

        private void cmbMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodo.SelectedItem == null)
                return;
            if (cmbMetodo.SelectedItem.ToString() == "Gauss-Seidel")
                method = "Gauss-Seidel";
            else
                method = "Jacobi";
        }

        private void txtMetodo_Click(object sender, EventArgs e)
        {

        }
        private Matrix<double> buildMatrix()
        {
            return Matrix<double>.Build.Dense(dgvMatrix.RowCount, dgvMatrix.ColumnCount - 1, (i, j) => getDgvValue(i,j, dgvMatrix));
        }
        private double getDgvValue(int i, int j, DataGridView matrix)
        {
            return Convert.ToDouble(matrix.Rows[i].Cells[j].Value);
        }
        private bool matrixFullAndDiagonal()
        {
            if (dgvMatrix.RowCount < 2)
            {
                MessageBox.Show("Ingrese un sistema de ecuaciones");
                return false;
            }
            for (int i = 0; i < dgvMatrix.RowCount; ++i)
                for (int j = 0; j < dgvMatrix.ColumnCount; ++j)
                {
                    if (dgvMatrix.Rows[i].Cells[j].Value == null)
                    {
                        MessageBox.Show("Complete la matriz para continuar");
                        return false;
                    }
                    dgvMatrix.Rows[i].Cells[j].Value = dgvMatrix.Rows[i].Cells[j].Value.ToString().Replace(".", ",");
                    if (i == j && !rowMax(i, j))
                        return false;
                }

            return true;
        }
        private Matrix<double> getIC()
        {
            return Matrix<double>.Build.Dense(dgvMatrix.RowCount, 1, (i, j) => getDgvValue(i, dgvMatrix.ColumnCount - 1, dgvMatrix));
        }
        private bool rowMax(int i, int j)
        {
            double testValue, testMax;

            if (!validStringNumber(dgvMatrix.Rows[i].Cells[j].Value.ToString()))
            {
                MessageBox.Show("Complete la matriz con numeros validos");
                return false;
            }

            testMax = Math.Abs(Convert.ToDouble(dgvMatrix.Rows[i].Cells[j].Value));
            for (int k = 0; k < dgvMatrix.ColumnCount - 1; ++k)
            {
                if (k == j)
                    continue;

                if (!validStringNumber(dgvMatrix.Rows[i].Cells[k].Value.ToString()))
                {
                    MessageBox.Show("Complete la matriz con numeros validos");
                    return false;
                }

                testValue = Convert.ToDouble(dgvMatrix.Rows[i].Cells[k].Value);
                if (matrixType == "diagonal")
                {
                    if (Math.Abs(testValue) > testMax)
                    {
                        MessageBox.Show("La matriz no es diagonal dominante. El valor de la fila " + i + " columna " + k + " es mayor que el de la diagonal.");
                        return false;
                    }
                }
                else
                {
                    if (Math.Abs(testValue) >= testMax)
                    {
                        MessageBox.Show("La matriz no es estrictamente diagonal dominante. El valor de la fila " + i + " columna " + k + " es mayor o igual que el de la diagonal.");
                        return false;
                    }
                }
                    
            }
            return true;
        }
        private Matrix<double> jacobiTMatrix(Matrix<double> m)
        {
            return invertedMatrix(diagonalMatrix(m)) * (diagonalWithZeroes(m.LowerTriangle() * -1) + diagonalWithZeroes(m.UpperTriangle() * -1)); 
        }
        private bool validStringNumber(string number)
        {
            double n = 0;
            return double.TryParse(number, out n);
        }
        private Matrix<double> diagonalMatrix(Matrix<double> m)
        {
            Matrix<double> a = Matrix<double>.Build.Dense(m.RowCount, m.ColumnCount);
            a.SetDiagonal(m.Diagonal());
            return a;
        }
        private bool validError()
        {
            if (!validStringNumber(txtError.Text))
            {
                MessageBox.Show("Ingrese un error valido");
                return false;
            }
            if (Convert.ToDouble(txtError.Text) < 0)
            {
                MessageBox.Show("Ingrese un error mayor a 0.");
                return false;
            }
            return true;
        }
        private void normalizeMatrixValues()
        {
            for (int i = 0; i < dgvMatrix.RowCount; ++i)
            {
                normalizeCellStringNumber(dgvInitialVector.Rows[i].Cells[0]);
                for (int j = 0; j < dgvMatrix.ColumnCount; ++j)
                    if (dgvMatrix.Rows[i].Cells[j].Value != null)
                        normalizeCellStringNumber(dgvMatrix.Rows[i].Cells[j]);
            }
        }
        private void normalizeCellStringNumber(DataGridViewCell cell)
        {
            cell.Value = cell.Value.ToString().Replace(".", ",");
        }
        private Matrix<double> invertedMatrix(Matrix<double> m)
        {
            Matrix<double> aux = m;
            return aux.Inverse();
        }
        private double getInverseMatrixValue(int i, int j, Matrix<double> m)
        {
            double cellValue = Convert.ToDouble(m.Row(i).At(j));
            if (cellValue != 0)
                return 1.0/Convert.ToDouble(m.Row(i).At(j));
            return 0;
        }
        private Matrix<double> jacobiCMatrix(Matrix<double> m)
        {
            return invertedMatrix(diagonalMatrix(m)) * getIC();
        }
        private Matrix<double> diagonalWithZeroes(Matrix<double> m)
        {
            m.SetDiagonal(Vector.Build.Dense(m.RowCount));
            return m;
        }
        private double selectedNorm(Matrix<double> r)
        {
            if (norm == "2")
                return r.L2Norm();
            else if (norm == "Infinito")
                return r.InfinityNorm();
            return r.L1Norm();
        }
        private Matrix<double> GSTMatrix(Matrix<double> m)
        {
            return invertedMatrix(diagonalMatrix(m) - diagonalWithZeroes(m.LowerTriangle() * -1)) * diagonalWithZeroes(m.UpperTriangle() * -1);
        }
        private Matrix<double> GSCMatrix(Matrix<double> m)
        {
            return invertedMatrix(diagonalMatrix(m) - diagonalWithZeroes(m.LowerTriangle() * -1)) * getIC();
        }
        private void mostrarResultado(Matrix<double> r)
        {
            string resultVariables = "(";
            string resultNumbers = "(";
            for (int i = 0; i < r.RowCount; ++i)
            {
                resultVariables += dgvMatrix.Columns[i].HeaderText + "; ";
                resultNumbers += Math.Round(r.Row(i).At(0), Convert.ToInt32(txtDecimals.Value), MidpointRounding.AwayFromZero).ToString() + "; ";
            }
            MessageBox.Show("El resultado es " + resultVariables.Substring(0, resultVariables.Length - 2) + ") = " + resultNumbers.Substring(0, resultNumbers.Length - 2) + ")");
        }
        private void clearDgvs()
        {
            dgvMatrix.Rows.Clear();
            dgvMatrix.Columns.Clear();
            dgvMatrix.Refresh();
            dgvUnknowns.Rows.Clear();
            dgvUnknowns.Columns.Clear();
            dgvUnknowns.Refresh();
            dgvInitialVector.Rows.Clear();
            dgvInitialVector.Columns.Clear();
            dgvInitialVector.Refresh();
        }
        private Matrix<double> getInitialVector()
        {
           return Matrix<double>.Build.Dense(dgvMatrix.RowCount, 1, (i, j) => getDgvValue(i, 0, dgvInitialVector));
        }

        private bool invalidInitialVector()
        {
            for (int i = 0; i < dgvInitialVector.RowCount; ++i)
                if (dgvInitialVector.Rows[i].Cells[0].Value == null)
                    return true;

            return false;
        }

        private void txtMatrixN_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dgvMatrix.ColumnCount - 1; ++i)
            {
                if (dgvUnknowns.Rows[i].Cells[0].Value == null)
                {
                    MessageBox.Show("Ingrese nombres de variables validos");
                    return;
                }
                dgvMatrix.Columns[i].HeaderText = dgvUnknowns.Rows[i].Cells[0].Value.ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbNorm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNorm.SelectedItem == null)
                return;
            if (cmbNorm.SelectedItem.ToString() == "1")
                norm = "1";
            else if (cmbNorm.SelectedItem.ToString() == "2")
                norm = "2";
            else
                norm = "Infinito";
        }

        private bool validInitialVector()
        {
            for (int i = 0; i < dgvInitialVector.RowCount; ++i)
            {
                if (dgvInitialVector.Rows[i].Cells[0].Value == null || !validStringNumber(dgvInitialVector.Rows[i].Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Ingrese un vector inicial valido");
                    return false;
                }
            }
            return true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void cmbDiagonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDiagonal.SelectedItem == null)
                return;
            if (cmbDiagonal.SelectedItem.ToString() == "Diagonalmente dominante")
                matrixType = "diagonal";
            else
                matrixType = "estrictamente diagonal";
        }
        private void initializeProcedureMatrix()
        {
            dgvProcedure.Rows.Clear();
            dgvProcedure.Columns.Clear();

            for (int i = 0; i < dgvMatrix.ColumnCount - 1; ++i)
                dgvProcedure.Columns.Add(dgvMatrix.Columns[i].HeaderText, dgvMatrix.Columns[i].HeaderText);

            dgvProcedure.Columns.Add("CP", "Criterio de paro");
            dgvProcedure.Columns[dgvProcedure.ColumnCount - 1].Width += 30;
        }
        private void printStep(Matrix<double> r, double error)
        {
            dgvProcedure.Rows.Add();

            for (int i = 0; i < dgvProcedure.ColumnCount - 1; ++i)
                dgvProcedure.Rows[dgvProcedure.RowCount - 1].Cells[i].Value = Math.Round(r.Row(i).At(0), Convert.ToInt32(txtDecimals.Value));

            dgvProcedure.Rows[dgvProcedure.RowCount - 1].Cells[dgvProcedure.ColumnCount - 1].Value = error;
        }
    }
}
