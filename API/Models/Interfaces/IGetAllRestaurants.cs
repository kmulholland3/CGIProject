using System.Collections.Generic;
namespace API.Models.Interfaces
{
    public interface IGetAllRestaurants
    {
         List<Restaurants> GetAllRestaurants();
    }
}