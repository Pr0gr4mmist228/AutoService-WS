using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceMethods
{
    public static class DiscountsCheck
    {
        public static double FirstValue(int firstItemID)
        {
            if (firstItemID == 0)
            {
                return 0;
            }
            else if (firstItemID == 1)
            {
                return 0.05;
            }
            else if (firstItemID == 2)
            {
                return 0.15;
            }
            else if (firstItemID == 3)
            {
                return 0.3;
            }
            else if (firstItemID == 4)
            {
                return 0.7;
            }
            return 0;
        }

        public static double SecondValue(int secondItemId)
        {
            if (secondItemId == 0)
            {
                return 0.05;
            }
            else if (secondItemId == 1)
            {
                return 0.15;
            }
            else if (secondItemId == 2)
            {
                return 0.3;
            }
            else if (secondItemId == 3)
            {
                return 0.7;
            }
            else if (secondItemId == 4)
            {
                return 1;
            }
            return 1;
        }
    }
}
