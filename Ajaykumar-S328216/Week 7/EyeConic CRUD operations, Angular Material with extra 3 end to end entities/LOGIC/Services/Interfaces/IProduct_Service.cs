using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Product;

namespace LOGIC.Services.Interfaces
{
    public interface IProduct_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Product_ResultSet>>> GetAllProducts();
        Task<Generic_ResultSet<Product_ResultSet>> GetProductById(Int64 id);

        //Task<Generic_ResultSet<Product_ResultSet>> GetProductByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Product_ResultSet>> AddProduct(string name, decimal price, int qty);
        Task<Generic_ResultSet<Product_ResultSet>> UpdateProduct(Int64 id, string name, decimal price, int qty);
        Task<Generic_ResultSet<bool>> DeleteProduct(Int64 id);
    }
}
