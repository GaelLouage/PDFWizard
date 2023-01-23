using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuur.Models
{
    public class PdfFileEntity<Tkey, TValue>
    {
        [JsonProperty("key")]
        public Tkey Key { get; set; }
        [JsonProperty("value")]
        public TValue Value { get; set; }
    }
}
