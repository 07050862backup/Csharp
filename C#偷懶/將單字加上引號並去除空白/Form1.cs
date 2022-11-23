using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 將單字加上引號並去除空白{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e) {
            text_output.Focus();
            text_output.Text = "";
            String input = text_input.Text;

            /*string strLineData;
            using (StringReader sr = new StringReader(text_input.Text.Trim()))
            {
                //讀取第一行
                strLineData = sr.ReadLine();
                while (!String.IsNullOrEmpty(strLineData))
                {
                    text_output.Text = text_output.Text.Replace(" ", "");
                    text_output.Text += "\"" + strLineData + "\"" + "\n";
                    strLineData = sr.ReadLine();

                   
                }
            }*/
            string[] str = new string[text_input.Lines.Length];

            for (int i = 0; i < text_input.Lines.Length; i++)
            {
                str[i] = text_input.Lines[i];
                if (String.IsNullOrEmpty(str[i]))
                    continue;
                else
                {
                    text_output.Text += "\"" + str[i] + "\"" +  "," +"\n";  //有逗號
                    //text_output.Text += "\"" + str[i] + "\"" + "\n";      //無逗號
                    text_output.Text = text_output.Text.Replace(" ", "");
                }
            }
        }



    }
}
