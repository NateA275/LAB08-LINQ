using System;
using System.IO;
using LINQ_In_Manhatten.Classes;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LINQ_In_Manhatten
{
    class Program
    {
        static void Main(string[] args)
        { 
            FeaturesCollection allFeatures = ReadFile();

            //Query All Neighborhoods
            Console.WriteLine("Press ENTER to Display all neighborhoods");

            //var firstQuery = from n in allFeatures.Features
            //                 where n.Properties.Neighborhood != null
            //                 select n.Properties.Neighborhood;

            var firstQuery = allFeatures.Features.Where(n => n.Properties.Neighborhood != null)
                                                 .Select(n => n.Properties.Neighborhood);

            DisplayResult(firstQuery);



            //Filter Blank Neighborhoods
            Console.WriteLine("Press ENTER to Dispaly all non-blank neighborhoods");

            //var secondQuery = from n in firstQuery
            //                  where n != ""
            //                  select n;

            var secondQuery = firstQuery.Where(n => n != "");

            DisplayResult(secondQuery);




            //Filter Dulicates
            Console.WriteLine("Press ENTER to Dispaly neighborhoods without duplicates");
            var thirdQuery = secondQuery.Distinct();

            DisplayResult(thirdQuery);



            //Single Query From
            Console.WriteLine("Press ENTER to Dispaly same results from a single query");
            var singleQuery = allFeatures.Features.Where(n => n.Properties.Neighborhood != null)
                                                  .Where(n => n.Properties.Neighborhood != "")
                                                  .Select(n => n.Properties.Neighborhood)
                                                  .Distinct();

            DisplayResult(singleQuery);


            Console.ReadLine();
        }


        public static FeaturesCollection ReadFile()
        {
            try
            {
                string jsonData;

                using (StreamReader reader = new StreamReader("../../../data.json"))
                {
                    jsonData = reader.ReadToEnd();
                }
                return JsonConvert.DeserializeObject<FeaturesCollection>(jsonData);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found");
                throw;
            }
        }


        public static void DisplayResult(IEnumerable<string> itemList)
        {
            Console.ReadLine();
            Console.Clear();
            int counter = 0;
            foreach (var n in itemList)
            {
                Console.WriteLine($"{++counter} - {n}");
            }
            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
