

namespace RentalApp
{
    public class Statistics
    {
        private const float  bonus  = 0.05f;
        private const float  bonus1 = 0.1f;
        private const float  bonus2 = 0.15f;
        private float tempDiscount = 0;



       
        public float AverageProfitsPerDay 
        { get
            {
               
                return (float)Math.Round(this.TotalProfits / this.DayValue, 2);          

            } 
        }
        public float TotalProfits { get; private set; }
        public  int DayValue { get; private set; }
        public float Profit { get;  set; }
        public int ProcentDiscount { get; set; }
           
      
        
        public Statistics()
        {
            Profit = 0;
            DayValue = 0;
            TotalProfits = 0; 
        }
       public float DiscountCalculation(float fPrice, int day, int numberOfCameras)//OBLICZANIE RABATU OD KONKRETNEJ KWOTY
        {
            this.Profit = fPrice * day * numberOfCameras;
            if (this.Profit >= 2500 && this.Profit < 5000)
            {
                this.ProcentDiscount = 5;
                tempDiscount = this.Profit;
                tempDiscount *= bonus;
                this.Profit -= tempDiscount;
            }
            else
            if (this.Profit >= 5000 && this.Profit < 8000)
            {
                this.ProcentDiscount = 10;
                tempDiscount = this.Profit;
                tempDiscount *= bonus1;
                this.Profit -= tempDiscount;
            }
            else
            if (this.Profit >= 8000)
            {
                this.ProcentDiscount = 15;
                tempDiscount = this.Profit;
                tempDiscount *= bonus2;
                this.Profit -= tempDiscount;
            }

            return this.Profit;        }

       
        public void AddCashInMemoryOrFile(float money, int day, float totalProfit)
        {
            this.Profit = money;
            this.TotalProfits = totalProfit;
            this.DayValue += day;
        }
    }
}
