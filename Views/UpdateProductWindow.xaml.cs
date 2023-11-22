using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Warehouse.Models;

namespace Warehouse.Views
{
    /// <summary>
    /// Логика взаимодействия для UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        public Product Product { get; set; }
        public ProductType PType { get; set; }
        public List<Product> Productees { get; set; }
        public List<ProductType> PTypes { get; set; }
        public UpdateProductWindow(Product product)
        {
            Product = product;
            PType = Product.ProductType;
            PTypes = Session.Instance.Context.ProductTypes.ToList();
            Productees = Session.Instance.Context.Products.ToList();
            InitializeComponent();
            if (Product.ProductId == 0)
            {
                headLab.Content = "Добавление товара";
                combo.SelectedIndex = 0;
            }
            else
            {
                headLab.Content = "Изменение товара";
                Session.Instance
                    .Context
                    .Products
                    .Entry(Product);
            }
        }

        private void saveChanges(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || combo.SelectedIndex == -1)
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var product = new Product
                {
                    ProductType = this.PType,
                    Name = name.Text
                };
                if (Product.ProductId == 0)
                {

                    Session.Instance.Context.Add(product);
                }
                else
                {
                    Product.ProductType = this.PType;
                }
                try
                {
                    Session.Instance.Context.SaveChanges();
                    MessageBox.Show("Данные сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                catch
                {
                    MessageBox.Show("При сохранении данных возникла ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (Product.ProductId == 0)
                    {
                        Session.Instance.Context.Remove(product);
                    }
                }
            }
        }
    }
}
