using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTNB.Models;
using BTNB.Service;

namespace BTNB.WindowsForms
{
    public partial class frmThemNhanVien : Form
    {
        public frmThemNhanVien()
        {
            InitializeComponent();
        }

        private void frmThemNhanVien_Load(object sender, EventArgs e)
        {
            List<LoaiNhanVien> listNhanVien = new List<LoaiNhanVien>()
            {
                new LoaiNhanVien(0, "Nhân viên hành chính"),
                new LoaiNhanVien(1, "Giảng viên")

            };
            LoaiNhanVienComboBox.DisplayMember = "Name";
            LoaiNhanVienComboBox.ValueMember = "Id";
            LoaiNhanVienComboBox.DataSource = listNhanVien;
            
            LoaiNhanVienComboBox.SelectedIndex = 0;
        }
        static int selectLoai;
        private void LoaiNhanVienComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectLoai = (int)LoaiNhanVienComboBox.SelectedValue;
            if (selectLoai == 0)
            {
                TrinhDo_ChucVuComboBox.DataSource = ChucVu.DanhSachChucVu();
                TrinhDo_ChucVuComboBox.DisplayMember = "Name";
                TrinhDo_ChucVuComboBox.ValueMember = "Id";
            }
            else if(selectLoai == 1)
            {
                TrinhDo_ChucVuComboBox.DataSource = TrinhDo.DanhSachTrinhDo();
                TrinhDo_ChucVuComboBox.DisplayMember = "Name";
                TrinhDo_ChucVuComboBox.ValueMember = "Id";
            }
        }

        private void ThemNhanVienButton_Click(object sender, EventArgs e)
        {
            if (selectLoai != 1 && selectLoai != 0)
            {
                return;
            }
            NhanVien nv = new NhanVien();
            nv.HoTen = HoTenTextBox.Text;
            try
            {
                nv.HeSoLuong = float.Parse(HeSoLuongTextBox.Text);
                nv.PhuCap = int.Parse(PhuCapTextBox.Text);
                nv.TrinhDo_ChucVu = (int)TrinhDo_ChucVuComboBox.SelectedValue;
                nv.SoTietDay_SoNgayCong = int.Parse(SoTietDay_NgayCongTextBox.Text);
            }
            catch (FormatException fEx)
            {
                MessageBox.Show(fEx.Message);
            }
            nv.Khoa_PhongBan = Khoa_PhongBanTextBox.Text;
            nv.LoaiNhanVien = (int)LoaiNhanVienComboBox.SelectedValue;
            switch (selectLoai)
            {
                case 1:
                    nv.TongLuong = nv.HeSoLuong * 730 + nv.PhuCap + nv.SoTietDay_SoNgayCong * 45;
                    break;
                case 0:
                    nv.TongLuong = nv.HeSoLuong * 730 + nv.PhuCap + nv.SoTietDay_SoNgayCong * 30;
                    break;
            }
            if (NhanVienService.ThemNhanVien(nv))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thất bài!");
            }
            
        }

        private void TrinhDo_ChucVuComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = TrinhDo_ChucVuComboBox.SelectedItem;
            if (selectLoai == 1)
            {
                PhuCapTextBox.Text = (item as TrinhDo).PhuCap.ToString();
                
            }
            else if (selectLoai == 0)
            {
                PhuCapTextBox.Text = (item as ChucVu).PhuCap.ToString();
            }
            else
            {
                return;
            }            
        }
    }
}
