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
using System.Configuration;

namespace hethong_tuyendung
{
    public partial class FrmDangNhap : Form
    {
        string cnStr;
        SqlConnection cn;
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            cnStr = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
            cn = new SqlConnection(cnStr);
            try
            {

                if (kiemTraDangNhapNTD() == 1)
                {
                    this.Hide();
                    NhaTuyenDung f = new NhaTuyenDung();
                    f.Show();
                  
                }

                else if (kiemTraDangNhapNTV() == 1)
                {
                    //goi proc NTV
                    this.Hide();
                    TaiKhoanUngVien_NguyenThiTuyen f = new TaiKhoanUngVien_NguyenThiTuyen();
                    f.Show();
                    
                }
                else
                {
                    MessageBox.Show("Sai m?t kh?u ho?c email.", "Thông báo!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public int kiemTraDangNhapNTD()
        {
            int kq = 0;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "uspKiemTraDangNhapNTD";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@Matkhau", SqlDbType.NVarChar).Value = txtMatKhau.Text;
                //SqlParameter newResult = new SqlParameter("@Result", SqlDbType.Bit);
                cmd.Parameters.Add("@Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                //SqlParameter newResult = new SqlParameter();
                //newResult.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(newResult);    
                //int kq = 0;
                object result = cmd.ExecuteScalar();
                if (result != null)
                    kq = Convert.ToInt32(result);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return kq;
        }

        public int kiemTraDangNhapNTV()
        {
            int kq = 0;

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "uspKiemTraDangNhapNTV";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50)).Value = txtEmail.Text;
                cmd.Parameters.Add(new SqlParameter("@Matkhau", SqlDbType.NVarChar, 50)).Value = txtMatKhau.Text;
                cmd.Parameters.Add("@Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                object result = cmd.ExecuteScalar();
                if (result != null)
                    kq = Convert.ToInt32(result);
                //return kq;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return kq;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                txtMatKhau.PasswordChar = '*';
            }
            else
            {
                txtMatKhau.PasswordChar = (char)0;
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            //frmTuyendung f = new frmTuyendung();
            //f.Show();
        }

        private void FrmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTuyendung f = new frmTuyendung();
            f.Show();
        }
    }
}
