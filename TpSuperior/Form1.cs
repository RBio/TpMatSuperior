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

namespace TpSuperior
{
    public partial class Form1 : Form
    {
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

        }

        private void cmbMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
