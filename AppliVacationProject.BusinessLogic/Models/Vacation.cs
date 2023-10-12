using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliVacationProject.DataAccess.Models
{
    public class Vacation
    {
        public int VacationId { get; set; }
        public string VacationName { get; set; }
        public string Reason { get; set; } 
        public string File { get; set; } 
        public string Deleted { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string VacationType { get; set; }
        public string VacationStatus { get; set; }
        public Users Users { get; set; }
        public int UsersId { get; set; }
    }
   
    
}
