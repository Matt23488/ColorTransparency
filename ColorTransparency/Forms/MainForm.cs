using ColorTransparency.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorTransparency.Forms
{
    public partial class MainForm : Form, IMainView
    {
        private Color _color = Color.Transparent;

        public event EventHandler FileSelected;
        public event EventHandler SaveButtonClicked;
        public string SourceFilePath => _fileBrowser.SelectedFilePath;
        public string DestinationFilePath
            => Path.Combine(Path.GetDirectoryName(SourceFilePath), $"{Path.GetFileNameWithoutExtension(SourceFilePath)}-transparent{Path.GetExtension(SourceFilePath)}");
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                _colorTextBox.Text = $"#{_color.Name}";
            }
        }

        public MainForm()
        {
            InitializeComponent();
            MainController.Start(this);
        }

        private void FileBrowser_FileSelected(object sender, EventArgs e)
        {
            FileSelected?.Invoke(this, EventArgs.Empty);
            _saveButton.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_colorTextBox.Text.Length == 0 || _colorTextBox.Text[0] != '#')
            {
                MessageBox.Show(
                    "Please select a color!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            SaveButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
