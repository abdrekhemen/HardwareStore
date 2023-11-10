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
    /// Логика взаимодействия для ProductPhotoControl.xaml
    /// </summary>
    public partial class ProductPhotoControl : UserControl
    {
        ProductPhotos photos;
        public ProductPhotoControl(ProductPhotos _photos)
        {
            InitializeComponent();
            photos = _photos;
            this.DataContext = photos;
        }

        private void MakeManeBtn_Click(object sender, RoutedEventArgs e)
        {
            var selPhoto = photos.PhotoByte;
            photos.PhotoByte = photos.Product.MainImage;
            photos.Product.MainImage = selPhoto;
            App.bd.SaveChanges();
        }

        private void DeletePhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            App.bd.ProductPhotos.Remove(photos);
            App.bd.SaveChanges();
        }
    }
}
