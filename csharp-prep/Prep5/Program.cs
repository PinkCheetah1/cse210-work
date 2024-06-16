using System;
using System.ComponentModel;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int number = PromptUserNumber();
        int squareNumber = SquareNumber(number);
        DisplayResults(userName, squareNumber);

    }


    // DisplayWelcome
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    // PromptUserName
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }
    // PromptUserNumber
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string userNumberInput = Console.ReadLine();
        int userNumber = int.Parse(userNumberInput);
        return userNumber;
    }
    // SquareNumber
    static int SquareNumber(int number)
    {
        int squareNumber = number * number;
        return squareNumber;
    }



    // DisplayResult
    static void DisplayResults(string name, int number)
    {
        Console.WriteLine($"{name}, the square of your number is {number}.");
    }



}


