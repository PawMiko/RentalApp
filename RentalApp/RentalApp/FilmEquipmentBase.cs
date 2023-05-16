namespace RentalApp;                                                    

public abstract class FilmEquipmentBase : IFilmEquipments
{

    public FilmEquipmentBase()
    {
    }
    public FilmEquipmentBase(string name)
    {
        Name = name;
    }
    public FilmEquipmentBase(string name, string namefile)
    {
        Name = name;
        NameFile = namefile;
    }
    public string Name { get; private set; }
    public string NameFile { get; set; }

    public abstract void AddPrice(float price, int day, int numberOfCameras);
    public abstract Statistics GetStat();

    public void AddPrice(string price, string day, string numberOfCameras)
    {
        var replacement = price.Replace(".", ",");

        if (float.TryParse(replacement, out float floatConvert) && int.TryParse(day, out int day1) && int.TryParse(numberOfCameras, out int numberOfCameras1))
        {
            this.AddPrice(floatConvert, day1, numberOfCameras1);
        }
    }

    public void AddPrice(ulong price, int day, int numberOfCameras)
    {
        var priceValue = (float)price;

        AddPrice(priceValue, day, numberOfCameras);
    }


}
