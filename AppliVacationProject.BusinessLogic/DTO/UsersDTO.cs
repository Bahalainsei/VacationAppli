using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliVacationProject.BusinessLogic.DTO
{
    public class UsersDTO
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalAddress { get; set; }
        public string City { get; set; }
        public string Profession { get; set; }
        public string MaritalStatus { get; set; }
        public string NumberOfChildren { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreateAccount { get; set; }
        public DateTime DateUpdateAccount { get; set; }
        public int RoleID { get; set; }

    }
}
