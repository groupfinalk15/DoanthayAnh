using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace khasingum
{
    public partial class FormNGUOIDUNGS : Form
    {
        NGUOIDUNG nd = new NGUOIDUNG();
        public FormNGUOIDUNGS()
        {
            this.ActiveControl = TENDANGNHAP;
            InitializeComponent();
            dataGridView1.DataSource = nd.getnNGUOIDUNG();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void FormNGUOIDUNGS_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void XOA_Click(object sender, EventArgs e)
        {
            if (ID.Text != string.Empty)
            {
                if (MessageBox.Show("Bạn có muốn xóa thông tin người dùng", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nd.deleteNGUOIDUNG(Convert.ToInt32(ID.Text));
                    MessageBox.Show("Xóa thành công", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = nd.getnNGUOIDUNG();
                }
            }
            else
            {
                MessageBox.Show("Chọn thông tin để xóa");

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            TENDANGNHAP.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            MATKHAU.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            LOAINGUOIDUNG.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            TEL.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            EMAIL.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void CAPNHAT_Click(object sender, EventArgs e)
        {
            if (ID.Text != string.Empty)
            {
                nd.updateNGUOIDUNG(TENDANGNHAP.Text, LOAINGUOIDUNG.Text, MATKHAU.Text, TEL.Text, EMAIL.Text, Convert.ToInt32(ID.Text));
                MessageBox.Show("Cập nhật thành công ", "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = nd.getnNGUOIDUNG();
            }

            else
            {
                MessageBox.Show("Chọn thông tin để sửa");
            }
        }

        private void RESET_Click(object sender, EventArgs e)
        {
            ID.Text = "";
            TENDANGNHAP.Text = "";
            LOAINGUOIDUNG.Text = "";
            MATKHAU.Text = "";
            TEL.Text = "";
            EMAIL.Text = "";
        }

        private void THEM_Click(object sender, EventArgs e)
        {
            if (TENDANGNHAP.Text == string.Empty || LOAINGUOIDUNG.Text == string.Empty || MATKHAU.Text == string.Empty || TEL.Text == string.Empty || EMAIL.Text == string.Empty)
            {
                MessageBox.Show("Thông tin chưa đầy đủ!!!", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                nd.insertNGUOIDUNG(TENDANGNHAP.Text, LOAINGUOIDUNG.Text, MATKHAU.Text, TEL.Text, EMAIL.Text);
                MessageBox.Show("Bạn đã thềm thành công!!!", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataGridView1.DataSource = nd.getnNGUOIDUNG();
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int x = 270, y = 41, a = 1;

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        Random ramdom = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {          
            try
            {
                x += a;
                label7.Location = new Point(x, y);
                if (x >= 603)
                {
                    a = -1;
                    label7.ForeColor = Color.FromArgb(ramdom.Next(0, 255), ramdom.Next(0, 255), ramdom.Next(0, 255));
                }
                if (x <= 270)
                {
                    a = 1;
                    label7.ForeColor = Color.FromArgb(ramdom.Next(0, 255), ramdom.Next(0, 255), ramdom.Next(0, 255));
                }
            }
            catch (Exception ex) { }        
       }
    }
}
