using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class MorningstarAutocomplete
    {
        public string count { get; set; }
        public string pages { get; set; }
        public List<MorningstarSearchResults> results { get; set; }
    }
    public class MorningstarSearchResults
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string exchange { get; set; }
        public string performanceId { get; set; }
        public string securityType { get; set; }
        public string ticker { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }

}
