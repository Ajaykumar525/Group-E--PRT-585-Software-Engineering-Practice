using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Book;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Book student Data
    /// </summary>
    public class Book_Service : IBook_Service
    {
        //Reference to our crud functions
        private IBook_Operations _book_operations = new Book_Operations();

        /// <summary>
        /// Obtains all the Books studentes that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Book_ResultSet>>> GetAllBooks()
        {
            Generic_ResultSet<List<Book_ResultSet>> result = new Generic_ResultSet<List<Book_ResultSet>>();
            try
            {
                //GET ALL Book bookES
                List<Book> Books = await _book_operations.ReadAll();
                //MAP DB Book RESULTS
                result.result_set = new List<Book_ResultSet>();
                Books.ForEach(b =>
                {
                    result.result_set.Add(new Book_ResultSet
                    {
                        BookId = b.BookId,
                        Name = b.Name,
                        Category = b.Category,
                        Code = b.Code
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Books obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Book_Service: GetAllBooks() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Book from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Book_Service: GetAllBooks(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Book_ResultSet>> GetBookById(long id)
        {
            Generic_ResultSet<Book_ResultSet> result = new Generic_ResultSet<Book_ResultSet>();
            try
            {
                //GET by ID Book 
                var Book = await _book_operations.Read(id);

                //MAP DB Book RESULTS
                result.result_set = new Book_ResultSet
                {
                    Name = Book.Name,
                    BookId = Book.BookId,
                    Category = Book.Category,
                    Code = Book.Code
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Book  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Book_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Book  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Book_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new book to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Book_ResultSet>> AddBook(String name, String category, Int32 code)
        {
            Generic_ResultSet<Book_ResultSet> result = new Generic_ResultSet<Book_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Book
                Book Book = new Book
                {
                    Name = name,
                    Category = category,
                    Code = code
                };

                //ADD Book TO DB
                Book = await _book_operations.Create(Book);

                //MANUAL MAPPING OF RETURNED Book VALUES TO OUR Book_ResultSet
                Book_ResultSet bookAdded = new Book_ResultSet
                {
                    Name = Book.Name,
                    BookId = Book.BookId,
                    Category = Book.Category,
                    Code = Book.Code
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Book {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Book_Service: AddBook() method executed successfully.";
                result.result_set = bookAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Book supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Book_Service: AddBook(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Book students name.
        /// </summary>
        /// <param name="student_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Book_ResultSet>> UpdateBook(Int64 book_id, String name, String category, Int32 code)
        {
            Generic_ResultSet<Book_ResultSet> result = new Generic_ResultSet<Book_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Book
                Book Book = new Book
                {
                    BookId = book_id,
                    Name = name,
                    Category = category,
                    Code = code
                    //Book_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Book IN DB
                Book = await _book_operations.Update(Book, book_id);

                //MANUAL MAPPING OF RETURNED Book VALUES TO OUR Book_ResultSet
                Book_ResultSet bookUpdated = new Book_ResultSet
                {
                    Name = Book.Name,
                    BookId = Book.BookId,
                    Category = Book.Category,
                    Code = Book.Code
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Book {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Book_Service: UpdateBook() method executed successfully.";
                result.result_set = bookUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Book supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Book_Service: UpdateBook(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteBook(long book_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Book IN DB
                var bookDeleted = await _book_operations.Delete(book_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Book {0} was deleted successfully", book_id);
                result.internalMessage = "LOGIC.Services.Implementation.Book_Service: DeleteBook() method executed successfully.";
                result.result_set = bookDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Book supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Book_Service: DeleteBook(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
