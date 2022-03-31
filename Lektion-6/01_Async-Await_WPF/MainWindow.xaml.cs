using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _01_Async_Await_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBlocking_Click(object sender, RoutedEventArgs e)
        {
            tblockResult.Text = "";

            Thread.Sleep(10 * 1000);
            tblockResult.Text = "Blocking Code Completed.";
        }

        private async void btnNonBlocking_Click(object sender, RoutedEventArgs e)
        {
            tblockResult.Text = "";

            await Task.Delay(10 * 1000);
            tblockResult.Text = "Non-Blocking Code Completed.";
        }
    }
}
