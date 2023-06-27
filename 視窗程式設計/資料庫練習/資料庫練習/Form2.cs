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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void ButtonInsertBook(object sender, EventArgs e)
        {
            using (SqlConnection sqlcn = new SqlConnection())
            {
                sqlcn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                    "AttachDBFilename=|DataDirectory|Bookstore.mdf;" +
                    "Integrated Security=True";
                sqlcn.Open();
                string isbn = booknametex.Text;
                string title = isbntext.Text;
                string author = authortext.Text;
                string publishing = publishingtext.Text;
                SqlCommand sqlcmd = new SqlCommand( "INSERT INTO Books (ISBN,Title,Author,Publishing )VALUES('" +
                    isbn + "',N'" + title + "',N'" + author + "',N'" + publishing + "')", sqlcn);
                int i = sqlcmd.ExecuteNonQuery();
            }
            this.Close();
        }

        private void cancelButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
