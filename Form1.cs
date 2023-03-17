using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace sistemadeTransporteEscolar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            F_Login f_login = new F_Login(this); //user: admin; password: 123
            f_login.ShowDialog();
        }

        private void managementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.logado == true)
            {
                if(Global.UserLevel > 1)
                {

                }
                else
                {
                    MessageBox.Show("Você precisa de um nivel de acesso maior para acessar isso");
                }
            }
            else
            {
                MessageBox.Show("Você precisa estar logado para acessar");
            }
        }

        private void userManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_UserManagment f_userManagment = new F_UserManagment();
            f_userManagment.ShowDialog();
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.logado == true)
            {
                if (Global.UserLevel > 1)
                {
                    F_NovoAluno f_NovoAluno = new F_NovoAluno();
                    f_NovoAluno.ShowDialog();
                }
                else
                {
                    MessageBox.Show("você não tem nivel suficiente para isso!");
                }
            }
            else
            {
                MessageBox.Show("você tem que Logar-se primeiramente!");
            }
            
        }

        private void novoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_novoUsuario f_NovoUsuario = new F_novoUsuario();
            f_NovoUsuario.ShowDialog();
        }

        private void studentManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_StudentMananger f_StudentMananger = new F_StudentMananger();
            f_StudentMananger.ShowDialog();
        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_Login f_login = new F_Login(this); //user: admin; password: 123
            f_login.ShowDialog();
            
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.logado = false;
            Global.UserLevel = 0;
            pictureBox1.Image = Properties.Resources.led_vermelho1;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
