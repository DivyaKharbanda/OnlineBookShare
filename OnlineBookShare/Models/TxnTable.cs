using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.Models
{
    public class TxnTable
    {
        public int TxnTableId { get; set; }
        public int OwnerId { get; set; }
        public int BorrowerId { get; set; }
        public int BookId { get; set; }
        public int NumberOfDaysRented { get; set; }
        public DateTime RentStartDate { get; set; }
        public decimal Price { get; set; }
    }
}
