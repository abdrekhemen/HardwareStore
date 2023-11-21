using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HardwareStore.Components
{
    public partial class Product
    {
        public string CostDiscount
        {
            get
            {
                if (Discount == 0)
                    return Cost.ToString("00");
                else
                    return (Convert.ToDouble(Cost) - (Convert.ToDouble(Cost) * Discount)).ToString();
            }
        }
        public double TotalCost
        {
            get
            {
                if (Discount != null)
                    return Convert.ToDouble((Cost - (Cost * (decimal)Discount)));
                else
                    return Convert.ToDouble(Cost);
            }
        }
        public int ReviewCount
        {
            get
            {
                return Feedback.Count;
            }
        }
        public double ProductRating
        {
            get
            {
                return Feedback.Average(x=>x.Evaluation);
            }
        }
        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }
        
        public string DiscoutPercent
        {
            get
            {
                if (Discount == 0) return null; else return ("-"+(Convert.ToDouble(Discount) * 100)+"%").ToString();
            }
        }
    }
}
