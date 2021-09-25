using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Publisher;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Publisher Publisher Data
    /// </summary>
    public class Publisher_Service : IPublisher_Service
    {
        //Reference to our crud functions
        private IPublisher_Operations _Publisher_operations = new Publisher_Operations();

        /// <summary>
        /// Obtains all the Publisher Publisheres that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Publisher_ResultSet>>> GetAllPublisher()
        {
            Generic_ResultSet<List<Publisher_ResultSet>> result = new Generic_ResultSet<List<Publisher_ResultSet>>();
            try
            {
                //GET ALL Publisher PublisherES
                List<Publisher> Publisheres = await _Publisher_operations.ReadAll();
                //MAP DB Publisher RESULTS
                result.result_set = new List<Publisher_ResultSet>();
                Publisheres.ForEach(s =>
                {
                    result.result_set.Add(new Publisher_ResultSet
                    {
                        Publisher_id = s.PublisherID,
                        name = s.Publisher_Name,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Publisher Publisheres obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Publisher_Service: GetAllPublishers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Publisher Publisheres from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Publisher_Service: GetAllPublishers(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Publisher_ResultSet>> GetPublisherById(long id)
        {
            Generic_ResultSet<Publisher_ResultSet> result = new Generic_ResultSet<Publisher_ResultSet>();
            try
            {
                //GET by ID Publisher 
                var Publisher = await _Publisher_operations.Read(id);

                //MAP DB Publisher RESULTS
                result.result_set = new Publisher_ResultSet
                {
                    name = Publisher.Publisher_Name,
                    Publisher_id = Publisher.PublisherID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Publisher  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Publisher_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Publisher  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Publisher_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new Publisher to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Publisher_ResultSet>> AddPublisher(string name)
        {
            Generic_ResultSet<Publisher_ResultSet> result = new Generic_ResultSet<Publisher_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Publisher
                Publisher Publisher = new Publisher
                {
                    Publisher_Name = name
                };

                //ADD Publisher TO DB
                Publisher = await _Publisher_operations.Create(Publisher);

                //MANUAL MAPPING OF RETURNED Publisher VALUES TO OUR Publisher_ResultSet
                Publisher_ResultSet PublisherAdded = new Publisher_ResultSet
                {
                    name = Publisher.Publisher_Name,
                    Publisher_id = Publisher.PublisherID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Publisher Publisher {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Publisher_Service: AddPublisher() method executed successfully.";
                result.result_set = PublisherAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Publisher Publisher supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Publisher_Service: AddPublisher(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Publisher Publishers name.
        /// </summary>
        /// <param name="Publisher_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Publisher_ResultSet>> UpdatePublisher(Int64 Publisher_id, string name)
        {
            Generic_ResultSet<Publisher_ResultSet> result = new Generic_ResultSet<Publisher_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Publisher
                Publisher Publisher = new Publisher
                {
                    PublisherID = Publisher_id,
                    Publisher_Name = name,
                    //Publisher_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Publisher IN DB
                Publisher = await _Publisher_operations.Update(Publisher, Publisher_id);

                //MANUAL MAPPING OF RETURNED Publisher VALUES TO OUR Publisher_ResultSet
                Publisher_ResultSet PublisherUpdated = new Publisher_ResultSet
                {
                    name = Publisher.Publisher_Name,
                    Publisher_id = Publisher.PublisherID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Publisher Publisher {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Publisher_Service: UpdatePublisher() method executed successfully.";
                result.result_set = PublisherUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Publisher Publisher supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Publisher_Service: UpdatePublisher(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeletePublisher(long Publisher_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Publisher IN DB
                var PublisherDeleted = await _Publisher_operations.Delete(Publisher_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Publisher Publisher {0} was deleted successfully", Publisher_id);
                result.internalMessage = "LOGIC.Services.Implementation.Publisher_Service: DeletePublisher() method executed successfully.";
                result.result_set = PublisherDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Publisher Publisher supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Publisher_Service: DeletePublisher(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


    }
}
