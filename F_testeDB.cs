using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemadeTransporteEscolar
{
    public partial class F_testeDB : Form
    {
        public F_testeDB()
        {
            InitializeComponent();
            bw_findAll.RunWorkerAsync();
            
        }

        private void bw_findAll_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void bw_findAll_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            return;
        }
    }
}
