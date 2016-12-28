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

namespace DANGKY
{
    public partial class frmDangKy : Form
    {
        string cnStr;
        SqlConnection cn;
        SqlCommand cmd = new SqlCommand();
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnStr = @"server = THAOVY-PC\LEVY; Database = HT_tuyendung; Integrated security = true;";
        }

        private void Connect()
        {
            if (cn != null && cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }
        private void Disconnect()
        {
            if (cn == null && cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btDangky_Click(object sender, EventArgs e)
        {
            Connect();
            try
            {
                cn = new SqlConnection(cnStr);
                cn.Open();
                cmd = new SqlCommand();
                if (rdNTV.Checked == true)
                {
                    if (txtnhaplaiMK.Text == txtMK.Text && txtMK.Text != null) //&& txtEmail.Text != null&& txtMK.Text != null && txtTen.Text == null && txtHo.Text == null)
                    {
                        cmd.CommandText = "usp_taikhoanNTV";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = cn;
                        cmd.Parameters.Add(new SqlParameter("@Ho", txtHo.Text));
                        cmd.Parameters.Add(new SqlParameter("@Ten", txtTen.Text));
                        cmd.Parameters.Add(new SqlParameter("@Email", txtEmail.Text));
                        cmd.Parameters.Add(new SqlParameter("@MKhau", txtMK.Text));
                        cmd.Parameters.Add(new SqlParameter("@DienThoai", txtSDT.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("ĐĂNG NHẬP THÀNH CÔNG", "thong bao");
                        Application.Exit();
                        
                        
                        
                    }
                    else if (txtnhaplaiMK.Text != txtMK.Text || txtnhaplaiMK.Text == null || txtMK.Text == null)
                    {
                        lbloi.Show();
                        lbloi.Text = "Nhập lại đúng mật khẩu";
                    }
                }
                else if (rdNTD.Checked == true)
                {

                    if (txtnhaplaiMK.Text == txtMK.Text) //&& txtEmail.Text != null && txtMK.Text != null && txtTen.Text == null)
                    {
                        cmd.CommandText = "usp_taikhoanNTD";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = cn;
                        cmd.Parameters.Add(new SqlParameter("@Ten", txtTen.Text));
                        cmd.Parameters.Add(new SqlParameter("@Email", txtEmail.Text));
                        cmd.Parameters.Add(new SqlParameter("@MKhau", txtMK.Text));
                        cmd.Parameters.Add(new SqlParameter("@DienThoai", txtSDT.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("ĐĂNG KÝ THÀNH CÔNG");
                        Application.Exit();
                    }
                    else if (txtnhaplaiMK.Text != txtMK.Text || txtnhaplaiMK.Text == null)
                    {
                        lbloi.Show();
                        lbloi.Text = "Nhập lại đúng mật khẩu";
                    }
                }
                else
                {
                    MessageBox.Show("BẠN LÀ NHÀ TUYỂN DỤNG HAY NGƯỜI TÌM VIỆC?");
                }
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
            finally
            {
                Disconnect();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThi.Checked)
            {
                txtMK.UseSystemPasswordChar = true;
                txtnhaplaiMK.UseSystemPasswordChar = true;
            }
            else
            {
                txtMK.UseSystemPasswordChar = false;
                txtnhaplaiMK.UseSystemPasswordChar = false;
            }
        }
        //private int KT_EmailNTV()
        //{
        //    Connect();
        //    try
        //    {
        //        cn = new SqlConnection(cnStr);
        //        cn.Open();
        //        cmd = new SqlCommand();
        //        cmd = new SqlCommand();
        //        cmd.CommandText = "USP_emailNTV";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = cn;
        //        cmd.Parameters.Add(new SqlParameter("@Email", txtEmail.Text));
        //        int x = (int)cmd.ExecuteScalar();
        //        return x;
        //        //if (x >= 2)
        //        //{
        //        //    MessageBox.Show("EMAIL ĐÃ CÓ NGƯỜI DÙNG");   
        //        //}
        //        //else
        //        //{
        //        //    MessageBox.Show("ĐĂNG NHẬP THÀNH CÔNG", "thong bao");
        //        //    Application.Exit();
        //        //}
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        //throw;
        //    }
        //    finally
        //    {
        //        Disconnect();
        //    }
           
        //}

        
    }
}
