﻿using System;
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


namespace GAMS.Applications.Logistics.LogisticsComponents
{
    /// <summary>
    /// Interaction logic for DeliveryAdviceAudit.xaml
    /// </summary>
    public partial class DeliveryAdviceAudit : Window
    {
        public DeliveryAdviceAudit(UserControl myOwner)
        {
            this.DataContext = myOwner.DataContext;
            InitializeComponent();

            this.Closing += DeliveryAdviceAudit_Closing;
        }

        private void DeliveryAdviceAudit_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Collapsed;
        }

        
    }
}
