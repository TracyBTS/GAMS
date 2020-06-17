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
using Microsoft.Toolkit.Wpf.UI.Controls;

namespace GAMS.ShareControls
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        UserControl MyOwner;


        public ReportWindow(UserControl myOwner)
        {
            InitializeComponent();

            MyOwner = myOwner;

            if (MyOwner is Applications.Logistics.Logistics || MyOwner is Applications.Logistics.DeliveryAdviceSingleView)
            {
                //use a webform from BNA
                wb_ReportView.Source = new Uri("http://bna.health.qld.gov.au/WebForm/WebForm_DAforExternal.aspx?id=178304");
                wb_ReportView.Source = new Uri("http://bna.health.qld.gov.au/WebForm/WebForm_DAforExternal.aspx?id=178304");
            }
        }

        public void LoadReport(string reportVariables, string title)
        {
            this.Title = title;
            wb_ReportView.Source = new Uri("https://google.com");
        }
    }
}
