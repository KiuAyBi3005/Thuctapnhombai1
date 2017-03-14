using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1_QuanLyNhanSu
{
    class MainSua
    {
        public void action_Sua(frmMain frm)
        {
            try
            {
                SqlConnection con = new SqlConnection(globalParemeter.connectionString);
                con.Open();
                string gt = "null";
                string cv = "null";
                string pb = "null";
                string td = "null";
                if (frm.cbGioiTinh.Checked == true)
                {
                    if (frm.rbtnNam.Checked) gt = "'Nam'";
                    else if (frm.rbtnNu.Checked) gt = "'Nu'";
                }
                if (frm.cbCongViec.Checked == true)
                {
                    cv = frm.cbbCongViec.SelectedValue.ToString();
                }
                if (frm.cbPhongBan.Checked == true)
                {
                    pb = frm.cbbPhongBan.SelectedValue.ToString();
                }
                if (frm.cbTrinhDo.Checked == true)
                {
                    td = frm.cbbTrinhDo.SelectedValue.ToString();
                }
                string sql = @"update tblNhanVien set MaPB=" + pb + ",MaCV=" + cv + ",MaTD=" + td + " where MaNV=" + frm.txtMaNV.Text + "\n"
                    + "update tblHoSo set TenNV='" + frm.txtTenNV.Text + "',GioiTinh=" + gt + ",QueQuan='" + frm.txtQueQuan.Text + "',BaoHiemXH='" + frm.txtBaoHiemXH.Text + "',SoDT='" + frm.txtSDT.Text + "' where MaNV=" + frm.txtMaNV.Text;

                try
                {
                    SqlCommand command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối");
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chưa Sửa được");
            }
            frm.getData("");
        }
    }
}
