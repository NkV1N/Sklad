using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page, INotifyPropertyChanged
    {   
        public ObservableCollection<Product> Products { get; private set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public int currentCount;
        public int CurrentCount
        {
            get => currentCount;
            set
            {
                currentCount = value;
                notifyPropertyChanged("CurrentCount");
            }
        }
        public int totalCount;
        public int TotalCount
        {
            get => totalCount;
            set
            {
                totalCount = value;
                notifyPropertyChanged("TotalCount");
            }
        }
        private void notifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ProductPage()
        {
            Products = new ObservableCollection<Product>(Session.Instance.Context.Products.Include(p => p.ProductType).Take(25));
            CurrentCount = Products.Count;
            TotalCount = Session.Instance.Context.Products.Count();
            InitializeComponent();
        }

        private IQueryable<Product> applySearch(IQueryable<Product> query) =>
            query.Where(q => q.Name.Contains(searchText.Text));
        private IQueryable<Product> applyCategoryFilter(IQueryable<Product> query)
        {
            if (filterComboBox.SelectedItem == null)
            {
                return query;
            }

            var filterComboBoxItem = (KeyValuePair<string, Func<IQueryable<Product>, IQueryable<Product>>>)filterComboBox.SelectedItem;
            var filterFunc = filterComboBoxItem.Value;
            return filterFunc(query);
        }
        private void applyFilters()
        {
            IQueryable<Product> query = Session.Instance.Context.Products.AsQueryable();
            query = applySearch(query);
            query = applyCategoryFilter(query);
            Products.Clear();
            foreach (Product product in query.Take(25))
            {
                Products.Add(product);
            }
            CurrentCount = Products.Count;
            if (CurrentCount == 0)
            {
                searchResultLabel.Content = "По данному запросу ничего не найдено";
                searchResultLabel.Visibility = Visibility.Visible;
            }
            else
            {
                searchResultLabel.Visibility = Visibility.Collapsed;
            }
            TotalCount = Session.Instance.Context.Products.Count();
        }
        public Dictionary<string, Func<IQueryable<Product>, IQueryable<Product>>> CategoryFilters { get; set; } =
            new Dictionary<string, Func<IQueryable<Product>, IQueryable<Product>>>
        {
            { "Все записи", q => q },
            { "Принтер", q => q.Where(p => p.ProductTypeId == 1) },
            { "Колонки", q => q.Where(p => p.ProductTypeId == 2) },
            { "Монитор", q => q.Where(p => p.ProductTypeId == 3) }
        };
        private void editProduct(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button)?.DataContext as Product;
            if (product == null) return;
            var dialog = new UpdateProductWindow(product);
            bool? result = dialog.ShowDialog();
        }

        private void RemoveProduct(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button)?.DataContext as Product;
            if (product == null) return;

            bool hasClientService = Session.Instance.Context.BalanceProducts.Any(cs => cs.ProductId == product.ProductId);

            if (hasClientService)
            {
                MessageBox.Show("Невозможно удалить товар, который есть на складе", "Удаление невозможно",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var answer = MessageBox.Show("Вы уверены, что хотите удалить товар", "Подтверждение удаления",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    Session.Instance.Context.Products.Remove(product);
                    Session.Instance.Context.SaveChanges();
                    MessageBox.Show("Товар удален.", "Удаление успешно",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    applyFilters();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при удалении!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void goToUpdateProductPage(object sender, RoutedEventArgs e)
        {
            var dialog = new UpdateProductWindow(new Product());
            bool? result = dialog.ShowDialog();
        }

        private void search(object sender, TextChangedEventArgs e)
        {
            applyFilters();
        }

        private void filter(object sender, SelectionChangedEventArgs e)
        {
            applyFilters();
        }
    }
}
