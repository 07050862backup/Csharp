using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;
using TextBox = System.Windows.Forms.TextBox;

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
            // 根據selectedFunction的值來選擇要執行的功能。
            if (selectedFunction == 1)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    // 當 button1 comboBox1 選中第一項時，執行普通模式
                    // 把多個輸入的字，以空白分開，並加上引號。
                    button1_NormalMode(text_input.Text);
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    // 當 button1 comboBox1 選中第二項時，執行特殊模式
                    // 把多個輸入的字，以空白分開，並加上引號，並去除中文，轉換斜線為底線。
                    //執行步驟為先去除中文->轉換斜線為底線->一般模式
                    string[] str = new string[text_input.Lines.Length];
                    string output = "";

                    for (int i = 0; i < text_input.Lines.Length; i++)
                    {
                        str[i] = text_input.Lines[i];
                        int ChineseFirstIndex = str[i].Length;

                        str[i] = text_input.Lines[i];

                        if (string.IsNullOrWhiteSpace(str[i]))
                        {
                            ChineseFirstIndex = 0;
                        }
                        else
                        {
                            for (int j = 0; j < str[i].Length; j++)
                            {
                                if (Regex.IsMatch(str[i][j].ToString(), @"[\u4e00-\u9fa5]"))
                                {
                                    ChineseFirstIndex = j;
                                    break;
                                }
                            }
                        }
                        output += str[i].Substring(0, ChineseFirstIndex).Replace("/", "_");
                        output += '\n';
                    }
                    button1_NormalMode(output);
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
            else if (selectedFunction == 3)
            {
                // 第三個功能：將json格式的值刪除，只留標題。
                string[] str = new string[text_input.Lines.Length];
                for (int i = 0; i < text_input.Lines.Length; i++)
                {
                    str[i] = text_input.Lines[i];
                    int firstQuoteIndex = str[i].IndexOf('"');
                    if (firstQuoteIndex >= 0)
                    {
                        // 搜尋第二個雙引號的位置，從第一個雙引號的下一個字元開始搜尋
                        int secondQuoteIndex = str[i].IndexOf('"', firstQuoteIndex + 1);
                        if (secondQuoteIndex >= 0)
                        {
                            // 從第一個雙引號到第二個雙引號之間取出文字
                            string truncated = str[i].Substring(firstQuoteIndex + 1, secondQuoteIndex - firstQuoteIndex - 1);
                            //第一個雙引號到第二個雙引號是空白的
                            if (String.IsNullOrEmpty(str[i]) || String.IsNullOrWhiteSpace(str[i]))
                                continue;
                            else
                            {
                                // 將逗號、引號、空白、全角空格和製表元取代為任何內容（即刪除它們）
                                truncated = truncated.Replace(",", "").Replace("\"", "").Replace(" ", "").Replace("　", "").Replace("\t", "");

                                text_output.Text += truncated + Environment.NewLine;
                            }
                        }
                    }
                }
            }
            
            // 刪除換行符號
            text_output.Text = text_output.Text.TrimEnd('\n');
        }
        private void RadioButton1_checkchanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox1.Visible = true;
            UpdateLabel();
        }
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            UpdateLabel();
        }
        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            UpdateLabel();
        }
        private void UpdateLabel()
        {
            if (radioButton1.Checked)
            {
                this.label3.Text = "把多個輸入的字，以空白分開，並加上引號。\r\n下面為輸出結果";
                text_input.Text = "       [  GET] /transportreturn/master/headers   取  得  退  運  單單  頭  標  題  名稱\r\n\r\n   [POST] /transportretu rn/m  aster 新 增退運  單單頭\r\n[PUT] /transportreturn/master 更新退運單單頭";

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
            else if (radioButton3.Checked)
            {
                this.label3.Text = "只留json的標題，將值捨去。\r\n下面為輸出結果";
                text_input.Text = "     \"cfNo\": \"2200000065\",\r\n        \"poNo\": \"2100000206\",\r\n        \"poSeq\": 1,\r\n        \"productNo\": \"CSD400001\",\r\n        \"productName\": \"可口可樂-1250ml\",\r\n        \"acceptQty\": 100,\r\n        \"okQty\": 100,";

                // 更新selectedFunction變量的值。
                selectedFunction = 3;
            }
        }
        private void button1_NormalMode(string temp_text)
        {
            string[] str = temp_text.Split('\n');

            int lastLineWithText = -1;
            for (int i = 0; i < str.Length; i++)
            {//先用一個迴圈遍歷每行，將最後一行有文字的行數紀錄下來
                
                if (String.IsNullOrEmpty(str[i]) || String.IsNullOrWhiteSpace(str[i]))
                {
                    continue;
                }
                else
                {
                    lastLineWithText = i;
                }
            }
            for (int i = 0; i < lastLineWithText + 1; i++)
            {
               
                if (String.IsNullOrEmpty(str[i]) || String.IsNullOrWhiteSpace(str[i]))
                    continue;
                else
                {
                    // Check if this is the last line with text
                    if (i == lastLineWithText)
                    {
                        // 最後一行不加上逗號
                        text_output.Text += "\"" + str[i] + "\"" + "\n";
                    }
                    else
                    {
                        text_output.Text += "\"" + str[i] + "\"" + "," + "\n";
                    }
                    text_output.Text = text_output.Text.Replace(" ", "　");
                    text_output.Text = text_output.Text.Replace("　", "");
                    text_output.Text = text_output.Text.Replace("\u200B", "");
                    text_output.Text = text_output.Text.Replace("\t", "");
                }
            }
        }
    }
}
