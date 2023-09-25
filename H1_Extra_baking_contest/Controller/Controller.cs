using H1_Extra_baking_contest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Extra_baking_contest.Controller
{
    internal class Controller
    {
        // Byte array to keep track of the cakes that the user decided to practice
        byte[] practiced = new byte[3];

        View.View view = new View.View();
        Cakes cakes = new Cakes();

        /// <summary>
        /// This is the entry point for the controller class.
        /// It calls each of the 3 other methods inside this class, in the correct order.
        /// First the menu gets shown, then the user inputs which cakes they wanna practice for the exam.
        /// The program then picks a random came and the user might have practiced for the right one.
        /// </summary>
        internal void Start()
        {
            Menu();
            User();
            Exam();
        }

        /// <summary>
        /// This method goes through each cake in the array inside the model class called "Cakes".
        /// It outputs each of those cakes in the array, in either white or dark gray color. 
        /// Then at the end it creates an empty line, as a space between the menu and user input.
        /// </summary>
        private void Menu()
        {
            for (byte i = 0; i < cakes.cakes.Length; i++)
            {
                view.Color(i);
                view.Message($"{i}\t{cakes.cakes[i]}");
            }

            view.Message("");
        }

        /// <summary>
        /// This method takes user input for which cakes that should be practiced.
        /// It has exception handling, which catches any errors related to the conversion between the different array types, in the for loop.
        /// Once the for loop is finished, without any errors, this method ends.
        /// </summary>
        private void User()
        {
            view.ResetColor();

            while (true)
            {
                view.Message("Which cakes do you wanna practice?");
                view.Message("Write 3 numbers corresponding with the cakes above");

                try
                {
                    char[] input = Console.ReadLine().ToCharArray();

                    string[] inputStr = new string[3];

                    for (int i = 0; i < 3; i++)
                    {
                        inputStr[i] = input[i].ToString();

                        practiced[i] = byte.Parse(inputStr[i]);
                    }

                    break;
                }
                catch
                {
                    view.Message("Write only numbers, like '123'");
                }
            }
        }

        /// <summary>
        /// This method takes care of deciding the exam cake. It can only be one of those inside the cakes array (Model.cakes.cakes[])
        /// A random number between 0 and 10 gets picked, which then associates with the position of the cakes inside the array.
        /// Using a foreach loop, it checks if any of the bytes inside the 'practiced' array matches with the random number.
        /// If it matches, then the user passed the exam, else the user failed.
        /// </summary>
        private void Exam()
        {
            Random random = new Random();

            byte examCake = (byte)random.Next(0, 10);

            bool passed = false;

            foreach (byte i in practiced)
            {
                if (i == examCake)
                {
                    passed = true;
                    break;
                }
            }

            if(passed)
            {
                view.Passed();
                view.Message($"You passed the exam! Cake was {cakes.cakes[examCake]}");
            } else
            {
                view.Failed();
                view.Message($"You chose poorly! Cake was {cakes.cakes[examCake]}");
            }

            view.ResetColor();
        }
    }
}
