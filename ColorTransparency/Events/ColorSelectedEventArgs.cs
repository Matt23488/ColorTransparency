using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorTransparency.Events
{
    public delegate void ColorSelectedEventHandler(object sender, ColorSelectedEventArgs e);
    public class ColorSelectedEventArgs : EventArgs
    {
        public Color Color { get; }
        public ColorSelectedEventArgs(Color color)
        {
            this.Color = color;
        }
    }
}
