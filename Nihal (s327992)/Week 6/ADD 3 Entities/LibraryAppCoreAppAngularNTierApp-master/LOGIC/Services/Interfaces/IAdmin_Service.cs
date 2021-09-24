using LOGIC.Services.Models;
using LOGIC.Services.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IAdmin_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Admin_ResultSet>>> GetAllAdmins();
        Task<Generic_ResultSet<Admin_ResultSet>> GetAdminById(Int64 id);

        //Task<Generic_ResultSet<Student_ResultSet>> GetStudentByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Admin_ResultSet>> AddAdmin(string name);
        Task<Generic_ResultSet<Admin_ResultSet>> UpdateAdmin(Int64 id, string name);
        Task<Generic_ResultSet<bool>> DeleteAdmin(Int64 id);

    }
}