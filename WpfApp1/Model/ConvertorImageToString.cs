using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp1.Model
{
    public static class ConvertorImageToString
    {
        public static string ImageToString(BitmapImage image)
        {
            using MemoryStream ms = new();
            PngBitmapEncoder encoder = new();

            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(ms);
            byte[] buffer = ms.ToArray();

            return Convert.ToBase64String(buffer);
        }
    }
}
