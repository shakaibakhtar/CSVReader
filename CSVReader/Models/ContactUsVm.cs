using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSVReader.Models
{
    public class ContactUsVm
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string message { get; set; }
    }
}