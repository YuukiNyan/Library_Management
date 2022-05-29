﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ThayDoiQuyDinh
{

    public partial class FormThayDoiQuyDinh : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataTable table = new DataTable();
        string str = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        string DG = "";
        public FormThayDoiQuyDinh()
        {
            InitializeComponent();

        }
        void loadQD()
        {
            disableSortHeader();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select ThoiHanThe,TuoiToiThieu,TuoiToiDa,ThoiGianLuuHanh,SoNgayMuonMax,SoSachMuonMax,format(MucThuTienPhat,'#.') from ThamSo ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            string s = "";
            s += table.Rows[0].ItemArray[0].ToString();
         
                s += " tháng";
            
            label17.Text = s;
            s = "";
            s += table.Rows[0].ItemArray[3].ToString();
            s += " năm";
            label18.Text = s;
            s = "";
            s += table.Rows[0].ItemArray[2].ToString();
            s += " tuổi";
            label19.Text = s;
            s = "";
            s += table.Rows[0].ItemArray[1].ToString();
            s += " tuổi";
            label20.Text = s;
            s = "";
            s += table.Rows[0].ItemArray[4].ToString();
            s += " ngày";
            label21.Text = s;
            s = "";
            s += table.Rows[0].ItemArray[5].ToString();
            s += " cuốn";
            label22.Text = s;

            s = "";
            s += table.Rows[0].ItemArray[6].ToString();
            s += " đồng";
            label23.Text = s;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            connection = new SqlConnection(str);
            connection.Open();
         
            loadQD();
           

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cập nhật quy định thành công");
            if (txbThoiHanThe.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "update Thamso set ThoiHanThe='" + txbThoiHanThe.Text + "' ";
                command.ExecuteNonQuery();
            }
            if (txbThoiGianLuuHanh.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "update Thamso set ThoiGianLuuHanh='" + txbThoiGianLuuHanh.Text + "' ";
                command.ExecuteNonQuery();
            }
            if (txbTuoiToiDa.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "update Thamso set TuoiToiDa='" + txbTuoiToiDa.Text + "' ";
                command.ExecuteNonQuery();
            }
            if (txbTuoiToiThieu.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "update Thamso set TuoiToiThieu='" + txbTuoiToiThieu.Text + "' ";
                command.ExecuteNonQuery();
            }
            if (txbSoNgayMuonMax.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "update Thamso set SoNgayMuonMax='" + txbSoNgayMuonMax.Text + "' ";
                command.ExecuteNonQuery();
            }
            if (txbSoSachMuonMax.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "update Thamso set SoSachMuonMax='" + txbSoSachMuonMax.Text + "' ";
                command.ExecuteNonQuery();
            }
            if (txbMucThuTienPhat.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "update Thamso set MucThuTienPhat='" + txbMucThuTienPhat.Text + "' ";
                command.ExecuteNonQuery();
            }
            txbThoiHanThe.Text = "";
            txbThoiGianLuuHanh.Text = "";
            txbTuoiToiDa.Text = "";
            txbSoNgayMuonMax.Text = "";
            txbTuoiToiThieu.Text = "";
            txbSoSachMuonMax.Text = "";
            txbMucThuTienPhat.Text = "";
            loadQD();
        
        }

        private void nButton3_Click(object sender, EventArgs e)
        {
            panel4.Hide();
          
            btnCapNhat.Hide();
        
            panel2.Hide();
            label9.Text = "Danh Sách Loại Độc Giả";
            DataTable table1 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select MaLoaiDocGia as [Mã Loại],TenLoaiDocGia as [Tên Loại Độc Giả] from LoaiDocGia";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            gbQuyDinhHienHanh.DataSource = table1;

        }

        private void nButton2_Click(object sender, EventArgs e)
        {
            panel4.Show();
           
            btnCapNhat.Show();
          
            panel2.Show();
            label9.Text = "Quy Định Hiện Hành ";
            gbQuyDinhHienHanh.DataSource = null;
        }

        void loadDocGia()
        {
            DataTable table1 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select MaLoaiDocGia as [Mã Loại],TenLoaiDocGia as [Tên Loại Độc Giả] from LoaiDocGia";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            gbQuyDinhHienHanh.DataSource = table1;
        }
        void loadTheLoai()
        {
            DataTable table1 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select MaTheLoai as [Mã Loại],TenTheLoai as [Tên Thể Loại Sách] from TheLoai";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            gbQuyDinhHienHanh.DataSource = table1;
        }
        private void nButton4_Click(object sender, EventArgs e)
        {
            label9.Text = "Danh Sách Loại Độc Giả";
            loadDocGia();
            label24.Text = "Tên Loại Độc Giả";
      
        }

        private void nButton5_Click(object sender, EventArgs e)
        {
            label9.Text = "Danh Sách Thể Loại Sách";
            loadTheLoai();
            label24.Text = "Tên Thể Loại Sách";
       
        }

        private void nButton6_Click(object sender, EventArgs e)
        {
       
        }
        private void disableSortHeader()
        {
            foreach (DataGridViewColumn column in gbQuyDinhHienHanh.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
       

      
     

       

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Height.ToString() + " " + this.Width.ToString());
        }
    }
}