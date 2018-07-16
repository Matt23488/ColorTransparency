namespace DirectoryComparer.Forms.UserControls
{
    partial class FileBrowser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._browseButton = new System.Windows.Forms.Button();
            this._pathLabel = new System.Windows.Forms.Label();
            this._pathToolTip = new System.Windows.Forms.ToolTip(this.components);
            this._browseDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // _browseButton
            // 
            this._browseButton.Location = new System.Drawing.Point(3, 3);
            this._browseButton.Name = "_browseButton";
            this._browseButton.Size = new System.Drawing.Size(75, 23);
            this._browseButton.TabIndex = 0;
            this._browseButton.Text = "Browse";
            this._browseButton.UseVisualStyleBackColor = true;
            this._browseButton.Click += new System.EventHandler(this._browseButton_Click);
            // 
            // _pathLabel
            // 
            this._pathLabel.AutoSize = true;
            this._pathLabel.Location = new System.Drawing.Point(84, 8);
            this._pathLabel.Name = "_pathLabel";
            this._pathLabel.Size = new System.Drawing.Size(0, 13);
            this._pathLabel.TabIndex = 1;
            // 
            // _browseDialog
            // 
            this._browseDialog.InitialDirectory = "C:\\";
            // 
            // FileBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._pathLabel);
            this.Controls.Add(this._browseButton);
            this.Name = "FileBrowser";
            this.Size = new System.Drawing.Size(343, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _browseButton;
        private System.Windows.Forms.Label _pathLabel;
        private System.Windows.Forms.ToolTip _pathToolTip;
        private System.Windows.Forms.OpenFileDialog _browseDialog;
    }
}
