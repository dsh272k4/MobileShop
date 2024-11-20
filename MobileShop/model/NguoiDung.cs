using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.model
{
    internal class NguoiDung
    {
        public string Taikhoan { get; set; }
        public string Matkhau { get; set; }

        // Constructor để tạo đối tượng từ tham số
        public NguoiDung(string taikhoan, string matkhau)
        {
            Taikhoan = taikhoan;
            Matkhau = matkhau;
        }

        // Constructor để tạo đối tượng từ SqlDataReader (dữ liệu từ cơ sở dữ liệu)
        public NguoiDung(SqlDataReader reader)
        {
            Taikhoan = reader["tendangnhap"].ToString();
            Matkhau = reader["matkhau"].ToString();
        }
    }
}
