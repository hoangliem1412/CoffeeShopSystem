using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNB.Models
{
    public class ChucVu
    {
        private int id;
        private string name;
        private int phuCap;
        public ChucVu(int id, string name, int phucap)
        {
            this.id = id;
            this.name = name;
            this.phuCap = phucap;
        }

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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
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

        public static List<ChucVu> DanhSachChucVu()
        {
            List<ChucVu> lstChucVu = new List<ChucVu>();
            ChucVu cv = new ChucVu(1, "Trưởng phòng", 2000);
            lstChucVu.Add(cv);
            cv = new ChucVu(2, "Phó phòng", 1000);
            lstChucVu.Add(cv);
            cv = new ChucVu(3, "Nhân viên", 500);
            lstChucVu.Add(cv);
            return lstChucVu;
        }
    }
}
