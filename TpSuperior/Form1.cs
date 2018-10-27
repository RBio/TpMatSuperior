using System;
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
            double error = Convert.ToDouble(txtError.Text);
            bool firstTry = true;
            lr = Matrix<double>.Build.Dense(dgvMatrix.RowCount, 1);
            r = getInitialVector();
            if (matrixFullAndDiagonal())
            {
                m = buildMatrix();
                while (selectedNorm(r - lr) > error || firstTry)
                {
                    firstTry = false;
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
                    Console.WriteLine(r);
                    lr = r;
                    r = T * r + C;
                    Console.WriteLine(r);
                    Console.WriteLine(T);
                    Console.WriteLine(C);
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
            for (int i = 0; i < dgvMatrix.RowCount; ++i)
                for (int j = 0; j < dgvMatrix.ColumnCount; ++j)
                    if (dgvMatrix.Rows[i].Cells[j].Value == null)
                    {
                        MessageBox.Show("Complete la matriz para continuar");
                        return false;
                    }
                    else if (i == j && !rowMax(i, j))
                        return false;

            return true;
        }
        private Matrix<double> getIC()
        {
            return Matrix<double>.Build.Dense(dgvMatrix.RowCount, 1, (i, j) => getDgvValue(i, dgvMatrix.ColumnCount - 1, dgvMatrix));
        }
        private bool rowMax(int i, int j)
        {
            double testValue, testMax;
            testMax = Math.Abs(Convert.ToDouble(dgvMatrix.Rows[i].Cells[j].Value));
            for (int k = 0; k < dgvMatrix.ColumnCount - 1; ++k)
            {
                if (k == j)
                    continue;
                testValue = Convert.ToDouble(dgvMatrix.Rows[i].Cells[k].Value);
                if (matrixType == "diagonal")
                {
                    if (Math.Abs(testValue) >= testMax)
                    {
                        MessageBox.Show("La matriz no es diagonal dominante");
                        return false;
                    }
                }
                else
                {
                    if (testValue > testMax)
                    {
                        MessageBox.Show("La matriz no es estrictamente diagonal dominante");
                        return false;
                    }
                }
                    
            }
            return true;
        }
        private Matrix<double> jacobiTMatrix(Matrix<double> m)
        {
            return reciprocalMatrix(diagonalMatrix(m)) * (diagonalWithZeroes(m.LowerTriangle() * -1) + diagonalWithZeroes(m.UpperTriangle() * -1)); 
        }
        private Matrix<double> diagonalMatrix(Matrix<double> m)
        {
            Matrix<double> a = Matrix<double>.Build.Dense(m.RowCount, m.ColumnCount);
            a.SetDiagonal(m.Diagonal());
            return a;
        }
        private Matrix<double> reciprocalMatrix(Matrix<double> m)
        {
            return Matrix<double>.Build.Dense(m.RowCount, m.ColumnCount, (i, j) => getInverseMatrixValue(i, j, m));
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
            return reciprocalMatrix(diagonalMatrix(m)) * getIC();
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
            return reciprocalMatrix(diagonalMatrix(m) - diagonalWithZeroes(m.LowerTriangle() * -1)) * diagonalWithZeroes(m.UpperTriangle() * -1);
        }
        private Matrix<double> GSCMatrix(Matrix<double> m)
        {
            return reciprocalMatrix(diagonalMatrix(m) - diagonalWithZeroes(m.LowerTriangle() * -1)) * getIC();
        }
        private void mostrarResultado(Matrix<double> r)
        {
            string result = "(";
            for (int i = 0; i < r.RowCount; ++i)
                result += r.Row(i).At(0).ToString() + ", ";
            MessageBox.Show("El resultado es " + result.Substring(0, result.Length - 2) + ")");
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
                dgvMatrix.Columns[i].HeaderText = dgvUnknowns.Rows[i].Cells[0].Value.ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
