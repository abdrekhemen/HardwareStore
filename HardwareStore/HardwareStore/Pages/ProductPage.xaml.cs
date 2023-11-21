using HardwareStore.Components;
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

namespace HardwareStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public Order order;
        public Sostav sostav;
        public ProductPage()
        {
            InitializeComponent();
            var products = App.bd.Product.ToList();
            var review = App.bd.Feedback.ToList();
            App.CardWp = CardWP;
            Refresh();
            App.productPage = this;
            order = new Order();
        }
        private void Refresh()
        {
            IEnumerable<Product> products = App.bd.Product;
            if (CostSortCB.SelectedIndex != 0)
            {
                if (CostSortCB.SelectedIndex == 1)
                    products = products.OrderBy(x => x.TotalCost);
                else if (CostSortCB.SelectedIndex == 2)
                    products = products.OrderByDescending(x => x.TotalCost);
            }
            if (ReviewSortCB.SelectedIndex != 0)
            {
                if (ReviewSortCB.SelectedIndex == 1)
                    products = products.OrderByDescending(x => x.ProductRating);
                else if (ReviewSortCB.SelectedIndex == 2)
                    products = products.OrderByDescending(x => x.ReviewCount);
            }
            if (SearchTB.Text != "")
            {
                products = products.Where(x => x.Title.ToLower().Contains(SearchTB.Text.ToLower()) || x.Description.Contains(SearchTB.Text.ToLower()));
            }
            if (SaleAmountCB.SelectedIndex != 0)
            {
                if (SaleAmountCB.SelectedIndex == 1)
                    products = products.Where(x => x.Discount >= 0 && x.Discount <= 0.05);
                else if (SaleAmountCB.SelectedIndex == 2)
                    products = products.Where(x => x.Discount >= 0.05 && x.Discount <= 0.015);
                else if (SaleAmountCB.SelectedIndex == 3)
                    products = products.Where(x => x.Discount >= 0.15 && x.Discount <= 0.30);
                else if (SaleAmountCB.SelectedIndex == 4)
                    products = products.Where(x => x.Discount >= 0.30 && x.Discount <= 0.70);
                else if (SaleAmountCB.SelectedIndex == 5)
                    products = products.Where(x => x.Discount >= 0.70 && x.Discount <= 0.100);
            }

            ProductsWP.Children.Clear();
            foreach (var item in products)
            {
                ProductsWP.Children.Add(new ProductControl(item));
            }
            DataCountTB.Text = products.Count() + " из " + App.bd.Product.Count();
        }

        private void CostSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void ReviewSortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void SaleAmountCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void OrderConfirmation_Click(object sender, RoutedEventArgs e)
        {

            if (!CheckOrder())
                return;
            order.date = DateTime.Now;
            order.status = "Заказ принят";

            order = App.bd.Order.Add(order);
            foreach (CardProductsControl CardProd in CardWP.Children)
            {
                sostav = new Sostav();
                sostav.Order_id = order.id;
                sostav.Product_id = CardProd.product.Id;
                sostav.product_qnt = CardProd.Kolvo;
                order.TotalCost = Convert.ToInt32(TotalCostTB.Text);
                App.bd.Sostav.Add(sostav);
            }

            App.bd.SaveChanges();
            ClearZakaz();
        }
        private bool CheckOrder()
        {
            if (CardWP.Children.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы 1 товар!");
                return false;
            }

            foreach (CardProductsControl CardProd in CardWP.Children)
            {
                if (CardProd.KolvoTb.Text == "0")
                {
                    MessageBox.Show("Введите количество для всех товаров!");
                    return false;
                }
            }
            return true;
        }
        public void Calc()
        {
            double TotalCost = 0;
            foreach (CardProductsControl card in CardWP.Children)
            {
                TotalCost += Convert.ToDouble(card.summ);
            }
            TotalCostTB.Text = TotalCost.ToString();
        }

        private void ClearZakaz()
        {
            order = new Order();
            CardWP.Children.Clear();
        }
    }
}