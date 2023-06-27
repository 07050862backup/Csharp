using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 消費紀錄
{
    public partial class 記帳程式 : Form
    {
        public List<ITEM> shoppingList = new List<ITEM>();
        public 記帳程式()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float sum = 0;
            string name = textBox1.Text;
            float unitPrice = Convert.ToSingle(textBox2.Text);
            uint number = Convert.ToUInt32(textBox3.Text);
            shoppingList.Add(new ITEM(name, unitPrice, number));
            foreach(ITEM i in shoppingList)
            {
                sum += i.unitPrice * i.number;
            }
            label4.Text = "小計:" + Convert.ToString(unitPrice * number);
            label5.Text = "總價:" + Convert.ToString(sum);

            ListViewItem lvi = new ListViewItem();
            lvi.Text = name;
            lvi.SubItems.Add(Convert.ToString(unitPrice));
            lvi.SubItems.Add(Convert.ToString(number));
            listView1.Items.Add(lvi);
            listView1.EndUpdate();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileInfo recordFileInfo = new FileInfo("record.txt");
            StreamReader recordFileReader = recordFileInfo.OpenText();
            uint num = Convert.ToUInt32(recordFileReader.ReadLine());
            for(uint i = 0; i < num;++i)
            {
                string name = recordFileReader.ReadLine();
                float unitPrice = Convert.ToSingle(recordFileReader.ReadLine());
                uint number = Convert.ToUInt32(recordFileReader.ReadLine());
                shoppingList.Add(new ITEM(name, unitPrice, number));
            }
            recordFileReader.Close();
            float sum = 0;
            foreach (ITEM i in shoppingList)
            {
                sum += i.unitPrice * i.number;
            }
            label5.Text = "總價:" + Convert.ToString(sum);


            ColumnHeader ch1 = new ColumnHeader();
            ch1.Text = "品名";
            ch1.Width = 60;
            ch1.TextAlign = HorizontalAlignment.Left;
            listView1.Columns.Add(ch1);

            ColumnHeader ch2 = new ColumnHeader();
            ch2.Text = "單價";
            ch2.Width = 60;
            ch2.TextAlign = HorizontalAlignment.Left;
            listView1.Columns.Add(ch2);

            ColumnHeader ch3 = new ColumnHeader();
            ch3.Text = "數量";
            ch3.Width = 60;
            ch3.TextAlign = HorizontalAlignment.Left;
            listView1.Columns.Add(ch3);
            listView1.View = View.Details;
            foreach (ITEM i in shoppingList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = i.name;
                lvi.SubItems.Add(Convert.ToString(i.unitPrice));
                lvi.SubItems.Add(Convert.ToString(i.number));
                listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//關閉視窗時，存檔
        {
            FileInfo recordFileInfo = new FileInfo("record.txt");
            StreamWriter recordFileReader = recordFileInfo.CreateText();
            recordFileReader.WriteLine(Convert.ToString(shoppingList.Count()));
            foreach (ITEM i in shoppingList)
            {
               recordFileReader.WriteLine(i.name);
               recordFileReader.WriteLine(Convert.ToString(i.unitPrice));
               recordFileReader.WriteLine(Convert.ToString(i.number));
            }
            recordFileReader.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
