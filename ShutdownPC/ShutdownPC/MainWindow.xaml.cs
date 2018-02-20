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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShutdownPC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WriteToCmd cmd = new WriteToCmd();
       
        string message = "";

        public MainWindow()
        {
            InitializeComponent();

            desLabel.Content = @"Enter time for your computer to close."+ Environment.NewLine + "Set 0 instead of empty";
            message = cmd.ReadFile();
            MessageBack.Text = message;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int chosenHour = 0;
            int chosenMin = 0;

            try
            {
                chosenHour = int.Parse(txtboxHour.Text);
                chosenMin = int.Parse(txtboxMin.Text);

                message = "\n" + DateTime.Now.ToLongDateString() + "  Shutdown computer in: " + chosenHour.ToString() + " Hour and " + chosenMin.ToString() + " Min";
              
                new WriteToCmd(chosenHour, chosenMin, message);
                MessageBack.Text += message;

                btnSave.Visibility = Visibility.Hidden;
                btnTurnback.Visibility = Visibility;
            }
            catch (Exception ex)
            {
                MessageBox.Show("You have not set any hours or min");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTurnback_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cmd.disconnectommand();
                message = "\n" + DateTime.Now.ToLongDateString() + "  Shutdown have been canceled";
                new WriteToCmd(message);
                MessageBack.Text += "\n" + DateTime.Now.ToLongDateString() + "  Shutdown have been canceled";

                btnSave.Visibility = Visibility;
                btnTurnback.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
