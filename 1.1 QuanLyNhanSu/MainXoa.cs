using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1_QuanLyNhanSu
{
    class MainXoa
    {
        public void action_Xoa(frmMain frm)
        {
            try
            {
                SqlConnection con = new SqlConnection(globalParemeter.connectionString);
                con.Open();
                string sql = @"delete tblHoSo where MaNV=" + frm.txtMaNV.Text + "\n" +
                    "delete tblNhanVien where MaNV=" + frm.txtMaNV.Text;
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
                MessageBox.Show("Lỗi chưa Xóa được");
            }
            frm.getData("");
        }
    }
}
