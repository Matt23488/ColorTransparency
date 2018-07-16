using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorTransparency.Views
{
    interface IView
    {
        event EventHandler LocationChanged;
        Point Location { get; set; }
        Size Size { get; set; }
        void Show();
        void Hide();
    }
}
