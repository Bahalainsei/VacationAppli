

namespace AppliVacationProject.DataAccess.Models
{
    public class VacationBalances
    {
       public int VacationBalancesID { get; set; }
       public int UsersId { get; set; }
       public string VacationType { get; set; }
       public Users Users { get; set; }

    }
}
