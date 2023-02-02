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
    public partial class F_UserManagment : Form
    {
        public F_UserManagment()
        {
            InitializeComponent();
        }

        private void dgv_usuarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contLinhas = dgv.SelectedRows.Count;
            if (contLinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt = Banco.ObterDadosUsers1(vid);
                tb_id.Text = dt.Rows[0].Field<Int64>("N_IDUSER").ToString();
                tb_Nome.Text = dt.Rows[0].Field<string>("T_NOMEUSER").ToString();
                tb_username.Text = dt.Rows[0].Field<string>("T_USERNAME").ToString();
                tb_password.Text = dt.Rows[0].Field<string>("T_PASSWORD").ToString();
                cb_Status.Text = dt.Rows[0].Field<string>("T_STATUSUSER").ToString();
                nup_Level.Value = dt.Rows[0].Field<Int64>("N_USERLEVEL");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_novoUsuario f_NovoUsuario = new F_novoUsuario();
            f_NovoUsuario.ShowDialog();
            dgv_usuarios.DataSource = Banco.ObterUsersIdNome();
        }

        private void F_UserManagment_Load(object sender, EventArgs e)
        {
            dgv_usuarios.DataSource = Banco.ObterUsersIdNome();
            dgv_usuarios.Columns[0].Width = 85;
            dgv_usuarios.Columns[1].Width = 190;
        }

        private void dgv_usuarios_SelectionChanged_1(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contLinhas = dgv.SelectedRows.Count;
            if (contLinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt = Banco.ObterDadosUsers1(vid);
                tb_id.Text = dt.Rows[0].Field<Int64>("N_ID").ToString();
                //tb_Nome.Text = dt.Rows[0].Field<string>("T_NOME"); // <-- problem
                tb_username.Text = dt.Rows[0].Field<string>("T_USERNAME").ToString();
                tb_password.Text = dt.Rows[0].Field<string>("T_PASSWORD").ToString();
                nup_Level.Value = dt.Rows[0].Field<Int64>("N_USERLEVEL");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.N_ID = Convert.ToInt32(tb_id.Text);
            u.T_NOME = tb_Nome.Text;
            u.T_USERNAME = tb_username.Text;
            u.T_PASSWORD = tb_password.Text;
            u.N_USERLEVEL = Convert.ToInt32(Math.Round(nup_Level.Value, 0));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja realmente deletar esse usuario? esta ação não pode ser revertida!", "Deletar?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Banco.DelUser(tb_id.Text);
                dgv_usuarios.DataSource = Banco.ObterUsersIdNome();
            }
        }
    }
}
