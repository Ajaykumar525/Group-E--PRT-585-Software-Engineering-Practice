using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IPublisher_Operations
    {
        Task<Publisher> Create(string Publisher);
        Task<Publisher> Read(Int64 entityId);
        Task<List<Publisher>> ReadAll();
        Task<Publisher> Update(Publisher objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
        Task<Publisher> Create(Publisher Publisher);
    }
}
