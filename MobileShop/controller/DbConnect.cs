using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.controller
{
    internal class DbConnect
    {
        public SqlConnection GetConnection()
        {
            SqlConnection conn = null;
            try
            {
                // Chuỗi kết nối
                string connectionString = "Server=DUONG2724;Database=MobileShop;User Id=sa;Password=dsh272k4;TrustServerCertificate=True;";

                // Tạo đối tượng SqlConnection
                conn = new SqlConnection(connectionString);

                // Mở kết nối
                conn.Open();

                Console.WriteLine("Kết nối thành công");
            }
            catch (Exception e)
            {
                Console.WriteLine("Không thể kết nối đến cơ sở dữ liệu: " + e.Message);
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu: " + e.Message);
            }
            return conn;
        }
    }
}
