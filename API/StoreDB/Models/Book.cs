using System;
using System.Collections.Generic;

namespace StoreDB.Models
{

    
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public double price { get; set; }
        public string synopsis { get; set; }
        public bookType type { get; set; }

        public enum bookType {
            Fiction,
            NonFiction,
        }

    }
}
