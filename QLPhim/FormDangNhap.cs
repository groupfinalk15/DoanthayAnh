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
    public partial class FormDangNhap : Form
    {
        DANGNHAP DN = new DANGNHAP();
        public FormDangNhap()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Form1_Load(object sender, EventArgs e)
        {
        }

       
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDangNhap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = DN.login(username.Text, password.Text);
            if (table.Rows.Count > 0)
            {

                if (table.Rows[0]["TYPE"].ToString() == "admin")
                {
                    this.Hide();
                    formchinh FH = new formchinh();
                    FH.Show();

                }

                else
                {
                    this.Hide();
                    formchinh FH = new formchinh();
                    FH.button3.Visible = false;
                    FH.Show();

                }
            }

            else
            {
                MessageBox.Show("Ten Dang nhap hoac mat khau khong chinh xac!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
