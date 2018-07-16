using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorTransparency.Views
{
    interface IMainView : IView
    {
        event EventHandler FileSelected;
        event EventHandler SaveButtonClicked;

        string SourceFilePath { get; }
        string DestinationFilePath { get; }
        Color Color { get; set; }
    }
}
