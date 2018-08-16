using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParseTraco
{
    public class Record
    {
        public Record()
        {
            values = new List<double>();
        }
        public double instant { get; set; }
        public List<double> values { get; set; }
    }
}
