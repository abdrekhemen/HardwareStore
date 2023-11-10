using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Xml.Serialization;

namespace HardwareStore.Components
{
    internal class Navigation
    {
        private static List<PageComponents> components = new List<PageComponents>();
        public static MainWindow mainWindow;

        public static void ClearHistory()
        {
            components.Clear();
        }
        public static void NextPage(PageComponents pageComponents)
        {
            components.Add(pageComponents);
            Update(pageComponents);
        }
        public static void BackPage()
        {
            if (components.Count > 1)
            {
                components.RemoveAt(components.Count - 1);
                Update(components[components.Count - 1]);
            }
        }
        public static void Update(PageComponents pageComponents)
        {
            mainWindow.BackBTn.Visibility = components.Count() > 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            mainWindow.MainFrame.Navigate(pageComponents.Page);
        }
    }
    public class PageComponents
    {
        public Page Page { get; set; }
        public PageComponents(Page page)
        {
            Page = page;
        }
    }
}

