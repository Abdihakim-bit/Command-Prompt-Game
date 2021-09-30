/*  
    Program ID: FinalExam
    Purpose : Exam
    Revision History: Created April 2020 by Abdihakim Ali 

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            StringOperations(Console.ReadLine());

            Console.WriteLine("\nEnter Postal Code in the form of letter/Number/Letter/space/number/letter/number): ");
            string postalCode = Console.ReadLine();
            PostalCodeValidation(postalCode);

            string[] strCandyArray = { "1", "Yummy Candy", "Chocolate", "5.00" };
            string[] shortCandyArr = ArrayToArray(strCandyArray);
            Console.WriteLine("Answer to question 3 is:");
            foreach (string candy in shortCandyArr) { Console.WriteLine(candy); }

            Candy candy1 = new Candy();
            double result;
            Console.WriteLine("Enter candy quantity: ");
            try
            {
                int quantity = int.Parse(Console.ReadLine());
                if (IsValid(quantity))
                {
                    result = candy1.Cost(quantity);
                    Console.WriteLine("With a Quantity of " + quantity + ", your cost would be: " + result.ToString("C2"));
                }
                if (!IsValid(quantity))
                {
                    Console.WriteLine("Quantity more than 100!");
                }
            }
            catch (FormatException) { Console.WriteLine("Make sure quantity is an integer!"); }
            Console.Read();
        }
        static string[] StringOperations(string input)
        {
            char[] inputCharArray = input.ToCharArray();
            char[] newCharArray = new char[input.Length];
            while (input.Equals(""))       // Make sure something was entered.
            {
                Console.WriteLine("Please enter a string: ");
                input = Console.ReadLine();
            }
            for (int i = 0; i < inputCharArray.Length; i++)  // Find any and all punctuations and store characters that are not punctuations into a new array. 
            {
                if (!char.IsPunctuation(inputCharArray[i])) { newCharArray[i] = inputCharArray[i]; }
            }
            Console.WriteLine(newCharArray); // Display result.
            string unpunctuatedInput = new string(newCharArray);  // store string without punctuation.
            string[] array = new string[] { input, unpunctuatedInput };  // Store in array.
            Console.Write("Unpunctuated string printed using for loop: ");
            for (int i = 0; i < newCharArray.Length; i++)  // Display result from a loop.
            {
                Console.Write(newCharArray[i]);
            }
            return array;
        }
        static void PostalCodeValidation(string postalCode)
        {
            char[] charArray = postalCode.ToCharArray();
            if (char.IsDigit(charArray[0]))
            {  // Validates 1st character
                Console.WriteLine("You entered a 0-9 entry, where A-Z was expected, in position: 1");
            }
            if (char.IsLetter(charArray[1])) // Validates 2nd character
            {
                Console.WriteLine("You entered a A-Z entry, where 0-9 was expected, in position: 2");
            }
            if (char.IsDigit(charArray[2]))   // Validates 3rd character
            {
                Console.WriteLine("You entered a 0-9 entry, where A-Z was expected, in position: 3");
            }
            if (char.IsLetter(charArray[4]))    // Validates 4th character
            {
                Console.WriteLine("You entered a A-Z entry, where 0-9 was expected, in position: 4");
            }
            if (char.IsDigit(charArray[5]))   // Validates 5th character
            {
                Console.WriteLine("You entered a 0-9 entry, where A-Z was expected, in position: 5");
            }
            if (char.IsLetter(charArray[6]))    // validates 6th charatcer
            {
                Console.WriteLine("You entered a A-Z entry, where 0-9 was expected, in position: 6");
            }
        }
        static string[] ArrayToArray(string[] strCandyArray)
        {
            string[] shortCandyArr = new string[2];     // Create new string array of size 2
            for (int i = 0; i < strCandyArray.Length; i++)  // 1st and last values from strCandyArray is placed into shortCandyArr
            {
                if (i == 0) { shortCandyArr[i] = strCandyArray[i]; }
                if (i == strCandyArray.Length - 1) { shortCandyArr[1] = strCandyArray[i]; }
            }
            return shortCandyArr;
        }
        static bool IsValid(int quantity)
        {
            if (quantity < 100) { return true; }
            else return false;
        }
    }
    class Candy
    {
        // class fields
        private int id;
        private string name;
        private string flavor;
        private double price;

        public Candy()  // Default Constructor
        {
            id = 0;
            name = "No name";
            flavor = "No flavor";
            price = 3.00;
        }
        public Candy(int idNo, string nameInfo, string flavorInfo, double priceInfo)    // Overloaded Constructor
        {
            id = idNo;
            name = nameInfo;
            flavor = flavorInfo;
            price = priceInfo;
        }
        public double Cost(int quantity)
        {
            double cost = quantity * price;
            return cost;
        }
    }

}

