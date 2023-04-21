using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalApp
{
    public abstract  class FilmEquipmentBase : IFilmEquipments
    {

        public filmequipmentbase()
        {
        }
        public filmequipmentbase(string name)
        {
            name = name;
        }
        public filmequipmentbase(string name, string namefile)
        {
            name = name;
            namefile = namefile;
        }
        public string Name { get; private set; }
        public string NameFile { get;  set; }

        

        public abstract void AddPrice(float fPrice, int day, int numberOfCameras);
        public abstract void AddPrice(string sPrice, string day, string numberOfCameras);
        public abstract void AddPrice(ulong uPrice, int day1, int numberOfCameras1);
        public abstract Statistics ReadPriceList();

    }
}
