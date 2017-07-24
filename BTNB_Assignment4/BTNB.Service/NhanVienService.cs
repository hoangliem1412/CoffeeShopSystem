using BTNB.Data;
using BTNB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNB.Service
{
    public class NhanVienService
    {
        static List<TrinhDo> danhSachTrinhDo = TrinhDo.DanhSachTrinhDo();
        static List<ChucVu> danhSachChucVu = ChucVu.DanhSachChucVu();
        public static List<NhanVienView> SearchNhanVien(string keyword)
        {
            List<NhanVien> listNhanVien = null; // NhanVienRopository.SearchNhanVien(keyword);
            var query1 = listNhanVien.Where(x => x.LoaiNhanVien == 1).Join(danhSachTrinhDo, nv => nv.TrinhDo_ChucVu, td => td.Id, (nv, td) => new NhanVienView { Id = nv.Id, HoTen = nv.HoTen, HeSoLuong = nv.HeSoLuong, Khoa_PhongBan = nv.Khoa_PhongBan, LoaiNhanVien = nv.LoaiNhanVien, PhuCap = nv.PhuCap, SoTietDay_SoNgayCong = nv.SoTietDay_SoNgayCong, TenTrinhDo_ChucVu = td.Name, TongLuong = nv.TongLuong, TrinhDo_ChucVu = nv.TrinhDo_ChucVu });
            var query2 = listNhanVien.Where(x => x.LoaiNhanVien == 0).Join(danhSachChucVu, nv => nv.TrinhDo_ChucVu, cv => cv.Id, (nv, cv) => new NhanVienView { Id = nv.Id, HoTen = nv.HoTen, HeSoLuong = nv.HeSoLuong, Khoa_PhongBan = nv.Khoa_PhongBan, LoaiNhanVien = nv.LoaiNhanVien, PhuCap = nv.PhuCap, SoTietDay_SoNgayCong = nv.SoTietDay_SoNgayCong, TenTrinhDo_ChucVu = cv.Name, TongLuong = nv.TongLuong, TrinhDo_ChucVu = nv.TrinhDo_ChucVu });
            var result = query1.Union(query2).OrderBy(x => x.Id).ToList();
            return result;
        }

        public static bool ThemNhanVien(NhanVien nv)
        {
            return false; // NhanVienRopository.ThemNhanVien(nv);
        }
    }
}
