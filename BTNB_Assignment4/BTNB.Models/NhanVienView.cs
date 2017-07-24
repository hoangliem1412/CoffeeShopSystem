using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNB.Models
{
    public class NhanVienView : NhanVien
    {
        private string tenTrinhDo_ChucVu;

        public string TenTrinhDo_ChucVu
        {
            get
            {
                return tenTrinhDo_ChucVu;
            }

            set
            {
                tenTrinhDo_ChucVu = value;
            }
        }
    }
}
