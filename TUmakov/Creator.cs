using System;
using System.Collections.Generic;
using TumakovHomeTask;

namespace TUmakov
{
    internal class Creator
    {
        private static readonly Dictionary<uint, Build> buildsDictionary = new Dictionary<uint, Build>();
        public static uint CreateBuild(double HeightBuild, uint NumberOfFloors, uint QtyOfApartments, uint QtyOfEntrances)
        {
            Build newBuild = new Build(HeightBuild, NumberOfFloors, QtyOfApartments, QtyOfEntrances);
            buildsDictionary.Add(newBuild.ID, newBuild);
            return newBuild.ID;
        }
        public static uint CreateBuild()
        {
            return CreateBuild(0, 0, 0, 0);
        }
        private Creator() { }
        public static void RemoveBuild(uint ID)
        {
            if (buildsDictionary.ContainsKey(ID))
            {
                buildsDictionary.Remove(ID);
                Console.WriteLine($"Номер здания {ID} было удалено из списка.");
            }
            else
                Console.WriteLine($"Номер здания {ID} не зайден.");

        }
    }
}
