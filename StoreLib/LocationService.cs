using StoreDB;
using StoreDB.Models;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreLib
{
    public class LocationService
    {
        private ILocationRepo repo;

        public LocationService(ILocationRepo repo) {
            this.repo = repo;
        }

        public void AddLocation(Location location) {
            repo.AddLocation(location);
        }

        public void UpdateLocation(Location location) {
            repo.UpdateLocation(location);
        }

        public Location GetLocationById(int id) {
             Location location = repo.GetLocationById(id);
             return location;
         }

        public Location GetLocationByState(string state) {
             Location location = repo.GetLocationByState(state);
             return location;
         }

        public List<Location> GetAllLocations() {
            List<Location> locations = repo.GetAllLocations();
            return locations;
        }

        public void DeleteLocation(Location location) {
            repo.DeleteLocation(location);
        }

    }
}