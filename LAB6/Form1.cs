using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace 1150080142 
{
    public partial class Form1 : Form
    {
        private string strCon = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        private SqlConnection sqlCon = null;

        public Form1()
        {
            InitializeComponent();
            this.Load += (s, e) => HienThiDanhSachXB();
            btnThem.Click += (s, e) => ThemNXB();
        }

        private void MoKetNoi()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }

        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }

        // ===== Hiển thị danh sách =====
        private void HienThiDanhSachXB()
        {
            MoKetNoi();
            using (SqlCommand cmd = new SqlCommand("HienThiXB", sqlCon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                lsvDanhSach.Items.Clear();
                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["MaNXB"].ToString());
                    item.SubItems.Add(rd["TenNXB"].ToString());
                    item.SubItems.Add(rd["DiaChi"].ToString());
                    lsvDanhSach.Items.Add(item);
                }
                rd.Close();
            }
            DongKetNoi();
        }

        // ===== Thêm dữ liệu =====
        private void ThemNXB()
        {
            if (txtMaXB.Text.Trim() == "" || txtTenXB.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            MoKetNoi();
            using (SqlCommand cmd = new SqlCommand("ThemDuLieu", sqlCon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maXB", txtMaXB.Text.Trim());
                cmd.Parameters.AddWithValue("@tenXB", txtTenXB.Text.Trim());
                cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu thành công!");
            }
            DongKetNoi();
            HienThiDanhSachXB();
            txtMaXB.Clear(); txtTenXB.Clear(); txtDiaChi.Clear();
        }
    }
}
