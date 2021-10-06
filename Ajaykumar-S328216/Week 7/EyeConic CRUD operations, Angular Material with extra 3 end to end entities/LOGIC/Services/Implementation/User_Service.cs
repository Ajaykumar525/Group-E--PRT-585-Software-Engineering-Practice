using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update User User Data
    /// </summary>
    public class User_Service : IUser_Service
    {
        //Reference to our crud functions
        private IUser_Operations _User_operations = new User_Operations();

        /// <summary>
        /// Obtains all the User Useres that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<User_ResultSet>>> GetAllUsers()
        {
            Generic_ResultSet<List<User_ResultSet>> result = new Generic_ResultSet<List<User_ResultSet>>();
            try
            {
                //GET ALL User UserES
                List<User> Useres = await _User_operations.ReadAll();
                //MAP DB User RESULTS
                result.result_set = new List<User_ResultSet>();
                Useres.ForEach(s =>
                {
                    result.result_set.Add(new User_ResultSet
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Contact = s.Contact,
                        Email = s.Email,
                        Address = s.Address
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All User Useres obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: GetAllUsers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required User Useres from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: GetAllUsers(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<User_ResultSet>> GetUserById(long id)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                //GET by ID User 
                var User = await _User_operations.Read(id);

                //MAP DB User RESULTS
                result.result_set = new User_ResultSet
                {
                    Name = User.Name,
                    Id = User.Id,
                    Contact = User.Contact,
                    Email = User.Email,
                    Address = User.Address
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - User  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required User  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new User to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<User_ResultSet>> AddUser(string name, Int64 contact, string email, string address)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF User
                User User = new User
                {
                    Name = name,
                    Contact = contact,
                    Email = email,
                    Address = address
                };

                //ADD User TO DB
                User = await _User_operations.Create(User);

                //MANUAL MAPPING OF RETURNED User VALUES TO OUR User_ResultSet
                User_ResultSet UserAdded = new User_ResultSet
                {
                    Name = User.Name,
                    Id = User.Id,
                    Contact = User.Contact,
                    Email = User.Email,
                    Address = User.Address
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied User User {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: AddUser() method executed successfully.";
                result.result_set = UserAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the User User supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: AddUser(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an User Users name.
        /// </summary>
        /// <param name="User_id"></param>
        /// <param name="name"></param>
        /// <param name="experience"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<User_ResultSet>> UpdateUser(Int64 id, string name, Int64 contact, string email, string address)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF User
                User User = new User
                {
                    Id = id,
                    Name = name,
                    Contact = contact,
                    Email = email,
                    Address = address
                    //User_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE User IN DB
                User = await _User_operations.Update(User, id);

                //MANUAL MAPPING OF RETURNED User VALUES TO OUR User_ResultSet
                User_ResultSet UserUpdated = new User_ResultSet
                {
                    Name = User.Name,
                    Id = User.Id,
                    Contact = User.Contact,
                    Email = User.Email,
                    Address = User.Address
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied User User {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: UpdateUser() method executed successfully.";
                result.result_set = UserUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the User User supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: UpdateUser(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteUser(long User_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete User IN DB
                var UserDeleted = await _User_operations.Delete(User_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied User User {0} was deleted successfully", User_id);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: DeleteUser() method executed successfully.";
                result.result_set = UserDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the User User supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: DeleteUser(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
