using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Common.Helpers
{
    public class ModelHelpers
    {
        public static string DateToString(DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }
    }
}
