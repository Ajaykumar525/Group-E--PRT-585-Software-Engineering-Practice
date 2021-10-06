using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IContracter_Operations
    {
        Task<Contracter> Create(string contracter);
        Task<Contracter> Read(Int64 entityId);
        Task<List<Contracter>> ReadAll();
        Task<Contracter> Update(Contracter objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
        Task<Contracter> Create(Contracter contracter);
    }
}
