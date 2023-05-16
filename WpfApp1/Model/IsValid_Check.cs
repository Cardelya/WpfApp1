using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public static class IsValid_Check
    {
        public static bool IsNameValid(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            else
            {
                if (double.TryParse(name, out _))
                {
                    return false;
                }
                else
                {
                    if (name.Length > 15)
                    {
                        return false;
                    }
                    return true;
                }
            }
        }

        public static bool IsPriceValid(double price)
        {
            if (double.IsNaN(price))
            {
                return false;
            }
            else
            {
                if (price > 1000000)
                {
                    return false;
                }
                return true;
            }
        }

        public static bool IsDescriptValid(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return false;
            }
            else
            {
                if (description.Length > 30)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
