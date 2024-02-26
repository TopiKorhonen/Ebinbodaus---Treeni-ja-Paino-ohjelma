using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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

namespace Ohjelmisto_projekti
{
    /// <summary>
    /// Interaction logic for Treenit.xaml
    /// </summary>
    public partial class Treenit : Window
    {
        public Treenit()
        {
            InitializeComponent();
        }

        private void Maanantai_Click(object sender, RoutedEventArgs e)
        {
            TMa myWindow = new();
            if (myWindow.ShowDialog() == true);
        }
    }
}
