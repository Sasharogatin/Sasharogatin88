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
    public partial class RegForm : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnectionSettings);
        Form auth; // null

        public RegForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int errors = 0;
            String message = "";

            if(textBox1.Text == "")
            {
                errors++;
                message += "Пожалуйста введите имя\n";
            }
            if (textBox2.Text == "")
            {
                errors++;
                message += "Пожалуйста введите логин\n";
            }
            if (textBox3.Text == "")
            {
                errors++;
                message += "Пожалуйста введите пароль\n";
            }

            if (textBox4.Text == "")
            {
                errors++;
                message += "Пожалуйста введите подтверждение пароля\n";
            }
            
            if(textBox3.Text != textBox4.Text)
            {
                errors++;
                message += "Пароли не совпадают!\n";
            }

            if(errors>0) {
                MessageBox.Show(message);
            } else {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO users (login,password,role,name) VALUES (@login,@password,@role,@name)",connection);
                    command.Parameters.AddWithValue("@login", textBox2.Text);
                    command.Parameters.AddWithValue("@password", textBox3.Text);
                    command.Parameters.AddWithValue("@role", "User");
                    command.Parameters.AddWithValue("@name", textBox1.Text);
                    int regged = Convert.ToInt32(command.ExecuteNonQuery());
                    connection.Close();
                    MessageBox.Show("Пользователь успешно зарегистрировался!\n");
                } catch
                {
                    MessageBox.Show("Такой пользователь существует!\n");

                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            auth = new AuthForm();
            auth.Show();
        }
    }
}
