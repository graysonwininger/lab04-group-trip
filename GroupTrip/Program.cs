/*
* Name: Grayson Wininger
* Course: CSCI 1250, Section 001
* Assignment: Lab 04, The Group Trip
* Date: October 12, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it
* reports on a whole group instead of one person.
*/

using System.Numerics;
const int pizza = 8;
const double taxRate = .18;

//Part 1: Three Methods

//Prompts for round trip miles and asks for input
Console.Write("What are the round trip miles? ");
int miles = Convert.ToInt32(Console.ReadLine());

//Prompts for miles per gallon and asks for input
Console.Write("What is your miles per gallon for the car you traveled in? ");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

//Prompts for price per gallon and asks for input
Console.Write("What was the average price per gallon you paid?");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

//Prompts for amount of pizzas and asks for input
Console.WriteLine("How many pizzas will there be?");
double amountPizzas = Convert.ToDouble(Console.ReadLine());

//Prompts for price per pizza and asks for input
Console.WriteLine("What is the price per pizza?");
double pircePerPizza = Convert.ToDouble(Console.ReadLine());

//Calculates pizza cost
double totalSlices = amountPizzas * pizza;
double pizzaCost = amountPizzas * pircePerPizza;

//Calculates trip total
double tripTotal = FuelCost(miles, milesPerGallon, pricePerGallon) + pizzaCost;


//Displays fuel cost, pizza cost, and trip total
Console.WriteLine("=== Part 1: The Trip ===");
Console.WriteLine("Fuel Cost: " + FuelCost(miles, milesPerGallon, pricePerGallon).ToString("C"));
Console.WriteLine("Pizza Cost: " + pizzaCost.ToString("C"));
Console.WriteLine("Trip Total: " + tripTotal.ToString("C"));

//Part 2: The Group

//Creates arrays for data for the four people going
string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

//Displays people going, slices each, and cost per person
Console.WriteLine("=== Part 2: The Group ===");
Console.WriteLine("People going: " + names.Length);
Console.WriteLine("Slices each " + (totalSlices / names.Length).ToString("F1"));
Console.WriteLine("Cost per person: " + (tripTotal / names.Length).ToString("C"));

// double slicesPerPerson = totalSlices / amountPeople;

// Console.WriteLine("Total slices: " + totalSlices.ToString("F"));
// Console.WriteLine("Slices per person: " + slicesPerPerson.ToString("F1"));
// Console.WriteLine("Pizza cost: " + pizzaCost.ToString("C"));



// Console.WriteLine("Gross pay : " + grossPay.ToString("C"));
// Console.WriteLine("Tax withheld : " + taxWithheld.ToString("C"));
// Console.WriteLine("Take home pay: " + takeHomePay.ToString("C"));



// Console.WriteLine("Trip total: " + tripTotal.ToString("C"));
// Console.WriteLine("Cost per person: " + costPerPerson.ToString("C"));
// Console.WriteLine("Take home pay per hour: " + takeHomePayPerHour.ToString("C"));
// Console.WriteLine("Hours you must work to cover your share: " + hoursYouMustWork.ToString("F2"));

//Methods

//Calculates FuelCost
static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallonsNeeded = miles / milesPerGallon;

    return gallonsNeeded * pricePerGallon; 
}

//Calculates TakeHomePay
static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    double taxWithheld = grossPay * taxRate;
    return grossPay - taxWithheld;
}

//Calculates HoursToCover
static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}

//     double costPerPerson = amountOwed / amountPeople;
//     double takeHomePerHour = takeHomePay / hoursWorked;