using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using BUS;

namespace QuanLyThuVien
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnloginthoat_Click(object sender, EventArgs e)
        {
            DialogResult drl = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (drl == DialogResult.Yes) this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Account account = new Account(txtlogin.Text, txtpassword.Text);
            if (AccountBUS.Instance.login(account))
            {
                QuanLySach f = new QuanLySach();
                this.Hide();
                f.ShowDialog();
               
            }
            else MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
        }

        private void Login_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = imguser.Images[0];

        }
    }
}
