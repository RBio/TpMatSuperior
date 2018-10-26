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

namespace TpSuperior
{
    public partial class Form1 : Form
    {
        string method = "Jacobi";
        string matrixType = "diagonal";
        Matrix<double> solutionVector;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbMetodo.Items.Add("Metodo de Jacobi");
            cmbMetodo.Items.Add("Metodo de Gauss-Seidel");
            cmbMetodo.SelectedItem = "Metodo de Jacobi";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvMatrix.Rows.Clear();
            dgvMatrix.Columns.Clear();
            dgvMatrix
                .Refresh();
            decimal n = txtMatrixN.Value;
            decimal m = txtMatrixM.Value;
            for (int j = 0; j < m; ++j)
            {
                dgvMatrix.Columns.Add("X" + dgvMatrix.Columns.Count, "X" + dgvMatrix.Columns.Count);
            }
            dgvMatrix.Columns.Add("TI" ,"Terminos independientes");
            for (int i = 0; i < n; ++i)
            {
                dgvMatrix.Rows.Add();
            }

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
            Matrix<double> T, r, C, m;
            if (matrixFullAndDiagonal())
            {
               r = getIC();
               m = buildMatrix();
               if (method == "Jacobi")
                {
                    T = jacobiTMatrix(m);
                    C = jacobiCMatrix(m);
                }
                else
                {
                    //T = GSTMatrix(m);
                    //C = GSCMatrix(m);
                }
                //solutionVector = T * r + C;
            }
        }

        private void cmbMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMetodo_Click(object sender, EventArgs e)
        {

        }
        private Matrix<double> buildMatrix()
        {
            return Matrix<double>.Build.Dense(dgvMatrix.RowCount, dgvMatrix.ColumnCount - 1, (i, j) => getDvgMatrixValue(i,j));
        }
        private double getDvgMatrixValue(int i, int j)
        {
            return Convert.ToDouble(dgvMatrix.Rows[i].Cells[j].Value);
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
            return Matrix<double>.Build.Dense(dgvMatrix.RowCount, 1, (i, j) => getDvgMatrixValue(i, dgvMatrix.ColumnCount - 1));
        }
        private bool rowMax(int i, int j)
        {
            double testValue, testMax;
            for (int k = 0; k < dgvMatrix.ColumnCount; ++k)
            {
                if (k == j)
                    continue;
                testValue = Convert.ToDouble(dgvMatrix.Rows[i].Cells[k].Value);
                testMax = Convert.ToDouble(dgvMatrix.Rows[i].Cells[j].Value);
                if (matrixType == "diagonal")
                {
                    if (testValue >= testMax)
                    {
                        MessageBox.Show("La matriz no es diagonal");
                        return false;
                    }
                }
                else
                {
                    if (testValue > testMax)
                    {
                        MessageBox.Show("La matriz no es estrictamente diagonal");
                        return false;
                    }
                }
                    
            }
            return true;
        }
        private Matrix<double> jacobiTMatrix(Matrix<double> m)
        {
            return reciprocalMatrix(diagonalMatrix(m)) * (m.LowerTriangle() + m.UpperTriangle()); 
        }
        private Matrix<double> diagonalMatrix(Matrix<double> m)
        {
            Matrix<double> a = Matrix<double>.Build.Dense(m.RowCount, m.ColumnCount);
            a.SetDiagonal(m.Diagonal());
            return a;
        }
        private Matrix<double> reciprocalMatrix(Matrix<double> m)
        {
            return Matrix<double>.Build.Dense(dgvMatrix.RowCount, dgvMatrix.ColumnCount - 1, (i, j) => 1/getMatrixValue(i, j, m));
        }
        private double getMatrixValue(int i, int j, Matrix<double> m)
        {
            return Convert.ToDouble(m.Row(i).At(j)); //Check this "At"
        }
        private Matrix<double> jacobiCMatrix(Matrix<double> m)
        {
            return reciprocalMatrix(diagonalMatrix(m)) * getIC();
        }
    }
}
