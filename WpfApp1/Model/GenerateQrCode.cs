using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp1.Model
{
    public static class GenerateQrCode
    {
        public static BitmapImage GenerateQR(string name, double price, string description)
        {
            string info = $"Название товара: {name} \nСтоимость: {price} \nОписание товара: {description}";

            QRCodeGenerator qRGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRGenerator.CreateQrCode(info, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap image = qRCode.GetGraphic(25);

            return Converter(image);
        }
        public static BitmapImage Converter(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)bmp).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = ms;
            ms.Seek(0, SeekOrigin.Begin);
            image.EndInit();

            return image;
        }
    }
}
