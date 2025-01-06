using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;
using CmlLib.Core;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Web.UI.WebControls;

namespace Minecraft_Launcher
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        public string Username { get; private set; }
        string guna2Text1;

        private void MainScreen_Load(object sender, EventArgs e)
        {
            InitializeUsername();
            LoadSkinHead();
            PopulateVersionList();
        }

        private void InitializeUsername()
        {
            Username = LoginScreen.username;
            lblusername.Text = Username;
        }

        private void LoadSkinHead()
        {
            try
            {
                SetSkinHeadImage("https://cravatar.eu/helmavatar/" + Username + "/190.png");
            }
            catch
            {
                SetSkinHeadImage("https://cravatar.eu/helmavatar/Null/190.png");
            }
        }

        private void SetSkinHeadImage(string url)
        {
            var request = WebRequest.Create(url);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
                picSkinhead.Image = Bitmap.FromStream(stream);
        }

        private async void PopulateVersionList()
        {
            var versions = await FetchVersionsAsync();
            AddVersionsToComboBox(versions);
        }

        private async Task<IEnumerable<string>> FetchVersionsAsync()
        {
            var path = new MinecraftPath(Environment.GetEnvironmentVariable("APPDATA") + "/.acord-launcher");
            var launcher = new MinecraftLauncher(path);
            var versions = await launcher.GetAllVersionsAsync();

            return versions.Where(v => v.Type == "release").Select(v => v.Name);
        }

        private void AddVersionsToComboBox(IEnumerable<string> versions)
        {
            foreach (var version in versions)
            {
                comboversion.Items.Add(version);
            }

            if (comboversion.Items.Count > 0)
            {
                comboversion.SelectedIndex = 0;
            }
        }

        private async void startMinecraft()
        {
            var path = new MinecraftPath(Environment.GetEnvironmentVariable("APPDATA") + "/.acord-launcher");
            var launcher = new MinecraftLauncher(path);

            ConfigureLauncherProgress(launcher);

            await launcher.InstallAsync(comboversion.SelectedItem.ToString());
            var process = await launcher.BuildProcessAsync(comboversion.SelectedItem.ToString(), new MLaunchOption
            {
                Session = MSession.CreateOfflineSession(Username),
                FullScreen = true,
                MaximumRamMb = 4096,
                //ServerIp = "" //otomatik sunucuya bağlan
            });

            HandleProcessEvents(process);
            process.Start();
            this.Hide();
        }

        private void ConfigureLauncherProgress(MinecraftLauncher launcher)
        {
            ConfigureFileProgress(launcher);
            ConfigureByteProgress(launcher);
        }

        private void ConfigureFileProgress(MinecraftLauncher launcher)
        {
            launcher.FileProgressChanged += (sender, args) =>
            {
                progressbar.Text = args.Name;
            };
        }

        private void ConfigureByteProgress(MinecraftLauncher launcher)
        {
            launcher.ByteProgressChanged += (sender, args) =>
            {
                progressbar.Maximum = (int)args.TotalBytes;
                progressbar.Value = (int)args.ProgressedBytes;
            };
        }

        private void HandleProcessEvents(System.Diagnostics.Process process)
        {
            process.EnableRaisingEvents = true;

            process.Exited += (s, e) =>
            {
                this.Invoke((Action)(() =>
                {
                    this.Show(); // Minecraft kapandığında launcher'ı yeniden göster
                    ResetLauncherUI();
                }));
            };
        }

        private void ResetLauncherUI()
        {
            startbtn.Enabled = true;
            comboversion.Enabled = true;
            progressbar.Visible = false;
        }

        private void AcordLauncher_Click(object sender, EventArgs e)
        {
            LoginScreen user = new LoginScreen();
            user.Show();
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
