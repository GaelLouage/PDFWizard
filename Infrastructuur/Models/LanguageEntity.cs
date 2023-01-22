using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuur.Models
{
    public class LanguageEntity<Tkey, Tvalue>
    {
        public Tkey Key { get; set; }
        public Tvalue Value { get; set; }
    }
}
