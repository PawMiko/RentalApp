﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalApp
{
    public interface IFilmEquipments
    {
   
         string Name { get; }
         string NameFile { get; }

        void AddPrice(float fPrice, int day, int numberOfCameras);
        void AddPrice(string sPrice, string day, string numberOfCameras);
        void AddPrice(ulong uPrice, int day1, int numberOfCameras1);
        Statistics ReadPriceListOrFile();
    }
}
