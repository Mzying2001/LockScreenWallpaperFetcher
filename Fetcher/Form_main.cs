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

        /*temp files to be deleted when exit the program*/
        readonly List<string> delete_list = new List<string>();

        /*dictionary of the wallpaper file path*/
        readonly Dictionary<string, string> dic = new Dictionary<string, string>();

        /*path that save the lock screen wallpaper on windows10*/
        readonly string path_wallpapers = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                          @"\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets\";

        string Path_source
        {
            get
            {
                return dic[listBox_files.SelectedItem.ToString()];
            }
        }
        string Path_temp
        {
            get
            {
                string tmp;
                tmp = dic[listBox_files.SelectedItem.ToString()];
                tmp = tmp.Substring(tmp.LastIndexOf('\\') + 1);

                return Path.GetTempPath() + tmp + ".jpg";
            }
        }


        public Form_main()
        {
            InitializeComponent();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(path_wallpapers))
            {
                int ignore = 0; //num of ignored items
                string[] files = Directory.GetFiles(path_wallpapers);
                for(int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        Image img = Image.FromFile(files[i]);
                        if (img.Width < 100 || img.Height < 100)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        ignore++;
                        continue;
                    }

                    string tmp = string.Format("wallpaper - {0}", i - ignore + 1);
                    dic.Add(tmp, files[i]);
                    listBox_files.Items.Add(tmp);
                }
            }
            else
            {
                MessageBox.Show(string.Format("Unable to find path \"{0}\"", path_wallpapers), "Error");
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
                    groupBox_picture.Text = string.Format("fetched {0} wallpaper", listBox_files.Items.Count);
                    groupBox_picture.Text += listBox_files.Items.Count > 1 ? "s" : null;
                }
                else
                {
                    panel_buttons.Enabled = true;
                    img = Image.FromFile(Path_source);
                    groupBox_picture.Text = string.Format("item {0} of {1}", listBox_files.SelectedIndex + 1, listBox_files.Items.Count);
                }
            }
            catch (Exception)
            {
                panel_buttons.Enabled = false;
                img = pictureBox_view.ErrorImage;
                groupBox_picture.Text = "ERROR";
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
                    for (int i = 2; Directory.Exists(path_output); i++)
                    {
                        path_output = string.Format("{0}\\Wallpaper ({1})", fbd.SelectedPath, i);
                    }
                    Directory.CreateDirectory(path_output);
                    foreach(var tmp in listBox_files.Items)
                    {
                        string filename = tmp.ToString();
                        File.Copy(dic[filename], string.Format(@"{0}\{1}.jpg", path_output, filename));
                    }
                    MessageBox.Show(string.Format("Saved all wallpaper to \"{0}\"", path_output), "Message");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void ListBox_files_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox_files.IndexFromPoint(e.Location);
            if (index != -1 && index == listBox_files.SelectedIndex)
            {
                Button_open_Click(null, null);
            }
        }
    }
}
