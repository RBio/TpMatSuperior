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
            for (int i = 0; i < n; ++i)
            {
                dgvMatrix.Columns.Add("X" + dgvMatrix.Columns.Count, "X" + dgvMatrix.Columns.Count);
                dgvMatrix.Rows.Add();
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
            lr = Matrix<double>.Build.Dense(dgvMatrix.RowCount, 1);
            r = getIC();
            if (matrixFullAndDiagonal())
            {
                m = buildMatrix();
                while ((r - lr).L2Norm() > error)
                {
                   if (method == "Jacobi")
                    {
                        lr = r;
                        T = jacobiTMatrix(m);
                        C = jacobiCMatrix(m);
                        r = T * r + C;
                    }
                    else
                    {
                        //T = GSTMatrix(m);
                        //C = GSCMatrix(m);
                    }

                }
                mostrarResultado(r);
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
            return Matrix<double>.Build.Dense(dgvMatrix.RowCount, dgvMatrix.ColumnCount - 1, (i, j) => getInverseMatrixValue(i, j, m));
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
        private void mostrarResultado(Matrix<double> r)
        {
            string result = "";
            for (int i = 0; i < r.RowCount; ++i)
                result += r.Row(i).At(0);
            MessageBox.Show("El resultado es " + result);
        }
    }
}
