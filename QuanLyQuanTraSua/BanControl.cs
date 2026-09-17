using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class BanControl : UserControl
    {
        private int idBanDangChon;
        public int IdBan { get; set; }
        public string TenBan
        {
            get => lblTenBan.Text;
            set => lblTenBan.Text = value;
        }

        public event EventHandler Clicked;
        public event EventHandler<(int idBan, string tenBan)> BanDuocClick; 

        public BanControl(DTO_BanAn ban)
        {
            InitializeComponent();
            this.IdBan = ban.IdBanAn;
            this.TenBan = ban.TenBanAn;
            lblTrangThai.Text = ban.TrangThai;
            this.BackColor = ban.TrangThai == "Đã có người" ? System.Drawing.Color.LightSalmon : System.Drawing.Color.LightGreen;

            this.Click += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);
            lblTenBan.Click += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);
            lblTrangThai.Click += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);

            this.Click += (s, e) => BanDuocClick?.Invoke(this, (IdBan, TenBan));
            lblTenBan.Click += (s, e) => BanDuocClick?.Invoke(this, (IdBan, TenBan));
            lblTrangThai.Click += (s, e) => BanDuocClick?.Invoke(this, (IdBan, TenBan));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int radius = 20;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }

        private void BanControl_Load(object sender, EventArgs e) { }
        private void BanControl_Click(object sender, EventArgs e) { }
    }
}