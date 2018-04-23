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
        public List<BookMaster> GetBooksByUserId(int UserId)
        {
            return _appDbContext.BookMaster.Where(b => b.UserId == UserId).ToList();
        }
    }
}
