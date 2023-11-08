using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliVacationProject.BusinessLogic.DTO
{
    public class VacationBalancesDTO
    {
        public class VacationsBalanceDTO
        {
            public int VacationBalancesID { get; set; }
            public int? ID { get; set; }
            public int UserID { get; set; }
            public string BalanceType { get; set; }
            public int CurrentBalance { get; set; }
        }
    }
}
