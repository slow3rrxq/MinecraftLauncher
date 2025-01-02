using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core;
using CmlLib.Core.Auth;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CmlLib;

namespace listbox
{
    public partial class UserScreen : Form
    {
        public UserScreen()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public static string versiyon;
        public static string username;
        private void path()
        {
            var path = new MinecraftPath();

            var launcher = new MinecraftLauncher(path);


        }
        private void UserScreen_Load(object sender, EventArgs e)
        { 
            if(Properties.Settings.Default.rememberme == true)
            {
                guna2TextBox1.Text = Properties.Settings.Default.username;
                checkbox.Checked = true;
            }
        }

        private void loginbtns_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                MessageBox.Show("Bir isim yazmalısın!", "MorLauncher");
            } else
            {
                if(checkbox.Checked)
                {
                    Properties.Settings.Default.rememberme = true;
                    Properties.Settings.Default.username = guna2TextBox1.Text;
                }
                else
                {
                    Properties.Settings.Default.rememberme = false;
                    Properties.Settings.Default.username = "none";
                }
                Properties.Settings.Default.Save();
                username = guna2TextBox1.Text;
                mainScreen admin = new mainScreen();
                admin.Show();
                this.Hide();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void checkbox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
