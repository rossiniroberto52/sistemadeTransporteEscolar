using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace sistemadeTransporteEscolar
{
    public partial class F_NovoAluno : Form
    {
        public F_NovoAluno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student estudante = new Student();
            estudante.T_ENDERECO = tb_endereco.Text;
            estudante.T_NOME_ALUNO = tb_NomeAluno.Text;
            estudante.T_FONE = tb_TelResp.Text;
            estudante.T_ESCOLA = tb_Escola.Text;
            estudante.T_NOME_RESP = tb_NomeResp.Text;
            estudante.T_FONE_ALUNO = tb_TelAluno.Text;
            estudante.T_SERIE = tb_SerieAluno.Text;
            estudante.T_TURNO = tb_TurnoDoAluno.Text;
            estudante.T_VAL = tb_ValCobrado.Text;
            estudante.B_PAGO = false;

            Banco.newStudent(estudante);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
