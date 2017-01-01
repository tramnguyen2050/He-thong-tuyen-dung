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
    public partial class HoSoNguoiTimViec_NguyenThiTuyen : Form
    {
        public HoSoNguoiTimViec_NguyenThiTuyen()
        {
            InitializeComponent();
        }
        HT_tuyendungEntities db = new HT_tuyendungEntities();
        void kiemtra(bool t)
        {
            btnthem.Enabled = !t;
            btnsua.Enabled = !t;
            btnsave.Enabled = t;
            btnkosave.Enabled = t;
            btnxoa.Enabled = !t;
            dateTimePicker1.Enabled = t;
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txttenhoso.Text = row.Cells[0].Value.ToString();
                txttrinhdo.Text = row.Cells[1].Value.ToString();
                txtvitrimongmuon.Text = row.Cells[2].Value.ToString();
                txtngoaingu.Text = row.Cells[3].Value.ToString();
                dateTimePicker1.Text = row.Cells[4].Value.ToString();
                txtkinhnghiem.Text = row.Cells[5].Value.ToString();
                txtghichu.Text = row.Cells[6].Value.ToString();
                idhoso = int.Parse(row.Cells[7].Value.ToString());
            }
        }
         void moi()
        {
            txttenhoso.Text = "";
            txttrinhdo.Text = "";
            txtvitrimongmuon.Text = "";
            txtngoaingu.Text = "";
            dateTimePicker1.Text = "";
            txtkinhnghiem.Text = "";
            txtghichu.Text = "";

         }
         int co=0;
        private void btnthem_Click(object sender, EventArgs e)
        {
            kiemtra(true);
            moi();
            co = 1;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            kiemtra(true);
            txttenhoso.Focus();
            co = 2;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            kiemtra(false);
            if(co ==1 )
            {
                HoSoXinViec s = new HoSoXinViec();
                if(txttenhoso.Text.Length  <=10)
                {
                    s.Ten_HS = txttenhoso.Text;
                    s.GhiChu = txtghichu.Text;
                    s.KinhNghiem = txtkinhnghiem.Text;
                    s.Ma_NTV = mantv;
                    s.NgayNop = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());
                    s.NgoaiNgu = txtngoaingu.Text;
                    s.TrinhDo = txttrinhdo.Text;
                    s.ViTriMongMuon = txtvitrimongmuon.Text;
                    db.HoSoXinViec.Add(s);
                    db.SaveChanges();
                    MessageBox.Show("Thêm Thành Công");
                    hienthi();
                }
                else
                {
                    MessageBox.Show("Tên hồ Sơ không được lớn hơn 10 kí tự.");
                }
                
            }
            else if(co ==2)
            {
                HoSoXinViec s = db.HoSoXinViec.FirstOrDefault(x => x.Ma_HS == idhoso);
                if(s != null)
                {
                    s.Ten_HS = txttenhoso.Text;
                    s.GhiChu = txtghichu.Text;
                    s.KinhNghiem = txtkinhnghiem.Text;
                    s.Ma_NTV = mantv;
                    s.NgayNop = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());
                    s.NgoaiNgu = txtngoaingu.Text;
                    s.TrinhDo = txttrinhdo.Text;
                    s.ViTriMongMuon = txtvitrimongmuon.Text;
                    
                    db.SaveChanges();
                    MessageBox.Show("Sửa Thành Công!");
                    hienthi();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy!");
                }
            }
        }

        private void btnkosave_Click(object sender, EventArgs e)
        {
            kiemtra(false);
            moi();
        }

        private void HoSoNguoiTimViec_NguyenThiTuyen_Load(object sender, EventArgs e)
        {
            kiemtra(false);
            hienthi();
        }

        int mantv;
        int idhoso;
        
        void hienthi()
        {
            var uv = db.HoSoXinViec.Select(s => new { s.Ten_HS,s.TrinhDo,s.ViTriMongMuon,s.NgoaiNgu,s.NgayNop,s.KinhNghiem,s.GhiChu,s.Ma_HS,s.Ma_NTV}).Where(s => s.Ma_NTV == 1).ToList(); // 1 điều hướng từ from khác tới .. thay đổi sau
            dataGridView1.DataSource = uv;
            mantv = 1; // 1 này là từ mã người tìm việc từ form khác điều hướng qua
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            HoSoXinViec s = db.HoSoXinViec.FirstOrDefault(x => x.Ma_HS == idhoso);
            if(s != null)
            {
                db.HoSoXinViec.Remove(s);
                db.SaveChanges();
                hienthi();
                moi();
            }
            else
            {
                MessageBox.Show("Xóa Không Thành Công!");
            }
        }
    }
}
