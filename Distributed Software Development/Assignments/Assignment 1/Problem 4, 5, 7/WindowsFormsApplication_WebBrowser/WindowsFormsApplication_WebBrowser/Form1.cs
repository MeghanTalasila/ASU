using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

using System.Web;

namespace WindowsFormsApplication_WebBrowser
{
    public partial class Form1 : Form
    {
        String userLength;
        String myStr;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EncryptServiceReference.ServiceClient esr = new EncryptServiceReference.ServiceClient();
            richTextBox2.Text = esr.Encrypt(richTextBox1.Text);
            richTextBox3.Text = esr.Decrypt(richTextBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ImageVerifierService.ServiceClient ivs = new ImageVerifierService.ServiceClient();
            userLength = textBox2.Text;
            myStr = ivs.GetVerifierString(userLength);
            button4.Text = "Generate another string";
            pictureBox1.Visible = true;
            if (myStr == null)
            {
                if (userLength == null)
                {
                    userLength = "3";
                }
                else 
                {
                    userLength = userLength.ToString();
                }
                myStr = ivs.GetVerifierString(userLength);
            }
            else
            {
                myStr = myStr.ToString();
            }
            Stream myStream = ivs.GetImage(myStr);
            System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
            pictureBox1.Image = myImage;
            label8.Text = "";
            textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // if (Session["generatedString"].Equals(textBox3.Text))
                if (myStr.Equals(textBox3.Text))
            {
                label8.Text = "Congratualtions. The Code you entered is correct.";
            }
            else
            {
                label8.Text = "I am sorry. The code that you entered does not match with code in image.";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
