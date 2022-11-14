using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Xunit.Abstractions;
using System.IO;

namespace PROD.Models
{
    public class CAR
    {
        public int Carid { get; set; }
        public string Carname { get; set; }
        public string CarType { get; set; }
        public Nullable<int> PerDayCharge { get; set; }
        public Nullable<int> ChargePerKm { get; set; }
        public string Available { get; set; }
        [DisplayName("Image")]
      
        public string Photo{ get; set; }
    }
}