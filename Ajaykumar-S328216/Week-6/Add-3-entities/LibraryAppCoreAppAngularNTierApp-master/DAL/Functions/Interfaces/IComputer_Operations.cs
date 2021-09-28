using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IComputer_Operations
    {
        Task<Computer> Create(Computer objectToAdd);
        Task<Computer> Read(Int64 entityId);
        Task<List<Computer>> ReadAll();
        Task<Computer> Update(Computer objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
