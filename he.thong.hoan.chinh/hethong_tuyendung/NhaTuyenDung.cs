using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hethong_tuyendung
{
    public partial class NhaTuyenDung : Form
    {
        string cnStr = "";
        SqlConnection cn;
        DataSet ds;
        DataTable dt;
        public NhaTuyenDung()
        {
            InitializeComponent();
        }

        private void NhaTuyenDung_Load(object sender, EventArgs e)
        {
            cnStr = "Server = .; Database = HT_tuyendung; Integrated security = true;";
            cn = new SqlConnection();
            cn.ConnectionString = cnStr;

            string sql = "select * from NhaTuyenDung";
            dt = GetNhaTuyenDung(sql).Tables[0];
            dgvNhaTuyenDung.DataSource = dt;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "uspThemNTD";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenCty",txtTenCty.Text));
                cmd.Parameters.Add(new SqlParameter("@Email", txtEmail.Text));
                cmd.Parameters.Add(new SqlParameter("@Matkhau", txtMatKhau.Text));
                cmd.Parameters.Add(new SqlParameter("@SDT", txtSDT.Text));
                cmd.Parameters.Add(new SqlParameter("@Fax", txtFax.Text));
                cmd.Parameters.Add(new SqlParameter("@Diachi", txtDiaChi.Text));
                cmd.Parameters.Add(new SqlParameter("@Quymo", txtQuyMo.Text));
                cmd.Parameters.Add(new SqlParameter("@Ghichu", txtGhiChu.Text));
                cmd.ExecuteNonQuery();
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

        private void btSua_Click(object sender, EventArgs e)
        {
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "uspSuaNTD";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MaNTD", txtMaNTD.Text));
                cmd.Parameters.Add(new SqlParameter("@TenCty", txtTenCty.Text));
                cmd.Parameters.Add(new SqlParameter("@Email", txtEmail.Text));
                cmd.Parameters.Add(new SqlParameter("@Matkhau", txtMatKhau.Text));
                cmd.Parameters.Add(new SqlParameter("@SDT", txtSDT.Text));
                cmd.Parameters.Add(new SqlParameter("@Fax", txtFax.Text));
                cmd.Parameters.Add(new SqlParameter("@Diachi", txtDiaChi.Text));
                cmd.Parameters.Add(new SqlParameter("@Quymo", txtQuyMo.Text));
                cmd.Parameters.Add(new SqlParameter("@Ghichu", txtGhiChu.Text));
                cmd.ExecuteNonQuery();
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

        private void btXoa_Click(object sender, EventArgs e)
        {
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "uspXoaNTD";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MaNTD", txtMaNTD.Text));
                cmd.ExecuteNonQuery();
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
        public DataSet GetNhaTuyenDung(string sql)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void dgvNhaTuyenDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvNhaTuyenDung.Rows[e.RowIndex];
                txtMaNTD.Text = row.Cells[0].Value.ToString();
                txtTenCty.Text = row.Cells[1].Value.ToString();
                txtEmail.Text = row.Cells[2].Value.ToString();
                txtMatKhau.Text = row.Cells[3].Value.ToString();
                txtSDT.Text = row.Cells[4].Value.ToString();
                txtFax.Text = row.Cells[5].Value.ToString();
                txtDiaChi.Text = row.Cells[6].Value.ToString();
                txtQuyMo.Text = row.Cells[7].Value.ToString();
                txtGhiChu.Text = row.Cells[8].Value.ToString();
            }
        }

    }
}
