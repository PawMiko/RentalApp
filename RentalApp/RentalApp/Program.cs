// See https://aka.ms/new-console-template for more information
using RentalApp;
int i=0;
var Business  = new PriceOfFilmEquipmentToFile("MassConcept: ","massConcept.txt");
var Business1 = new PriceOfFilmEquipmentToFile("Strip Studio: ","StripStudio.txt");
var Business2 = new PriceOfFilmEquipmentToFile("Sioux Film: ","SiouxFilm.txt");

Business.PriceAddedToFile += Information;
Business1.PriceAddedToFile += Information;
Business2.PriceAddedToFile += Information;




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
           Console.WriteLine("sumaryczny zysk na wszystkich firmach to: "+((float)Math.Round(stat1.TotalProfits + stat2.TotalProfits + stat3.TotalProfits, 2)));
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


    Console.WriteLine($"wartość ostatniej transakcji wynosi     {stat.Profit}  zł z rabatem { stat.ProcentDiscount} %" );

    Console.WriteLine($"Sumaryczny zarobek na firmie    {Business.Name}  to  {stat.TotalProfits}  zł");
    Console.WriteLine($"Średnia dniówka na   {stat.DayValue}  dni wypożyczenia sprzętu wynosi : {stat.AverageProfitsPerDay}  zł\n");
    Console.WriteLine("naciśnij klawisz");
    Console.ReadKey();
  
    
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

    Console.WriteLine($"wartość ostatniej transakcji wynosi     {stat.Profit}  zł z rabatem {stat.ProcentDiscount} %");
    Console.WriteLine($"Sumaryczny zarobek na firmie    {Business1.Name}  to   {stat.TotalProfits}  zł");
    Console.WriteLine($"Średnia dniówka na sumaryczne  {stat.DayValue}  dni wypozyczenia sprzętu wynosi:  {stat.AverageProfitsPerDay}  zł\n");
    Console.WriteLine("naciśnij klawisz");
    Console.ReadKey();
   
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

    Console.WriteLine($"wartość ostatniej  transakcji wynosi     {stat.Profit}  zł z rabatem {stat.ProcentDiscount} %");
    Console.WriteLine($"Sumaryczny zarobke na firmie   { Business2.Name }  to   { stat.TotalProfits}   zł");
    Console.WriteLine($"Średnia dniówka na   {stat.DayValue}   dni wypozyczenia sprzętu wynosi : { stat.AverageProfitsPerDay}   zł\n");
    Console.WriteLine("naciśnij klawisz");
    Console.ReadKey();
   

}
void Information(object sender, EventArgs args)
{
    Console.WriteLine("Dane dodano do pliku ");
}