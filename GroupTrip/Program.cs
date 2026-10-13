/*
* Name: Grayson Wininger
* Course: CSCI 1250, Section 001
* Assignment: Lab 04, The Group Trip
* Date: October 12, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it
* reports on a whole group instead of one person.
*/

using System.Numerics;

//Constants
const int pizza = 8;
const double taxRate = .18;

//Part 1: Three Methods(Methods are at bottom)

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
double pricePerPizza = Convert.ToDouble(Console.ReadLine());

//Calculates pizza cost
double totalSlices = amountPizzas * pizza;
double pizzaCost = amountPizzas * pricePerPizza;

//Calculates trip total
double tripTotal = FuelCost(miles, milesPerGallon, pricePerGallon) + pizzaCost;

//Displays all user inputs
Console.WriteLine("Round trip miles: " + miles);
Console.WriteLine("Miles per gallon: " + milesPerGallon);
Console.WriteLine("Price per gallon: " + pricePerGallon);
Console.WriteLine("How many pizzas: " + amountPizzas);
Console.WriteLine("Price per pizza: " + pricePerPizza);

//Displays fuel cost, pizza cost, and trip total
Console.WriteLine("\n=== Part 1: The Trip ===");
Console.WriteLine("Fuel Cost: " + FuelCost(miles, milesPerGallon, pricePerGallon).ToString("C"));
Console.WriteLine("Pizza Cost: " + pizzaCost.ToString("C"));
Console.WriteLine("Trip Total: " + tripTotal.ToString("C"));
Console.WriteLine();

//Part 2: The Group

//Creates arrays for data for the four people going
string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };
int amountPeople = names.Length;

//Calculates amount of slices for each person and the cost per person
double slicesEach = totalSlices / names.Length;
double costPerPerson = tripTotal / names.Length;

//Displays people going, slices each, and cost per person
Console.WriteLine("=== Part 2: The Group ===");
Console.WriteLine("People going: " + names.Length);
Console.WriteLine("Slices each " + slicesEach.ToString("F1"));
Console.WriteLine("Cost per person: " + costPerPerson.ToString("C"));
Console.WriteLine();

//Part 3: The Report

double totalHours = 0;
double totalTakeHomePay = 0;
double longest = 0;

Console.WriteLine("=== Part 3: Who Works How Long ===");
for (int i = 0; i < names.Length; i++)
{
double currentTakeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
double takeHomePerHour = (TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate)) / hoursWorked[i];
double currentHoursWorked = HoursToCover(costPerPerson, takeHomePerHour);
Console.WriteLine(names[i] + ":" + " takes home " + currentTakeHomePay.ToString("C") + " for " + hoursWorked[i] + " hours, " + takeHomePerHour.ToString("C") + " per hour, must work " + currentHoursWorked.ToString("F2") + " hours");
totalHours += hoursWorked[i];
totalTakeHomePay += currentTakeHomePay;
longest = Math.Max(longest, currentHoursWorked);
}
Console.WriteLine("\nTotal hours worked: " + totalHours);
Console.WriteLine("Total take home pay: " + totalTakeHomePay.ToString("C"));
Console.WriteLine("Longest anyone must work: " + longest.ToString("F2"));


//Methods

//Calculates FuelCost by dividing miles by miles per gallon and then multiplying gallons needed by price per gallon
static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallonsNeeded = miles / milesPerGallon;

    return gallonsNeeded * pricePerGallon; 
}

//Calculates TakeHomePay by multiplying hours by hourly rate, than gross pay by taxrate, then gross pay minus tax withheld
static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    double taxWithheld = grossPay * taxRate;
    return grossPay - taxWithheld;
}

//Calculates HoursToCover by dividing amount owed by the amount of people
static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}
