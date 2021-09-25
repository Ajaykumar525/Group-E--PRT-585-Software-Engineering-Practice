using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        //return task of type product
        //can await this method because we used async
        Task<Product> GetProductByIdAsync(int id);

        //product type object is returned
        //IReadOnly gives read only access
        Task<IReadOnlyList<Product>> GetProductAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}
