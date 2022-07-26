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

namespace 資料庫練習
{
    public partial class Form1 : Form
    {
        private string m_BookISBN;
        private string m_BookName;
        public Form1()
        {
            InitializeComponent();
            m_BookISBN = "";
            m_BookName = "";
        }
        private void FormLoad(object sender, EventArgs e)
        {
            ColumnHeader ch1 = new ColumnHeader();
            ch1.Text = "ISBN";
            ch1.Width = 100;
            ch1.TextAlign = HorizontalAlignment.Left;
            listView1.Columns.Add(ch1);
            ColumnHeader ch1_2 = (ColumnHeader)ch1.Clone();
            listView2.Columns.Add(ch1_2);
            ColumnHeader ch2 = new ColumnHeader();
            ch2.Text = "書名";
            ch2.Width = 300;
            ch2.TextAlign = HorizontalAlignment.Left;
            listView1.Columns.Add(ch2);
            ColumnHeader ch2_2 = (ColumnHeader)ch2.Clone();
            listView2.Columns.Add(ch2_2);
            ColumnHeader ch3 = new ColumnHeader();
            ch3.Text = "作者";
            ch3.Width = 160;
            ch3.TextAlign = HorizontalAlignment.Left;
            listView1.Columns.Add(ch3);
            ColumnHeader ch4 = new ColumnHeader();
            ch4.Text = "出版社";
            ch4.Width = 150;
            ch4.TextAlign = HorizontalAlignment.Left;
            listView1.Columns.Add(ch4);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            ShowBooks();
        }
        private void ShowBooks()
        {
            using(SqlConnection sqlcn = new SqlConnection())
            {
                sqlcn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                    "AttachDBFilename=|DataDirectory|Bookstore.mdf;" +
                    "Integrated Security=True";
                sqlcn.Open();
                SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Books", sqlcn);
                SqlDataReader sqldr = sqlcmd.ExecuteReader();
                while(sqldr.Read())
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = sqldr["ISBN"].ToString();
                    lvi.SubItems.Add(sqldr["Title"].ToString());
                    lvi.SubItems.Add(sqldr["Author"].ToString());
                    lvi.SubItems.Add(sqldr["Publishing"].ToString());
   
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
            }
        }

        private void buttonNewBook_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            listView1.Items.Clear();
            ShowBooks();
        }

        private void SelectedIndexChangedListview1(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                m_BookISBN = listView1.SelectedItems[0].SubItems[0].Text;
                m_BookName = listView1.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void AddOrder(object sender, EventArgs e)
        {
            //自己寫
            using (SqlConnection sqlcn = new SqlConnection())
            {
                sqlcn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                    "AttachDBFilename=|DataDirectory|Bookstore.mdf;" +
                    "Integrated Security=True";
                sqlcn.Open();

                string ID = textBoxID.Text;
                string Name = textBoxName.Text;
                string Mobile = textBoxMobile.Text;
                string Address = textBoxAddress.Text;
                SqlCommand sqlcmd = new SqlCommand("INSERT INTO Orders (Id,Name,Address,PhoneNumber)VALUES('" +
                    ID + "',N'" + Name + "',N'" + Mobile + "',N'" + Address + "')", sqlcn);
                int i = sqlcmd.ExecuteNonQuery();
            }
        }

        private void ClearOrder(object sender, EventArgs e)
        {
            textBoxID.Text     = "";
            textBoxName.Text   = "";
            textBoxMobile.Text = "";
            textBoxAddress.Text = "";
            listView2.Items.Clear();
        }

        private void SearchOrder(object sender, EventArgs e)
        {
            using (SqlConnection sqlcn = new SqlConnection())
            {
                sqlcn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                    "AttachDBFilename=|DataDirectory|Bookstore.mdf;" +
                    "Integrated Security=True";
                sqlcn.Open();
                SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Orders WHERE Id='" + textBoxID.Text + "'", sqlcn);
                SqlDataReader sqldr = sqlcmd.ExecuteReader();
                sqldr.Read();
                textBoxName.Text   = sqldr["Name"].ToString();
                textBoxAddress.Text= sqldr["Address"].ToString();
                textBoxMobile.Text = sqldr["PhoneNumber"].ToString();
                sqldr.Close();
                sqlcmd.CommandText = "SELECT * FROM OrderBook LEFT JOIN Books ON OrderBook.ISBN=Books.ISBN WHERE Id='"+
                    textBoxID.Text + "'";
                sqldr = sqlcmd.ExecuteReader();
                while(sqldr.Read())
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = sqldr["ISBN"].ToString();
                    lvi.SubItems.Add(sqldr["title"].ToString());
                    listView2.Items.Add(lvi);
                    listView2.View = View.Details;
                    listView2.EndUpdate();
                }
            }
        }

        private void AddOrderToListview(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = m_BookISBN;
            lvi.SubItems.Add(m_BookName);
            listView2.Items.Add(lvi);
            listView2.View = View.Details;
            listView2.EndUpdate();
        }
    }
}
