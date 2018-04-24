using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.Models
{
    public class BookMasterRepository : IBookMasterRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookMasterRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public BookMaster GetBook(int bookId)
        {
            return _appDbContext.BookMaster.FirstOrDefault(b => b.BookMasterId == bookId);
        }
        public int AddBook(BookMaster book)
        {
            _appDbContext.BookMaster.Add(book);
            return _appDbContext.SaveChanges();
        }

        public int DeleteBook(BookMaster book)
        {
            _appDbContext.BookMaster.Remove(book);
            return _appDbContext.SaveChanges();
        }

        public List<BookMaster> GetBooksByUserId(int UserId)
        {
            return _appDbContext.BookMaster.Where(b => b.UserId == UserId).ToList();
        }

        public int UpdateBook(BookMaster book)
        {
            _appDbContext.BookMaster.Update(book);
            return _appDbContext.SaveChanges();
        }
    }
}
