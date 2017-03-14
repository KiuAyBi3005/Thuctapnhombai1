using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1_QuanLyNhanSu
{
    class MainTimKiem
    {
        public void action_TimKiem(frmMain frm)
        {
            string sl = "";
            try
            {
                SqlConnection con = new SqlConnection(globalParemeter.connectionString);
                con.Open();
                string gt = "";
                if (frm.cbGioiTinh.Checked == true)
                {
                    if (frm.rbtnNam.Checked) gt = "Nam";
                    else if (frm.rbtnNu.Checked) gt = "Nu";
                    sl = sl + " and GioiTinh = '" + gt + "'";
                }
                if (frm.cbCongViec.Checked == true)
                {
                    sl = sl + " and cv.MaCV=" + frm.cbbCongViec.SelectedValue.ToString();
                }
                if (frm.cbPhongBan.Checked == true)
                {
                    sl = sl + " and pb.MaPB=" + frm.cbbPhongBan.SelectedValue.ToString();
                }
                if (frm.cbTrinhDo.Checked == true)
                {
                    sl = sl + " and td.MaTD=" + frm.cbbTrinhDo.SelectedValue.ToString();
                }
                if (frm.txtMaNV.Text != "")
                {
                    sl = sl + " and nv.MaNV = " + frm.txtMaNV.Text;
                }
                if (frm.txtTenNV.Text != "")
                {
                    sl = sl + " and TenNV = '" + frm.txtTenNV.Text + "'";
                }
                if (frm.txtQueQuan.Text != "")
                {
                    sl = sl + " and QueQuan = '" + frm.txtQueQuan.Text + "'";
                }
                if (frm.txtBaoHiemXH.Text != "")
                {
                    sl = sl + " and BaoHiemXh = '" + frm.txtBaoHiemXH.Text + "'";
                }
                if (frm.txtSDT.Text != "")
                {
                    sl = sl + " and SoDt = '" + frm.txtSDT.Text + "'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chưa Thêm được");
            }
            frm.getData(sl);
        }

    }
}
