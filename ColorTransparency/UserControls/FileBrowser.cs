using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DirectoryComparer.Forms.UserControls
{
    public partial class FileBrowser : UserControl
    {
        public event EventHandler FileSelected;
        public string SelectedFilePath { get; private set; }
        public string Filter
        {
            get => _browseDialog.Filter;
            set => _browseDialog.Filter = value;
        }

        public FileBrowser()
        {
            InitializeComponent();
        }

        private void _browseButton_Click(object sender, EventArgs e)
        {
            if (_browseDialog.ShowDialog() != DialogResult.OK) return;

            var path = _browseDialog.FileName;
            var pathParts = path.Split(Path.DirectorySeparatorChar);
            if (pathParts.Length > 4)
            {
                var newPathParts = new []
                {
                    pathParts[0],
                    pathParts[1],
                    "...",
                    pathParts.Last()
                };

                path = string.Join(Path.DirectorySeparatorChar.ToString(), newPathParts);
            }

            SelectedFilePath = _browseDialog.FileName;
            _pathToolTip.SetToolTip(_pathLabel, _browseDialog.FileName);
            _pathLabel.Text = path;

            FileSelected?.Invoke(this, EventArgs.Empty);
        }
    }
}
