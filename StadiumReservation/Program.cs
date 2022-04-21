using StadiumReservation.Data;
using StadiumReservation.Models;
using System;
using System.Data.SqlClient;

namespace StadiumReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StadiumData stadiumData = new StadiumData();
            string ans = "";
            string stadiumName = "";
            string hourPriceStr;
            decimal hourPrice;
            string capacityStr;
            int capacity;
            do
            {
                Console.WriteLine("1. Stadion elave et\n2. Stadionlari goster\n3. Verilmish id'li stadionu goster\n4. Verilmish id'li stadionu sil\n0. Proqrami bitir");
                ans = Console.ReadLine();

                switch (ans)
                {
                    case "1":

                        do
                        {
                            Console.WriteLine("Stadion adini daxil edin: ");
                            stadiumName = Console.ReadLine();
                        } while (stadiumName.Length<256 && String.IsNullOrEmpty(stadiumName));

                        do
                        {
                            Console.WriteLine("Stadionun saatliq qiymetini daxil edin: ");
                            hourPriceStr = Console.ReadLine();
                        } while (!decimal.TryParse(hourPriceStr, out hourPrice));

                        do
                        {
                            Console.WriteLine("Stadionun tutumunu yazin: ");
                            capacityStr = Console.ReadLine();
                        } while (!int.TryParse(capacityStr,out capacity));

                        Stadium stadium = new Stadium
                        {
                            Name = stadiumName,
                            HourPrice = hourPrice,
                            Capacity = capacity,
                        };

                        
                        stadiumData.Add(stadium);
                        break;
                    case "2":

                        stadiumData.GetAll();

                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer daxil edin: ");
                        break;
                }


            } while (true);
        }
    }
}
