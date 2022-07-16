using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace foto_gray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnac_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.PNG)|*.PNG";
            DialogResult result = ofd.ShowDialog();
            if(result == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
            }
        }

        private void btnDonustur_Click(object sender, EventArgs e)
        {
            GrayscaleBT709 gs = new GrayscaleBT709();
            pictureBox2.Image = gs.Apply((Bitmap)pictureBox1.Image);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            DialogResult result = kaydet.ShowDialog();
            if(result == DialogResult.OK)
            {
                pictureBox2.Image.Save(kaydet.FileName);
            }
        }
    }
}
