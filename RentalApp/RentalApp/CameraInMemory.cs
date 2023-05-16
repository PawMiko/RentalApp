
namespace RentalApp;                                                            

public class CameraInMemory : FilmEquipmentBase
{
    private int tempProcent = 0;

    private List<float> allPrices = new();
    private List<int> day = new();


    public CameraInMemory(string name)
    {
        Name = name;
    }

    public string Name { get; set; }


    public override void AddPrice(float price, int day, int numberOfCameras)
    {
        var dis = new Discount();

        var temp = dis.DiscountCalculation(price, day, numberOfCameras);
        this.allPrices.Add(temp);
        tempProcent = dis.ProcentDiscount;
        this.day.Add(day);

    }

    public override Statistics GetStat()
    {
        var stat = new Statistics();
        float totalProfits = 0;
        float profit = 0;
        int tempDay = 0;

        for (int i = 0; i < allPrices.Count; i++)
        {
            totalProfits += allPrices[i];
            profit = allPrices[i];
        }

        foreach (var day in day)
        {
            tempDay += day;
        }

        stat.ProcentDiscount = this.tempProcent;
        stat.AddCashToStat(profit, tempDay, totalProfits);

        return stat;
    }

}
