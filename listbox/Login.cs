using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listbox
{
    public partial class Login : Form
    {
        private Timer transitionTimer;

        public Login()
        {
            InitializeComponent();
        }
        int failedAttempts = 0;
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            //Caps Lock uyarısı
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("Caps Lock açık! Şifrenizi yanlış yazıyor olabilirsiniz.",
                                "Caps Lock Uyarısı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

            //TextBox'lar boş kalamaz uyarısı
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text))
            {
                MessageBox.Show("Lütfen kullanıcı adını ve şifreyi doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Giriş bilgileri ve yönlendirme
            if (guna2TextBox1.Text == "slow3rxq" && guna2TextBox2.Text == "slower123xd")
            { 
                Project project = new Project();
                project.Show();
                this.Close();
            }
            else //Kullanıcı adı ve şifreyi yanlış girerse uyarı
            {
                MessageBox.Show(
                    "Admin değil iseniz giriş yapamazsınız.\nLütfen geliştiricilere ulaşınız.",
                    "Erişim Engellendi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            //3 defa hatalı giriş yaparsa uyarı atıyor ve programı kapatıyor
            failedAttempts++;
            if (failedAttempts >= 3)
            {
                MessageBox.Show("Çok fazla hatalı giriş yaptınız. Lütfen daha sonra tekrar deneyin.", "Erişim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        //2 saniye dolunca admin ekranına yönlendiriyor
        private void TransitionToAdmin(object sender, EventArgs e)
        {
            
            mainScreen adm = new mainScreen();
            adm.Show();
            this.Hide();
            transitionTimer.Stop();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        { 
           UserScreen user = new UserScreen();
            user.Show();
            this.Hide();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Uri u = new Uri("C:\\Users\\LAB\\Desktop\\mylivewallpapers.com-Minecraft-Cherry-Grove-FHD.mp4");
            axWindowsMediaPlayer1.URL = u.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.uiMode = "None";
        }
    }
}
