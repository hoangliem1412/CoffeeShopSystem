using BTNB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTNB.Service;
namespace BTNB.WindowsForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            DanhSachNhanVienData.AutoGenerateColumns = false;
        }
        List<NhanVienView> listNhanVien = new List<NhanVienView>();
        bool check = false;
        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            
            string keyword = TenNhanVienTextBox.Text;
            listNhanVien = NhanVienService.SearchNhanVien(keyword);
            DanhSachNhanVienData.DataSource = listNhanVien.Skip(5 * 0).Take(5).ToList();

            if (check == false)
            {
                for (int i = 0; i < listNhanVien.Count / 5; i++)
                {
                    Button PhanTrangButton = new Button();
                    PhanTrangButton.Click += PhanTrangButton_Click;
                    PhanTrangButton.Text = (i + 1).ToString();
                    PhanTrangButton.Width = 20;
                    PhanTrangLowLayoutPanel.Controls.Add(PhanTrangButton);
                }
                check = true;
            }
            

        }

        private void PhanTrangButton_Click(object sender, EventArgs e)
        {
            int pageNum = int.Parse((sender as Button).Text) - 1;
            DanhSachNhanVienData.DataSource = listNhanVien.Skip(5 * pageNum).Take(5).ToList();
        }

        private void ThemNhanVienButton_Click(object sender, EventArgs e)
        {
            frmThemNhanVien frm = new frmThemNhanVien();
            frm.ShowDialog();
        }

        private void SapXepButton_Click(object sender, EventArgs e)
        {
            TenNhanVienTextBox.Text = "";
            listNhanVien = listNhanVien.OrderBy(x => x.TongLuong).ThenBy(x => x.HoTen).ToList();
            DanhSachNhanVienData.DataSource = listNhanVien.Skip(5 * 0).Take(5).ToList();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }
    }
}
