using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNB.Models
{
    public class NhanVien
    {
        private int id;

        private string hoTen;

        private string khoa_PhongBan;

        private int trinhDo_ChucVu;

        private int phuCap;

        private int soTietDay_SoNgayCong;

        private float heSoLuong;

        private float tongLuong;

        private int loaiNhanVien;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string HoTen
        {
            get
            {
                return hoTen;
            }

            set
            {
                hoTen = value;
            }
        }

        public string Khoa_PhongBan
        {
            get
            {
                return khoa_PhongBan;
            }

            set
            {
                khoa_PhongBan = value;
            }
        }

        public int TrinhDo_ChucVu
        {
            get
            {
                return trinhDo_ChucVu;
            }

            set
            {
                trinhDo_ChucVu = value;
            }
        }

        public int PhuCap
        {
            get
            {
                return phuCap;
            }

            set
            {
                phuCap = value;
            }
        }

        public int SoTietDay_SoNgayCong
        {
            get
            {
                return soTietDay_SoNgayCong;
            }

            set
            {
                soTietDay_SoNgayCong = value;
            }
        }

        public float HeSoLuong
        {
            get
            {
                return heSoLuong;
            }

            set
            {
                heSoLuong = value;
            }
        }

        public float TongLuong
        {
            get
            {
                return tongLuong;
            }

            set
            {
                tongLuong = value;
            }
        }

        public int LoaiNhanVien
        {
            get
            {
                return loaiNhanVien;
            }

            set
            {
                loaiNhanVien = value;
            }
        }
    }
}
