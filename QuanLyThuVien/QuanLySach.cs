using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;
using DTO;

namespace QuanLyThuVien
{
    public partial class QuanLySach : Form
    {
        public QuanLySach()
        {
            InitializeComponent();
        }

     
        int row;
        private void QuanLySach_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_QuanLyThuVien1_0DataSet.DocGia' table. You can move, or remove it, as needed.
            //this.docGiaTableAdapter.Fill(this._QuanLyThuVien1_0DataSet.DocGia);
            
            dtgQuanLySach.DataSource = SachBUS.Instance.ShowSach();
            dtgDocGia.DataSource = DocGiaBUS.Instance.ShowDG();
            dgvPhieuMuon.DataSource = PhieuMuonBUS.Instance.LoadPhieuMuon();

            //đổ dữ liệu lên combobox Thể loại sách
            cmbTheLoai.DataSource = SachBUS.Instance.GetCatory();
            cmbTheLoai.DisplayMember = "TenTheLoai";
            cmbTheLoai.ValueMember = "MaTheLoai";

            //đổ dữ liệu lên combobox Tên sách
            cmbTenSachPhieu.DataSource = SachBUS.Instance.ShowSach();
            cmbTenSachPhieu.DisplayMember = "TenSach";
            cmbTenSachPhieu.ValueMember = "MaSach";

            //do du lieu len combobox Ten Doc Gia
            cmbTenDGPhieu.DataSource = DocGiaBUS.Instance.ShowDG();
            cmbTenDGPhieu.DisplayMember = "TenDocGia";
            cmbTenDGPhieu.ValueMember = "MaDocGia";

            //đổ dữ liệu lên combobox phiếu trả
            cboDGPT.DataSource = PhieuMuonBUS.Instance.GetMaDG();
            cboDGPT.ValueMember = "MaDocGia";


            //code phần độc giả
            //Tăng mã tự động
            txtMaSach.Text = "MS" + (dtgQuanLySach.RowCount+1 < 11 ? "0" : "") + ((dtgQuanLySach.RowCount) );
            //txtMaDG.Text = "DG" + (dtgDocGia.RowCount + 1 < 11 ? "0" : "") + ((dtgDocGia.RowCount));
            tangMaDG();
            //txtMaPhieu.Text = "MP" + (dgvPhieuMuon.RowCount + 1 < 11 ? "0" : "") + ((dgvPhieuMuon.RowCount));

            txtMaDG.Enabled = false;

            
        }

        private void tangMaDG() //Tăng Mã Độc Giả
        {
            string str = (dtgDocGia.Rows[dtgDocGia.Rows.Count-1].Cells[0].Value.ToString()).Remove(0,2);
            Int32 temp = Int32.Parse(str);
            txtMaDG.Text = "DG"+ (temp+1 < 10 ?"0":"") + (temp+1);

        }

        //show panel,form
        private void btnDocGia_Click(object sender, EventArgs e)
        {
            panDocGia.Show();
            panQuanLySach.Hide();
            tabQuanLyPhieu.Hide();
            panThongKe.Hide();
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            DialogResult drl = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (drl == DialogResult.Yes) Application.Exit();
        }


        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            panQuanLySach.Show();
            panDocGia.Hide();
            panThongKe.Hide();
            tabQuanLyPhieu.Hide();
          
        }

        private void btnQuanLyPhieu_Click(object sender, EventArgs e)
        {
            panQuanLySach.Hide();
            panDocGia.Hide();
            panThongKe.Hide();
            tabQuanLyPhieu.Show();
            

            tabQuanLyPhieu.SelectedTab = tabQuanLyPhieu.TabPages[0];
            cmbTenDGPhieu.Text = "";
            cmbTenSachPhieu.SelectedIndex = -1;       
            lstSachMuon.Items.Clear();
            txtMaDGPhieu.Text = "";
            lblSLM.Hide();
            txtSLMuon.Hide();
            cboDGPT.SelectedIndex = -1;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            panQuanLySach.Hide();
            panDocGia.Hide();
            tabQuanLyPhieu.Hide();
            panThongKe.Show();
        }

        //Code phần độc giả

        private void btnThemDG_Click(object sender, EventArgs e) //Thêm DG
        {
            try
            {
                //txtMaDG.Text = "DG" + (dtgDocGia.RowCount + 1 < 10 ? "0" : "") + (dtgDocGia.RowCount);
                tangMaDG();

                if (txtTenDG.Text == "")
                    MessageBox.Show("Nhập tên độc giả.");
                else if (rdoNam.Checked == false && rdoNu.Checked == false)
                    MessageBox.Show("Chọn giới tính.");
                else if (txtDiaChi.Text == "")
                    MessageBox.Show("Nhập địa chỉ.");
                else
                {
                    String gioitinh;
                    if (rdoNam.Checked) gioitinh = "Nam";
                    else gioitinh = "Nữ";

                    Double value;
                    if (Double.TryParse(txtSDT.Text, out value) == false)
                        MessageBox.Show("Số điện thoại phải là số.");
                    else if (txtSDT.TextLength < 10 || txtSDT.TextLength > 11)
                        MessageBox.Show("Số điện thoại gồm 10 hoặc 11 số.");
                    else
                    {
                        DocGia docgia = new DocGia(txtMaDG.Text, txtTenDG.Text, gioitinh, txtDiaChi.Text, txtSDT.Text);
                        DocGiaBUS.Instance.ThemDG(docgia);

                        QuanLySach_Load(sender, e);
                        MessageBox.Show("Thêm thành công.");
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Trùng mã độc giả.");
            }
        }

        private void btnSuaDG_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenDG.Text == "" && rdoNam.Checked == false && rdoNu.Checked == false && txtDiaChi.Text == "" && txtSDT.Text == "")
                    MessageBox.Show("Chọn độc giả.");
                else
                {
                    String gioitinh;
                    if (rdoNam.Checked) gioitinh = "Nam";
                    else gioitinh = "Nữ";

                    Double value;
                    if (Double.TryParse(txtSDT.Text, out value) == false)
                        MessageBox.Show("Số điện thoại phải là số.");
                    else if (txtSDT.TextLength < 10 || txtSDT.TextLength > 11)
                        MessageBox.Show("Số điện thoại gồm 10 hoặc 11 số.");
                    else
                    {
                        DocGia docgia = new DocGia(txtMaDG.Text, txtTenDG.Text, gioitinh, txtDiaChi.Text, txtSDT.Text);
                        DocGiaBUS.Instance.SuaDG(docgia);
                        QuanLySach_Load(sender, e);

                        MessageBox.Show("Sửa thành công.");
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void btnXoaDG_Click(object sender, EventArgs e)
        {
            try
            {
                //DialogResult dlr = MessageBox.Show("Mọi thông tin về độc giả '"+txtTenDG.Text+"' sẽ bị xóa vĩnh viễn.\nBạn muốn tiếp tục?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (txtTenDG.Text == "" && rdoNam.Checked == false && rdoNu.Checked == false && txtDiaChi.Text == "" && txtSDT.Text == "")
                    MessageBox.Show("Chọn độc giả.");
                else //if(dlr == DialogResult.Yes)
                {
                    DocGiaBUS.Instance.XoaDG(txtMaDG.Text);  
                    QuanLySach_Load(sender, e);
                }

            }
            catch
            {
                return;
            }
        }

        private void btnLapPhieuMuon_Click(object sender, EventArgs e)
        {
            if (txtTenDG.Text == "")
                MessageBox.Show("Vui lòng chọn độc giả.");
            else
            {
                panQuanLySach.Hide();
                panDocGia.Hide();
                tabQuanLyPhieu.Show();

                txtMaDGPhieu.Text = txtMaDG.Text;
                cmbTenDGPhieu.SelectedValue = txtMaDGPhieu.Text;
                tabQuanLyPhieu.SelectedTab = tabQuanLyPhieu.TabPages[0];
            }
            
            
        }

        private void txtTimKiemDocGia_TextChanged(object sender, EventArgs e)
        {
            String str = txtTimKiemDocGia.Text;
            dtgDocGia.DataSource = DocGiaBUS.Instance.TimKiemDG(str);
        }

        private void dtgDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                row = e.RowIndex;

                txtMaDG.Enabled = false;
                txtMaDG.Text = dtgDocGia.Rows[row].Cells[0].Value.ToString();
                txtTenDG.Text = dtgDocGia.Rows[row].Cells[1].Value.ToString();

                String gioitinh = dtgDocGia.Rows[row].Cells[2].Value.ToString(); ;
                if (gioitinh == "Nam") rdoNam.Checked = true;
                else rdoNu.Checked = true;

                txtDiaChi.Text = dtgDocGia.Rows[row].Cells[3].Value.ToString();
                txtSDT.Text = dtgDocGia.Rows[row].Cells[4].Value.ToString();
            }
            catch
            {
                return;
            }
        }

        private void panDocGia_MouseClick(object sender, MouseEventArgs e)
        {
            //txtMaDG.Text = "DG" + (dtgDocGia.RowCount + 1 < 10 ? "0" : "") + (dtgDocGia.RowCount+1);
            tangMaDG();
            txtMaDG.Enabled = false;

            txtTenDG.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }
        // Kết thúc Độc Giả

        //Code Quản lý sách

        private void dtgQuanLySach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaSach.Enabled = false;
                row = e.RowIndex;
                txtMaSach.Text = dtgQuanLySach.Rows[row].Cells[0].Value.ToString();
                txtTenSach.Text = dtgQuanLySach.Rows[row].Cells[1].Value.ToString();
                cmbTheLoai.Text = dtgQuanLySach.Rows[row].Cells[2].Value.ToString();
                txtSoLuong.Text = dtgQuanLySach.Rows[row].Cells[3].Value.ToString();
                txtTacGia.Text = dtgQuanLySach.Rows[row].Cells[4].Value.ToString();
            }
            catch
            {
                return;
            }

        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            
            //if (txtMaSach.TextLength == 0) MessageBox.Show("Mã sách không được để trông.");
             if (txtTenSach.TextLength == 0) MessageBox.Show("Tên sách không được để trống.");
            else if (txtSoLuong.TextLength == 0) MessageBox.Show("vui lòng nhập số lượng");
            else
            {
                try
                {
                    Sach sach = new Sach(txtMaSach.Text, txtTenSach.Text, (cmbTheLoai.SelectedValue.ToString()), int.Parse(txtSoLuong.Text), txtTacGia.Text);
                    SachBUS.Instance.AddBook(sach);
                    QuanLySach_Load(sender, e);
                    txtMaSach.Text = "MS" + (dtgQuanLySach.RowCount+1 < 11 ? "0" : "") + ((dtgQuanLySach.RowCount) + 1);
                    txtMaSach.Text = "MS" + (dtgQuanLySach.RowCount + 1 < 11 ? "0" : "") + ((dtgQuanLySach.RowCount) );
                }
                catch (SqlException)
                {
                    MessageBox.Show("Trùng mã Sách.");
                }
                catch(FormatException)
                {
                    MessageBox.Show("Nhập sai kiểu dữ liệu.");
                }

            }
            
        }
      
        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            if (txtTenSach.TextLength == 0) MessageBox.Show("Tên sách không được để trống.");
            else if (txtSoLuong.TextLength == 0) MessageBox.Show("vui lòng nhập số lượng");
            else
            {
                try
                {
                    Sach sach = new Sach(txtMaSach.Text, txtTenSach.Text, cmbTheLoai.SelectedValue.ToString(), int.Parse(txtSoLuong.Text), txtTacGia.Text);

                    SachBUS.Instance.UpdateBook(sach);

                    QuanLySach_Load(sender, e);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Nhập sai kiểu dữ liệu.");
                }
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMaSach.Text;
                SachBUS.Instance.DeleteBook(ma);
                QuanLySach_Load(sender, e);
            }
            catch 
            {
                return;
            }
            
           
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            
            string dk = txtTimKiem.Text;
            dtgQuanLySach.DataSource= SachBUS.Instance.LookBook(dk);
        }

        private void panQuanLySach_Click(object sender, EventArgs e)
        {
            //txtMaSach.Enabled = true;
            txtTenSach.Text = "";
            txtSoLuong.Text = "";
            txtTacGia.Text = "";
            txtMaSach.Text = "MS" + (dtgQuanLySach.RowCount + 1 < 11 ? "0" : "") + ((dtgQuanLySach.RowCount));
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        //Quản Lý Phiếu Mượn Trả

        private void txtTKPhieu_TextChanged(object sender, EventArgs e)
        {
           dgvPhieuMuon.DataSource= PhieuMuonBUS.Instance.LookPhieuMuon(txtTKPhieu.Text);

           dgvPhieuTra.DataSource= PhieuMuonBUS.Instance.LookPhieuTra(txtTKPhieu.Text);
        }
        //Xóa Bên Phiếu Mượn
        private void btnXoaP_Click_1(object sender, EventArgs e)
        {
            try
            {
                int currentIndex = dgvPhieuMuon.CurrentCell.RowIndex;
                string mdg = dgvPhieuMuon.Rows[currentIndex].Cells[0].Value.ToString();
                string ms = dgvPhieuMuon.Rows[currentIndex].Cells[1].Value.ToString();
                PhieuMuonBUS.Instance.DeletePhieu(mdg, ms);
                dgvPhieuMuon.DataSource = PhieuMuonBUS.Instance.LoadPhieuMuon();
            }
            catch 
            {

                return;
            }
               
            
        }

        private void cmbTenSachPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblSLM.Show();
            txtSLMuon.Show();
        }

        //Phiếu Mượn
        private void btnShowPM_Click(object sender, EventArgs e)
        {
            dgvPhieuTra.Hide();
            dgvPhieuMuon.Show();
            dgvPhieuMuon.DataSource = PhieuMuonBUS.Instance.LoadPhieuMuon();

        }

        private void btnThemPhieu_Click_1(object sender, EventArgs e)
        {
            if (txtMaDGPhieu.TextLength == 0) MessageBox.Show("Mã Độc Giả Trống.");

            else if (cmbTenSachPhieu.SelectedIndex == -1) MessageBox.Show("Vui lòng chọn sách");

            else if (txtSLMuon.TextLength == 0) MessageBox.Show("Vui lòng nhập số lượng.");
            else
            try
            {
                row = lstSachMuon.Items.Count;
                lstSachMuon.Items.Add(cmbTenSachPhieu.SelectedValue.ToString());
                lstSachMuon.Items[row].SubItems.Add(cmbTenSachPhieu.Text);
                lstSachMuon.Items[row].SubItems.Add(txtSLMuon.Text);
                lblSLM.Hide();
                txtSLMuon.Hide();
            }
            catch
            {
                return;
            }

        }

        private void btnXoaListSach_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstSachMuon.Items)
            {
                if (item.Selected)
                    item.Remove();
            }
        }

        private void btnLapPhieu_Click_1(object sender, EventArgs e)
        {
            if (txtMaDGPhieu.TextLength == 0) MessageBox.Show("Mã Độc Giả Trống.");

            else if (cmbTenSachPhieu.SelectedIndex == -1) MessageBox.Show("Vui lòng chọn sách");

            else if (txtSLMuon.TextLength == 0) MessageBox.Show("Vui lòng nhập số lượng.");

            else
            {
                for (int i = 0; i < lstSachMuon.Items.Count; i++)
                {
                    PhieuMuon phieu = new PhieuMuon(txtMaDGPhieu.Text, lstSachMuon.Items[i].SubItems[0].Text, int.Parse(lstSachMuon.Items[i].SubItems[2].Text), dpkNgayMuon.Value);
                    PhieuMuonBUS.Instance.AddPhieuMuon(phieu);
                }
                QuanLySach_Load(sender, e);
                MessageBox.Show("Lập Thành Công.");
            }

       
            
        }

        private void dgvPhieuMuon_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    row = e.RowIndex;
            //    txtTKPhieu.Text = dgvPhieuMuon.Rows[row].Cells[0].Value.ToString();
            //}
            //catch
            //{
            //    return;
            //}
        }


        //Phiếu Trả


        private void btnShowPT_Click(object sender, EventArgs e)
        {
            dgvPhieuMuon.Hide();
            dgvPhieuTra.Show();
            dgvPhieuTra.DataSource = PhieuMuonBUS.Instance.LoadPhieuTra();
        }

        private void cmbTenDGPhieu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                txtMaDGPhieu.Text = cmbTenDGPhieu.SelectedValue.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Mã DG trống.");
            }
            
        }
      
        private void dgvPhieuTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    row = e.RowIndex;
            //    txtTKPhieu.Text = dgvPhieuTra.Rows[row].Cells[0].Value.ToString();
            //}
            //catch
            //{
            //    return;
            //}
            
        }
       
        private void cboDGPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSachTra.DataSource = PhieuMuonBUS.Instance.GetSachTra(cboDGPT.Text);
        }
       
        private void btnXoaSachTra_Click(object sender, EventArgs e)
        {
            try
            {
                int currentIndex = dgvSachTra.CurrentCell.RowIndex;
                dgvSachTra.Rows.RemoveAt(currentIndex);
            }
            catch 
            {
                return;
            }
            
            
        }

        private void btnLapPhieuTra_Click(object sender, EventArgs e)
        {
            DateTime ngaytra = dpkNgayTra.Value;
            if (cboDGPT.SelectedIndex == -1) MessageBox.Show("Chọn độc giả cần lập phiếu.");
            else
            {
                for (int i = 0; i < dgvSachTra.RowCount; i++)
                {
                    string masach = dgvSachTra.Rows[0].Cells[0].Value.ToString();
                    PhieuMuonBUS.Instance.AddPhieuTra(ngaytra, masach, cboDGPT.Text);
                    dgvSachTra.DataSource = PhieuMuonBUS.Instance.GetSachTra(cboDGPT.Text);
                }

                MessageBox.Show("Ok");
            }
           

        }

        //Xóa Bên Phiếu Trả
        private void btnXoaPT_Click(object sender, EventArgs e)
        {
            try
            {
                int currentIndex = dgvPhieuTra.CurrentCell.RowIndex;
                string mdg2 = dgvPhieuTra.Rows[currentIndex].Cells[0].Value.ToString();
                string ms2 = dgvPhieuTra.Rows[currentIndex].Cells[1].Value.ToString();
                PhieuMuonBUS.Instance.DeletePhieu(mdg2, ms2);
                dgvPhieuTra.DataSource = PhieuMuonBUS.Instance.LoadPhieuTra();
            }
            catch 
            {
                return;
            }




        }

        


        //Kết thúc xóa PT

        

    }
}
