namespace RentalApp;                                                            

public class CameraInFile : FilmEquipmentBase
{
    private int procent = 0;

    public CameraInFile()
    {
    }
    public CameraInFile(string name) : base(name)
    {
    }
    public CameraInFile(string name, string nameFile) : base(name, nameFile)
    {
    }

    public delegate void PriceAddedDelegate(object sender, EventArgs arg);
    public event PriceAddedDelegate PriceAddedToFile;

    public override void AddPrice(float price, int day, int numberOfCameras)
    {
        var dis = new Discount();

        var temp = dis.DiscountCalculation(price, day, numberOfCameras);
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

    public override Statistics GetStat()
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
