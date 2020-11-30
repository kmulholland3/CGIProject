using System;
using System.Collections.Generic;
using System.IO;
namespace Database
{
    public class Restaurants
    {
        public int RestID { get; set; }
        public string RestName { get; set; }

        public override string ToString () {
            return this.RestName;
        }


    }
}