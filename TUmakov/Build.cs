using System;

namespace TumakovHomeTask
{
    internal class Build
    {
        private static uint buildNumberSeed = 0;
        public uint ID { get; }
        public double HeightBuild { get; private set; }
        public uint NumberOfFloors { get; private set; }
        public uint QtyOfApartments { get; private set; }
        public uint QtyOfEntrances { get; private set; }

        private uint GenerateID()
        {
            buildNumberSeed++;
            return buildNumberSeed;
        }
        public Build()
        {
            ID = GenerateID();
        }
        internal Build(double HeightBuild, uint NumberOfFloors, uint QtyOfApartments, uint QtyOfEntrances)
        {
            ID = GenerateID();
            this.HeightBuild = HeightBuild;
            this.NumberOfFloors = NumberOfFloors;
            this.QtyOfApartments = QtyOfApartments;
            this.QtyOfEntrances = QtyOfEntrances;
        }
        public void GetInfoOfBuild()
        {
            Console.WriteLine($"Номер здания: {ID}\n" +
                $"Высота здания: {HeightBuild}\n" +
                $"Количество этажей в здании: {NumberOfFloors}\n" +
                $"Количество квартир в здании: {QtyOfApartments}\n" +
                $"Количество подъездов в здании: {QtyOfEntrances}");
        }
        public double CalculateHeighPerFloor()
        {
            return (HeightBuild / NumberOfFloors);
        }
        public uint? CalculateApartmentsPerEntrances()
        {
            if (QtyOfApartments % QtyOfEntrances == 0) return QtyOfApartments / QtyOfEntrances;
            else return null;
        }
        public uint? CalculateApartmentsPerFloors()
        {
            if (QtyOfApartments % NumberOfFloors == 0) return QtyOfApartments / NumberOfFloors;
            else return null;
        }
    }
}