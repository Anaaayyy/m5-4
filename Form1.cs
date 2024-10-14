using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m5_4
{
    public partial class Form1 : Form
    {
        private float zoomFactor = 1.0f; // Масштаб изображения

        public Form1()
        {
            InitializeComponent();
        }

              
        private void UpdateImage()
        {
            if (pictureBox.Image != null)
            {
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Установка режима зума
                pictureBox.Width = (int)(pictureBox.Image.Width * zoomFactor); // Изменение ширины
                pictureBox.Height = (int)(pictureBox.Image.Height * zoomFactor); // Изменение высоты
                pictureBox.Refresh(); // Обновление PictureBox
            }
        }

        private void btnSelectImage_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Загружаем выбранное изображение
                    pictureBox.Image = new Bitmap(openFileDialog.FileName);
                    zoomFactor = 1.0f; // Сброс масштаба
                    trackBarZoom.Value = 100; // Установка начального значения
                    UpdateImage(); // Обновляем изображение
                }
            }
        }

        private void trackBarZoom_Scroll_1(object sender, EventArgs e)
        {
            zoomFactor = trackBarZoom.Value / 100.0f; // Установка нового масштаба
            UpdateImage(); // Обновляем изображение
            lblZoom.Text = $"Масштаб: {trackBarZoom.Value}%"; // Обновление текста метки
        }
    }
}
