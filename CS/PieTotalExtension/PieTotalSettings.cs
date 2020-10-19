using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieTotalExtension
{
    public class PieTotalSettings
    {
        public bool Enabled { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public string MeasureId { get; set; }

        public PieTotalSettings()
        {
            Enabled = false;
            Prefix = "Total";
        }

        public static PieTotalSettings FromJson(string json)
        {
            if (string.IsNullOrEmpty(json))
                return new PieTotalSettings();
            return JsonConvert.DeserializeObject<PieTotalSettings>(json) as PieTotalSettings;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

}
