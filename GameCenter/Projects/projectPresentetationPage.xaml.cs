using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameCenter.Projects
{
    /// <summary>
    /// Interaction logic for projectPresentetationPage.xaml
    /// </summary>
    public partial class projectPresentetationPage : Window
    {
        private Window currentProject;
        public projectPresentetationPage()
        {
            InitializeComponent();
            DispatcherTimer clock = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            clock.Tick += ShowCurrentDate!;
            clock.Start();
        }

        private void ShowCurrentDate(object sender, EventArgs e)
        {
            DateLabel.Content = DateTime.UtcNow.ToString("dddd, dd, MMMM, yyyy HH:mm:ss");
        }

        public void OnStart(string title, string projectDescription, ImageSource imageSoursce, Window project)
        {
            TitleLabel.Content = title;
            ProjectText.Text = projectDescription;
            ProjectImage.Source = imageSoursce;
            currentProject = project;
        }

        private void ProjectImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Hide();
            currentProject.ShowDialog();
            Close();
        }
    }
}
