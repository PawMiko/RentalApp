

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
        public float TotalProfits { get; private set; }//sumaryczny zysk na firme
        public  int DayValue { get; private set; } //ilość dni
        public float Profit { get;  set; } //jednostkowy zysk na firmie
        public int ProcentDiscount { get; set; } // kwotowa wartośc procentu 5%,10%,15%
           
      
        
        public Statistics()
        {
            Profit = 0;
            DayValue = 0;
            TotalProfits = 0; 
        }
       public float DiscountCalculation(float fPrice, int day, int numberOfCameras)//OBLICZANIE RABATU OD KONKRETNEJ KWOTY
        {
            this.Profit = fPrice* day * numberOfCameras;
            if (this.Profit < 0)                 //sprawdzanie czy  profit jest ujemny jeżeli jest to mnożymy go przez -1 ( bo cena musi być dodatnia)
                this.Profit = this.Profit * (-1);

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

            return (float)Math.Round(this.Profit,2);
        }

       
        public void AddCashInMemoryOrFile(float money, int day, float totalProfit)
        {
            this.Profit = money;
            this.TotalProfits = (float)Math.Round(totalProfit,2);
            this.DayValue = day;
        }
    }
}
