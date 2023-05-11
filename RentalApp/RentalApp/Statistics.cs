namespace RentalApp;                                     

public class Statistics
{
  
    public Statistics()
    {
        Profit = 0;
        DayValue = 0;
        TotalProfits = 0;
    }
 
    public float TotalProfits { get; private set; }
    public int DayValue { get; private set; } 
    public float Profit { get; set; } 
    public int ProcentDiscount { get; set; }
    public float AverageProfitsPerDay
    {
        get
        {
            return (float)Math.Round(this.TotalProfits / this.DayValue, 2);
        }
    }

    public void AddCashToStat(float money, int day, float totalProfit)
    {
        this.Profit = money;
        this.TotalProfits = (float)Math.Round(totalProfit, 2);
        this.DayValue = day;
    }
}
