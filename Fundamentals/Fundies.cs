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
       
        public GameInfo game = new GameInfo();


        public Fundies()
        {

            Console.WriteLine($"There are {game.MetaData.Count} games.");
            Console.WriteLine($"The most common game genre is {GenreFreq}!");
            mapCharCount();
            DisplayInfo();
            FindZs();

        }

        //kind of struggling with a decent way to do this
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
            //created dictionary, variable for highest length
         Dictionary<string, string> longestNames = new Dictionary<string, string>();
         int highestNameLength = 0;

           foreach(var info in game.MetaData) 
            {
                //for each of the map names
              foreach(string mapName in info.MapNames)
                {
                    //replace any spaces with null text
                    string noSpaceName = mapName.Replace(" ", "");
                    //store non-spaced number
                    int nameLength = noSpaceName.Length;

                    //if the name of the map is higher than the current highest, replace it.
                    if(nameLength > highestNameLength)
                    {
                        highestNameLength = nameLength;
                        longestNames.Clear();
                        longestNames[mapName] = info.Name;
                    }

                    //if the name of the map is the same as the highest, then add it to the dictionary
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
            //adding each game to the dictionary
            foreach(var info in game.MetaData)
            {
                infoDict[info.Id] = info.Name;
            }

            //need to fix the listing starting at 0
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
                    // add mapname to list if it contains z
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
