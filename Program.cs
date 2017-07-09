using System;
using System.Collections.Generic;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("PMS", "Post Monopoly Sadness");
            stocks.Add("FBI", "Fiery Body Infection");

            List<(string ticker, int shares, double price)> purchases = new List<(string,int,double)>();


            purchases.Add(("GM", shares: 100, price: 17.98 ));
            purchases.Add(("GM", shares: 13, price: 19.00));
            purchases.Add(("GM", shares: 14, price: 21.67));

            purchases.Add(("CAT", shares: 18, price: 16.70));
            purchases.Add(("CAT", shares: 170, price: 19.01));
            purchases.Add(("CAT", shares: 17, price: 19.00));

            purchases.Add(("PMS", shares: 145, price: 7.89));
            purchases.Add(("PMS", shares: 10, price: 19.00));
            purchases.Add(("PMS", shares: 17, price: 45.07));

            purchases.Add(("FBI", shares: 35, price: 3.78));
            purchases.Add(("FBI", shares: 4, price: 13.47));
            purchases.Add(("FBI", shares: 12, price: 19.02));

            // Create new Dictionary to hold company name and total amounts
            Dictionary<string, double> Totals = new Dictionary<string,double>();

            // Loop over List to compare KeyValues
            foreach ((string ticker, int shares, double price) amount in purchases)
            {
                // First check the Dictionary-stock to see if it has a key that matches the string "ticker" from the List-purchases
                if (stocks.ContainsKey(amount.ticker)){
                    // Then check the second Dictionary-Totals to see if it has a key that matches the same "ticker" from List-purchases
                    if (Totals.ContainsKey(stocks[amount.ticker])){
                        // if the key exists, set its value here using syntax Total[key] = the value you give it
                        // amount.ticker at this point is only the initials of the company, must reference stocks[amount.ticker] to get the value which is the full name of the company 
                        Totals[stocks[amount.ticker]] += amount.price * amount.shares;
                    }else {
                        // if keyValue does not exist, add it here by passing a string and a double
                        Totals.Add(stocks[amount.ticker], amount.shares * amount.price);
                    }
                }
            }

            // Loop over Dictionary-Totals and use method KeyValuePair so they will both display when consoled
            foreach (KeyValuePair<string, double> total in Totals){
                Console.WriteLine(total);
            }

        }
    }
}
