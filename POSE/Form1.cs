using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSE
{
    public partial class MainWindow : Form
    {
        public Image CurrentImage
        {
            get => pbImage.Image;
            set
            {
                pbImage.Image = value;

                pbImage.Width = pbImage.Image.Width;
                pbImage.Height = pbImage.Image.Height;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            RegisterTestImages();
        }

        private void RegisterTestImages()
        {
            cbImages.Items.Clear();
            cbImages.Items.Add(new MyImage("C:\\temp\\test.png", "test"));
            cbImages.Items.Add(new MyImage("C:\\temp\\test2.png", "test2"));
            cbImages.Items.Add(new MyImage("C:\\temp\\test3.png", "test3"));
        }

        private Image LoadImageByPath(string path)
        {
            return !File.Exists(path) ? null : Image.FromFile(path);
        }

        private void CbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var myImage = comboBox.SelectedItem as MyImage;

            if (myImage == null)
            {
                MessageBox.Show($"Invalid Image selected:\n{comboBox.SelectedText}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var img = LoadImageByPath(myImage.imagePath);
            if (img == null)
            {
                MessageBox.Show($"Image does not exist on Path:\n[{myImage.imagePath}]", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CurrentImage = img;
        }
    }
}
