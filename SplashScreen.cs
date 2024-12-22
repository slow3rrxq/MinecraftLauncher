using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AcordLauncher
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        private int counter = 0;
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(CheckInternet);
            t.Start();
        }

        private void CheckInternet(object sender, EventArgs e)
        {

            //İnternet kontrolününe göre bağlandı veya bağlanmadı mesajı yazdırma
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                loadingtxt.Text = "Bağlantı kuruldu";


                (sender as Timer).Stop();

                Timer t = new Timer();
                t.Interval = 100;
                t.Tick += new EventHandler(UpdateUI);
                t.Start();
            }
            else
            {

                loadingtxt.Text = "Bağlantı kurulamadı. Yeniden deneniyor...";
            }
        }

        private void UpdateUI(object sender, EventArgs e)
        {

            prograssbar.Value = Math.Min(prograssbar.Value + 10, 100);

            counter++;
            if (counter == 2 || counter == 4 || counter == 6 || counter == 8)
            {
                switch (counter)
                {
                    case 2:
                        loadingtxt.Text = "Kontrol Ediliyor...";
                        break;
                    case 4:
                        loadingtxt.Text = "Kontrol Edildi";
                        break;
                    case 6:
                        loadingtxt.Text = "Kontrol Başarılı";
                        break;
                    case 8:
                        loadingtxt.Text = "Başlatılıyor...";
                        break;
                }
            }

            if (prograssbar.Value == 100)
            {
                LoginScreen loginForm = new LoginScreen();
                loginForm.Show();
                (sender as Timer).Stop();
                this.Hide();
            }
        }
    }
}
