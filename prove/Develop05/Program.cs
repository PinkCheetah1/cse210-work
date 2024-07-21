using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        Menu menu = new Menu();
        string userInput;
        List<Goal> goals = new List<Goal>();
        bool isValid;
        string fileName;



        while (isRunning)
        {
            menu.PrintMenuOptions();
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
                            newGoal = menu.NewEternal();
                            goals.Add(newGoal);
                            break;
                            
                        case "3":
                            newGoal = menu.NewChecklist();
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


                // MENU ITEM: Load Goals      
                case "4":
                    isValid = false;
                    while (!isValid)
                    {
                        
                        Console.Write("What is the name of the file you'd like to load from? ");
                        fileName = Console.ReadLine();

                        if (fileName == "")
                        {
                            Console.WriteLine("Returning to menu... ");
                            isValid = true;
                        }

                        else if (File.Exists(fileName))
                        {
                            goals = menu.ReadGoalsFromFile(fileName);
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