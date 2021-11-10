using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace betamart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:/sekolah/UKK/ukk/betamart/app.accdb");
        OleDbCommand cmd;
        OleDbDataReader dr;
        string sql;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name, price, type, size;
                name = txtname.Text;
                price = txtprice.Text;
                type = txttype.Text;
                size = txtsize.Text;

                sql = "Insertinto record(name, price, type, size)values(?,?,?)";
                cmd = new OleDbCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("price", price);
                cmd.Parameters.AddWithValue("type", type);
                cmd.Parameters.AddWithValue("size", size);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record added");
                con.Close();

                txtname.Clear();
                txtprice.Clear();
                txttype.Clear();
                txtsize.Clear();



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
