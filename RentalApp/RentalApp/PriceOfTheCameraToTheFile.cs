namespace RentalApp;                                                            //.

public class PriceOfTheCameraToTheFile : FilmEquipmentBase
{
    private int procent = 0;

    public PriceOfTheCameraToTheFile()
    {
    }
    public PriceOfTheCameraToTheFile(string name) : base(name)
    {
    }
    public PriceOfTheCameraToTheFile(string name, string nameFile) : base(name, nameFile)
    {
    }

    public delegate void PriceAddedDelegate(object sender, EventArgs arg);
    public event PriceAddedDelegate PriceAddedToFile;

    public override void AddPrice(float fPrice, int day, int numberOfCameras)
    {
        var dis = new Discount();

        var temp = dis.DiscountCalculation(fPrice, day, numberOfCameras);
        procent = dis.ProcentDiscount;

        using (var writer = File.AppendText(NameFile))
        {
            writer.WriteLine(Math.Round(temp, 2));
            writer.WriteLine(day);

            {
                PriceAddedToFile(this, new EventArgs());
            }
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

    public override Statistics LoadedPrices()
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
                profit = float.Parse(line);

                totalProfits += profit;
                line = reader.ReadLine();

                tempDay += int.Parse(line);

                line = reader.ReadLine();
            }
        }
        stat.AddCashToStat(profit, (int)tempDay, totalProfits);
        stat.ProcentDiscount = procent;
        return stat;
    }


}
