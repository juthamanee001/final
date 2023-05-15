﻿class program{
    static void Main(string[] args){
        using System;
using System.Collections.Generic;

        Console.Write("กรุณาระบุจำนวนเมืองที่ต้องการแสดงในแบบจำลอง: ");
        int cityCount = int.Parse(Console.ReadLine());

        List<City> cities = new List<City>();

        for (int i = 0; i < cityCount; i++)
        {
            Console.Write($"เมืองที่ {i}: ");
            string cityName = Console.ReadLine();
            City city = new City(i, cityName);
            cities.Add(city);
        }

        foreach (var city in cities)
        {
            Console.WriteLine($"เมือง: {city.CityName}");
            Console.Write("จำนวนเมืองที่ติดต่อกับเมืองนี้: ");
            int connectedCities = int.Parse(Console.ReadLine());

            for (int i = 0; i < connectedCities; i++)
            {
                Console.Write($"หมายเลขประจำเมืองที่ {i}: ");
                int cityId = int.Parse(Console.ReadLine());

                if (cityId < 0 || cityId >= cities.Count || cityId == city.CityId)
                {
                    Console.WriteLine("Invalid ID");
                    i--;
                }
                else
                {
                    city.ConnectedCities.Add(cityId);
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine("ข้อมูลเมืองทั้งหมด:");
        foreach (var city in cities)
        {
            Console.WriteLine($"หมายเลขประจำเมือง: {city.CityId}, ชื่อเมือง: {city.CityName}");
            Console.WriteLine("เมืองที่ติดต่อกับเมืองนี้:");
            foreach (var connectedCity in city.ConnectedCities)
            {
                Console.WriteLine($"- {cities[connectedCity].CityName}");
            }
            Console.WriteLine();
        }
    }

class City
{
    public int CityId { get; }
    public string CityName { get; }
    public List<int> ConnectedCities { get; }

    public City(int cityId, string cityName)
    {
        CityId = cityId;
        CityName = cityName;
        ConnectedCities = new List<int>();
    }
}

