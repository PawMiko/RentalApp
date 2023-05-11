
namespace RentalApp;                                                            //*

public class ThePriceOfTheCameraInMemory : FilmEquipmentBase
{
    private int tempProcent = 0;

    private List<float> AllPrices = new();
    private List<int> Day = new();


    public ThePriceOfTheCameraInMemory(string name)
    {
        Name = name;
    }

    public string Name { get; set; }


    public override void AddPrice(float fPrice, int day, int numberOfCameras)
    {
        var stat = new Discount();

        var temp = stat.DiscountCalculation(fPrice, day, numberOfCameras);
        this.AllPrices.Add(temp);
        tempProcent = stat.ProcentDiscount;
        this.Day.Add(day);

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
        var stat1 = new Statistics();
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

        stat1.ProcentDiscount = this.tempProcent;
        stat1.AddCashToStat(profit, tempDay, totalProfits);

        return stat1;
    }

}
