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
    /// Логика взаимодействия для EditProductWIndow.xaml
    /// </summary>
    public partial class EditProductWIndow : Window
    {
        public Product SelectedProduct { get; set; }
        public EditProductWIndow(Product selproduct)
        {
            InitializeComponent();
            SelectedProduct = selproduct;
            DataContext = SelectedProduct;
        }

        private void UpdateQRCode_btn_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage qr = GenerateQrCode.GenerateQR(name_tb.Text, Convert.ToDouble(price_tb.Text), descript_tb.Text);
            QrCodik.Source = qr;

            SelectedProduct.QrCode = ConvertorImageToString.ImageToString(qr);
        }

        private void EditProduct_btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
