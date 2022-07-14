using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;


namespace Aforge1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FilterInfoCollection kamerasayisi; // kaç adet kamera olduğunu tutar
        VideoCaptureDevice kamera;


        private void Form1_Load(object sender, EventArgs e)
        {
            kamerasayisi = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo f in kamerasayisi)
            {
                comboBox1.Items.Add(f.Name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kamera = new VideoCaptureDevice(kamerasayisi[comboBox1.SelectedIndex].MonikerString);
            kamera.NewFrame += Kamera_NewFrame;
            kamera.Start();
        }

        private void Kamera_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
