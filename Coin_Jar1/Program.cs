using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PayPal.Api;
using PayPal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpCompress.Common;
using System.Globalization;

namespace Coin_Jar1
{
    interface ICoinJar
        {
            void AddCoin(decimal coin); 
            decimal GetTotalAmount();
            void Reset(); // interface method (does not have a body)
    }
    class USCoinTypes : ICoinJar, ICoin
    {
            //Might want to make this a static array.
            public static readonly int US_CURRENCY_TYPE = 1;
            public static readonly int CURRENCY_AMOUNT = 0;
            public static readonly int CURRENCY_VOLUME = 1;
            public static readonly int MAX_VOLUME = 42;

            public enum CoinTypes
            {
                ONE_CENT = 0,
                FIVE_CENT,
                TEN_CENT,
                TWENTY_FIVE_CENT
            }

            public static readonly int[,] CoinInfo =
            {
        //amount, volume
                 {1,5},
                 {5,6},
                 {10,3},
                 {25,8}
            };

        public decimal Amount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal Volume { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal Coinage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // The body of animalSound() is provided here
        public void AddCoin()
        {
            Console.WriteLine("Please PRESS an ENTER key add a Coin");
            Console.ReadLine();
        }
        public void Reset()
        {
            Console.WriteLine("Please press ENTER to Clear");
            Console.Clear();
        }

        public void AddCoin(decimal coin)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalAmount()
        {
            throw new NotImplementedException();
        }
    }
    interface ICoin
        {
            decimal Amount { get; set; }
            decimal Volume { get; set; }
            decimal Coinage { get; set; }
            public static readonly int MAX_VOLUME = 42;


            //in Cents.
            //Could also make this accept an array for inserting multiple coins.
            public void AddCoin(ICoin coin)
            {
                if (coin.GetType().BaseType != typeof(USCoinTypes))
                    throw new Exception("CoinJar accepts only UsCoin");
                if (MAX_VOLUME < (Volume + coin.Volume))
                    throw new Exception();

                Volume += coin.Volume;
                Amount += coin.Amount;
            }

            public void Reset()
            {
                Coinage = 0;
                Volume = 0;
            }
        }
    public class Program
    {
        static void Main(string[] args)
        {
            USCoinTypes myCoinTypes = new USCoinTypes();
            myCoinTypes.AddCoin();
            

            int number1, // declare first number to add   
            number2, // declare second number to add  
            sum; // declare sum of number1 and number2

            Console.Write("Enter an Amount: "); // prompt user
            
            // read first number from user
            number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("$" + $"{number1} is the Coin Amount added", CultureInfo.GetCultureInfo("en-US")); // display first 
            Console.WriteLine();
            
            Console.Write("Enter Another Amount: "); // prompt user
            
            // read second number from user
            number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("$" + $"{number2} is the Coin Amount added", CultureInfo.GetCultureInfo("en-US")); // display second number
            Console.WriteLine();


            sum = number1 + number2; // add numbers
            Console.WriteLine("$" + $"{sum} is a Total", CultureInfo.GetCultureInfo("en-US")); // display sum 
            Console.WriteLine();
            Console.Clear();
            Console.ReadLine();
        }
    }
}
