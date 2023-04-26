
namespace RentalApp
{
    public class FilmEquipmentToMemory : FilmEquipmentBase
    {
        private List<float> AllPrices = new List<float>(); //lista przechowuje ceny z poszczególnych transakcji
        private List<int> Day = new List<int>();//lista przechowuje  ilość dni które później są wykorzystywane do wyciagnięcia
                                                //średniego zysku licząc na dzień

        private int tempProcent = 0;

        public FilmEquipmentToMemory(string name)
        {
            Name = name;
        }
        public FilmEquipmentToMemory(string name, string nameFile)
        {
            Name = name;
            NameFile = nameFile;
        }
        public string NameFile { get; set; }
        public string Name { get; set; }


        public override void AddPrice(float fPrice, int day, int numberOfCameras) //
        {
            var stat = new Statistics();

            var temp = stat.DiscountCalculation(fPrice, day, numberOfCameras);
            this.AllPrices.Add(temp);// DODAWANIE DO LISTY SUMY Z JEDNEJ TRANSAKCJI  
            tempProcent = stat.ProcentDiscount;
            this.Day.Add(day);//DODAWANIE DO LISTY ILOŚĆ DNI KTÓRE NAWIĄZUJĄDO WYOŻYCZENIA 

        }

        public override void AddPrice(string sPrice, string day, string numberOfCameras) //METODA KONWERTUJĄCA DO ODPOWIEDNIEGO TYPU ZE STRINGA
        {
            var replacement = sPrice.Replace(".", ",");//PONIEWAŻ MI SIE TO ZDAŻA TO NIE MA ZNACZENIA CZY PRZECINEK CZY KROPKA.

            if (float.TryParse(replacement, out float floatConvert) && int.TryParse(day, out int day1) && int.TryParse(numberOfCameras, out int numberOfCameras1))
            {
                this.AddPrice(floatConvert, day1, numberOfCameras1);
            }
        }

        public override void AddPrice(ulong uPrice, int day1, int numberOfCameras1)
        {
            var price = (float)uPrice;

            AddPrice(price, day1, numberOfCameras1);
        }

        public override Statistics ReadPriceListOrFile()//metoda odczytująca odpowiednio z list
        {
            var stat = new Statistics();
            float totalProfits = 0;
            float profit = 0;
            int tempDay = 0;

            for (int i = 0; i < AllPrices.Count; i++)
            {
                totalProfits += AllPrices[i];
                profit = AllPrices[i];
            }

            foreach (var day in Day)
            {
                tempDay += day;
            }

            stat.ProcentDiscount = this.tempProcent;
            stat.AddCashInMemoryOrFile(profit, tempDay, totalProfits);

            return stat;
        }

    }
}
