using System;
using System.Collections.Generic;
using System.IO;
namespace Database
{
    public class PostFile
    {
            public static List<Restaurants> GetPostsFromFile () {
            List<Restaurants> restsList = new List<Restaurants> ();
            //read file
            StreamReader inFile = null;
            //try catch for file
            try {
                inFile = new StreamReader ("posts.txt");
            } catch (FileNotFoundException e) {
                Console.WriteLine ("Something went wrong..... returning blank list {0}", e);
                return restsList;
            }

            string line = inFile.ReadLine ();
            while (line != null) {
                string[] temp = line.Split ('#');
                //fill list
                restsList.Add (new Restaurants() { RestID = int.Parse (temp[0]), RestName = temp[1]});
                line = inFile.ReadLine ();
            }
            inFile.Close ();
            return restsList;
        }
    }
}