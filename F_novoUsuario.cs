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
    public partial class F_novoUsuario : Form
    {
        public F_novoUsuario()
        {
            InitializeComponent();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            tb_Nome.Clear();
            tb_username.Clear();
            tb_password.Clear();
            nup_Level.Value = 1;
            tb_Nome.Focus();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.T_USERNAME = tb_username.Text;
            user.T_NOME = tb_Nome.Text;
            user.T_PASSWORD = tb_password.Text;
            user.N_USERLEVEL = Convert.ToInt32(Math.Round(nup_Level.Value, 0));

            Banco.newUser(user);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tb_Nome.Clear();
            tb_username.Clear();
            tb_password.Clear();
            nup_Level.Value = 1;
            tb_Nome.Focus();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
