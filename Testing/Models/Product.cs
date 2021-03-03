using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Product
    {
        public Product()
        {
        }

            public int ProductID { get; set; }
            public int NameID { get; set; }
            public int PriceID { get; set; }
            public int CategoryID { get; set; }
            public int OnSaleID { get; set; }
            public int StockLevelID { get; set; }
    }

    }

