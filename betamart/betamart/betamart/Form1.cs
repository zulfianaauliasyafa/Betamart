using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace betamart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        pictureBox.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                productsBindingSource.ResetBindings(false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                txtProductName.Focus();
                this.appData.Products.AddProductsRow(this.appData.Products.NewProductsRow());
                productsBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            txtProductName.Focus();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            productsBindingSource.ResetBindings(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                productsBindingSource.EndEdit();
                productsTableAdapter.Update(this.appData.Products);
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                productsBindingSource.ResetBindings(false);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)30)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                    dataGridView.DataSource = productsBindingSource;
                else
                {
                    var query = from o in this.appData.Products
                                where o.ProductName.Contains(txtSearch.Text) || o.Type == txtSearch.Text || o.Price == txtSearch.Text || o.Size.Contains(txtSearch.Text)
                                select o;
                    dataGridView.DataSource = query.ToList();
                }
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete)
            {
                if (MessageBox.Show("Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    productsBindingSource.RemoveCurrent();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appData.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.appData.Products);
            productsBindingSource.DataSource = this.appData.Products;
        }

        
    }
}
