using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class TkaniForm : Form
    {

        SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnectionSettings);

        WareForm ware;
        DataSet ds;
        SqlDataAdapter sda;

        public TkaniForm()
        {
            InitializeComponent();
        }

        private void TkaniForm_Load(object sender, EventArgs e)
        {
           String query = "SELECT * FROM tkani";
           sda = new SqlDataAdapter(query, connection);
           ds = new DataSet();
           sda.Fill(ds, "tkani");
           dataGridView1.DataSource = ds.Tables["tkani"];
        
            DataGridViewImageColumn abc = new DataGridViewImageColumn();
            abc.Name = "img";
            abc.HeaderText = "Картинка";
            dataGridView1.Columns.Add(abc);
            for(int i =0; i<dataGridView1.RowCount;i++) 
            { 
                if(dataGridView1.Rows[i].Cells[1].Value != null) 
                { 
                    string basePath = @"C:\Users\User8\Downloads\demo27042019-8292b8bc90d94025bbd2302114d3c647be001c4c\App\images\tkani\";
                    string filename = dataGridView1.Rows[i].Cells[1].Value + ".jpg";
                    string fullPath = basePath + filename;
                    Image image; 
                    if(File.Exists(fullPath)) 
                    { 
                        image = Image.FromFile(fullPath); 
                    }else 
                    { 
                        image = Image.FromFile(basePath+ "Untitled.jpg"); 
                    }
                    dataGridView1.Rows[i].Cells["img"].Value = image; 
                };
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ware = new WareForm();
            ware.Show();
        }
    
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet changes = this.ds.GetChanges();
            if(changes !=null)
            {
                int updatesRows = this.sda.Update(changes);
                this.ds.AcceptChanges();
            }
        }
    }
}
