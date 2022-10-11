using System;
using System.Collections.Generic;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class AkbseatMap
    {
        public int MovieId { get; set; }
        public string SeatNo { get; set; } = null!;
        public int? Status { get; set; }

        public virtual Akbmovie Movie { get; set; } = null!;
    }
}
