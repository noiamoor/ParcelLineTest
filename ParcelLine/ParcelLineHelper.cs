using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ParcelLine
{
    public class ParcelLineHelper
    {
        private const string ARG_ERR_MESSAGE = "Input not in correct format. Correct format: at least 3 positive integers separted with comma!";
        /// <summary>
        /// Check if input string is in correct format.
        /// Correct format: at least 3 comma-separated integers. 
        /// </summary>
        public static bool ValidateParcelPipeCommaStrInput(string input)
        {
            string regexToMatch = "^([1-9][0-9]*,\\s*){2,}[1-9][0-9]*$";
            return Regex.IsMatch(input, regexToMatch);
        }

        /// <summary>
        /// Get parcel from input string: first two integers define width and length of the parcel.
        /// </summary>
        public static Parcel GetParcelFromCommaStrInput(string input)
        {
            if (ValidateParcelPipeCommaStrInput(input) == false)
            {
                throw new ArgumentException(ARG_ERR_MESSAGE);
            }
            int[] input_arr = Array.ConvertAll(input.Split(","), int.Parse);
            return new Parcel(input_arr[0], input_arr[1]);
        }

        /// <summary>
        /// Get pipe from input string. pipe starts from the third integer.
        /// </summary>
        public static Pipe GetPipeFromCommaStrInput(string input)
        {  
            if (ValidateParcelPipeCommaStrInput(input) == false)
            {
                throw new ArgumentException(ARG_ERR_MESSAGE);
            }
            int[] input_arr = Array.ConvertAll(input.Split(","), int.Parse);
            int[] pipe_arr = new ArraySegment<int>(input_arr, 2, input_arr.Length - 2).ToArray();
            return new Pipe(pipe_arr);
        }



    }
}
