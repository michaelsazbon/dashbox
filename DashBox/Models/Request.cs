using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DashBox.Models {
    public class Request {
        public int take { get; set; }
        public string viewid { get; set; }
        public string cardcode { get; set; }
        public string totalht { get; set; }
        public int skip { get; set; }
        public int page { get; set; }
        public List<Sort> sort { get; set; }
        public Filter filter { get; set; }
    }

    public class Sort {
        public string field { get; set; }
        public string dir { get; set; }
    }

    public class Filter
    {
        public List<Filters> filters { get; set; }
        public string logic { get; set; }
    }

    public class Filters
    {
        public string field { get; set; }
        public string _operator { get; set; }
        public string value { get; set; }
    }
}