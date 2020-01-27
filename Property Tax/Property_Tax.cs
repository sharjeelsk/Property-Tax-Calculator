/* Programmer: Austin Parker
   Date: Jan. 27th, 2020
   Purpose: This program is used to calculate and 
   display owners property tax information.
 */



using System;
using static System.Console;
using static System.Math;

namespace Property_Tax
{
    class Property_Tax
    {
        static void Main()
        {
            /* Declared variables */
            string propertyAddress;
            double lastYearValue;
            double thisYearValue;
            double taxesOwed;
            const double VALUE_INCREASE = 0.027;
            const double HOMEOWNER_EXEMPTION = 25000.00;
            const double annualMillRate = 10.03;
            DisplayInstructions();

            /* Declares the methods that will be called by the variables. */
            propertyAddress = GetAddress("");
            lastYearValue = GetLastYearValue("");
            thisYearValue = CalculateThisYearValue(lastYearValue, HOMEOWNER_EXEMPTION, VALUE_INCREASE);
            taxesOwed = GetTaxesOwed(thisYearValue, annualMillRate);
            DisplayResults(propertyAddress, thisYearValue, taxesOwed);
            ReadKey();
        }

        /* Displays the instructions to the user how to use the program. */
        static void DisplayInstructions()
        {
            WriteLine(" Welcome to the Property Tax program!\n");
            WriteLine("     You will first be asked to enter the address you want to calculate taxes for.\n");
            WriteLine("     Next, you will be asked to input the prior year assessed value for the property.\n");
            WriteLine("     Lastly, the porgram will calculate the information provided then,\n" +
                      "\n     display the property's current value and proposed taxes owed.\n");
            WriteLine(" Please press any key to continue.");
            ReadKey();
            Clear();
        }
         
        /* Asks user for property address and stores it in propertyAddress variable. */
        static string GetAddress(string property)
        {
            string inputProperty;
            Write("Enter Property Address: {0}", property);
            inputProperty = ReadLine();
            return inputProperty;
        }

        /* Asks user for last years assessed value, will Parse string to a Double, and store in lastYearValue variable. */
        static double GetLastYearValue(string lastVal)
        {
            string inputOldVal;
            double oldValTotal;
            Write("\n Enter Prior Year Assessed Value: {0}", lastVal);
            inputOldVal = ReadLine();
            oldValTotal = double.Parse(inputOldVal);
            return oldValTotal;
        }

        /* Calculates value of property including discount for Homeowner exemption and currrent year value increase to support school system. */
        static double CalculateThisYearValue(double oldValue, double HOMEOWNER_EXEMPTION, double VALUE_INCREASE)
        {
            double discount = oldValue - HOMEOWNER_EXEMPTION;
            double newVal = VALUE_INCREASE * discount;
            double taxValue = discount + newVal;
            return taxValue;
        }

        /* Calculates current year Millage Rate based on total assessed value. */
        static double GetTaxesOwed(double currentValue, double annMillageRate)
        {
            return currentValue * annMillageRate / 1000;

        }

        /* Displays results to user including property address, Assessed Value, and Taxes Owed based on Millage Rate. */
        static void DisplayResults(string propertyAddress, double currentValue, double taxesOwed)
        {
            Clear();
            WriteLine(" Property Address: {0}\n", propertyAddress);
            WriteLine("     Total Assessed Value: {0:C2}\n", currentValue);
            WriteLine("     Current Proposed Tax Owed: {0:C2}\n", taxesOwed);
            WriteLine(" Thanks for using Property Tax Calculator! Press any key to end the program");
        }








    }
}
