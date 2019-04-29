using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class UserForm : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnectionSettings);

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            String sql = "select * from izdelie";
            SqlDataAdapter sda = new SqlDataAdapter(sql, connection);      
            DataSet ds = new DataSet();          
            sda.Fill(ds, "izdelie");
             dataGridView1.DataSource = ds.Tables["izdelie"];
           

            

        }
    }
}
