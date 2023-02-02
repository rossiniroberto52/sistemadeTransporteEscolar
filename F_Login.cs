using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemadeTransporteEscolar
{
    public partial class F_Login : Form
    {
        Form1 form1;
        DataTable dt = new DataTable();
        public F_Login(Form1 f)
        {
            InitializeComponent();
            form1 = f;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text;
            string password = tb_password.Text;

            if(username == "" || password == "")
            {
                MessageBox.Show("Usuario e ou senha invalidos");
                tb_username.Focus();
                tb_username.Clear();
                tb_password.Clear();
                return;
            }

            string sql = "SELECT * FROM tb_users WHERE T_USERNAME = '" + username + "' AND T_PASSWORD = '" + password + "'";
            dt = Banco.consulta(sql);

            if(dt.Rows.Count == 1)
            {
                form1.label1.Text = "Nome: " + dt.Rows[0].Field<string>("T_USERNAME");
                form1.pictureBox1.Image = Properties.Resources.led_verde1;
                form1.label2.Text = "Nivel: " + dt.Rows[0].Field<Int64>("N_USERLEVEL");
                Global.UserLevel = (int)dt.Rows[0].Field<Int64>("N_USERLEVEL");
                Global.logado = true;
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
