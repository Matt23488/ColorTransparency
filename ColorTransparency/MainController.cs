using ColorTransparency.Events;
using ColorTransparency.Forms;
using ColorTransparency.Utilities;
using ColorTransparency.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorTransparency
{
    class MainController
    {
        private static MainController _instance;

        private IMainView _mainView;
        private IImagePreviewView _imageView;

        private Bitmap _image;

        public static void Start(IMainView mainForm)
        {
            if (_instance != null) return;

            _instance = new MainController(mainForm);
        }

        private MainController(IMainView mainForm)
        {
            _mainView = mainForm;
            _imageView = new ImagePreviewForm
            {
                MaximumSize = new Size(800, 600)
            };

            WireEvents();
        }

        private void WireEvents()
        {
            _mainView.FileSelected += MainForm_FileSelected;
            _mainView.LocationChanged += MainForm_LocationChanged;
            _mainView.SaveButtonClicked += MainForm_SaveButtonClicked;

            _imageView.ColorSelected += ImageView_ColorSelected;
        }

        private void MainForm_FileSelected(object sender, EventArgs e)
        {
            if (_image != null) _image.Dispose();

            using (var image = Image.FromFile(_mainView.SourceFilePath) as Bitmap)
            {
                if (image == null)
                {
                    MessageBox.Show(
                        "The selected file does not appear to be a Bitmap. This application only supports Bitmap images.",
                        "Unsupported Image Format",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                _image = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
                using (var graphics = Graphics.FromImage(_image))
                {
                    graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                }
            }

            _imageView.Image = _image;
            _imageView.Show();
            MainForm_LocationChanged(_mainView, EventArgs.Empty);
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            _imageView.Location = new Point(_mainView.Location.X + _mainView.Size.Width - 15, _mainView.Location.Y);
        }

        private void MainForm_SaveButtonClicked(object sender, EventArgs e)
        {
            var color = _mainView.Color;

            using (var image = _image.Clone() as Bitmap)
            {
                using (var thingy = new BitmapManipulator(image))
                {
                    for (int y = 0; y < thingy.Height; y++)
                    {
                        for (int x = 0; x < thingy.Width; x++)
                        {
                            var pixel = thingy.GetPixel(x, y);
                            if (pixel == color) thingy.SetPixel(x, y, Color.Transparent);
                        }
                    }
                }

                using (var memory = new MemoryStream())
                {
                    using (var file = new FileStream(_mainView.DestinationFilePath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        image.Save(memory, ImageFormat.Png);
                        var bytes = memory.ToArray();
                        file.Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        private void ImageView_ColorSelected(object sender, ColorSelectedEventArgs e)
        {
            _mainView.Color = e.Color;
        }
    }
}
