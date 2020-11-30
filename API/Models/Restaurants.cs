namespace API.Models
{
    public class Restaurants
    {
        public int ID{get;set;}
        public string Name{get;set;}

        public override string ToString(){
            return ID + " " + Name;
        }
    }
}