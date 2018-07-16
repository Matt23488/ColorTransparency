using ColorTransparency.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorTransparency.Views
{
    interface IImagePreviewView : IView
    {
        event ColorSelectedEventHandler ColorSelected;
        Image Image { get; set; }
    }
}
