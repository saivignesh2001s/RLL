using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROD.Models
{
    public class Cost
    {
        public int Rentid
        {
            get;
            set;
        }
        public int KmsCovered
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }
        public double tax
        {
            get;
            set;
        }
        public double TotalCost
        {
            get;
            set;
        }

    }
}