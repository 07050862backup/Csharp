using System.Windows.Forms;

namespace ScreenshotApp
{
    internal class Form2 : Form
    {
        private TextBox textBox1;

        public Form2()
        {
            // Create a new text box
            textBox1 = new TextBox();
            textBox1.Multiline = true;
            textBox1.Dock = DockStyle.Fill;
            this.Controls.Add(textBox1);
        }

        public void SetText(string text)
        {
            // Set the text of the text box
            textBox1.Text = text;
        }
    }
}
