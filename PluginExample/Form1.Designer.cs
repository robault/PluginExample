namespace PluginExample
{
    partial class Form1
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
            this.foundPluginsListBox = new System.Windows.Forms.ListBox();
            this.pluginDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.browseForPluginButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.pluginLoadedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // foundPluginsListBox
            // 
            this.foundPluginsListBox.FormattingEnabled = true;
            this.foundPluginsListBox.Location = new System.Drawing.Point(12, 12);
            this.foundPluginsListBox.Name = "foundPluginsListBox";
            this.foundPluginsListBox.Size = new System.Drawing.Size(260, 95);
            this.foundPluginsListBox.TabIndex = 0;
            this.foundPluginsListBox.SelectedIndexChanged += new System.EventHandler(this.foundPluginsListBox_SelectedIndexChanged);
            // 
            // pluginDirectoryTextBox
            // 
            this.pluginDirectoryTextBox.Location = new System.Drawing.Point(12, 115);
            this.pluginDirectoryTextBox.Name = "pluginDirectoryTextBox";
            this.pluginDirectoryTextBox.ReadOnly = true;
            this.pluginDirectoryTextBox.Size = new System.Drawing.Size(173, 20);
            this.pluginDirectoryTextBox.TabIndex = 1;
            this.pluginDirectoryTextBox.Text = "C:\\";
            // 
            // browseForPluginButton
            // 
            this.browseForPluginButton.Location = new System.Drawing.Point(191, 113);
            this.browseForPluginButton.Name = "browseForPluginButton";
            this.browseForPluginButton.Size = new System.Drawing.Size(81, 23);
            this.browseForPluginButton.TabIndex = 2;
            this.browseForPluginButton.Text = "Plugin Folder";
            this.browseForPluginButton.UseVisualStyleBackColor = true;
            this.browseForPluginButton.Click += new System.EventHandler(this.browseForPluginButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selected plugin:";
            // 
            // pluginLoadedLabel
            // 
            this.pluginLoadedLabel.AutoSize = true;
            this.pluginLoadedLabel.Location = new System.Drawing.Point(95, 155);
            this.pluginLoadedLabel.Name = "pluginLoadedLabel";
            this.pluginLoadedLabel.Size = new System.Drawing.Size(90, 13);
            this.pluginLoadedLabel.TabIndex = 4;
            this.pluginLoadedLabel.Text = "No plugin loaded.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 192);
            this.Controls.Add(this.pluginLoadedLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browseForPluginButton);
            this.Controls.Add(this.pluginDirectoryTextBox);
            this.Controls.Add(this.foundPluginsListBox);
            this.Name = "Form1";
            this.Text = "Plugin Host Applicatiuon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox foundPluginsListBox;
        private System.Windows.Forms.TextBox pluginDirectoryTextBox;
        private System.Windows.Forms.Button browseForPluginButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pluginLoadedLabel;
    }
}

