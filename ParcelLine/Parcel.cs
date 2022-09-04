using System;

namespace ParcelLine
{
    public class Parcel
    {
        public readonly int Width; 
        public readonly int Length;

        public Parcel(int width, int length)
        {
            if (width <= 0 || length <= 0)
            {
                throw new ArgumentException("Invalid Parcel measurements! Width and Length has to be positive numbers.");
            }
            Width = Math.Min(width, length);
            Length = Math.Max(length, width);

        }


    }
}
