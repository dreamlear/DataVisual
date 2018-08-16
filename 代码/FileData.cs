using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestParseTraco
{
    public class FileData
    {
        public List<Data> history { get; private set; }

        public FileData()
        {
            history = new List<Data>();
        }

        //得到一个新行，stream将get的行截去
        public bool GetLine(ref string stream, ref string end)
        {
            if (stream.IndexOf("\n") > 0)
            {
                end = stream.Substring(0, stream.IndexOf("\n"));
                stream = stream.Substring(stream.IndexOf("\n") + 1);
                return true;
            }
            return false;
        }

        //得到标签下的内容
        public string Get(ref string stream, string name)
        {
            string line = "";
            if (GetLine(ref stream, ref line))
            {
                int delimiter = line.IndexOf('=');
                if ((delimiter > 0) && (line.Substring(0, delimiter) == name))
                {
                    return line.Substring(delimiter + 1);
                }
            }
            return "";
        }

        public bool Parse(string content)
        {
            history.Clear();
            string stream = content;
            string line = "";
            string settings = ""; //参数详细信息
            Get(ref stream, "version");
            bool inStatement = false;
            while (GetLine(ref stream, ref line))
            {
                if (line.IndexOf("#TRACOSTATEMENTBEGIN#") == 0)
                {
                    inStatement = true;
                }
                else if (line.IndexOf("#TRACOSTATEMENTEND#") == 0)
                {
                    break;
                }
                else if (inStatement)
                {
                    settings += line;
                }
            }
            if (string.IsNullOrEmpty(settings))
            {
                return false;
            }
            JObject handler = (JObject)JsonConvert.DeserializeObject(settings);
            Data currentHistory = new Data();
            history.Add(currentHistory);
            currentHistory.selected = false;
            currentHistory.name = handler["name"].ToString();
            currentHistory.description = handler["description"].ToString();
            currentHistory.condition = handler["condition"].ToString();
            currentHistory.head = handler["head"].ToString();
            currentHistory.total = handler["total"].ToString();
            JToken results = handler["results"]; //每个参数的详细信息
            for (int i = 0; i < results.Count(); i++)
            {
                Variable variable = new Variable();
                variable.name = results[i]["name"].ToString();
                variable.address = results[i]["address"].ToString();
                variable.type = results[i]["type"].ToString();
                currentHistory.results.Add(variable);
            }
            handler = (JObject)JsonConvert.DeserializeObject(Get(ref stream, "records"));
            int records = int.Parse(handler["count"].ToString());
            UInt64 triggerts = UInt64.Parse(handler["triggerts"].ToString());
            UInt64 triggerself = UInt64.Parse(handler["triggerself"].ToString());
            double triggerinstant = double.Parse(handler["triggerinstant"].ToString());
            for (int i = 0; i < records; i++)
            {
                Record record = new Record();
                handler = (JObject)JsonConvert.DeserializeObject(Get(ref stream, "record"));
                record.instant = double.Parse(handler["instant"].ToString());
                JToken values = handler["values"];
                for (int j = 0; j < values.Count(); j++)
                {
                    record.values.Add(double.Parse(values[j].ToString()));
                }
                if (record.values.Count != currentHistory.results.Count)
                {
                    return false;
                }
                currentHistory.records.Add(record);
            }

            currentHistory.information = "Trigger TS: " + triggerts + ", Self: " + triggerself + ", Instant: " + ParseTime(triggerinstant).ToString("yyyy-MM-dd HH:mm:ss:fff");
            currentHistory.time = ParseTime(triggerinstant).ToString("yyyy-MM-dd HH-mm-ss-fff");

            currentHistory.rawData = content;
            return true;
        }

        //时间戳转换为正常时间
        public static DateTime ParseTime(double instant)
        {
            string timeStamp = ((long)instant / 1000).ToString();
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long time = long.Parse(timeStamp + "0000");
            TimeSpan timeSpan = new TimeSpan(time);
            return start.Add(timeSpan);
        }

    }
}
