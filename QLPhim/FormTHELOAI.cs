using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace khasingum
{
    public partial class FormTHELOAI : Form
    {
        THELOAI tl = new THELOAI();
        SANPHAM sp = new SANPHAM();
        DATABASE diaphim = new DATABASE();
        DataTable table = new DataTable();
        public FormTHELOAI()
        {
            InitializeComponent();
            table = diaphim.getData("spr_THELOAI_SANPHAM", null);
            dataGridView1.DataSource = table;
            try
            {
                listBox1.DataSource = sp.getSANPHAMbyTHELOAI(Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString()));
                listBox1.DisplayMember = "NAME";
                listBox1.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void FormTHELOAI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            id.Text = "";
            name.Text = "";
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            diaphim.openConnection();
            if (name.Text != string.Empty)
            {
                tl.insertTHELOAI(name.Text);
                MessageBox.Show("Thêm thành công", "Thêm Thể Loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = tl.getTHELOAI();
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (id.Text != string.Empty)
            {
                if (MessageBox.Show("Bạn có muốn xóa không", "Xóa thể loại", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        tl.deleteTHELOAI(Convert.ToInt32(id.Text));
                        table = tl.getTHELOAI();
                        dataGridView1.DataSource = table;
                        MessageBox.Show("Bạn đã xóa thành công!!!", "Xóa thể loại");
                        id.Text = "";
                        name.Text = "";
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("ID rỗng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (id.Text != string.Empty || name.Text != string.Empty)
            {
                try
                {
                    diaphim.openConnection();
                    tl.updateTHELOAI(Convert.ToInt16(id.Text), name.Text);
                    MessageBox.Show("Cập nhật thành công", "Sửa thể loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = tl.getTHELOAI();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu rỗng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                listBox1.DataSource = sp.getSANPHAMbyTHELOAI(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                listBox1.DisplayMember = "TENPHIM";
                listBox1.ValueMember = "ID";
                
               
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            int val;
            Int32.TryParse(dataGridView1.CurrentRow.Cells[0].Value.ToString(), out val);
            dataGridView2.DataSource = sp.getSANPHAMbyTHELOAI(val);
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView2.Columns[4];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.RowTemplate.Height = 60;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        int x = 219, y = 44, a = 1;
        Random ramdom = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                x += a;
                label3.Location = new Point(x, y);
                if (x >= 661)
                {
                    a = -1;
                    label3.ForeColor = Color.FromArgb(ramdom.Next(0, 255), ramdom.Next(0, 255), ramdom.Next(0, 255));
                }
                if (x <= 219)
                {
                    a = 1;
                    label3.ForeColor = Color.FromArgb(ramdom.Next(0, 255), ramdom.Next(0, 255), ramdom.Next(0, 255));
                }
            }
            catch (Exception ex) { }
        }
    }
}
