

using System.IO.Enumeration;

namespace RentalApp
{
    public class PriceOfFilmEquipmentToFile :FilmEquipmentBase
    {

        public PriceOfFilmEquipmentToFile() 
        {
        }

        public PriceOfFilmEquipmentToFile(string name) :base(name) 
        {          
        }
        public PriceOfFilmEquipmentToFile(string name,string nameFile) : base(name,nameFile)
        {  
        }

        
        public override void AddPrice(float fPrice, int day, int numberOfCameras)
        {
            fPrice = fPrice * day * numberOfCameras;
            using (var writer=File.AppendText(NameFile))
            {
                writer.WriteLine(fPrice);
                writer.WriteLine(day);
            }

        }

        public override void AddPrice(string sPrice, string day, string numberOfCameras)
        {
            var replacement = sPrice.Replace(".", ",");

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

        public override Statistics ReadPriceList()
        {
            var stat = new Statistics();
            using (var reader = File.OpenText(NameFile))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var money = float.Parse(line);
                    line = reader.ReadLine();
                    var day= int.Parse(line);
                    
                    stat.AddCash(money,day);
                    
                    line = reader.ReadLine();
                }
            }
            return stat;
        }

    }
}
