using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listbox
{
    public partial class Project : Form
    {
        public Project()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            listBox1.Items.Clear();
            int accound = 0;
            for (int i = 0; i < 50; i++)
            {
                listBox1.Items.Add(rnd.Next(1, 100));
                if (Convert.ToInt32(listBox1.Items[i]) % 2 == 0)
                    accound++;
            }
            guna2TextBox1.Text += "çift sayı:" + accound.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int temp = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = i + 1; j < listBox1.Items.Count; j++)
                {
                    int valueI = Convert.ToInt32(listBox1.Items[i]);
                    int valueJ = Convert.ToInt32(listBox1.Items[j]);

                    if (valueI < valueJ)
                    {
                        temp = valueI;
                        listBox1.Items[i] = valueJ;
                        listBox1.Items[j] = temp;
                    }
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            int maxValue = Convert.ToInt32(listBox1.Items[0]);
            int minValue = Convert.ToInt32(listBox1.Items[0]);

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                int currentValue = Convert.ToInt32(listBox1.Items[i]);

                if (currentValue > maxValue)
                {
                    maxValue = currentValue;
                }
                else if (currentValue < minValue)
                {
                    minValue = currentValue;
                }
            }

            guna2TextBox1.Text += "En Büyük Sayı: " + maxValue.ToString() + (char)10;
            guna2TextBox1.Text += "En Küçük Sayı: " + minValue.ToString() + (char)10;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = i + 1; j < listBox1.Items.Count; j++)
                {
                   
                    if (listBox1.Items[i].ToString() == listBox1.Items[j].ToString())
                    {
                        listBox1.Items.RemoveAt(j);
                        j--;
                    }
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Ders2 ders = new Ders2();
            ders.Show();
            this.Close();
        }
    }
}
