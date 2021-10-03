using LOGIC.Services.Models;
using LOGIC.Services.Models.Contracter;
using LOGIC.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IContracter_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Contracter_ResultSet>>> GetAllContracter();
        Task<Generic_ResultSet<Contracter_ResultSet>> GetContracterById(Int64 id);

        //Task<Generic_ResultSet<Student_ResultSet>> GetStudentByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Contracter_ResultSet>> AddContracter(String name, String contact, String email);
        Task<Generic_ResultSet<Contracter_ResultSet>> UpdateContracter(Int64 id, String name, String contact, String email);
        
        Task<Generic_ResultSet<bool>> DeleteContracter(Int64 id);
        
    }
}
