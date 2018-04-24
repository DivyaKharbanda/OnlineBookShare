using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.Models
{
    public interface IBookMasterRepository
    {
        List<BookMaster> GetBooksByUserId(int UserId);
        int AddBook(BookMaster book);
        int UpdateBook(BookMaster book);
        int DeleteBook(BookMaster book);
        BookMaster GetBook(int bookId);
    }
}
