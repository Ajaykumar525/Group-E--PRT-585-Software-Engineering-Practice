using LOGIC.Services.Models;
using LOGIC.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ICategory_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Category_ResultSet>>> GetAllCategories();
        Task<Generic_ResultSet<Category_ResultSet>> GetCategoryById(int id);

        //Task<Generic_ResultSet<Category_ResultSet>> GetCategoryByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Category_ResultSet>> AddCategory(string name, string gender);
        Task<Generic_ResultSet<Category_ResultSet>> UpdateCategory(int id, string name, string gender);
        Task<Generic_ResultSet<bool>> DeleteCategory(int id);
    }
}
