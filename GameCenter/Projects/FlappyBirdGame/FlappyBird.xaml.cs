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

namespace GameCenter.Projects.FlappyBirdGame
{
    /// <summary>
    /// Interaction logic for FlappyBird.xaml
    /// </summary>
    public partial class FlappyBird : Window
    {
        public FlappyBird()
        {
            InitializeComponent();

            //DispatcherTimer gameTimer = new DispatcherTimer();
            //gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            //gameTimer.Tick += GameLoop;
            //gameTimer.Start();
        }

        
    }
}



