

namespace RentalApp
{
    public class FilmEquipment
    {
        List<float> AllPrices = new List<float>();
        List<int>Day=new List<int>();
        int i = 0;
        
        public FilmEquipment(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int TempDay { get; set; }

        public void AddPrice(float fPrice, int day,int numberOfCameras)
        {
            this.i++;
            fPrice =fPrice*day* numberOfCameras;
            this.AllPrices.Add(fPrice);
            this.Day.Add(day);
        
        }

        public void AddPrice(string sPrice,string day,string numberOfCameras)
        {
            var replacement = sPrice.Replace(".", ",");

            if (float.TryParse(replacement, out float floatConvert)&& int.TryParse(day,out int day1) && int.TryParse(numberOfCameras, out int numberOfCameras1) )
            {
                this.AddPrice(floatConvert, day1, numberOfCameras1);
            }
        }  

        public void AddPrice(ulong uPrice,int day,int numberOfCameras)
        {
            var price = (float)uPrice;
           AddPrice(price,day,numberOfCameras);
        }

        public Statistics ReadPriceList()
        {
            var stat =new Statistics();
            stat.TotalProfits = 0;

            for(int i = 0; i < AllPrices.Count; i++) 
            {
                   stat.TotalProfits += AllPrices[i];
                   stat.Profit = AllPrices[i];
            }
            foreach(var day in Day)
            {
                stat.DayValue += day;
             
            }
            if (stat.DayValue > 0)
                stat.AverageProfitsPerDay = stat.TotalProfits / stat.DayValue;
            else
                stat.AverageProfitsPerDay = 0;
            return stat;   
        }

    }

}
