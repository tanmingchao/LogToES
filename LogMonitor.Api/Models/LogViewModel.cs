using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogMonitor.Api.Models
{
    public class LogViewModel
    {
        public string IndexName { get; set; }

        [Keyword(Name = "operator")]
        public string Operator { get; set; }

        [Text(Name = "action_name")]
        public string ActionName { get; set; }

        [Text(Name = "action_params")]
        public string ActionParams { get; set; }

        [Keyword(Name = "area_key_words")]
        public string[] AreaKeyWords { get; set; }

        [Date(Name = "create_time")]
        public DateTime CreateTime { get; set; }
    }
}
