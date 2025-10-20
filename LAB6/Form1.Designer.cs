using System.Drawing;
using System.Windows.Forms;

namespace 1150080142
{

    public partial class Form1
    {
        // 🔹 Khai báo control
        private ListView lsvDanhSach;
        private TextBox txtMaXB, txtTenXB, txtDiaChi;
        private Button btnThem;
        private Label lblMaXB, lblTenXB, lblDiaChi, lblDanhSach, lblThongTin, lblTieuDe;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // ===== FORM =====
            this.Text = "Thêm dữ liệu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(720, 420);
            this.BackColor = Color.WhiteSmoke;

            // ===== LABEL TIÊU ĐỀ =====
            lblTieuDe = new Label
            {
                Text = "Thêm dữ liệu",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(270, 10),
                AutoSize = true
            };

            // ===== DANH SÁCH =====
            lblDanhSach = new Label { Text = "Danh sách nhà xuất bản:", Location = new Point(20, 50), AutoSize = true };

            lsvDanhSach = new ListView
            {
                Location = new Point(20, 70),
                Size = new Size(360, 280),
                View = View.Details,
                GridLines = true,
                FullRowSelect = true
            };
            lsvDanhSach.Columns.Add("Mã NXB", 80);
            lsvDanhSach.Columns.Add("Tên NXB", 120);
            lsvDanhSach.Columns.Add("Địa chỉ", 150);

            // ===== THÔNG TIN NHẬP =====
            lblThongTin = new Label { Text = "Thông tin nhập liệu:", Location = new Point(400, 50), AutoSize = true };

            lblMaXB = new Label { Text = "Mã NXB:", Location = new Point(400, 90), AutoSize = true };
            txtMaXB = new TextBox { Location = new Point(480, 85), Width = 200 };

            lblTenXB = new Label { Text = "Tên NXB:", Location = new Point(400, 130), AutoSize = true };
            txtTenXB = new TextBox { Location = new Point(480, 125), Width = 200 };

            lblDiaChi = new Label { Text = "Địa chỉ:", Location = new Point(400, 170), AutoSize = true };
            txtDiaChi = new TextBox { Location = new Point(480, 165), Width = 200 };

            // ===== NÚT THÊM =====
            btnThem = new Button
            {
                Text = "Thêm nhà xuất bản",
                BackColor = Color.LightGreen,
                Location = new Point(440, 220),
                Size = new Size(180, 40)
            };

            // ===== ADD CONTROL =====
            this.Controls.Add(lblTieuDe);
            this.Controls.Add(lblDanhSach);
            this.Controls.Add(lsvDanhSach);
            this.Controls.Add(lblThongTin);
            this.Controls.Add(lblMaXB);
            this.Controls.Add(txtMaXB);
            this.Controls.Add(lblTenXB);
            this.Controls.Add(txtTenXB);
            this.Controls.Add(lblDiaChi);
            this.Controls.Add(txtDiaChi);
            this.Controls.Add(btnThem);

            this.ResumeLayout(false);
        }
    }
}