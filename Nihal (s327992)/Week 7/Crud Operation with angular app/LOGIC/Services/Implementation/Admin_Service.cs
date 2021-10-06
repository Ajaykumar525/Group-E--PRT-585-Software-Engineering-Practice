using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Admin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Admin Admin Data
    /// </summary>
    public class Admin_Service : IAdmin_Service
    {
        //Reference to our crud functions
        private IAdmin_Operations _Admin_operations = new Admin_Operations();

        /// <summary>
        /// Obtains all the Admin Admines that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Admin_ResultSet>>> GetAllAdmins()
        {
            Generic_ResultSet<List<Admin_ResultSet>> result = new Generic_ResultSet<List<Admin_ResultSet>>();
            try
            {
                //GET ALL Admin AdminES
                List<Admin> Admines = await _Admin_operations.ReadAll();
                //MAP DB Admin RESULTS
                result.result_set = new List<Admin_ResultSet>();
                Admines.ForEach(s =>
                {
                    result.result_set.Add(new Admin_ResultSet
                    {
                        Admin_id = s.AdminID,
                        name = s.Admin_Name,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Admin Admines obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Admin_Service: GetAllAdmins() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Admin Admines from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Admin_Service: GetAllAdmins(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Admin_ResultSet>> GetAdminById(long id)
        {
            Generic_ResultSet<Admin_ResultSet> result = new Generic_ResultSet<Admin_ResultSet>();
            try
            {
                //GET by ID Admin 
                var Admin = await _Admin_operations.Read(id);

                //MAP DB Admin RESULTS
                result.result_set = new Admin_ResultSet
                {
                    name = Admin.Admin_Name,
                    Admin_id = Admin.AdminID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Admin  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Admin_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Admin  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Admin_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new Admin to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Admin_ResultSet>> AddAdmin(string name)
        {
            Generic_ResultSet<Admin_ResultSet> result = new Generic_ResultSet<Admin_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Admin
                Admin Admin = new Admin
                {
                    Admin_Name = name
                };

                //ADD Admin TO DB
                Admin = await _Admin_operations.Create(Admin);

                //MANUAL MAPPING OF RETURNED Admin VALUES TO OUR Admin_ResultSet
                Admin_ResultSet AdminAdded = new Admin_ResultSet
                {
                    name = Admin.Admin_Name,
                    Admin_id = Admin.AdminID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Admin Admin {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Admin_Service: AddAdmin() method executed successfully.";
                result.result_set = AdminAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Admin Admin supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Admin_Service: AddAdmin(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Admin Admins name.
        /// </summary>
        /// <param name="Admin_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Admin_ResultSet>> UpdateAdmin(Int64 Admin_id, string name)
        {
            Generic_ResultSet<Admin_ResultSet> result = new Generic_ResultSet<Admin_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Admin
                Admin Admin = new Admin
                {
                    AdminID = Admin_id,
                    Admin_Name = name,
                    //Admin_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Admin IN DB
                Admin = await _Admin_operations.Update(Admin, Admin_id);

                //MANUAL MAPPING OF RETURNED Admin VALUES TO OUR Admin_ResultSet
                Admin_ResultSet AdminUpdated = new Admin_ResultSet
                {
                    name = Admin.Admin_Name,
                    Admin_id = Admin.AdminID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Admin Admin {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Admin_Service: UpdateAdmin() method executed successfully.";
                result.result_set = AdminUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Admin Admin supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Admin_Service: UpdateAdmin(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteAdmin(long Admin_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Admin IN DB
                var AdminDeleted = await _Admin_operations.Delete(Admin_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Admin Admin {0} was deleted successfully", Admin_id);
                result.internalMessage = "LOGIC.Services.Implementation.Admin_Service: DeleteAdmin() method executed successfully.";
                result.result_set = AdminDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Admin Admin supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Admin_Service: DeleteAdmin(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
