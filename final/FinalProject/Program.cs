using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        /// When the program runs I want it to: 
        ///     Load user info
        ///     Load goals info
        ///     Load shop info
        ///     Create a new menu so that we can do stuff
        ///     Set program to running so it runs
        ///     
        bool isRunning = true;
        Menu menu = new Menu();
        string userInput;
        List<Goal> goals = new List<Goal>();
        bool isValid;
        string fileName;

        // Load in data:
        string userFileName = "User.txt";
        string goalsFileName = "Goals.txt";
        string shopFileName = "Shop.txt";

        if (File.Exists(userFileName))
        {
            goals = menu.ReadGoalsFromFile(userFileName);
            isValid = true;
        }
        else
        {
            Console.WriteLine("ERROR: user file missing. ");
        }

        if (File.Exists(goalsFileName))
        {
            goals = menu.ReadGoalsFromFile(goalsFileName);
            isValid = true;
        }
        else
        {
            Console.WriteLine("ERROR: goals file missing. ");
        }

        if (File.Exists(shopFileName))
        {
            goals = menu.ReadGoalsFromFile(shopFileName);
            isValid = true;
        }
        else
        {
            Console.WriteLine("ERROR: shop file missing. ");
        }



        while (isRunning)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Create New Goal");
            Console.WriteLine("    2. List Goals");
            Console.WriteLine("    3. Save");
            Console.WriteLine("    4. Open Shop");
            Console.WriteLine("    5. Record Event");
            Console.WriteLine("    6. Quit");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                // MENU ITEM: Create New Goal
                case "1":
                    Console.WriteLine("Create Goal:");
                    Console.WriteLine();
                    Console.WriteLine("The types of goals are: ");
                    Console.WriteLine("    1. Simple Goal");
                    Console.WriteLine("    2. Eternal Goal");
                    Console.WriteLine("    3. Checklist Goal");
                    Console.Write("What type of goal would you like to create? ");
                    userInput = Console.ReadLine();
                    Goal newGoal;

                    switch (userInput)
                    {
                        case "1":
                            newGoal = menu.NewSimpleGoal();
                            goals.Add(newGoal);
                            break;
                            
                        case "2":
                            newGoal = menu.NewEternalGoal();
                            goals.Add(newGoal);
                            break;
                            
                        case "3":
                            newGoal = menu.NewChecklistGoal();
                            goals.Add(newGoal);
                            break;
                        
                        default:
                            Console.WriteLine("Please enter a valid input");
                            break;
                    }
                    Console.WriteLine();
                    break;
                

                // MENU ITEM: List Goals
                case "2":
                    Console.WriteLine();
                    Console.WriteLine("Goals: ");
                    menu.DisplayGoals(goals);
                    Console.WriteLine();
                    break;
                

                // MENU ITEM: Save Goals
                case "3":
                    isValid = false;
                    while (!isValid)
                    {
                        Console.Write("What is the filename for the goal file? ");
                        fileName = Console.ReadLine();

                        if (fileName == "")
                        {
                            Console.WriteLine("Returning to menu... ");
                            isValid = true;
                        }

                        else if (File.Exists(fileName))
                        {
                            menu.WriteGoalsToFile(fileName, goals);
                            isValid = true;
                        }

                        else
                        {
                            Console.WriteLine("Invalid file name.");
                            Console.WriteLine("Please enter a valid file name or press ENTER to return to menu. ");
                            Console.WriteLine(); 
                        }
                    }
                        
                    break;


                // MENU ITEM: BLANK (will become SHOP)   
                case "4":
                    break;


                // MENU ITEM: Record Event          
                case "5":

                    Console.WriteLine();
                    menu.DisplayGoals(goals);
                    Console.Write("Which goal did you accomplish? ");
                    int goalIndex = int.Parse(Console.ReadLine());
                    menu.CheckOffGoal(goalIndex - 1, goals);
                    break;


                // MENU ITEM: Quit           
                case "6":
                    Console.WriteLine("Bye bye!");
                    isRunning = false;
                    break;


                // INVALID INPUT CATCH            
                default:
                    Console.WriteLine("Please enter a valid input");
                    break;
            }
        }
    }
}