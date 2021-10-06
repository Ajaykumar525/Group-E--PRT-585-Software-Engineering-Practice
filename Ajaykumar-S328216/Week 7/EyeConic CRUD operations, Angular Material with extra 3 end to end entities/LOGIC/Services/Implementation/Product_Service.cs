using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Product Product Data
    /// </summary>
    public class Product_Service : IProduct_Service
    {
        //Reference to our crud functions
        private IProduct_Operations _Product_operations = new Product_Operations();

        /// <summary>
        /// Obtains all the Product Productes that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Product_ResultSet>>> GetAllProducts()
        {
            Generic_ResultSet<List<Product_ResultSet>> result = new Generic_ResultSet<List<Product_ResultSet>>();
            try
            {
                //GET ALL Product ProductES
                List<Product> Products = await _Product_operations.ReadAll();
                //MAP DB Product RESULTS
                result.result_set = new List<Product_ResultSet>();
                Products.ForEach(s =>
                {
                    result.result_set.Add(new Product_ResultSet
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Price = s.Price,
                        Quantity = s.Quantity
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Product Productes obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: GetAllProducts() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Product Productes from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: GetAllProducts(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Product_ResultSet>> GetProductById(long id)
        {
            Generic_ResultSet<Product_ResultSet> result = new Generic_ResultSet<Product_ResultSet>();
            try
            {
                //GET by ID Product 
                var Product = await _Product_operations.Read(id);

                //MAP DB Product RESULTS
                result.result_set = new Product_ResultSet
                {
                    Name = Product.Name,
                    Id = Product.Id,
                    Price = Product.Price,
                    Quantity = Product.Quantity
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Product  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Product  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new Product to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Product_ResultSet>> AddProduct(string name, decimal price, int qty)
        {
            Generic_ResultSet<Product_ResultSet> result = new Generic_ResultSet<Product_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Product
                Product Product = new Product
                {
                    Name = name,
                    Price = price,
                    Quantity = qty
                };

                //ADD Product TO DB
                Product = await _Product_operations.Create(Product);

                //MANUAL MAPPING OF RETURNED Product VALUES TO OUR Product_ResultSet
                Product_ResultSet ProductAdded = new Product_ResultSet
                {
                    Name = Product.Name,
                    Id = Product.Id,
                    Price = Product.Price,
                    Quantity = Product.Quantity
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Product Product {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: AddProduct() method executed successfully.";
                result.result_set = ProductAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Product Product supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: AddProduct(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Product Products name.
        /// </summary>
        /// <param name="Product_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Product_ResultSet>> UpdateProduct(Int64 Product_id, string name, decimal price, int qty)
        {
            Generic_ResultSet<Product_ResultSet> result = new Generic_ResultSet<Product_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Product
                Product Product = new Product
                {
                    Id = Product_id,
                    Name = name,
                    Price = price,
                    Quantity = qty
                    //Product_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Product IN DB
                Product = await _Product_operations.Update(Product, Product_id);

                //MANUAL MAPPING OF RETURNED Product VALUES TO OUR Product_ResultSet
                Product_ResultSet ProductUpdated = new Product_ResultSet
                {
                    Name = Product.Name,
                    Id = Product.Id,
                    Price = Product.Price,
                    Quantity = Product.Quantity
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Product Product {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: UpdateProduct() method executed successfully.";
                result.result_set = ProductUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Product Product supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: UpdateProduct(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteProduct(long Product_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Product IN DB
                var ProductDeleted = await _Product_operations.Delete(Product_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Product Product {0} was deleted successfully", Product_id);
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: DeleteProduct() method executed successfully.";
                result.result_set = ProductDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Product Product supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: DeleteProduct(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
