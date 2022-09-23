using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.Building
{
    public class BuildingCatalogue
    {
        private List<Item> ItemList;
        public BuildingCatalogue()
        {
            ItemList = new List<Item>();
        }
        public void AddItem(string name, IBuildable building, int price)
        {
            ItemList.Add(new Item(name.ToLower(), building, price));
        }

        public void AddItem(IBuildable building, int price)
        {
            ItemList.Add(new Item(building.GetType().Name.ToLower(), building, price));
        }

        public bool RequestItemByName(string name, out Item item)
        {
            item = new Item();
            foreach (var entry in ItemList)
            {
                if (entry.Name == name.ToLower())
                {
                    item = entry;
                    return true;
                }
            }
            return false;
        }

        public IReadOnlyList<Item> GetList()
        {
            return ItemList.AsReadOnly();
        }
        public struct Item
        {
            public string Name;
            public IBuildable Building;
            public int Price;

            public Item(string name, IBuildable building, int price)
            {
                Name = name;
                Building = building;
                Price = price;
            }
        }
    }
}
