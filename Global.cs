using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemadeTransporteEscolar
{
    internal class Global
    {
        public static string version = "1.0";
        public static bool logado = false; 
        public static string NomeDB = "DB.db";
        public static string Way = System.Environment.CurrentDirectory;
        public static string WayDB = Way + @"\DB\" + NomeDB;
        public static int UserLevel = 0;//0 - deslogado; 1 - logado; 2 - gerente; 3 - adm
        
        /*
         N_ID
         T_ENDERECO
         T_NOME_ALUNO
         T_FONE
         T_ESCOLA
         T_NOME_RESP
         T_FONE_ALUNO
         T_SERIE
         T_TURNO
         T_VAL
         B_PAGO
         */
    }
}
