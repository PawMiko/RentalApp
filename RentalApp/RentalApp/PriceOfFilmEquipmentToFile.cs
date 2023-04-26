﻿

using System.IO.Enumeration;

namespace RentalApp
{
    public class PriceOfFilmEquipmentToFile :FilmEquipmentBase
    {
        private int tempProcent = 0;
        public delegate void PriceAddedDelegate (object sender, EventArgs arg); 
        public event PriceAddedDelegate PriceAddedToFile;

        public PriceOfFilmEquipmentToFile()
        {
        }
        public PriceOfFilmEquipmentToFile(string name) :base(name) 
        {          
        }
        public PriceOfFilmEquipmentToFile(string name,string nameFile) : base(name,nameFile)
        {  
        }

        
        public override void AddPrice(float fPrice, int day, int numberOfCameras)//METODA DODAJĄCA DO PLIKU KWOTĘ JUŻ PO RABACIE
        {
            var stat = new Statistics();

            var temp = stat.DiscountCalculation(fPrice, day, numberOfCameras); //ODWOŁANIE  DO STATYSTYK GDZIE JEST SĄ PEŁNE OBLICZENA 
            tempProcent = stat.ProcentDiscount; //zachowanie w pamięci  wartości procentowej (5,10 lub 15%) gdzie będzie później wykorzystana do wyświetlania w konsoli  
                  
            using (var writer=File.AppendText(NameFile))
            {
                writer.WriteLine(Math.Round(temp,2)); // DODAWANIE DO PLIKU SUMY Z JEDNEJ TRANSAKCJI   - LINIA NIEPAZYSTA
                writer.WriteLine(day); //DODAWANIE DO TEGO SAMEGO PLIKU ILOŚC DNI KTÓRE NAWIĄZUJĄDO WYOŻYCZENIA  -LINIA PAZYSTA
                                    // PRZYDA SIE TO PÓŹNIEJ DO ODCZYTU I ZSUMOWANIA WSZYSTKICH DNI ABY WYCIĄGNĄĆ ŚREDNI ZAROBEK W PRZELICZENIA NA DZIEŃ.
                if (PriceAddedToFile!=null) 
                {
                    PriceAddedToFile(this,new EventArgs());//EVENT  
                }
            }

        }

        public override void AddPrice(string sPrice, string day, string numberOfCameras)//METODA KONWERTUJĄCA DO ODPOWIEDNIEGO TYPU ZE STRINGA
        {
            var replacement = sPrice.Replace(".", ","); //PONIEWAZ MI SIE TO ZDAŻA TO NIE MA ZNACZENIA CZY PRZECINEK CZY KROPKA.

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

        public override Statistics ReadPriceListOrFile()//METODA ODCZYTUJĄCA ODPOWIEDNIO  Z PLIKU
        {
            var stat = new Statistics();

            float profit = 0;
            float totalProfits = 0;
            float tempDay = 0;
            using (var reader = File.OpenText(NameFile))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    profit = float.Parse(line); //sczytywanie pierwszej linii

                    totalProfits += profit;  
                    line = reader.ReadLine();

                    tempDay += int.Parse(line); //sczytywanie drugiej linii                

                    line = reader.ReadLine(); 
                }
            }
            stat.AddCashInMemoryOrFile(profit, (int)tempDay, totalProfits);
            stat.ProcentDiscount = tempProcent;
            return stat;
        }

    }
}
