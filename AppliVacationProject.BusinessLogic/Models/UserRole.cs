using System;

namespace AppliVacationProject.DataAccess.Models
{

    public class UserRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
