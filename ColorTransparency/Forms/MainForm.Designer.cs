namespace ColorTransparency.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            this._colorTextBox = new System.Windows.Forms.TextBox();
            this._saveButton = new System.Windows.Forms.Button();
            this._fileBrowser = new DirectoryComparer.Forms.UserControls.FileBrowser();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(16, 41);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(34, 13);
            label1.TabIndex = 1;
            label1.Text = "Color:";
            // 
            // _colorTextBox
            // 
            this._colorTextBox.Enabled = false;
            this._colorTextBox.Location = new System.Drawing.Point(56, 38);
            this._colorTextBox.Name = "_colorTextBox";
            this._colorTextBox.Size = new System.Drawing.Size(100, 20);
            this._colorTextBox.TabIndex = 2;
            // 
            // _saveButton
            // 
            this._saveButton.Enabled = false;
            this._saveButton.Location = new System.Drawing.Point(280, 36);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 3;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // _fileBrowser
            // 
            this._fileBrowser.Filter = "Bitmap Files|*.bmp;*.png";
            this._fileBrowser.Location = new System.Drawing.Point(12, 12);
            this._fileBrowser.Name = "_fileBrowser";
            this._fileBrowser.Size = new System.Drawing.Size(343, 29);
            this._fileBrowser.TabIndex = 0;
            this._fileBrowser.FileSelected += new System.EventHandler(this.FileBrowser_FileSelected);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 72);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._colorTextBox);
            this.Controls.Add(label1);
            this.Controls.Add(this._fileBrowser);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DirectoryComparer.Forms.UserControls.FileBrowser _fileBrowser;
        private System.Windows.Forms.TextBox _colorTextBox;
        private System.Windows.Forms.Button _saveButton;
    }
}