using Guna.UI2.WinForms;
using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace listbox
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
            t.Interval = 1000; // 1 saniye
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
           
            loadingBar.Value = Math.Min(loadingBar.Value + 10, 100);

           //İnternet kontrol noktası
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

            //loadingBar 100 ulaşınca login ekranına yönlendir "( Login loginForm = new Login(); | loginForm.Show(); )" ve timer'i durdur "( (sender as Timer).Stop(); )"
            if (loadingBar.Value == 100)
            {
                Login loginForm = new Login();
                loginForm.Show();
                (sender as Timer).Stop();
                this.Hide();
            }
        }
    }
}
