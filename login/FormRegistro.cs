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

namespace login
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void btnConfis_Click(object sender, EventArgs e)
        {
            Registro();
            if (txtContrasena.Text == txtConfirma.Text)
            {
                MessageBox.Show("You've signed a new user", "NEW REGISTER", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("you've entered incorrect login details", "ERROR", MessageBoxButtons.OK);

            }
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }

        private void Registro()
        {
            SqlConnection conexion = new SqlConnection(@"server=STEPHANY\SQLEXPRESS ; database = miLogin ; INTEGRATED SECURITY = true");
            conexion.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO miRegistro (IDUser, Usser, Pass) VALUES ('" + txtID.Text.Trim() + "', '" + txtName.Text.Trim() + "', '" + txtContrasena.Text.Trim() + "')", conexion);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

    }
}


