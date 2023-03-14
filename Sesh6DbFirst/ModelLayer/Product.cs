using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesh6DbFirst.ModelLayer
{
    internal class Product
    {
        public Product(int tempId, string tempName, decimal tempPrice)
        {
            TempId = tempId;
            TempName = tempName;
            TempPrice = tempPrice;
        }

        public int TempId { get; }
        public string TempName { get; }
        public decimal TempPrice { get; }
    }
}
