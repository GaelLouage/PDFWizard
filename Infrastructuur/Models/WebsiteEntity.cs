using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuur.Models
{
    public class WebsiteEntity
    {
        public string Url { get; set; }
        public string TagName { get; set; }
        public string Language { get; set; } = "en";
        
    }
}
