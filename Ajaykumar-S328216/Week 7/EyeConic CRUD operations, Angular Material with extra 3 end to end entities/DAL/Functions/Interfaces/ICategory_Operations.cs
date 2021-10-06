using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface ICategory_Operations
    {
        Task<Category> Create(Category objectToAdd);
        Task<Category> Read(Int64 entityId);
        Task<List<Category>> ReadAll();
        Task<Category> Update(Category objectToUpdate, int entityId);
        Task<bool> Delete(int entityId);
    }
}
