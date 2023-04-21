// See https://aka.ms/new-console-template for more information
using RentalApp;
int i=0;
var Business  = new PriceOfFilmEquipmentToFile("MassConcept: ","massConcept.txt");
var Business1 = new PriceOfFilmEquipmentToFile("Strip Studio: ","StripStudio.txt");
var Business2 = new PriceOfFilmEquipmentToFile("Sioux Film: ","SiouxFilm.txt");
var Global    = new PriceOfFilmEquipmentToFile();
float[] global = new float[3];



for (; ; )
{
    Console.Clear();
    Console.WriteLine("-----------------------STATYCZNA WYPOŻYCZALNIA SPRŻETU FILMOWEGO-----------------------");
    Console.WriteLine("=======================================================================================");
    Console.WriteLine("-------Masz wybór pomiędzy trzema firmami które mogą wypozyczyc sprzęt filmowy---------/n");
    Console.WriteLine("naciśnij M - wybierzesz  firmę Mass Concept");
    Console.WriteLine("naciśnij ST - wybierzesz  firmę Strip Studio");
    Console.WriteLine("naciśnij S - wybierzesz  firmę Sioux Film:");
    Console.WriteLine("naciśnij Q - wyjscie\n");

    Console.WriteLine("wybierz firmę ");
    var input = Console.ReadLine();
    switch (input)
    {
        case "M":
        case "m":
            MassConcept();
            break;
        case "ST":
        case "st":
            StripStudio();
            break;
        case "s":
        case "S":
            SiouxFilm();
            break;
        case "q":
        case "Q":
            var stat1 = Business.ReadPriceList();
            var stat2 = Business1.ReadPriceList();
            var stat3 = Business2.ReadPriceList();
           Console.WriteLine("sumaryczny zysk na wszystkich firmach to: "+(stat1.TotalProfits+stat2.TotalProfits+stat3.TotalProfits));
            i = 1;
            break;
        case "T":
        case "t":
            Console.WriteLine("sumaryczny zysk na wszystkich firmach to: " + (global[0] + global[1] + global[2]));
            i = 1;
            break;
        default:
            Console.WriteLine("dokonaj poprawnego wyboru");
            break;
    }
    if (i == 1)
        break;
}



void MassConcept()
{
    Console.WriteLine(Business.Name);
    Console.WriteLine("Kamera  koszt: ");
    var input = Console.ReadLine();
    Console.WriteLine("ile kamer?: ");
    var input3 = Console.ReadLine();
    Console.WriteLine("ile dni: ");
    var input2 = Console.ReadLine();
    Business.AddPrice(input, input2, input3);
      
    var stat = Business.ReadPriceList();
    Console.WriteLine($"wartość transakcji wynosi     {stat.Profit}  zł");

    Console.WriteLine($"Sumaryczny zarobke na firmie    {Business.Name}  to  {stat.TotalProfits}  zł");
    Console.WriteLine($"Średnia dniówka na   {stat.DayValue}  dni wypozyczenia sprzętu wynosi : {stat.AverageProfitsPerDay}  zł\n");
    Console.WriteLine("naciśnij klawisz");
    Console.ReadKey();
    global[0] = stat.TotalProfits;
    
}

void StripStudio()
{
    Console.WriteLine(Business1.Name);
    Console.WriteLine("Kamera  koszt: ");
    var input = Console.ReadLine();
    Console.WriteLine("ile kamer?: ");
    var input3 = Console.ReadLine();
    Console.WriteLine("ile dni: ");
    var input2 = Console.ReadLine();
    Business1.AddPrice(input, input2, input3);



    var stat = Business1.ReadPriceList();
  
    Console.WriteLine($"wartość transakcji wynosi    {stat.Profit}  zł");
    Console.WriteLine($"Sumaryczny zarobek na firmie    {Business1.Name}  to   {stat.TotalProfits}  zł");
    Console.WriteLine($"Średnia dniówka na sumaryczne  {stat.DayValue}  dni wypozyczenia sprzętu wynosi:  {stat.AverageProfitsPerDay}  zł\n");
    Console.WriteLine("naciśnij klawisz");
    Console.ReadKey();
    global[1] = stat.TotalProfits;
}
void SiouxFilm()
{
    Console.WriteLine(Business2.Name);
    Console.WriteLine("Kamera  koszt: ");
    var input = Console.ReadLine();
    Console.WriteLine("ile kamer?: ");
    var input3 = Console.ReadLine();
    Console.WriteLine("ile dni: ");
    var input2 = Console.ReadLine();
    Business2.AddPrice(input, input2, input3);
    
    var stat = Business2.ReadPriceList();

    Console.WriteLine($"wartość transakcji wynosi    {stat.Profit}  zł");
    Console.WriteLine($"Sumaryczny zarobke na firmie   { Business2.Name }  to   { stat.TotalProfits}   zł");
    Console.WriteLine($"Średnia dniówka na   {stat.DayValue}   dni wypozyczenia sprzętu wynosi : { stat.AverageProfitsPerDay}   zł\n");
    Console.WriteLine("naciśnij klawisz");
    Console.ReadKey();
    global[2] = stat.TotalProfits;

}