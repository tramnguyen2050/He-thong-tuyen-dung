using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hethong_tuyendung.Model;
namespace hethong_tuyendung
{
    public partial class ChinhSuaThongTinCaNhan_NguyenThiTuyen : Form
    {
        public ChinhSuaThongTinCaNhan_NguyenThiTuyen()
        {
            InitializeComponent();
        }
        HT_tuyendungEntities db = new HT_tuyendungEntities();

        private void ChinhSuaThongTinCaNhan_NguyenThiTuyen_Load(object sender, EventArgs e)
        {
            hienthi();
        }
        public void hienthi()
        {
            NguoiTimViec n = db.NguoiTimViec.FirstOrDefault(s => s.Ma_NTV == TaiKhoanUngVien_NguyenThiTuyen.idungvien);
            txtdiachi.Text = n.DiaChi;
            txtemail.Text = n.Email;
            txtghichu.Text = n.GhiChu;
            txtsdt.Text = n.Sdt;
            txtten.Text = n.Ten;
            txtho.Text = n.Ho;
            if (n.GioiTinh.Trim() == "Nam")
                radioButton1.Checked = true;
            else if (n.GioiTinh.Trim() == "Nữ")
                radioButton2.Checked = true;
            if( string.IsNullOrEmpty(n.NgaySinh.ToString()) == true)
            dateTimePicker1.Text = n.NgaySinh.ToString();


        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NguoiTimViec n = db.NguoiTimViec.FirstOrDefault(s => s.Ma_NTV == TaiKhoanUngVien_NguyenThiTuyen.idungvien);
                n.DiaChi = txtdiachi.Text;
                n.Email = txtemail.Text;
                n.GhiChu = txtghichu.Text;
                n.Sdt = txtsdt.Text;
                n.Ten = txtten.Text;
                n.Ho = txtho.Text;
                if (radioButton1.Checked == true)
                    n.GioiTinh = "Nam";
                else if (radioButton2.Checked == true)
                    n.GioiTinh = "Nữ";

                n.NgaySinh = DateTime.Parse(dateTimePicker1.Value.ToShortDateString().ToString());
                db.SaveChanges();
                MessageBox.Show("Cập Nhập Thành Công");
   
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi" + ex);
            }
          

        }
    }
}
