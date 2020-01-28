using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiblaryExamAgeev
{
    class UserCard
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public List<History> UserHistory { get; set; }

        public UserCard(long id, long userId)
        {
            Id = id;
            UserId = userId;
            UserHistory =new List<History>();
        }

        public void addHistoryItem( long bookId, DateTime dateTaken)
        {
            UserHistory.Add(new History( bookId, dateTaken));
        }
    }
}
