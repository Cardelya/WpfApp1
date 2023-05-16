using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WpfContext db = new WpfContext();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.Products.Load();
            DataContext = db.Products.Local.ToObservableCollection();
        }

        private void AddProduct_btn_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow window = new AddProductWindow(new Product());
            if (window.ShowDialog() == true)
            {
                Product product = window.Product;
                if (!IsValid_Check.IsNameValid(window.Product.Name))
                {
                    MessageBox.Show("Неправильные данные");
                }
                if (!IsValid_Check.IsPriceValid(window.Product.Price))
                {
                    MessageBox.Show("Неправильные данные");
                }
                if (!double.TryParse(Convert.ToString(window.Product.Price), out _))
                {
                    MessageBox.Show("Неправильные данные");
                }
                if (!IsValid_Check.IsDescriptValid(window.Product.Description))
                {
                    MessageBox.Show("Неправильные данные");
                }
                else
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    product_lb.Items.Refresh();
                }
            }
        }

        private void RemoveProduct_btn_Click(object sender, RoutedEventArgs e)
        {
            Product? selectedprod = (Product)product_lb.SelectedItem;
            if (selectedprod == null)
                return;

            db.Remove(selectedprod);
            db.SaveChanges();
            product_lb.Items.Refresh();
        }

        private void EditProduct_btn_Click(object sender, RoutedEventArgs e)
        {
            Product? selectedprod = (Product)product_lb.SelectedItem;
            // Если ни один элемент не выделен, то отмена
            if (selectedprod == null)
                return;
            // Открыть окно редактирования товара
            EditProductWIndow window = new EditProductWIndow(new Product
            {
                // Привязать данные из класса к данным выбранного товара
                Name = selectedprod.Name,
                Price = selectedprod.Price,
                Description = selectedprod.Description,
                QrCode = selectedprod.QrCode,
            });
            if (window.ShowDialog() == true)
            {
                // Если окно открыто успешно, то получить изменённый товар
                selectedprod = db.Products.Where(x => x.Id == selectedprod.Id).FirstOrDefault();
                if (selectedprod != null)
                {
                    selectedprod.Name = window.SelectedProduct.Name;
                    selectedprod.Price = window.SelectedProduct.Price;
                    selectedprod.Description = window.SelectedProduct.Description;
                    selectedprod.QrCode = window.SelectedProduct.QrCode;
                    // Привязать данные выделенного товара к данным окна
                    if (!IsValid_Check.IsNameValid(window.SelectedProduct.Name))
                    {
                        MessageBox.Show("Неправильные данные");
                    }
                    if (!IsValid_Check.IsPriceValid(window.SelectedProduct.Price))
                    {
                        MessageBox.Show("Неправильные данные");
                    }
                    if (!double.TryParse(Convert.ToString(window.SelectedProduct.Price), out _))
                    {
                        MessageBox.Show("Неправильные данные");
                    }
                    if (!IsValid_Check.IsDescriptValid(window.SelectedProduct.Description))
                    {
                        MessageBox.Show("Неправильные данные");
                    }
                    db.SaveChanges();
                    product_lb.Items.Refresh();
                }
            }
        }
    }
}
