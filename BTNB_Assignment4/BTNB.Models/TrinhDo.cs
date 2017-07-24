using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNB.Models
{
    public class TrinhDo
    {
        private int id;
        private string name;
        private int phuCap;
        public TrinhDo(int id, string name, int phucap)
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

        public static List<TrinhDo> DanhSachTrinhDo()
        {
            List<TrinhDo> lstTrinhDo = new List<TrinhDo>();
            TrinhDo td = new TrinhDo(1, "Cử nhân", 300);
            lstTrinhDo.Add(td);
            td = new TrinhDo(2, "Thạc sĩ", 500);
            lstTrinhDo.Add(td);
            td = new TrinhDo(3, "Tiến sĩ", 1000);
            lstTrinhDo.Add(td);
            return lstTrinhDo;
        }
    }
}
