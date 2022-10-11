using System;
using System.Collections.Generic;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class AkbtransactionSeat
    {
        public int? TransactionId { get; set; }
        public string SeatNo { get; set; } = null!;

        public virtual AkbtransactionDetail Transaction { get; set; } = null!;
    }
}
