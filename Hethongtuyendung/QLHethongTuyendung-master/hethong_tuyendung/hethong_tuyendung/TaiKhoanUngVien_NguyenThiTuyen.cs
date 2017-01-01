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
    public partial class TaiKhoanUngVien_NguyenThiTuyen : Form
    {
        public TaiKhoanUngVien_NguyenThiTuyen()
        {
            InitializeComponent();
        }
        HT_tuyendungEntities db = new HT_tuyendungEntities();

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void TaiKhoanUngVien_NguyenThiTuyen_Load(object sender, EventArgs e)
        {
            hienthi();
           
        }
       
        public void hienthi()
        {
            NguoiTimViec ungvien = db.NguoiTimViec.FirstOrDefault(s => s.Ma_NTV == 1); // 1 thay bằng  mã người tìm việc  khi đăng  nhập từ form đăng nhập vào
            lbltenntv.Text = ungvien.Ho + " " + ungvien.Ten;
            lbldiachi.Text = ungvien.DiaChi;
            lbldienthoai.Text = ungvien.Sdt;
            lblemail.Text = ungvien.Email;
            lblghichu.Text = ungvien.GhiChu;
            lblgioitinh.Text = ungvien.GioiTinh;
            lblngaysinh.Text = ungvien.NgaySinh.ToString();
            idungvien = ungvien.Ma_NTV;
            
        }
     
        
        public static int idungvien;
        private void button1_Click(object sender, EventArgs e)
        {
            
            ChinhSuaThongTinCaNhan_NguyenThiTuyen z = new ChinhSuaThongTinCaNhan_NguyenThiTuyen();
            z.ShowDialog();
            //base.OnLoad(e);
           hienthi();
          
            
        }

       
      
    }
}
