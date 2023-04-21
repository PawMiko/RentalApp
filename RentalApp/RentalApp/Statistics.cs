

namespace RentalApp
{
    public class Statistics
    {
        public float TotalProfits { get; private set;}
        public float AverageProfitsPerDay 
        { get
            {
                return (float)Math.Round(this.TotalProfits / this.DayValue, 2);
            } 
        }
        public int DayValue { get; set; }
        public float Profit { get; set; }
        
        public Statistics()
        {
            Profit = 0;
            DayValue = 0;
            TotalProfits = 0;
           
        }


        public void AddCash(float money, int day)
        {
            this.Profit = money;
            this.TotalProfits +=money;
            this.DayValue += day;
           
        }
       
    }
}
