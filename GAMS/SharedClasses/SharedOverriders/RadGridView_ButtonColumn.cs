using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using System.Threading.Tasks;

namespace GAMS.SharedClasses.SharedOverriders
{
    class RadGridView_ButtonColumn : Telerik.Windows.Controls.GridViewColumn
    {
        public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
        {
            RadButton button = cell.Content as RadButton;
            if (button == null)
            {
                button = new RadButton();
                button.Content = "Delete";
                button.Command = RadGridViewCommands.Delete;
            }

            button.CommandParameter = dataItem;
            return button;
        }
    }
}
