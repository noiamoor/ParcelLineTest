using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelLine
{
    public class Pipe
    {
        public readonly int[] Widths;

        public Pipe(int[] widths)
        {
            if (widths.Length == 0)
            {
                throw new ArgumentException("Invalid Pipe. Widths are empty.");
            }
            foreach (int item in widths)
            {
                if (item <= 0)
                {
                    throw new ArgumentException("Invalid Pipe. All widths have to be positive integers.");
                }
            }
            Widths = widths;
        }


        /// <summary>
        ///  Test if 2D quadrangle fits into 2D quadrangular pipe which has 90 grade turns.
        ///  Assumption here is that parcel with width x fits through the pipe with the same size
        /// </summary>
        /// <param name="parcel">quadrangle</param>
        /// <returns>true if parcel fits, false if not.</returns>

        public bool CanParcelFit(Parcel parcel)
        {
            for (int i = 0; i < Widths.Length; i++)
            {
                int pipe1 = Widths[i];
                if (parcel.Width > pipe1) { return false; }
                if (Widths.Length > i + 1)
                {
                    int pipe2 = Widths[i + 1];
                    if (parcel.Width > pipe2) { return false; }
                    if (!(parcel.Width <= Math.Min(pipe1, pipe2) && parcel.Length <= Math.Max(pipe1, pipe2)))
                    { 
                        double max_length = Math.Sqrt(2) * pipe1 + Math.Sqrt(2) * pipe2;
                        double max_width = (max_length - parcel.Length) / 2;
                        if (max_length < parcel.Length || max_width < parcel.Width) { return false; }
                    }
                }
            }
            return true;
        }
    }
}


