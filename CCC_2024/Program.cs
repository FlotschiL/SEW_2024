using System;
using System.ComponentModel.Design.Serialization;
using System.Net.NetworkInformation;
using System.Transactions;

namespace ccc2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dir = @"C:\Users\MainUserFlo\Downloads\CCC_2024";
            string level = "level3";
            string outdir = dir + level + @"\output";

            if (Directory.Exists(outdir))
            {
                Directory.Delete(outdir, true);
            }

            Directory.CreateDirectory(outdir);

            //TryTest
            using (StreamReader sr = new StreamReader((dir + @"\" + level + @"\" + level + $"_example.in")))
            {
                using (StreamWriter sw = new StreamWriter(outdir + @"\" + level + $"example.out"))
                {
                    CodingContextExecute(sr, sw);
                }
            }

            Environment.Exit(0);

            for (int i = 1; i < 6; i++)
            {
                using (StreamReader sr = new StreamReader(dir + @"\" + level + @"\" + level + $"_{i}.in"))
                {

                    using (StreamWriter sw = new StreamWriter(outdir + @"\" + level + $"_{i}.out"))
                    {
                        CodingContextExecute(sr, sw);
                    }
                }

            }
        }
        static void CodingContextExecute(StreamReader file, StreamWriter sw)
        {
            int maxAcceleration = 20;
            int length = Int32.Parse(file.ReadLine());
            int maxTicks = Int32.Parse(file.ReadLine());
            while (file.Peek() != -1)
            {
                Drone drone = new Drone();
                drone.TargetHeight = Int32.Parse(file.ReadLine());
                drone.decelerationStartHeight = drone.TargetHeight / 2;
                do
                {
                    int distanceToTarget = drone.TargetHeight - drone.Height;
                    if (drone.Height < drone.decelerationStartHeight&&drone.TargetHeight > maxAcceleration)
                    {
                        // Acceleration phase: apply enough upward acceleration to overcome gravity
                        drone.Acceleration = maxAcceleration;
                    }
                    else
                    {
                        // Calculate required acceleration to stop exactly at target height
                        drone.Acceleration = (drone.Velosity * drone.Velosity) / (2 * distanceToTarget);
                        continue;
                    }

                    if (-drone.Velosity > drone.Height)
                    {
                        drone.Acceleration = maxAcceleration;
                    }



                    // Increment tick counter
                    Console.WriteLine(drone);
                } while (drone.Height > 0);
                    sw.WriteLine();
                    Console.WriteLine();
                }
            }
    }
}

class Drone
        {
            public int decelerationStartHeight { get; set; } = 0;
            public int Height { get; set; } = 0;
            public int TargetHeight { get; set; } = 0;
            private int acc = 0;
            public int Acceleration
            {
                get
                {
                    return acc;
                }
                set
                {
                    Velosity +=  value - 10;
                    Height += Velosity;
                    if (value <= 20)
                    {
                        acc = value;
                    }
                    else
                    {
                        throw new ArgumentException("acc too big");
                    }
                }
            }

            public int Velosity { get; set; } = 0;
        }