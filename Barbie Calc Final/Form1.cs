using System;
using System.Data;
using System.Windows.Forms;
using System.Media;
using System.Drawing;
 
namespace Barbie_Calc_Final
{
    public partial class Form1 : Form
    {
        SoundPlayer p1 = new SoundPlayer(@"C:\Users\Jermzu\Music\startup.wav");
        SoundPlayer p2 = new SoundPlayer(@"C:\Users\Jermzu\Music\wawayut.wav");
        SoundPlayer p3 = new SoundPlayer(@"C:\Users\Jermzu\Music\arf.wav");
        SoundPlayer p4 = new SoundPlayer(@"C:\Users\Jermzu\Music\ayayay.wav");

        public Form1()
        {
            InitializeComponent();
            p1.Play();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void button17_Click(object sender, EventArgs e)
        {
            button17.BringToFront();
            p4.Play();
            string equation = textBox1.Text;
            int ctr = 0;
            bool dividebyzero = false;

            foreach(char c in equation)
            {
                ctr++;
                if(c == '/')
                {
                    if (equation[ctr] == '0')
                    {
                        textBox1.Text = "MATH ERROR!";
                        dividebyzero = true;
                    }
                }
            }
            
            if(!dividebyzero)
            {
                try
                {
                    var result = new DataTable().Compute(equation, null);
                    textBox1.Text = result.ToString();
                }
                catch
                {
                    textBox1.Text = "MATH ERROR!";
                }
            }

            dividebyzero = false;
        }

        private void btn(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (textBox1.Text == "0" && button.Text != ".")
                textBox1.Clear();
            textBox1.Text += button.Text;

            if (button.Text == "-" || button.Text == "*" || button.Text == "/" || button.Text == "+")
                p3.Play();
            else
                p2.Play();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            p3.Play();
            textBox1.Text = "0";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
