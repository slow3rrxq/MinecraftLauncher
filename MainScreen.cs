using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;
using CmlLib.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;

namespace AcordLauncher
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }
        string username;
        private void MainScreen_Load(object sender, EventArgs e)
        {
            username = LoginScreen.username;
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
            var path = new MinecraftPath(Environment.GetEnvironmentVariable("APPDATA") + "/.acordLauncher");
            var launcher = new MinecraftLauncher(path);
            var versions = await launcher.GetAllVersionsAsync();
            foreach (var version in versions)
            {
                if (version.Type == "release")
                {
                    comboversion.Items.Add(version.Name);
                }
            }
            if (comboversion.Items.Count > 0)
            {
                comboversion.SelectedIndex = 0;
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
    }
}
