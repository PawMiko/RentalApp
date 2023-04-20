// See https://aka.ms/new-console-template for more information
using RentalApp;
int i=0;
var User  = new FilmEquipment("MassConcept: ");
var User1 = new FilmEquipment("Strip Studio: ");
var User2 = new FilmEquipment("Sioux Film: ");




Console.WriteLine("-----------------------STATYCZNA WYPOŻYCZALNIA SPRŻETU FILMOWEGO-----------------------");
Console.WriteLine("=======================================================================================");
Console.WriteLine("-------Masz wybór pomiędzy trzema firmami które mogą wypozyczyc sprżet filmowy---------");
Console.WriteLine("naciśnij M - wybierzesz  firmę Mass Concept");
Console.WriteLine("naciśnij U - wybierzesz  firmę Universal Studio");
Console.WriteLine("naciśnij S - wybierzesz  firmę Sioux Film:");
Console.WriteLine("naciśnij Q - wyjscie");

for (; ; )
{
    Console.WriteLine("wybierz firmę ");
    var input = Console.ReadLine();
    switch(input)
    {
        case "M":
        case "m":
            MassConcept();
            break;
        case "U":
        case "u":
            StripStudio();
            break;
        case "s":
        case "S":
            SiouxFilm();
            break;
        case "q":
        case "Q":
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
    Console.WriteLine(User.Name);
    Console.WriteLine("Kamera  koszt: ");
    var input = Console.ReadLine();
    Console.WriteLine("ile kamer?: ");
    var input3 = Console.ReadLine();
    Console.WriteLine("ile dni: ");
    var input2 = Console.ReadLine();
    User.AddPrice(input, input2, input3);
      
    var stat = User.ReadPriceList();
    Console.WriteLine("wartość transakcji wynosi   " + stat.Profit + " zł");

    Console.WriteLine("Sumaryczny zarobke na firmie   " + User.Name + " to " + stat.TotalProfits + " zł");
    Console.WriteLine("Średnia dniówka na " + stat.DayValue + " dni wypozyczenia sprzętu wynosi :" + stat.AverageProfitsPerDay + " zł");
}
void StripStudio()
{
    Console.WriteLine(User1.Name);
    Console.WriteLine("Kamera  koszt: ");
    var input = Console.ReadLine();
    Console.WriteLine("ile kamer?: ");
    var input3 = Console.ReadLine();
    Console.WriteLine("ile dni: ");
    var input2 = Console.ReadLine();
    User1.AddPrice(input, input2, input3);



    var stat = User1.ReadPriceList();
    Console.WriteLine("wartość transakcji wynosi   " + stat.Profit + " zł");

    Console.WriteLine("Sumaryczny zarobke na firmie  " + User1.Name + " to " + stat.TotalProfits + " zł");
    Console.WriteLine("Średnia dniówka na " + stat.DayValue + " dni wypozyczenia sprzętu wynosi :" + stat.AverageProfitsPerDay + " zł");
}
void SiouxFilm()
{
    Console.WriteLine(User2.Name);
    Console.WriteLine("Kamera  koszt: ");
    var input = Console.ReadLine();
    Console.WriteLine("ile kamer?: ");
    var input3 = Console.ReadLine();
    Console.WriteLine("ile dni: ");
    var input2 = Console.ReadLine();
    User2.AddPrice(input, input2, input3);

    var stat = User2.ReadPriceList();

    Console.WriteLine("Sumaryczny zarobke na firmie  " + User2.Name + " to " + stat.TotalProfits + " zł");
    Console.WriteLine("Średnia dniówka na " + stat.DayValue + " dni wypozyczenia sprzętu wynosi :" + stat.AverageProfitsPerDay + " zł");
}