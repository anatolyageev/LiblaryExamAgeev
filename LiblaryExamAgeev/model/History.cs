using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiblaryExamAgeev
{
    class History
    {
        private static long Id = 1;
        public long BookId { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime DateBack { get; set; }

        public History( long bookId, DateTime dateTaken)
        {
            Id ++;
            BookId = bookId;
            DateTaken = dateTaken;
        }
    }
}
