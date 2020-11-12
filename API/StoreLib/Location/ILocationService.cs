using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public interface ILocationService
    {
        void AddLocation(Location location);
        void DeleteLocation(Location location);
        List<Location> GetAllLocations();
        Location GetLocationById(int id);
        Location GetLocationByState(string state);
        void UpdateLocation(Location location);
    }
}