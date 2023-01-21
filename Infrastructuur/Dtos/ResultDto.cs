using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuur.Dtos
{
    public class ResultDto
    {
        public List<string> Errors { get; set; } = new List<string>();
        public Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();

    }
}
