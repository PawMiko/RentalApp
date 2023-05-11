using RentalApp;
int i = 0;
var company = new PriceOfTheCameraToTheFile("MassConcept: ", "massConcept.txt");
var company1 = new PriceOfTheCameraToTheFile("Strip Studio: ", "StripStudio.txt");
var company2 = new PriceOfTheCameraToTheFile("Sioux Film: ", "SiouxFilm.txt");
var currentCompany = new PriceOfTheCameraToTheFile();

company.PriceAddedToFile += Information;
company1.PriceAddedToFile += Information;
company2.PriceAddedToFile += Information;

for (; ; )
{
    Console.Clear();
    Console.WriteLine("-----------------------STATYCZNA WYPOŻYCZALNIA SPRZĘTU FILMOWEGO-----------------------");
    Console.WriteLine("=======================================================================================");
    Console.WriteLine("-------Masz wybór pomiędzy trzema firmami które mogą wypożyczyć sprzęt filmowy---------/n");
    Console.WriteLine("naciśnij M - wybierzesz  firmę Mass Concept");
    Console.WriteLine("naciśnij ST - wybierzesz  firmę Strip Studio");
    Console.WriteLine("naciśnij S - wybierzesz  firmę Sioux Film:");
    Console.WriteLine("naciśnij Q - wyjście\n");

    Console.WriteLine("wybierz firmę ");
    var input = Console.ReadLine();
    switch (input)
    {
        case "M":
        case "m":
            ChooseACompany("M");
            break;
        case "ST":
        case "st":
            ChooseACompany("ST");
            break;
        case "s":
        case "S":
            ChooseACompany("S");
            break;
        case "q":
        case "Q":
            var stat1 = company.LoadedPrices();
            var stat2 = company1.LoadedPrices();
            var stat3 = company2.LoadedPrices();
            Console.WriteLine($"Sumaryczny zysk na wszystkich firmach to: {(float)Math.Round(stat1.TotalProfits + stat2.TotalProfits + stat3.TotalProfits, 2)}");
            i = 1;
            break;
        default:
            Console.WriteLine(" zły wybór. Naciśnij dowolny klawisz i dokonaj poprawnego wyboru");
            Console.ReadKey();
            break;
    }
    if (i == 1)
        break;
}

void ChooseACompany(string letter)
{

    if (letter == "M")
    {
        currentCompany = company;
    }
    else
        if (letter == "ST")
    {
        currentCompany = company1;
    }
    else
        if (letter == "S")
    {
        currentCompany = company2;
    }

    Console.WriteLine(currentCompany.Name);
    Console.WriteLine("Kamera  koszt: ");
    var input = Console.ReadLine();
    Console.WriteLine("ile kamer?: ");
    var input3 = Console.ReadLine();
    Console.WriteLine("ile dni: ");
    var input2 = Console.ReadLine();

    currentCompany.AddPrice(input, input2, input3);
    var stat = currentCompany.LoadedPrices();

    Console.WriteLine($"wartość ostatniej transakcji wynosi     {stat.Profit}  zł z rabatem {stat.ProcentDiscount} %");
    Console.WriteLine($"Sumaryczny zarobek na firmie    {currentCompany.Name}  to  {stat.TotalProfits}  zł");
    Console.WriteLine($"Średnia dniówka na   {stat.DayValue}  dni wypożyczenia sprzętu wynosi : {stat.AverageProfitsPerDay}  zł\n");
    Console.WriteLine("naciśnij klawisz");
    Console.ReadKey();

}

void Information(object sender, EventArgs args)
{
    Console.WriteLine("Dane dodano do pliku ");
}