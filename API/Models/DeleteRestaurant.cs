using API.Models.Interfaces;
using System.Data.SQLite;
namespace API.Models
{
    public class DeleteRestaurant : IDeleteRestaurant
    {
        public void RemoveRestaurant(int id)
        {
            string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/restaurants.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"DELETE FROM restaurants WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}