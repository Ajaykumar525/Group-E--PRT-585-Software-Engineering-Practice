using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Contracter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Contracter Contracter Data
    /// </summary>
    public class Contracter_Service : IContracter_Service
    {
        //Reference to our crud functions
        private IContracter_Operations _Contracter_operations = new Contracter_Operations();

        /// <summary>
        /// Obtains all the Contracter Contracteres that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Contracter_ResultSet>>> GetAllContracter()
        {
            Generic_ResultSet<List<Contracter_ResultSet>> result = new Generic_ResultSet<List<Contracter_ResultSet>>();
            try
            {
                //GET ALL Contracter ContracterES
                List<Contracter> Contracteres = await _Contracter_operations.ReadAll();
                //MAP DB Contracter RESULTS
                result.result_set = new List<Contracter_ResultSet>();
                Contracteres.ForEach(s =>
                {
                    result.result_set.Add(new Contracter_ResultSet
                    {
                        Contracter_id = s.ContracterID,
                        name = s.Contracter_Name,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Contracter Contracteres obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Contracter_Service: GetAllContracters() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Contracter Contracteres from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Contracter_Service: GetAllContracters(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Contracter_ResultSet>> GetContracterById(long id)
        {
            Generic_ResultSet<Contracter_ResultSet> result = new Generic_ResultSet<Contracter_ResultSet>();
            try
            {
                //GET by ID Contracter 
                var Contracter = await _Contracter_operations.Read(id);

                //MAP DB Contracter RESULTS
                result.result_set = new Contracter_ResultSet
                {
                    name = Contracter.Contracter_Name,
                    Contracter_id = Contracter.ContracterID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Contracter  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Contracter_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Contracter  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Contracter_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new Contracter to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Contracter_ResultSet>> AddContracter(string name)
        {
            Generic_ResultSet<Contracter_ResultSet> result = new Generic_ResultSet<Contracter_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Contracter
                Contracter Contracter = new Contracter
                {
                    Contracter_Name = name
                };

                //ADD Contracter TO DB
                Contracter = await _Contracter_operations.Create(Contracter);

                //MANUAL MAPPING OF RETURNED Contracter VALUES TO OUR Contracter_ResultSet
                Contracter_ResultSet ContracterAdded = new Contracter_ResultSet
                {
                    name = Contracter.Contracter_Name,
                    Contracter_id = Contracter.ContracterID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Contracter Contracter {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Contracter_Service: AddContracter() method executed successfully.";
                result.result_set = ContracterAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Contracter Contracter supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Contracter_Service: AddContracter(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Contracter Contracters name.
        /// </summary>
        /// <param name="Contracter_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Contracter_ResultSet>> UpdateContracter(Int64 Contracter_id, string name)
        {
            Generic_ResultSet<Contracter_ResultSet> result = new Generic_ResultSet<Contracter_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Contracter
                Contracter Contracter = new Contracter
                {
                    ContracterID = Contracter_id,
                    Contracter_Name = name,
                    //Contracter_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Contracter IN DB
                Contracter = await _Contracter_operations.Update(Contracter, Contracter_id);

                //MANUAL MAPPING OF RETURNED Contracter VALUES TO OUR Contracter_ResultSet
                Contracter_ResultSet ContracterUpdated = new Contracter_ResultSet
                {
                    name = Contracter.Contracter_Name,
                    Contracter_id = Contracter.ContracterID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Contracter Contracter {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Contracter_Service: UpdateContracter() method executed successfully.";
                result.result_set = ContracterUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Contracter Contracter supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Contracter_Service: UpdateContracter(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteContracter(long Contracter_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Contracter IN DB
                var ContracterDeleted = await _Contracter_operations.Delete(Contracter_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Contracter Contracter {0} was deleted successfully", Contracter_id);
                result.internalMessage = "LOGIC.Services.Implementation.Contracter_Service: DeleteContracter() method executed successfully.";
                result.result_set = ContracterDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Contracter Contracter supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Contracter_Service: DeleteContracter(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        
    }
}
