using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fetcher
{
    public partial class Form_main : Form
    {


        readonly string PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                @"\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets\";
        string Path_source
        {
            get
            {
                return PATH + listBox_files.SelectedItem;
            }
        }
        string Path_temp
        {
            get
            {
                return Path.GetTempPath() + listBox_files.SelectedItem + ".jpg";
            }
        }


        public Form_main()
        {
            InitializeComponent();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            foreach (string tmp in Directory.GetFiles(PATH))
            {
                listBox_files.Items.Add(tmp.Substring(tmp.LastIndexOf("\\") + 1));
            }
            button_saveall.Enabled = listBox_files.Items.Count > 0;
            ListBox_files_SelectedIndexChanged(null, null);
        }

        private void ListBox_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image img;
            try
            {
                if (listBox_files.SelectedIndex == -1)
                {
                    panel_buttons.Enabled = false;
                    img = pictureBox_view.InitialImage;
                }
                else
                {
                    panel_buttons.Enabled = true;
                    img = Image.FromFile(Path_source);
                }
            }
            catch (Exception)
            {
                panel_buttons.Enabled = false;
                img = pictureBox_view.ErrorImage;
            }
            if (img.Width < pictureBox_view.ClientSize.Width && img.Height < pictureBox_view.ClientSize.Height)
            {
                pictureBox_view.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else
            {
                pictureBox_view.SizeMode = PictureBoxSizeMode.Zoom;
            }
            pictureBox_view.Image = img;
        }

        private void Button_open_Click(object sender, EventArgs e)
        {
            File.Copy(Path_source, Path_temp, true);
            Process.Start(Path_temp);
        }

        private void Button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = listBox_files.SelectedItem.ToString(),
                Filter = "JPG|*.jpg"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Path_source, sfd.FileName);
                MessageBox.Show(string.Format("Saved wallpaper to \"{0}\"", sfd.FileName));
            }
        }

        private void Button_saveall_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = "Select save path",
            };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path_output = fbd.SelectedPath + @"\Wallpaper";
                for (int i = 1; Directory.Exists(path_output); i++)
                {
                    path_output = fbd.SelectedPath + @"\Wallpaper_" + i.ToString();
                }
                Directory.CreateDirectory(path_output);
                foreach (string tmp in Directory.GetFiles(PATH))
                {
                    string filename = tmp.Substring(tmp.LastIndexOf("\\") + 1);
                    File.Copy(tmp, string.Format(@"{0}\{1}.jpg", path_output, filename));
                }
                MessageBox.Show(string.Format("Saved all wallpaper to \"{0}\"", path_output));
            }
        }
    }
}
