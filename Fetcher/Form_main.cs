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

        readonly List<string> delete_list = new List<string>();
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

        private void Form_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (string tmp in delete_list)
            {
                try
                {
                    File.Delete(tmp);
                }
                catch (Exception)
                {
                    MessageBox.Show(string.Format("Unable to delete temp file \"{0}\"", tmp), "Error");
                }
            }
        }

        private void ListBox_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image img;

            if (pictureBox_view.Image != null)
            {
                pictureBox_view.Image.Dispose();
            }

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
            try
            {
                File.Copy(Path_source, Path_temp, true);
                if (!delete_list.Contains(Path_temp))
                {
                    delete_list.Add(Path_temp);
                }
                Process.Start(Path_temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
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
                try
                {
                    File.Copy(Path_source, sfd.FileName, true);
                    MessageBox.Show(string.Format("Saved wallpaper to \"{0}\"", sfd.FileName), "Message");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void Button_saveall_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = "Select output path",
            };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
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
                    MessageBox.Show(string.Format("Saved all wallpaper to \"{0}\"", path_output), "Message");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
    }
}
