using LOGIC.Services.Models;
using LOGIC.Services.Models.Publisher;
using LOGIC.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IPublisher_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Publisher_ResultSet>>> GetAllPublisher();
        Task<Generic_ResultSet<Publisher_ResultSet>> GetPublisherById(Int64 id);

        //Task<Generic_ResultSet<Student_ResultSet>> GetStudentByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Publisher_ResultSet>> AddPublisher(string name);
        Task<Generic_ResultSet<Publisher_ResultSet>> UpdatePublisher(Int64 id, string name);
        Task<Generic_ResultSet<bool>> DeletePublisher(Int64 id);
    }
}
