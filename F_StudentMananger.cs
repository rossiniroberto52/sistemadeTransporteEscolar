using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace sistemadeTransporteEscolar
{
    public partial class F_StudentMananger : Form
    {
        public F_StudentMananger()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_NovoAluno f_NovoAluno = new F_NovoAluno();
            f_NovoAluno.ShowDialog();
            dgv_usuarios.DataSource = Banco.ObterStudentIdNomePago();
        }

        private void F_StudentMananger_Load(object sender, EventArgs e)
        {
            dgv_usuarios.DataSource = Banco.ObterStudentIdNomePago();
            dgv_usuarios.Columns[0].Width = 85;
            dgv_usuarios.Columns[1].Width = 155;
            dgv_usuarios.Columns[2].Width = 35;
        }

        private void dgv_usuarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contTihas = dgv.SelectedRows.Count;
            string pago = "Não";
            if(contTihas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt = Banco.ObterDadosStudent(vid);
                tb_id.Text = dt.Rows[0].Field<Int64>("N_ID").ToString();
                tb_endereco.Text = dt.Rows[0].Field<string>("T_ENDERECO").ToString();
                tb_NomeAluno.Text = dt.Rows[0].Field<string>("T_NOME_ALUNO").ToString();
                tb_NomeResp.Text = dt.Rows[0].Field<string>("T_NOME_RESP").ToString();
                tb_TelResp.Text = dt.Rows[0].Field<string>("T_FONE").ToString();
                tb_Escola.Text = dt.Rows[0].Field<string>("T_ESCOLA").ToString();
                tb_Serie.Text = dt.Rows[0].Field<string>("T_SERIE").ToString();
                tb_Turno.Text = dt.Rows[0].Field<string>("T_TURNO").ToString();
                tb_TelAluno.Text = dt.Rows[0].Field<string>("T_FONE_ALUNO").ToString();
                tb_val.Text = dt.Rows[0].Field<string>("T_VAL").ToString();
                //cb_pago.Text = dt.Rows[0].Field<bool?>("B_PAGO").ToString();
                if (dt.Rows[0].Field<bool?>("B_PAGO") == null)
                {   
                    pago = "Não";
                    cb_pago.Text = pago;
                }else if(dt.Rows[0].Field<bool?>("B_PAGO") == true){
                    pago = "Sim";
                    cb_pago.Text = pago;
                }else if(dt.Rows[0].Field<bool?>("B_PAGO") == false)
                {
                    pago = "Não";
                    cb_pago.Text = pago;
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student estudante = new Student();
            estudante.N_ID = Convert.ToInt32(tb_id.Text);
            estudante.T_NOME_ALUNO = tb_NomeAluno.Text;
            estudante.T_FONE = tb_TelResp.Text;
            estudante.T_NOME_RESP = tb_NomeResp.Text;
            estudante.T_ESCOLA = tb_NomeResp.Text;
            estudante.T_FONE_ALUNO = tb_TelAluno.Text;
            estudante.T_SERIE = tb_Serie.Text;
            estudante.T_TURNO = tb_Turno.Text;
            estudante.T_VAL = tb_val.Text;
            if (cb_pago.Text == "Sim")
            {
                estudante.B_PAGO = true;
            }
            else if(cb_pago.Text == "Não")
            {
                estudante.B_PAGO = false;
            }
            Banco.StudentUpdate(estudante);
            dgv_usuarios.DataSource = Banco.ObterStudentIdNomePago();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string NomeComprovante = Global.Way + "\\comprovante.pdf";
            FileStream PdfArquive = new FileStream(NomeComprovante, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, PdfArquive);

            //doc.Open();
            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL,14,(int)FontStyle.Bold));
            
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("Vam da tia Kially\n");

            



            doc.Open();
        }
    }
}