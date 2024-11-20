using MobileShop.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.controller
{
    internal class NguoiDungController
    {
        private SqlConnection conn;

        // Constructor để khởi tạo kết nối
        public NguoiDungController()
        {
            try
            {
                conn = new DbConnect().GetConnection();
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể khởi tạo kết nối: " + ex.Message);
            }
        }

        // Phương thức kiểm tra đăng nhập
        public bool CheckLogin(string taikhoan, string matkhau)
        {
            string query = "SELECT * FROM nguoidung WHERE tendangnhap=@tendangnhap AND matkhau=@matkhau";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tendangnhap", taikhoan);
                    cmd.Parameters.AddWithValue("@matkhau", matkhau);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows; // Trả về true nếu có kết quả
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
                return false;
            }
        }

        // Phương thức lấy danh sách tất cả người dùng
        public List<NguoiDung> GetAllNguoiDung()
        {
            List<NguoiDung> lst = new List<NguoiDung>();
            string query = "SELECT * FROM DangNhap";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NguoiDung obj = new NguoiDung(reader);
                            lst.Add(obj);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách người dùng: " + ex.Message);
                throw new Exception("Có lỗi xảy ra khi lấy dữ liệu: " + ex.Message);
            }

            return lst;
        }

        // Phương thức thêm người dùng mới
        public void AddNguoiDung(NguoiDung nguoiDung)
        {
            string query = "INSERT INTO DangNhap (taikhoan, matkhau) VALUES (@taikhoan, @matkhau)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@taikhoan", nguoiDung.Taikhoan);
                    cmd.Parameters.AddWithValue("@matkhau", nguoiDung.Matkhau);

                    int rowsInserted = cmd.ExecuteNonQuery(); // Thực hiện truy vấn

                    if (rowsInserted > 0)
                    {
                        Console.WriteLine("Đăng ký thành công. Người dùng đã được thêm vào cơ sở dữ liệu.");
                    }
                    else
                    {
                        Console.WriteLine("Đăng ký thất bại. Không có dòng nào được thêm.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Lỗi khi thêm người dùng mới: " + ex.Message);
                throw new Exception("Có lỗi xảy ra khi tạo tài khoản: " + ex.Message);
            }
        }

        // Phương thức đóng kết nối
        public void CloseConnection()
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Lỗi khi đóng kết nối: " + ex.Message);
            }
        }
    }
}
