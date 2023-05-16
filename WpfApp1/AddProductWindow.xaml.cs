using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public Product Product { get; set; }
        public AddProductWindow(Product prod)
        {
            InitializeComponent();
            Product = prod;
            DataContext = Product;
        }

        private void CreateQRCode_btn_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage qr = GenerateQrCode.GenerateQR(name_tb.Text, Convert.ToDouble(price_tb.Text), descript_tb.Text);
            QrCodik.Source = qr;

            Product.QrCode = ConvertorImageToString.ImageToString(qr);
        }

        private void AddProduct_btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
