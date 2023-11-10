using HardwareStore.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HardwareStore
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HardwareStore322_abdullovEntities bd = new HardwareStore322_abdullovEntities();
        public static bool IsAdm = false;
    }
}
