using LOGIC.Services.Models;
using LOGIC.Services.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IBook_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Book_ResultSet>>> GetAllBooks();
        Task<Generic_ResultSet<Book_ResultSet>> GetBookById(Int64 id);

        //Task<Generic_ResultSet<Student_ResultSet>> GetStudentByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Book_ResultSet>> AddBook(String name, String category, Int32 code);
        Task<Generic_ResultSet<Book_ResultSet>> UpdateBook(Int64 id, String name, String category, Int32 code);
        Task<Generic_ResultSet<bool>> DeleteBook(Int64 id);

    }
}

