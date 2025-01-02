using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace listbox
{
    public partial class Ders2 : Form
    {
        public Ders2()
        {
            InitializeComponent();
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.AppendText(i.ToString());
            if (i == 100)
            {

                i = 0;
                textBox1.Clear();
            } else
            {
                i++;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
            for(int i = 0; i < 100; i++)
            {
                textBox1.AppendText(i.ToString() + Environment.NewLine);
                Thread.Sleep(200);
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           timer1.Enabled = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
