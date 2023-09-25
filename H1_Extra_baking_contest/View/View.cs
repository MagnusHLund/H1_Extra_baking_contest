using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Extra_baking_contest.View
{
    internal class View
    {
        /// <summary>
        /// Outputs a custom message based on the parameter
        /// </summary>
        /// <param name="message"></param>
        internal void Message(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// This method changes between white and dark gray colors, based on the parameter value and modulus.
        /// </summary>
        /// <param name="value"></param>
        internal void Color(byte value)
        {
            if(value % 2 == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            } else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// This method resets the console color to white.
        /// </summary>
        internal void ResetColor()
        {
            Console.ResetColor();
        }

        /// <summary>
        /// This makes the console color green
        /// </summary>
        internal void Passed()
        {
            Console.ForegroundColor= ConsoleColor.Green;
        }

        /// <summary>
        /// This makes the console color red
        /// </summary>
        internal void Failed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
