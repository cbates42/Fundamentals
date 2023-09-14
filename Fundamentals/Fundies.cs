using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    public class Fundies
    {


        public Dictionary<int, Info> games = new Dictionary<int, Info>();
        public GameInfo game = new GameInfo();


        public Fundies()
        {

           

            Console.WriteLine($"There are {game.MetaData.Count} games.");
            Console.WriteLine($"The most common game genre is {GenreFreq}!");
            mapCharCount();
            DisplayInfo();
            FindZs();



        }

        public string GenreFreq()
        {
            Dictionary<string, int> genreCount = new Dictionary<string, int>();
            string genre = "";
            int maxCount = 0;

            foreach (var info in game.MetaData)
            {
                if (!genreCount.ContainsKey(info.Genre))
                {
                    genreCount[info.Genre]++;
                }
            }

            return "adventure";
        }

        public void mapCharCount()
        {
         Dictionary<string, string> longestNames = new Dictionary<string, string>();
         int highestNameLength = 0;

           foreach(var info in game.MetaData) 
            {
              foreach(string mapName in info.MapNames)
                {
                    string noSpaceName = mapName.Replace(" ", "");
                    int nameLength = noSpaceName.Length;

                    if(nameLength > highestNameLength)
                    {
                        highestNameLength = nameLength;
                        longestNames.Clear();
                        longestNames[mapName] = info.Name;
                    }

                    else if (nameLength == highestNameLength)
                    {
                        longestNames[mapName] = info.Name;
                    }
                }
            }

           foreach(var kvp in longestNames)
            {
                Console.WriteLine("The longest map names are:");
                Console.WriteLine($"{kvp.Key}, from {kvp.Value}");
            }
        
        }

        public void DisplayInfo()
        {
            Dictionary<int, string> infoDict = new Dictionary<int, string>();
            foreach(var info in game.MetaData)
            {
                infoDict[info.Id] = info.Name;
            }

            Console.WriteLine("The current games are:");
            for (int i = 0; i < infoDict.Count; i++)
            {
                Console.WriteLine($"{i}: {infoDict[i]}");
            }
        }

        public void FindZs()
        {
            List<string> mapsWithZ = new List<string>();
            foreach(var info in game.MetaData)
            {
                foreach(var mapName in info.MapNames)
                {
                    if(mapName.Contains("z"))
                    {
                        mapsWithZ.Add(mapName);
                    }
                }
            }

            Console.WriteLine("The map names that start with z are:");
            foreach(var mapName in mapsWithZ)
            {
                Console.WriteLine(mapName);
            }
        }
 
     
    }
}
