using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;   // AForge.Video kütüphanesi yüklenilir ve buraya eklenir
using AForge.Video.DirectShow;  // AForge.Video.DirectShow kütüphanesi yüklenilir ve buraya eklenir


namespace Aforge1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FilterInfoCollection kamerasayisi;  // kaç adet kamera olduğunu tutar
        VideoCaptureDevice kamera;  // kullanılacak kameradan veri alabilmek için değişken

        // bilgisayara bağlı olan kameraları tarama ve comBox'a ekleme işlemi
         private void Form1_Load(object sender, EventArgs e)
        {
            kamerasayisi = new FilterInfoCollection(FilterCategory.VideoInputDevice); 
            foreach(FilterInfo f in kamerasayisi)
            {
                comboBox1.Items.Add(f.Name);
            }
            comboBox1.SelectedIndex = 0;
        }
        // butona basıldığında kamera açma işlemi
        private void button1_Click(object sender, EventArgs e)
        {
            kamera = new VideoCaptureDevice(kamerasayisi[comboBox1.SelectedIndex].MonikerString);
            kamera.NewFrame += Kamera_NewFrame;
            kamera.Start();
        }
        // kullanılacak cihazın metodunu oluşturma işlemi
        private void Kamera_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog foto_kaydetme = new SaveFileDialog();   // fotoğrafı kaydetme işlemi
            foto_kaydetme.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";  // kayıt türünü filtreleme işlemi
            DialogResult sonuc = foto_kaydetme.ShowDialog();  // foto kaydetmeden sonuç alma işlemi
            if(sonuc == DialogResult.OK)   // eğer foto kaydetme okeyse
            {
                pictureBox2.Image.Save(foto_kaydetme.FileName);  // fotoyu kaydet
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto_acma = new OpenFileDialog();
            foto_acma.Filter = "All Files(*.*) | *.*";
            DialogResult dialogResult = foto_acma.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                pictureBox3.ImageLocation = foto_acma.FileName;
            }
        }
    }
}
