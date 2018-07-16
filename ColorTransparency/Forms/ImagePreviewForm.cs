using ColorTransparency.Events;
using ColorTransparency.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorTransparency.Forms
{
    public partial class ImagePreviewForm : Form, IImagePreviewView
    {
        public event ColorSelectedEventHandler ColorSelected;

        public Image Image
        {
            get => _pictureBox.Image;
            set
            {
                if (_pictureBox.Image != null) _pictureBox.Image.Dispose();

                var maxImageSize = new Size(MaximumSize.Width - 16, MaximumSize.Height - 39);

                if (value.Size.Width > maxImageSize.Width || value.Size.Height > maxImageSize.Height)
                {
                    var aspectRatio = (double)value.Size.Width / value.Size.Height;
                    var imageSize = new Size();
                    if (maxImageSize.Height * aspectRatio > maxImageSize.Width)
                    {
                        imageSize = new Size(maxImageSize.Width, (int)Math.Floor(maxImageSize.Width / aspectRatio));
                    }
                    else
                    {
                        imageSize = new Size((int)Math.Floor(maxImageSize.Height * aspectRatio), maxImageSize.Height);
                    }

                    Size = new Size(imageSize.Width + 16, imageSize.Height + 39);
                    var image = new Bitmap(value, imageSize);
                    _pictureBox.Image = image;
                }
                else
                {
                    Size = new Size(value.Size.Width + 16, value.Size.Height + 39);
                    var image = new Bitmap(value);
                    _pictureBox.Image = image;
                }
            }
        }

        public ImagePreviewForm()
        {
            InitializeComponent();
        }

        private void ImagePreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var image = _pictureBox.Image as Bitmap;

            var selectedColor = image.GetPixel(e.X, e.Y);
            ColorSelected?.Invoke(this, new ColorSelectedEventArgs(selectedColor));
        }
    }
}
