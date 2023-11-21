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

namespace HardwareStore.Components
{
    /// <summary>
    /// Логика взаимодействия для CardProductsControl.xaml
    /// </summary>
    public partial class CardProductsControl : UserControl
    {
        public Product product;
        public int Kolvo;
        public double summ;

        public CardProductsControl(Product _product)
        {
            InitializeComponent();
            this.DataContext = _product;
            product = _product;
            CostTb.Text = product.TotalCost.ToString();
            _product.Id = product.Id;
            Kolvo = 1;
            KolvoTb.Text = Kolvo.ToString();

        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            App.CardWp.Children.Remove(this);
            App.productPage.Calc();
        }

        private void KolvoTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(KolvoTb.Text, out Kolvo) && Kolvo != 0)
            {
                summ = Kolvo * Convert.ToDouble(CostTb.Text);
                SummTb.Text = summ.ToString();
            }
            else
            {
                summ = 0;
                SummTb.Text = "";
            }
            App.productPage.Calc();
        }

        private void KolvoTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
                e.Handled = true;
        }
    }
}