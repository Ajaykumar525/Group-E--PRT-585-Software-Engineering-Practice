using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Computer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Computer student Data
    /// </summary>
    public class Computer_Service : IComputer_Service
    {
        //Reference to our crud functions
        private IComputer_Operations _book_operations = new Computer_Operations();

        /// <summary>
        /// Obtains all the Computers studentes that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Computer_ResultSet>>> GetAllComputers()
        {
            Generic_ResultSet<List<Computer_ResultSet>> result = new Generic_ResultSet<List<Computer_ResultSet>>();
            try
            {
                //GET ALL Computer bookES
                List<Computer> Computers = await _book_operations.ReadAll();
                //MAP DB Computer RESULTS
                result.result_set = new List<Computer_ResultSet>();
                Computers.ForEach(c =>
                {
                    result.result_set.Add(new Computer_ResultSet
                    {
                        ComputerId = c.ComputerId,
                        ComputerName = c.ComputerName,
                        Brand = c.Brand,
                        LastUser = c.LastUser
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Computers obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Computer_Service: GetAllComputers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Computer from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Computer_Service: GetAllComputers(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Computer_ResultSet>> GetComputerById(long id)
        {
            Generic_ResultSet<Computer_ResultSet> result = new Generic_ResultSet<Computer_ResultSet>();
            try
            {
                //GET by ID Computer 
                var Computer = await _book_operations.Read(id);

                //MAP DB Computer RESULTS
                result.result_set = new Computer_ResultSet
                {
                    ComputerId = Computer.ComputerId,
                    ComputerName = Computer.ComputerName,
                    Brand = Computer.Brand,
                    LastUser = Computer.LastUser
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Computer  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Computer_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Computer  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Computer_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new book to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Computer_ResultSet>> AddComputer(String name, String brand, String lastUser)
        {
            Generic_ResultSet<Computer_ResultSet> result = new Generic_ResultSet<Computer_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Computer
                Computer Computer = new Computer
                {
                    ComputerName = name,
                    Brand = brand,
                    LastUser = lastUser
                };

                //ADD Computer TO DB
                Computer = await _book_operations.Create(Computer);

                //MANUAL MAPPING OF RETURNED Computer VALUES TO OUR Computer_ResultSet
                Computer_ResultSet bookAdded = new Computer_ResultSet
                {
                    ComputerId = Computer.ComputerId,
                    ComputerName = Computer.ComputerName,
                    Brand = Computer.Brand,
                    LastUser = Computer.LastUser
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Computer {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Computer_Service: AddComputer() method executed successfully.";
                result.result_set = bookAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Computer supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Computer_Service: AddComputer(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Computer students name.
        /// </summary>
        /// <param name="student_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Computer_ResultSet>> UpdateComputer(Int64 computer_id, String computerName, String brand, String lastUser)
        {
            Generic_ResultSet<Computer_ResultSet> result = new Generic_ResultSet<Computer_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Computer
                Computer Computer = new Computer
                {
                    ComputerId = computer_id,
                    ComputerName = computerName,
                    Brand = brand,
                    LastUser = lastUser
                    //Computer_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Computer IN DB
                Computer = await _book_operations.Update(Computer, computer_id);

                //MANUAL MAPPING OF RETURNED Computer VALUES TO OUR Computer_ResultSet
                Computer_ResultSet bookUpdated = new Computer_ResultSet
                {
                    ComputerName = Computer.ComputerName,
                    ComputerId = Computer.ComputerId,
                    Brand = Computer.Brand,
                    LastUser = Computer.LastUser
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Computer {0} was updated successfully", computerName);
                result.internalMessage = "LOGIC.Services.Implementation.Computer_Service: UpdateComputer() method executed successfully.";
                result.result_set = bookUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Computer supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Computer_Service: UpdateComputer(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteComputer(long computer_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Computer IN DB
                var computerDeleted = await _book_operations.Delete(computer_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Computer {0} was deleted successfully", computer_id);
                result.internalMessage = "LOGIC.Services.Implementation.Computer_Service: DeleteComputer() method executed successfully.";
                result.result_set = computerDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Computer supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Computer_Service: DeleteComputer(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
