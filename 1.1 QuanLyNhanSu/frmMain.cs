using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1_QuanLyNhanSu
{
    public partial class frmMain : Form
    {
        public void getData(string select)
        {
            string sql = "";
            try
            {
                SqlConnection kn = new SqlConnection(globalParemeter.connectionString);
                kn.Open();
                sql = @"select nv.MaNV,TenNV,GioiTinh,QueQuan,BaoHiemXH,SoDT,TenPB,TenCV,TenTD,nv.MaCV,nv.MaPB,nv.MaTD
                                from tblNhanVien nv left join tblPhongBan pb
                                    on nv.MaPB= pb.MaPB left join tblChucVu cv 
                                    on nv.MaCV = cv.MaCV left join tblTrinhDo td
                                    on nv.MaTD = td.MaTD,tblHoSo hs
                                    where nv.MaNV = hs.MaNV";
                sql = sql + select;
                SqlCommand command = new SqlCommand();
                SqlDataAdapter com = new SqlDataAdapter();
                dgvNhanVien.Columns.Clear();
                dgvNhanVien.AutoGenerateColumns = false;
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaNV";
                column.HeaderText = "Mã NV";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TenNV";
                column.HeaderText = "Tên NV";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "GioiTinh";
                column.HeaderText = "Giới Tính";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "QueQuan";
                column.HeaderText = "Quê Quán";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "BaoHiemXH";
                column.HeaderText = "Mã BHXH";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "SoDT";
                column.HeaderText = "Số ĐT";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TenPB";
                column.HeaderText = "Phòng Ban";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TenTD";
                column.HeaderText = "Trình Độ";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TenCV";
                column.HeaderText = "Công Việc";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                command = new SqlCommand(sql, kn);
                com = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                com.Fill(dt);
                dgvNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối dữ liệu");
                MessageBox.Show(sql);
            }
            finally
            {
                SqlConnection con = new SqlConnection();
                con.Close();
            }
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            getData("");

            SqlConnection con = new SqlConnection(globalParemeter.connectionString);
            con.Open();

            string sql = "select * from tblPhongBan";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataAdapter com = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            com.Fill(dt);
            cbbPhongBan.DataSource = dt;
            cbbPhongBan.DisplayMember = dt.Columns["TenPB"].ToString();
            cbbPhongBan.ValueMember = dt.Columns["MaPB"].ToString();

            sql = "select * from tblChucVu";
            command = new SqlCommand(sql, con);
            com = new SqlDataAdapter(command);
            dt = new DataTable();
            com.Fill(dt);
            cbbCongViec.DataSource = dt;
            cbbCongViec.DisplayMember = dt.Columns["TenCV"].ToString();
            cbbCongViec.ValueMember = dt.Columns["MaCV"].ToString();

            sql = "select * from tblTrinhDo";
            command = new SqlCommand(sql, con);
            com = new SqlDataAdapter(command);
            dt = new DataTable();
            com.Fill(dt);
            cbbTrinhDo.DataSource = dt;
            cbbTrinhDo.DisplayMember = dt.Columns["TenTD"].ToString();
            cbbTrinhDo.ValueMember = dt.Columns["MaTD"].ToString();

            con.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MainThem them = new MainThem();
            them.action_Them(this);
            action_XoaThietLap();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MainSua sua = new MainSua();
            sua.action_Sua(this);
            action_XoaThietLap();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MainXoa xoa = new MainXoa();
            xoa.action_Xoa(this);
            action_XoaThietLap();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MainTimKiem timkiem = new MainTimKiem();
            timkiem.action_TimKiem(this);
        }
        private void action_XoaThietLap()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            rbtnNam.Checked = true;
            cbGioiTinh.Checked = false;
            txtQueQuan.Text = "";
            txtBaoHiemXH.Text = "";
            txtSDT.Text = "";
            cbCongViec.Checked = false;
            cbPhongBan.Checked = false;
            cbTrinhDo.Checked = false;
        }
        private void dgvNhanVien_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            if (dgvNhanVien.CurrentRow.Cells[2].Value.ToString() == "Nam")
            {
                cbGioiTinh.Checked = true;
                rbtnNam.Checked = true;
            }
            else if (dgvNhanVien.CurrentRow.Cells[2].Value.ToString() == "Nu")
            {
                cbGioiTinh.Checked = true;
                rbtnNu.Checked = true;
            }
            else
            {
                cbGioiTinh.Checked = false;
            }
            txtQueQuan.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            txtBaoHiemXH.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
            if (dgvNhanVien.CurrentRow.Cells["MaCV"].Value.ToString() != "")
            {
                cbCongViec.Checked = true;
                cbbCongViec.SelectedValue = dgvNhanVien.CurrentRow.Cells["MaCV"].Value.ToString();
            }
            else
            {
                cbCongViec.Checked = false;
            }
            if (dgvNhanVien.CurrentRow.Cells["MaPB"].Value.ToString() != "")
            {
                cbPhongBan.Checked = true;
                cbbPhongBan.SelectedValue = dgvNhanVien.CurrentRow.Cells["MaPB"].Value.ToString();
            }
            else
            {
                cbPhongBan.Checked = false;
            }
            if (dgvNhanVien.CurrentRow.Cells["MaTD"].Value.ToString() != "")
            {
                cbTrinhDo.Checked = true;
                cbbTrinhDo.SelectedValue = dgvNhanVien.CurrentRow.Cells["MaTD"].Value.ToString();
            }
            else
            {
                cbTrinhDo.Checked = false;
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult hoi;
            hoi = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
    }
}