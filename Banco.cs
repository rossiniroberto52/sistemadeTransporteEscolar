using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;

namespace sistemadeTransporteEscolar
{
    internal class Banco
    {
        private static SQLiteConnection conect;

        private static SQLiteConnection conectDB()
        {
            conect = new SQLiteConnection("Data Source = " + Global.WayDB);
            conect.Open();
            return conect;
        }

        public static DataTable dql1(string sql)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_users";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable dql2()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_aluno";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //find users and students routines
        public static bool UserFind(User user)
        {
            bool res;
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            var vcon = conectDB();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "SELECT T_USERNAME FROM tb_users WHERE T_USERNAME = '" + user + "'";
            da = new SQLiteDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            vcon.Close();
            return res;
        }


        public static bool StudentFind(Student estudante)
        {
            bool res;
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            var vcon = conectDB();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "SELECT T_NOME_ALUNO FROM tb_aluno WHERE T_NOME_ALUNO = '" + estudante + "'";
            da = new SQLiteDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }

            vcon.Close();
            return res;
        }

        //new client
        public static void newUser(User user)
        {
            if (UserFind(user))
            {
                MessageBox.Show("Username já está em uso, tente outro!");
                return;
            }
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO tb_users (T_USERNAME, T_NOME, T_PASSWORD, N_USERLEVEL) VALUES (@username, @nome, @password, @level)";
                cmd.Parameters.AddWithValue("@username", user.T_USERNAME);
                cmd.Parameters.AddWithValue("@nome", user.T_NOME);
                cmd.Parameters.AddWithValue("@password", user.T_PASSWORD);
                cmd.Parameters.AddWithValue("level", Convert.ToInt32(user.N_USERLEVEL));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Novo usuario cadastrado com total exito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to save new user on the DataBase");
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        //new student
        public static void newStudent(Student estudante)
        {
            if (StudentFind(estudante))
            {
                MessageBox.Show("Aluno já cadastrado!");
                return;
            }
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO tb_aluno (T_ENDERECO, T_NOME_ALUNO, T_FONE, T_ESCOLA, T_NOME_RESP, T_FONE_ALUNO, T_SERIE, T_TURNO, T_VAL) VALUES (@endereco, @nome_aluno, @telefone, @escola, @nome_resp, @tel_aluno, @serie, @turno, @val)";
                cmd.Parameters.AddWithValue("@endereco", estudante.T_ENDERECO);
                cmd.Parameters.AddWithValue("@nome_aluno", estudante.T_NOME_ALUNO);
                cmd.Parameters.AddWithValue("@telefone", estudante.T_FONE);
                cmd.Parameters.AddWithValue("@escola", estudante.T_ESCOLA);
                cmd.Parameters.AddWithValue("@nome_resp", estudante.T_NOME_RESP);
                cmd.Parameters.AddWithValue("@tel_aluno", estudante.T_FONE_ALUNO);
                cmd.Parameters.AddWithValue("@serie", estudante.T_SERIE);
                cmd.Parameters.AddWithValue("@turno", estudante.T_TURNO);
                cmd.Parameters.AddWithValue("@val", estudante.T_VAL);
                cmd.ExecuteNonQuery();
                vcon.Close();
                MessageBox.Show("Novo estudante registrado com exito! Meus parábens pelo novo aluno!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Erro ao salvar novo estudante. reinicie a aplicação e tente novamente");
            }
        }

        //end new student
        //Generic routine

        public static void UserUpdate(User u)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE tb_users SET T_NOMEUSER = '" + u.T_NOME + "', T_USERNAME = '" + u.T_USERNAME + "',  T_PASSWORD = '" + u.T_PASSWORD + "', N_USERLEVEL = " + u.N_USERLEVEL + " WHERE N_IDUSER = " + u.N_ID;
                da = new SQLiteDataAdapter(cmd.CommandText, conectDB());
                cmd.ExecuteNonQuery();
                vcon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable consulta(string sql)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();

                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, conectDB());
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DelUser(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "DELETE from tb_users WHERE N_ID = " + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DelStudent(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "DELETE from tb_aluno WHERE N_ID = " + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no banco de dados. problem in func: DelStudent");
                throw ex;
            }
        }

        public static void StudentUpdate(Student u)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE tb_aluno SET T_ENDERECO = '" + u.T_ENDERECO + "', T_NOME_ALUNO = '" + u.T_NOME_ALUNO + "', T_FONE = '" + u.T_FONE + "', T_ESCOLA = '"+ u.T_ESCOLA + "', T_NOME_RESP = '" + u.T_NOME_RESP + "', T_FONE_ALUNO = '" + u.T_FONE_ALUNO + "', T_SERIE = '" + u.T_SERIE+ "', T_TURNO = '"+ u.T_TURNO+ "', T_VAL = '" + u.T_VAL +"', B_PAGO = " + u.B_PAGO +" WHERE N_ID = " + u.N_ID;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static DataTable ObterUsersIdNome()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT  N_ID as 'id', T_USERNAME as 'Username' FROM tb_users";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ObterStudentIdNome()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT  N_ID as 'id', T_NOME_ALUNO as 'Username' FROM tb_aluno";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ObterStudentIdNomePago()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT  N_ID as 'id', T_NOME_ALUNO as 'aluno', B_PAGO as 'pago' FROM tb_aluno";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //F_usermanagment
        public static DataTable ObterDadosUsers1(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_users WHERE N_ID = " + id;
                da = new SQLiteDataAdapter(cmd.CommandText, conectDB());
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable ObterDadosStudent(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conectDB();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_aluno WHERE N_ID = " + id;
                da = new SQLiteDataAdapter(cmd.CommandText, conectDB());
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } 
}
