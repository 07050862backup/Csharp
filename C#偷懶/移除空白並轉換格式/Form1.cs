using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 移除空白並轉換格式 {
    public partial class Form1 : Form
    {
        private int selectedFunction = 1;

        public Form1()
        {
            InitializeComponent();

            radioButton1.Checked = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            text_output.Focus();
            text_output.Text = "";
            String input = text_input.Text;


            // 根據selectedFunction的值來選擇要執行的功能。
            if (selectedFunction == 1)
            {
                // 第一個功能：把多個輸入的字，以空白分開，並加上引號。
             
                string[] str = new string[text_input.Lines.Length];

                for (int i = 0; i < text_input.Lines.Length; i++)
                {
                    str[i] = text_input.Lines[i];
                    if (String.IsNullOrEmpty(str[i]) || String.IsNullOrWhiteSpace(str[i]))
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
            else if (selectedFunction == 2)
            {
                // 第二個功能：將引號去除。
                string[] str = new string[text_input.Lines.Length];


                for (int i = 0; i < text_input.Lines.Length; i++)
                {
                    str[i] = text_input.Lines[i];
                    if (String.IsNullOrEmpty(str[i]) || String.IsNullOrWhiteSpace(str[i]))
                        continue;
                    else
                    {
                        //將逗號、引號、空白、全角空格和製表元取代為任何內容（即刪除它們）
                        string output = str[i].Replace(",", "").Replace("\"", "").Replace(" ", "").Replace("　", "").Replace("\t", "");

                        //將輸出字串追加到text_output，後跟換行符
                        text_output.Text += output + Environment.NewLine;
                    }
                }
            }
        }
        private void newButtonClickHandler(object sender, EventArgs e)
        {
            text_output.Focus();
            text_output.Text = "";


            text_output.Text += "新功能";
        }

        private void RadioButton1_checkchanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.label3.Text = "把多個輸入的字，以空白分開，並加上引號。\r\n下面為輸出結果";
                text_input.Text = "    你好\n  嗨 \n          朋友\n蘋   果\n   糖            果";

                // 更新selectedFunction變量的值。
                selectedFunction = 1;
            }
            else if (radioButton2.Checked)
            {
                this.label3.Text = "去除逗號和引號";
                text_input.Text = "    \"A\",\"B\",\"C\"\n\"D\",\"E\"\n    \"F\"  ";

                // 更新selectedFunction變量的值。
                selectedFunction = 2;
            }
            
        }
    }
}
