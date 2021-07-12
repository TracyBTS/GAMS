using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GAMS.Interfaces
{
    interface ImessageInterface
    {
        MessageBoxResult ShowMessageBox(string text, string title,
                                    MessageBoxButton buttons);
    }
}
