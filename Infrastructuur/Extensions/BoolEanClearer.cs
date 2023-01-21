using Infrastructuur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuur.Extensions
{
    public static class BoolEanClearer
    {
        public static void ResetItems(this List<PdfContent<string, string>> list)
        {
            foreach (var item in list)
            {
                item.IsClicked = false;
            }
        }
    }
}
