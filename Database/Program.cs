using System;
using System.Collections.Generic;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Restaurants> allRests = PostFile.GetPostsFromFile();
            ISeedData saveObject = new SaveData ();
            saveObject.SeedData (allRests);
            System.Console.WriteLine("Finished!");
        }
    }
}
