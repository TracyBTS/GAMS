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

namespace GAMS.ShareControls
{
    /// <summary>
    /// Interaction logic for FloatingWindow.xaml
    /// </summary>
    public partial class FloatingWindow : Window
    {
        public bool IsClosed { get; set; } = false;

        public FloatingWindow()
        {
            Closed += FloatingWindow_Closed;
            InitializeComponent();
        }

        private void FloatingWindow_Closed(object sender, EventArgs e)
        {
            IsClosed = true;
        }
    }
}
