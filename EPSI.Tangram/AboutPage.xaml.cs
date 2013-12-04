using System;
using System.Windows.Input;
using Microsoft.Phone.Tasks;

namespace EPSI.Tangram
{
    public partial class AboutPage
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public AboutPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Déclenché lorsque l'utilisateur clique sur l'URL du site EPSI
        /// </summary>
        /// <param name="sender">Textblock URL site EPSI</param>
        /// <param name="e"></param>
        private void SiteEPSI_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OuvrirSite("http://www.epsi.fr");
        }

        /// <summary>
        /// Déclenché lorsque l'utilisateur clique sur l'URL du site EPSILab
        /// </summary>
        /// <param name="sender">Textblock URL site EPSILab</param>
        /// <param name="e"></param>
        private void SiteEPSILab_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OuvrirSite("http://www.epsilab.net");
        }

        /// <summary>
        /// Ouvre l'URL souhaitée dans Internet Explorer
        /// </summary>
        /// <param name="url">URL du site</param>
        private void OuvrirSite(string url)
        {
            WebBrowserTask task = new WebBrowserTask
            {
                Uri = new Uri(url)
            };

            task.Show();
        }

        /// <summary>
        /// Déclenché lorsque l'utilisateur appuie sur le mail EPSILab
        /// </summary>
        /// <param name="sender">Texttblock mail EPSILab</param>
        /// <param name="e"></param>
        private void EmailEPSILab_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EmailComposeTask task = new EmailComposeTask
            {
                To = "epsilab@outlook.com",
                Subject = "Support application EPSI Tangram pour Windows Phone"
            };

            task.Show();
        }
    }
}