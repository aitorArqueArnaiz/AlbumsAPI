namespace AlbumsFormulary
{
    partial class Albums
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            titleAlbumFiltertextBox = new TextBox();
            label2 = new Label();
            button1 = new Button();
            photosPanel = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)photosPanel).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 18);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 0;
            label1.Text = "List Albums";
            // 
            // titleAlbumFiltertextBox
            // 
            titleAlbumFiltertextBox.Location = new Point(168, 57);
            titleAlbumFiltertextBox.Name = "titleAlbumFiltertextBox";
            titleAlbumFiltertextBox.Size = new Size(405, 23);
            titleAlbumFiltertextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 60);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 2;
            label2.Text = "Album Title";
            // 
            // button1
            // 
            button1.Location = new Point(602, 60);
            button1.Name = "button1";
            button1.Size = new Size(163, 23);
            button1.TabIndex = 3;
            button1.Text = "Search Photos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // photosPanel
            // 
            photosPanel.Location = new Point(76, 148);
            photosPanel.Name = "photosPanel";
            photosPanel.Size = new Size(1049, 337);
            photosPanel.TabIndex = 4;
            photosPanel.TabStop = false;
            // 
            // Albums
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 497);
            Controls.Add(photosPanel);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(titleAlbumFiltertextBox);
            Controls.Add(label1);
            Name = "Albums";
            Text = "Form1";
            Load += Albums_Load;
            ((System.ComponentModel.ISupportInitialize)photosPanel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox titleAlbumFiltertextBox;
        private Label label2;
        private Button button1;
        private PictureBox photosPanel;
    }
}
