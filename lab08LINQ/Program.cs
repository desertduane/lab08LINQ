using QuickType;
using System.Linq;
using System;
using System.IO;
using System.Collections.Generic;

namespace lab08LINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string fileName = "data.json";
            string path = Path.Combine(Environment.CurrentDirectory, @"data\", fileName);
            string jsonFile;

            // Reading the Json
            using (StreamReader sr = File.OpenText(path))
            {
                jsonFile = File.ReadAllText(path);
              
            }


            
            var data = GettingStarted.FromJson(jsonFile);

            IEnumerable<Feature> allNeighborhoods = from n in data.Features
                                                   where n.Properties.Neighborhood != null
                                                   select n;

            foreach (var n in data.Features)
            {
                Console.WriteLine(n.Properties.Neighborhood);
            }
            Console.Clear();

            // removes the blanks

            var noBlankNeighborhoods = allNeighborhoods.Where(n => n.Properties.Neighborhood != "");

            foreach(var n in noBlankNeighborhoods)
            {
                Console.WriteLine(n.Properties.Neighborhood);
            }
            Console.Clear();

            // removes the duplicate neighborhoods

            var uniqueNeighborhoods = noBlankNeighborhoods.GroupBy(n => n.Properties.Neighborhood).Select(n => n.First());

            foreach(var n in uniqueNeighborhoods)
            {
                Console.WriteLine(n.Properties.Neighborhood);
            }
            Console.Clear();
            
            // all of the above in one

            var allInOne = data.Features.Where(n => n.Properties.Neighborhood != "").GroupBy(n => n.Properties.Neighborhood).Select(n => n.First());

            foreach(var n in allInOne)
            {
                Console.WriteLine(n.Properties.Neighborhood);
            }


            Console.Read();
        

            

            
        }
    }
}
