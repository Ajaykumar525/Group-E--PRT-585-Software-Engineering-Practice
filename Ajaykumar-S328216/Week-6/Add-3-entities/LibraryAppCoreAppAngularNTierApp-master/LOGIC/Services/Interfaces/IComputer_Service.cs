using LOGIC.Services.Models;
using LOGIC.Services.Models.Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IComputer_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Computer_ResultSet>>> GetAllComputers();
        Task<Generic_ResultSet<Computer_ResultSet>> GetComputerById(Int64 id);

        //Task<Generic_ResultSet<Student_ResultSet>> GetStudentByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Computer_ResultSet>> AddComputer(String name, String brand, String lastUser);
        Task<Generic_ResultSet<Computer_ResultSet>> UpdateComputer(Int64 id, String name, String brand, String lastUser);
        Task<Generic_ResultSet<bool>> DeleteComputer(Int64 id);
    }
}
