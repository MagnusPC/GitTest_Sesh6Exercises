using Sesh6DbFirst.DbLayer;
using Sesh6DbFirst.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesh6DbFirst.CtrlLayer
{
    internal class ProductCtrl
    {
        public Product? GetProductById(int id)
        {
            Product? foundProd;

            try
            {
                ProductDB prodDB = new();
                foundProd = prodDB.GetProductById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                foundProd = null;
            }
            return foundProd;
        }

        public List<Product>? GetAllProducts()
        {
            List<Product>? foundProductList = new();

            try
            {
                ProductDB prodDB = new();
                foundProductList = prodDB.GetAllProducts();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                foundProductList = null;
            }
            return foundProductList;
        }
    }
}
