namespace AppliVacationProject.BusinessLogic.DTO
{
    public class VacationCalendarDTO
    {
        
        
            public int? ID { get; set; }
            public int UserID { get; set; }
            public int VacationID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Status { get; set; }
        public int VacationBalancesID { get; set; }
        public int CurrentBalance { get; set; }
        public object BalanceType { get; set; }
    }
}
