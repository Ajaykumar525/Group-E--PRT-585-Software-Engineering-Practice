using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IAdmin_Operations
    {
        Task<Admin> Create(Admin objectToAdd);
        Task<Admin> Read(Int64 entityId);
        Task<List<Admin>> ReadAll();
        Task<Admin> Update(Admin objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}

