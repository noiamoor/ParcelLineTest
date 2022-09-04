using ParcelLine;
using System;
using System.Text.RegularExpressions;

namespace ParcelLineCL
{
    public class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("To get know if parcel can fit through the pipe or not please insert comma-separated integers, first two are the dimensions for the parcel and the rest are pipe widths:");
                string input = Console.ReadLine();

                String message = GetParcelFitMessage(input);
                Console.WriteLine(message);
                Console.WriteLine();
            }
        }


        public static string GetParcelFitMessage(string input)
        {
            try
            {
                Parcel parcel = ParcelLineHelper.GetParcelFromCommaStrInput(input);
                Pipe pipe = ParcelLineHelper.GetPipeFromCommaStrInput(input);
                if (pipe.CanParcelFit(parcel) == false)
                {
                    return String.Format("Parcel with width {0} and length {1} DOES NOT FIT into pipe {2}!", parcel.Width, parcel.Length, pipe);
                }
                return String.Format("Parcel with width {0} and length {1} FITS into pipe {2}!", parcel.Width, parcel.Length, pipe);
            }
            catch(ArgumentException e)
            {
                return (e.Message);
            }
        }
    }
}
