using System.Data.SQLite;
using API.Models.Interfaces;
namespace API.Models
{
    public class SaveRestaurant : IInsertRestaurant
    {
        public void InsertRestaurant(Restaurants value)
        {
            string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/restaurants.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO restaurants(resttext) VALUES(@resttext)";
            cmd.Parameters.AddWithValue("@resttext", value.Name);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}