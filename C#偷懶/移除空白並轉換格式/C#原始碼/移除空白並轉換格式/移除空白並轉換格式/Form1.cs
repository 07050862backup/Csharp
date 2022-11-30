using System;
using System.Windows.Forms;

namespace 移除空白並轉換格式 {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            text_output.Focus();
            text_output.Text = "";
            String input = text_input.Text;

           
            string[] str = new string[text_input.Lines.Length];

            for (int i = 0; i < text_input.Lines.Length; i++)
            {
                str[i] = text_input.Lines[i];
                if (String.IsNullOrEmpty(str[i])  || String.IsNullOrWhiteSpace(str[i]) )
                    continue;
                else
                {
                    text_output.Text += "\"" + str[i] + "\"" + "," + "\n";  //有逗號
                    //text_output.Text += "\"" + str[i] + "\"" + "\n";      //無逗號
                    text_output.Text = text_output.Text.Replace(" ", "　");
                    text_output.Text = text_output.Text.Replace("　", "");
                    text_output.Text = text_output.Text.Replace("\t", "");
                }
            }
        }



    }
}
