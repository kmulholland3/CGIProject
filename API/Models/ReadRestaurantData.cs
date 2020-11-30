using System.Collections.Generic;
using System.Data.SQLite;
using API.Models.Interfaces;
namespace API.Models
{
    public class ReadRestaurantData : IGetAllRestaurants, IGetRestaurant
    {
        public List<Restaurants> GetAllRestaurants()
        {
            string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/restaurants.db";
            using var con = new SQLiteConnection(cs);
            con.Open();
            
            string stm = "SELECT * FROM restaurants";
            using var cmd = new SQLiteCommand(stm,con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            List<Restaurants> allRests = new List<Restaurants>();
            while(rdr.Read()){
                allRests.Add(new Restaurants(){ID = rdr.GetInt32(0), Name = rdr.GetString(1)});
            }

            return allRests;
        }

        public Restaurants GetRestaurant(int ID)
        {
            string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/restaurants.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM restaurants WHERE id = @id";
            using var cmd = new SQLiteCommand(stm,con);
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Restaurants(){ID = rdr.GetInt32(0), Name = rdr.GetString(1)};
        }
    }
}