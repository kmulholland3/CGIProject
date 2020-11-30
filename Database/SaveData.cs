using System.Data.SQLite;
using System.Collections.Generic;
namespace Database
{
    public class SaveData : ISeedData
    {
        public void SeedData(List<Restaurants> allRests){
            string cs = @"URI=file:/Users/katiemulholland/source/repos/spinner/API/restaurants.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = "DROP TABLE IF EXISTS restaurants";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE restaurants(id INTEGER PRIMARY KEY, resttext TEXT)";
            cmd.ExecuteNonQuery();

            
            foreach(Restaurants rest in allRests){
            cmd.CommandText = @"INSERT INTO restaurants(resttext) VALUES(@resttext)";
            cmd.Parameters.AddWithValue("@resttext", rest.RestName);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            }
            
        }
    }
}