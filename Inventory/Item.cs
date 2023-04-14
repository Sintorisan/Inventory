using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    internal class Item
    {
        public string Name { get; set; }

        public int Inventory { get; set; }
        
        public int ArtNumber { get; set; }

        public string Category { get; set; }

        public Item(string category, string name, int artNumber, int inventory)
        {
            this.Name = name;
            this.Inventory = inventory;
            this.ArtNumber = artNumber;
            this.Category = category;
        }
    }
}
