using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiblaryExamAgeev
{
    class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public User(long id, string name, string surname, string PhoneNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = PhoneNumber;
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user != null &&
                   Id == user.Id &&
                   Name == user.Name &&
                   Surname == user.Surname &&
                   PhoneNumber == user.PhoneNumber;
        }

        public override string ToString()
        {
            return $"Id {this.Id}; " +
                   $"Name {this.Name}; " +
                   $"Surname {this.Surname}; " +
                   $"Author {this.PhoneNumber}\n";
        }

        public override int GetHashCode()
        {
            var hashCode = 1466826866;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PhoneNumber);
            return hashCode;
        }

        public static bool operator ==(User user1, User user2)
        {
            return EqualityComparer<User>.Default.Equals(user1, user2);
        }

        public static bool operator !=(User user1, User user2)
        {
            return !(user1 == user2);
        }
    }
}
