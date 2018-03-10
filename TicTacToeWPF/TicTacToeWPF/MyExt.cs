using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToeWPF
{

    public static class MyExt
    {
        public static void PerformClick(this Button btn)
        {
            try
            {
                btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            catch (Exception e)
            {

                MessageBox.Show(""+ e.Message);
            }
            
        }
    }

}
