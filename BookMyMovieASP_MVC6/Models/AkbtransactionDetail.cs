using System;
using System.Collections.Generic;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class AkbtransactionDetail
    {
        public AkbtransactionDetail()
        {
            AkbtransactionSeats = new HashSet<AkbtransactionSeat>();
        }

        public int TransactionId { get; set; }
        public int? CustomerId { get; set; }
        public int? MovieId { get; set; }
        public DateTime TransactionTime { get; set; }

        public virtual Akbcustomer? Customer { get; set; }
        public virtual Akbmovie? Movie { get; set; }
        public virtual ICollection<AkbtransactionSeat> AkbtransactionSeats { get; set; }
    }
}
