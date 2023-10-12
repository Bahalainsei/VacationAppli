using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliVacationProject.DataAccess.Models
{

    public class Users
    {
        public int UsersId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string LastName { get; set; } 
        public string FirstName { get; set; } 
        public string Status { get; set; } 
        public string Gender { get; set; } 

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int RoleId { get; set; } /// clé étrangère pour la classe role
        public UserRole Role { get; set; }
        public ICollection <Vacation> Vacations { get; set; }
    }
}
