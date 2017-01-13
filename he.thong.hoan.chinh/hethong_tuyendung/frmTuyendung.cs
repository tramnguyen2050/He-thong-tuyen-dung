using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hethong_tuyendung
{
    public partial class frmTuyendung : Form
    {
        string cnStr;
        SqlConnection cn;
        public frmTuyendung()
        {
            InitializeComponent();
        }

        private void frmTuyendung_Load(object sender, EventArgs e)
        {
            cnStr = "Server =.; Database = HT_tuyendung; Integrated security = true;";
            cn = new SqlConnection(cnStr);
        }
        private void Connect()
        {
            try
            {
                 if (cn != null && cn.State == ConnectionState.Open)
                    cn.Open();
            }
            catch (SqlException ex)
            {
                 MessageBox.Show("Loi...\n" + ex.Message);
                
                //throw;
            }
        }
        private void DisConnect()
        {
            if (cn != null && cn.State == ConnectionState.Open)
                cn.Close();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDangNhap f = new FrmDangNhap();
            f.Show();
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangKy f = new frmDangKy();
            f.Show();
        }

    }
}
