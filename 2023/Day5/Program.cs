﻿using Day5.Domain;
using System.Data.Common;

Almanac almanac = new Almanac();
almanac.ParseLinesToMaps(File.ReadLines(@"Inputs\Input.txt").ToList());

almanac.PartNumber = 1;
Int64 result1 = almanac.GetMinLocationNumber();
Console.WriteLine(result1);

almanac.PartNumber = 2;
Int64 result2 = almanac.GetMinLocationNumber();
Console.WriteLine(result2);
Console.ReadLine();
