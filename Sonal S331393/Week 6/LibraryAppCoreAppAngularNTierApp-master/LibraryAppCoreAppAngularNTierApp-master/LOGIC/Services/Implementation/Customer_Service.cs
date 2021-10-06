using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Customer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Customer customer Data
    /// </summary>
    public class Customer_Service : ICustomer_Service
    {
        //Reference to our crud functions
        private ICustomer_Operations _customer_operations = new Customer_Operations();

        /// <summary>
        /// Obtains all the Customer customeres that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Customer_ResultSet>>> GetAllCustomers()
        {
            Generic_ResultSet<List<Customer_ResultSet>> result = new Generic_ResultSet<List<Customer_ResultSet>>();
            try
            {
                //GET ALL Customer customerES
                List<Customer> Customeres = await _customer_operations.ReadAll();
                //MAP DB Customer RESULTS
                result.result_set = new List<Customer_ResultSet>();
                Customeres.ForEach(s =>
                {
                    result.result_set.Add(new Customer_ResultSet
                    {
                        customer_id = s.CustomerID,
                        name = s.Customer_Name,
                        Customer_Lastname = s.Customer_Lastname,
                        Contact_Number = s.Contact_Number
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Customer customeres obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Customer_Service: GetAllCustomers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Customer customeres from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Student_Service: GetAllCustomers(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Customer_ResultSet>> GetCustomerById(long id)
        {
            Generic_ResultSet<Customer_ResultSet> result = new Generic_ResultSet<Customer_ResultSet>();
            try
            {
                //GET by ID Customer 
                var Customer = await _customer_operations.Read(id);

                //MAP DB Customer RESULTS
                result.result_set = new Customer_ResultSet
                {
                    name = Customer.Customer_Name,
                    customer_id = Customer.CustomerID,
                    Customer_Lastname = Customer.Customer_Lastname,
                    Contact_Number = Customer.Contact_Number
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Customer  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Customer_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Customer  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Customer_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new customer to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Customer_ResultSet>> AddCustomer(string name, string Customer_Lastname, string Contact_Number)
        {
            Generic_ResultSet<Customer_ResultSet> result = new Generic_ResultSet<Customer_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF customer
                Customer Customer = new Customer
                {
                    Customer_Name = name,
                    Customer_Lastname = Customer_Lastname,
                    Contact_Number = Contact_Number
                };

                //ADD Customer TO DB
                Customer = await _customer_operations.Create(Customer);

                //MANUAL MAPPING OF RETURNED Customer VALUES TO OUR Customer_ResultSet
                Customer_ResultSet customerAdded = new Customer_ResultSet
                {
                    name = Customer.Customer_Name,
                    customer_id = Customer.CustomerID,
                    Customer_Lastname = Customer.Customer_Lastname,
                    Contact_Number = Customer.Contact_Number
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Customer customer {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Customer_Service: AddCustomer() method executed successfully.";
                result.result_set = customerAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Customer customer supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Customer_Service: AddCustomer(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat a Customer customers name.
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Customer_ResultSet>> UpdateCustomer(Int64 customer_id, string name, string Customer_Lastname, string Contact_Number)
        {
            Generic_ResultSet<Customer_ResultSet> result = new Generic_ResultSet<Customer_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Customer
                Customer Customer = new Customer
                {
                    CustomerID = customer_id,
                    Customer_Name = name,
                    Customer_Lastname = Customer_Lastname,
                    Contact_Number = Contact_Number
                    //Customer_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Customer IN DB
                Customer = await _customer_operations.Update(Customer, customer_id);

                //MANUAL MAPPING OF RETURNED Customer VALUES TO OUR Customer_ResultSet
                Customer_ResultSet customerUpdated = new Customer_ResultSet
                {
                    name = Customer.Customer_Name,
                    customer_id = Customer.CustomerID,
                    Customer_Lastname = Customer.Customer_Lastname,
                    Contact_Number = Customer.Contact_Number
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Customer customer {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Customer_Service: UpdateCustomer() method executed successfully.";
                result.result_set = customerUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Customer customer supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Customer_Service: UpdateCustomer(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteCustomer(long customer_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Customer IN DB
                var customerDeleted = await _customer_operations.Delete(customer_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Customer customer {0} was deleted successfully", customer_id);
                result.internalMessage = "LOGIC.Services.Implementation.Customer_Service: DeleteCustomer() method executed successfully.";
                result.result_set = customerDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Customer customer supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Customer_Service: DeleteCustomer(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
