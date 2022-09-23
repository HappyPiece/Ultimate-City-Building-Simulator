using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.Building;
using UltimateCityBuildingSimulator.Game;

namespace UltimateCityBuildingSimulator.Utility
{
    public static class StringHelper
    {
        public static string DictionaryToString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            var items = from kvp in dictionary
                        select kvp.Key + "\t\t" + kvp.Value;

            return string.Join("\n", items).ToLower();
        }

        public static bool TryParseStringToBuilding(string input, IEnumerable<IBuildable> buildables, out IBuildable building)
        {
            building = null;
            if (string.IsNullOrEmpty(input) || buildables == null) return false;
            foreach (var buildable in buildables)
            {
                var buildType = buildable.GetType().Name.ToString().ToLower();
                if (buildType.IndexOf(input) >= 0)
                {
                    building = (IBuildable)buildable.Clone();
                    return true;
                }
            }
            return false;
        }
    }
}
