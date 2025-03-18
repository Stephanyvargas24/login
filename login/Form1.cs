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
using System.Data.SqlClient;

namespace login
{
    public partial class Form1 : Form
    {
        private bool vShowPass = false;//variable para condicionar si se vera o no el password
        public Form1()
        {
            InitializeComponent();
        }
        public void Login()
        {
            //creamos la liga de conexion entre nuestro servidoy y VS
            SqlConnection conexion = new SqlConnection(@"server=STEPHANY\SQLEXPRESS ; database = miLogin ; INTEGRATED SECURITY = true");
            conexion.Open();//abrimos la conexion

            SqlCommand cmd = new SqlCommand("SELECT Usser, Pass From miRegistro WHERE Usser = @vUsser AND Pass = @vPass", conexion);
            cmd.Parameters.AddWithValue("@vUsser", txtUser.Text.Trim());
            cmd.Parameters.AddWithValue("@vPass", txtPass.Text.Trim());

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read()) 
            {
                conexion.Close();
                MessageBox.Show("Login Exitoso");
                Form2 index = new Form2();
                index.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error no se encontraron los datos");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Login();
            //if(txtUser.Text == "Admin" && txtPass.Text == "2412")
            //{
            //    Form2 form2 = new Form2();
            //    form2.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Login Failed");

            //}
        }

        private void lklblRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegistro registro = new FormRegistro();//creamos una instancia al formulario que nos mandara para crear un nuevo usuario
            registro.Show();//mostramos el formulario
            this.Hide();//ocultamos el formulario actual
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            /* condicion para decirle al sistema que si el texto de la Texbox es igual a example@domain.com 
             entonces borrara el texto y el nuevo texto se escribira en negro*/
            if(txtUser.Text == "example@domain.com")
            {
                txtUser.Text = "";
                txtPass.ForeColor = Color.Black;
            }
        }
        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "example@domain.com";
                txtUser.ForeColor = Color.Gray;
            }

        }

        private void pbOjo_Click(object sender, EventArgs e)
        {
            vShowPass = !vShowPass;

            if (vShowPass)
            {
                txtPass.PasswordChar = '\0';
                pbOjo.Image = login.Properties.Resources.cerrado;
            }
            else
            {
                txtPass.PasswordChar = 'x';
                pbOjo.Image = login.Properties.Resources.abierto;
            }
        }
    }
}
