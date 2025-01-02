using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Version;
using CmlLib.Core.ProcessBuilder;

namespace listbox
{
    public partial class mainScreen : Form
    {
        public mainScreen()
        {
            InitializeComponent();
        }
        string username;

        private void mainScreen_Load(object sender, EventArgs e)
        {
            Uri u = new Uri("C:\\Users\\LAB\\Desktop\\mylivewallpapers.com-Minecraft-Cherry-Grove-FHD.mp4");
            axWindowsMediaPlayer1.URL =u.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.uiMode = "None";
            username = UserScreen.username;
            lblusername.Text = username;
            displaySkinHead();
            listVersion();
        }

        private void displaySkinHead()
        {
            try
            {
                var request = WebRequest.Create("https://cravatar.eu/helmavatar/" + username + "/190.png");
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                    picSkinhead.Image = Bitmap.FromStream(stream);
            }
            catch
            {
                var request = WebRequest.Create("https://cravatar.eu/helmavatar/Null/190.png");
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                    picSkinhead.Image = Bitmap.FromStream(stream);
            }
        }

        private async Task listVersion()
        {
            var path = new MinecraftPath(Environment.GetEnvironmentVariable("APPDATA") + "/.mor");
            var launcher = new MinecraftLauncher(path);
            var versions = await launcher.GetAllVersionsAsync();

            // Doğrudan 1.8.9'u seçmek için kontrol ekliyoruz
            foreach (var version in versions)
            {
                if (version.Name == "1.8.9")
                {
                    comboversion.Items.Add(version.Name);
                    break;
                }
            }

            if (comboversion.Items.Count > 0)
            {
                comboversion.SelectedIndex = 0; // Varsayılan olarak 1.8.9 seçili olacak
            }
            else
            {
                MessageBox.Show("1.8.9 sürümü bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void startMinecraft()
        {
            var path = new MinecraftPath(Environment.GetEnvironmentVariable("APPDATA") + "/.mor");
            var launcher = new MinecraftLauncher(path);

            launcher.FileProgressChanged += (sender, args) =>
            {
                progressbar.Text = args.Name;
            };

            launcher.ByteProgressChanged += (sender, args) =>
            {
                progressbar.Maximum = (int)args.TotalBytes;
                progressbar.Value = (int)args.ProgressedBytes;
            };

            await launcher.InstallAsync(comboversion.SelectedItem.ToString());
            var process = await launcher.BuildProcessAsync(comboversion.SelectedItem.ToString(), new MLaunchOption
            {
                Session = MSession.CreateOfflineSession(username),
                FullScreen = true,
                MaximumRamMb = 4096,
                //ServerIp = "ibandee.lunecraft.net"
            });
            process.Start();
            this.Hide();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            startMinecraft();
            progressbar.Visible = true;
            startbtn.Enabled = false;
            comboversion.Enabled = false;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            UserScreen user = new UserScreen();
            user.Show();
            this.Hide();
        }
    }
}
