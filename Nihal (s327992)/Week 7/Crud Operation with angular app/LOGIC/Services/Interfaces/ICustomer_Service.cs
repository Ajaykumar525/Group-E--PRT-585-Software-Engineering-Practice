using LOGIC.Services.Models;
using LOGIC.Services.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ICustomer_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Customer_ResultSet>>> GetAllCustomers();
        Task<Generic_ResultSet<Customer_ResultSet>> GetCustomerById(Int64 id);

        //Task<Generic_ResultSet<Student_ResultSet>> GetStudentByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Customer_ResultSet>> AddCustomer(String Customer_Name, String Customer_Surname, String Contact_Email, String Contact_Number);
        Task<Generic_ResultSet<Customer_ResultSet>> UpdateCustomer(Int64 id, String Customer_Name, String Customer_Surname, String Contact_Email, String Contact_Number);
        Task<Generic_ResultSet<bool>> DeleteCustomer(Int64 id);

    }
}
