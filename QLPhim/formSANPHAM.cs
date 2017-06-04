using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
namespace khasingum
{
    public partial class formSANPHAM : Form
    {
        FormTENTHELOAI ttl = new FormTENTHELOAI();
        THELOAI tl = new THELOAI();
        SANPHAM SP = new SANPHAM();
        public formSANPHAM()
        {
            InitializeComponent();
            loadComboCategory();
            dataGridViewsp.DataSource = SP.getSANPHAM();
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridViewsp.Columns[4];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewsp.AllowUserToAddRows = false;
            dataGridViewsp.RowTemplate.Height = 50;
            COMBO_TheLoai.DataSource = tl.getTHELOAI();
            COMBO_TheLoai.DisplayMember = "NAME";
            COMBO_TheLoai.ValueMember = "T_ID";
        }

        private void tab1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void COMBO_TheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txttenphim_TextChanged(object sender, EventArgs e)
        {

        }

        private void laltenphim_Click(object sender, EventArgs e)
        {

        }

        public void loadComboCategory()
        {
            COMBO_TheLoai.DataSource = tl.getTHELOAI();
            COMBO_TheLoai.DisplayMember = "NAME";
            COMBO_TheLoai.ValueMember = "T_ID";
        }

        private void Btnthem_Click(object sender, EventArgs e)
        {
            FormTENTHELOAI fg = new FormTENTHELOAI();
            fg.ShowDialog();
            loadComboCategory();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ImagefileDialog = new OpenFileDialog();
            ImagefileDialog.Filter = "HINHANH |*.JPG; *.PNG; *.GIF";
            if (ImagefileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ImagefileDialog.FileName);
                
            }
        }

        private void txtthoiluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            char separator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != separator)
            {
                e.Handled = true;
            }
        }

        private void butthem_Click(object sender, EventArgs e)
        {
            if(txttenphim.Text == string.Empty || txtlinkphim.Text == string.Empty || txtthoiluong.Text == string.Empty || txtnamsanxuat.Text == string.Empty || txtdaodien.Text == string.Empty || pictureBox1.Image == null)
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin !!!", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] image = ms.ToArray();

                SP.insertSANPHAM(Convert.ToInt32(COMBO_TheLoai.SelectedValue), txttenphim.Text,
                                     txtlinkphim.Text, image, Convert.ToInt32(txtthoiluong.Text), txtnamsanxuat.Text, txtdaodien.Text);
                MessageBox.Show("Bạn đã thêm thành công", "New Product", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            dataGridViewsp.DataSource = SP.getSANPHAM();
        }

        private void butsua_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] image = ms.ToArray();

            if (txttenphim.Text == string.Empty || txtlinkphim.Text == string.Empty || txtthoiluong.Text == string.Empty || txtnamsanxuat.Text == string.Empty || txtdaodien.Text == string.Empty || pictureBox1.Image == null)
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin!!!", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SP.updateSANPHAM(Convert.ToInt32(label4.Text), Convert.ToInt32(COMBO_TheLoai.SelectedValue), 
                    txttenphim.Text, txtlinkphim.Text, image, Convert.ToInt32(txtthoiluong.Text), txtnamsanxuat.Text, txtdaodien.Text);
                MessageBox.Show("Bạn đã sửa Phim Thành công", "update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataGridViewsp.DataSource = SP.getSANPHAM();
        }

        private void dataGridViewsp_DoubleClick(object sender, EventArgs e)
        {
            label4.Text = dataGridViewsp.CurrentRow.Cells[0].Value.ToString();
            txttenphim.Text = dataGridViewsp.CurrentRow.Cells[1].Value.ToString();
            txtlinkphim.Text = dataGridViewsp.CurrentRow.Cells[2].Value.ToString();
            txtthoiluong.Text = dataGridViewsp.CurrentRow.Cells[3].Value.ToString();
            COMBO_TheLoai.Text = dataGridViewsp.CurrentRow.Cells[7].Value.ToString();
            txtnamsanxuat.Text = dataGridViewsp.CurrentRow.Cells[5].Value.ToString();
            txtdaodien.Text = dataGridViewsp.CurrentRow.Cells[6].Value.ToString();
            byte[] img = (byte[])dataGridViewsp.CurrentRow.Cells[4].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            dataGridViewsp.DataSource = SP.getSANPHAM();
            
        }

        private void formSANPHAM_Load(object sender, EventArgs e)
        {

        }

        private void butcapnhap_Click(object sender, EventArgs e)
        {
            txttenphim.Text = "";
            txtlinkphim.Text = "";
            txtthoiluong.Text ="";
            txtnamsanxuat.Text = "";
            txtdaodien.Text = "";
        }

        private void butxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa phim không !!!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SP.deleteSANPHAM(Convert.ToInt16(dataGridViewsp.CurrentRow.Cells[0].Value));   
                MessageBox.Show("Bạn đã xóa thành công", "delete");
                formSANPHAM sp = new formSANPHAM();
                sp.Show();

            }
            dataGridViewsp.DataSource = SP.getSANPHAM();
        }

        private void laltenphim_Click_1(object sender, EventArgs e)
        {

        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            dataGridViewsp.DataSource = SP.searchSANPHAM(txttimkiem.Text);
        } 

        private void panel4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
       

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void formSANPHAM_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        int x = 219, y = 44, a = 1;

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://google.com");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridViewsp.DataSource = SP.searchSANPHAM(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridViewsp.DataSource = SP.searchSANPHAM(textBox2.Text);
        }

        private void txtlinkphim_TextChanged(object sender, EventArgs e)
        {

        }

        Random ramdom = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                x += a;
                label3.Location = new Point(x, y);
                if (x>=544)
                {
                    a = -1;
                    label3.ForeColor=Color.FromArgb(ramdom.Next(0,255), ramdom.Next(0,255), ramdom.Next(0, 255));
                }
                if(x<=219)
                {
                    a = 1;
                    label3.ForeColor = Color.FromArgb(ramdom.Next(0, 255), ramdom.Next(0, 255), ramdom.Next(0, 255));
                }
            }
            catch(Exception ex) { }
        }
    }
}
