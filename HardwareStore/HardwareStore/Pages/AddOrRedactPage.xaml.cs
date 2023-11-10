using HardwareStore.Components;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddOrRedactPage.xaml
    /// </summary>
    public partial class AddOrRedactPage : Page
    {
        private Product product;
        public AddOrRedactPage(Product _product)
        {
            InitializeComponent();
            product = _product;
            this.DataContext = product;
        }

        private void ChangeImgBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFIle = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg|all files|*.*"
            };
            if (openFIle.ShowDialog().GetValueOrDefault())
            {
                product.MainImage = File.ReadAllBytes(openFIle.FileName);
                ProductImg.Source = new BitmapImage(new Uri(openFIle.FileName));
            }
        }

        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (product.Id == 0)
            {
                if (App.bd.Product.Any(x => x.Title == product.Title))
                {
                    errors.AppendLine("Ошибка");
                }
                else if(Convert.ToInt32(CostTB.Text)<=0)
                {
                    errors.AppendLine("Цена не должна быть меньше 0");
                }
                else if(Convert.ToDouble(DiscountTB.Text)<0&&Convert.ToDouble(DiscountTB.Text)>0.100)
                {
                    if (DiscountTB.Text == "")
                        DiscountTB.Text = "0";
                    errors.AppendLine("Скидка должна быть в диапазоне от 0 до 0.100 ");
                }
                else
                {
                    App.bd.Product.Add(product);
                    Navigation.BackPage();
                }
            }
            if (errors.Length > 0)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                App.bd.SaveChanges();
                Navigation.BackPage();
            }

            Navigation.BackPage();
        }

    }
}
