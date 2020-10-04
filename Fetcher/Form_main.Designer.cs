namespace Fetcher
{
    partial class Form_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_view = new System.Windows.Forms.PictureBox();
            this.button_save = new System.Windows.Forms.Button();
            this.button_open = new System.Windows.Forms.Button();
            this.button_saveall = new System.Windows.Forms.Button();
            this.groupBox_picture = new System.Windows.Forms.GroupBox();
            this.listBox_files = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_view)).BeginInit();
            this.groupBox_picture.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_view
            // 
            this.pictureBox_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_view.Location = new System.Drawing.Point(6, 20);
            this.pictureBox_view.Name = "pictureBox_view";
            this.pictureBox_view.Size = new System.Drawing.Size(422, 282);
            this.pictureBox_view.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_view.TabIndex = 1;
            this.pictureBox_view.TabStop = false;
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(497, 326);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.Button_save_Click);
            // 
            // button_open
            // 
            this.button_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_open.Location = new System.Drawing.Point(416, 326);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 0;
            this.button_open.Text = "open";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.Button_open_Click);
            // 
            // button_saveall
            // 
            this.button_saveall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_saveall.Location = new System.Drawing.Point(138, 326);
            this.button_saveall.Name = "button_saveall";
            this.button_saveall.Size = new System.Drawing.Size(75, 23);
            this.button_saveall.TabIndex = 2;
            this.button_saveall.Text = "save all";
            this.button_saveall.UseVisualStyleBackColor = true;
            this.button_saveall.Click += new System.EventHandler(this.Button_saveall_Click);
            // 
            // groupBox_picture
            // 
            this.groupBox_picture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_picture.Controls.Add(this.pictureBox_view);
            this.groupBox_picture.Location = new System.Drawing.Point(138, 12);
            this.groupBox_picture.Name = "groupBox_picture";
            this.groupBox_picture.Size = new System.Drawing.Size(434, 308);
            this.groupBox_picture.TabIndex = 4;
            this.groupBox_picture.TabStop = false;
            this.groupBox_picture.Text = "groupBox";
            // 
            // listBox_files
            // 
            this.listBox_files.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_files.FormattingEnabled = true;
            this.listBox_files.IntegralHeight = false;
            this.listBox_files.ItemHeight = 12;
            this.listBox_files.Location = new System.Drawing.Point(12, 12);
            this.listBox_files.Name = "listBox_files";
            this.listBox_files.Size = new System.Drawing.Size(120, 337);
            this.listBox_files.TabIndex = 0;
            this.listBox_files.SelectedIndexChanged += new System.EventHandler(this.ListBox_files_SelectedIndexChanged);
            this.listBox_files.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_files_MouseDoubleClick);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.listBox_files);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.groupBox_picture);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.button_saveall);
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "Form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lock Screen Wallpaper Fetcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_main_FormClosed);
            this.Load += new System.EventHandler(this.Form_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_view)).EndInit();
            this.groupBox_picture.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox_view;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_saveall;
        private System.Windows.Forms.GroupBox groupBox_picture;
        private System.Windows.Forms.ListBox listBox_files;
    }
}

