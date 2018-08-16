using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParseTraco
{
    public class Threshold
    {
        public string min { get; set; }
        public string max { get; set; }

        public Threshold()
        {
            this.min = "无";
            this.max = "无";
        }

        public Threshold(string min, string max)
        {
            this.min = min;
            this.max = max;
        }

    }
}
