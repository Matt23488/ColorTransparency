using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ColorTransparency.Utilities
{
    class BitmapManipulator : IDisposable
    {
        private Bitmap _source = null;
        private IntPtr _ptr = IntPtr.Zero;
        private BitmapData _data = null;
        private byte[] _pixels = null;

        public int Width { get; }
        public int Height { get; }

        public BitmapManipulator(Bitmap source)
        {
            _source = source;
            Width = _source.Width;
            Height = _source.Height;
            LockBits();
        }

        public Color GetPixel(int x, int y)
        {
            var index = (y * Width + x) * 4;
            var b = _pixels[index + 0];
            var g = _pixels[index + 1];
            var r = _pixels[index + 2];
            var a = _pixels[index + 3];
            return Color.FromArgb(a, r, g, b);
        }

        public void SetPixel(int x, int y, Color color)
        {
            var index = (y * Width + x) * 4;
            _pixels[index + 0] = color.B;
            _pixels[index + 1] = color.G;
            _pixels[index + 2] = color.R;
            _pixels[index + 3] = color.A;
        }

        public void Dispose() => UnlockBits();

        private void LockBits()
        {
            var pixelCount = Width * Height;
            var lockRect = new Rectangle(0, 0, Width, Height);

            _data = _source.LockBits(lockRect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            _pixels = new byte[pixelCount * 4];
            _ptr = _data.Scan0;

            Marshal.Copy(_ptr, _pixels, 0, _pixels.Length);
        }

        private void UnlockBits()
        {
            Marshal.Copy(_pixels, 0, _ptr, _pixels.Length);
            _source.UnlockBits(_data);
        }
    }
}
