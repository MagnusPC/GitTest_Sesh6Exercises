using Sesh6DbFirst.ModelLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesh6DbFirst.DbLayer
{
    internal class ProductDB
    {
        private readonly string connectionString = "data Source=.; Database=SalesDatabase; integrated security=true";

        public Product GetProductById(int id)
        {
            Product foundProd = null;

            string queryString = "select id, name, price from Product where product.id = @Id";

            using (SqlConnection con = new(connectionString))
            using (SqlCommand cmd = new(queryString, con))
            {
                cmd.Parameters.AddWithValue("Id", id);
                if (con != null)
                {
                    con.Open();
                    SqlDataReader prodReader = cmd.ExecuteReader();
                    List<Product> foundProductslist = GetProductObjects(prodReader);
                    if(foundProductslist.Count > 0)
                    {
                        foundProd = foundProductslist[0];
                    }
                }
            }
            return foundProd;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> productList = null;

            string queryString = "select id, name, price from Product";

            using (SqlConnection con = new(connectionString))
            using (SqlCommand cmd = new(queryString, con))
                if(con != null)
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    productList = GetProductObjects(reader);
                }
            return productList;
        }

        private List<Product> GetProductObjects(SqlDataReader prodReader)
        {
            List<Product> foundProducts = new();
            Product tempProd;
            int tempId; string tempName; decimal tempPrice;
            
            while(prodReader.Read())
            {
                tempId = prodReader.GetInt32(prodReader.GetOrdinal("id"));
                tempName = prodReader.GetString(prodReader.GetOrdinal("name"));
                tempPrice = prodReader.GetDecimal(prodReader.GetOrdinal("price"));
                tempProd = new(tempId, tempName, tempPrice);

                foundProducts.Add(tempProd);
            }

            return foundProducts;
        }
    }
}
