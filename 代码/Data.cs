using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParseTraco
{
    public class Data
    {
        public Data()
        {
            results = new List<Variable>();
            records = new List<Record>();
        }

        public bool selected { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string time { get; set; }
        public string condition { get; set; }
        public List<Variable> results { get; set; }
        public string head { get; set; }
        public string total { get; set; }
        public List<Record> records { get; set; }
        public string information { get; set; }
        public string rawData { get; set; }
    }
}
