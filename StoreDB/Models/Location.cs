using System.Collections.Generic;

namespace StoreDB.Models
{
    public class Location
    {
        public int id { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set;}
        public string postalCode { get; set; }
        public List<InventoryItem> inventory { get; set; }

    }
}