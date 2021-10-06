using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Category Category Data
    /// </summary>
    public class Category_Service : ICategory_Service
    {
        //Reference to our crud functions
        private ICategory_Operations _Category_operations = new Category_Operations();

        /// <summary>
        /// Obtains all the Category Categoryes that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Category_ResultSet>>> GetAllCategories()
        {
            Generic_ResultSet<List<Category_ResultSet>> result = new Generic_ResultSet<List<Category_ResultSet>>();
            try
            {
                //GET ALL Category CategoryES
                List<Category> Categoryes = await _Category_operations.ReadAll();
                //MAP DB Category RESULTS
                result.result_set = new List<Category_ResultSet>();
                Categoryes.ForEach(s =>
                {
                    result.result_set.Add(new Category_ResultSet
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Gender = s.Gender
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Category Categoryes obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Category_Service: GetAllCategorys() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Category Categoryes from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Category_Service: GetAllCategorys(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Category_ResultSet>> GetCategoryById(int id)
        {
            Generic_ResultSet<Category_ResultSet> result = new Generic_ResultSet<Category_ResultSet>();
            try
            {
                //GET by ID Category 
                var Category = await _Category_operations.Read(id);

                //MAP DB Category RESULTS
                result.result_set = new Category_ResultSet
                {
                    Name = Category.Name,
                    Id = Category.Id,
                    Gender = Category.Gender
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Category  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Category_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Category  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Category_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new Category to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Category_ResultSet>> AddCategory(string name, string gender)
        {
            Generic_ResultSet<Category_ResultSet> result = new Generic_ResultSet<Category_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Category
                Category Category = new Category
                {
                    Name = name,
                    Gender = gender
                };

                //ADD Category TO DB
                Category = await _Category_operations.Create(Category);

                //MANUAL MAPPING OF RETURNED Category VALUES TO OUR Category_ResultSet
                Category_ResultSet CategoryAdded = new Category_ResultSet
                {
                    Name = Category.Name,
                    Id = Category.Id,
                    Gender = Category.Gender
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Category Category {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Category_Service: AddCategory() method executed successfully.";
                result.result_set = CategoryAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Category Category supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Category_Service: AddCategory(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Category Categorys name.
        /// </summary>
        /// <param name="Category_id"></param>
        /// <param name="name"></param>
        /// <param name="experience"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Category_ResultSet>> UpdateCategory(int Category_id, string name, string gender)
        {
            Generic_ResultSet<Category_ResultSet> result = new Generic_ResultSet<Category_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Category
                Category Category = new Category
                {
                    Id = (int)Category_id,
                    Name = name,
                    Gender = gender
                    //Category_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Category IN DB
                Category = await _Category_operations.Update(Category, Category_id);

                //MANUAL MAPPING OF RETURNED Category VALUES TO OUR Category_ResultSet
                Category_ResultSet CategoryUpdated = new Category_ResultSet
                {
                    Name = Category.Name,
                    Id = Category.Id,
                    Gender = Category.Gender
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Category Category {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Category_Service: UpdateCategory() method executed successfully.";
                result.result_set = CategoryUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Category Category supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Category_Service: UpdateCategory(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteCategory(int Category_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Category IN DB
                var CategoryDeleted = await _Category_operations.Delete(Category_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Category Category {0} was deleted successfully", Category_id);
                result.internalMessage = "LOGIC.Services.Implementation.Category_Service: DeleteCategory() method executed successfully.";
                result.result_set = CategoryDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Category Category supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Category_Service: DeleteCategory(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
