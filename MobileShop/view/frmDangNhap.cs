using MobileShop.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShop.view
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTaiKhoan.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrEmpty(taikhoan) || string.IsNullOrEmpty(matkhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra đăng nhập
            try
            {
                NguoiDungController nguoiDungController = new NguoiDungController();

                if (nguoiDungController.CheckLogin(taikhoan, matkhau))
                {
                    // Đăng nhập thành công
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở Form mới và đóng form đăng nhập
                    frmMain frm = new frmMain();
                    frm.Show();
                    this.Hide(); // Ẩn form đăng nhập
                }
                else
                {
                    // Đăng nhập thất bại
                    MessageBox.Show("Đăng nhập thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear(); // Xóa mật khẩu
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại sau.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
