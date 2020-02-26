using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSVReader.Models
{
    public class RegisterAgentsVM
    {
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Plot_Location { get; set; } = "";
        public string Plot_Size { get; set; } = "";
        public string Plot_No { get; set; } = "";
    }
}