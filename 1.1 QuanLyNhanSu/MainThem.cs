using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1_QuanLyNhanSu
{
    class MainThem
    {
        public void action_Them(frmMain frm)
        {
            try
            {
                SqlConnection con = new SqlConnection(globalParemeter.connectionString);
                con.Open();
                string gt = "";
                string cv = "null";
                string pb = "null";
                string td = "null";
                if (frm.cbGioiTinh.Checked == true)
                {
                    if (frm.rbtnNam.Checked) gt = "Nam";
                    else if (frm.rbtnNu.Checked) gt = "Nu";
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
                string sql = @"insert into tblNhanVien(MaNV,MaCV,MaTD,MaPB) values (" + frm.txtMaNV.Text + "," + cv + "," + td + "," + pb + ")" + "\n"
                    + "insert into tblHoSo(MaNV,TenNV,GioiTinh,QueQuan,BaoHiemXH,SoDT) values (" + frm.txtMaNV.Text + ",'" + frm.txtTenNV.Text + "','" + gt + "','" + frm.txtQueQuan.Text + "','" + frm.txtBaoHiemXH.Text + "','" + frm.txtSDT.Text + "')";
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
                MessageBox.Show("Lỗi chưa Thêm được");
            }
            frm.getData("");
        }
        
    }
}
