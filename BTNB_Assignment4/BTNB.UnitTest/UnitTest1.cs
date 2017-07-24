using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BTNB.Models;
using System.Collections.Generic;
using System.Linq;
using BTNB.Data;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace BTNB.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int i, j = 1, k;
            for (i = 0; i < 5; i++)
            {
                k = j++ + ++j;
                MessageBox.Show(k + " ");
            }

        }
        [TestMethod]
        public void test()
        {
            SqlConnection con = new SqlConnection(@"Data Source=300-FRS-V26;Initial Catalog=BTNB_QuanLyNhanVienTruong;Persist Security Info=True;User ID=sa;Password=123456Sql;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien", con);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            Assert.AreEqual(1, rs);
           
        }
        [TestMethod]
        public void TestSearch()
        {
            NhanVienRopository nvr = new NhanVienRopository();
            List<NhanVien> listNV = nvr.GetAll();
            Assert.AreEqual(16, listNV.Count());
        }
    }
}
