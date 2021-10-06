using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IBook_Operations
    {
        Task<Book> Create(Book objectToAdd);
        Task<Book> Read(Int64 entityId);
        Task<List<Book>> ReadAll();
        Task<Book> Update(Book objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
