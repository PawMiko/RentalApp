

namespace RentalApp
{
    public class Statistics
    {
        public float TotalProfits { get;set;}
        public float AverageProfitsPerDay { get;set;}
        public int DayValue { get; set; }
        public float Profit { get; set; }
        
        public Statistics()
        {
            Profit = 0;
            DayValue = 0;
            TotalProfits = 0;
            AverageProfitsPerDay = 0;
        }
            
    }
}
