using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // When the program runs I want it to: 
        // Load user info
        // Load goals info
        // Load shop info
        // Create a new menu so that we can do stuff
        // Set program to running so it runs

        bool isRunning = true;
        Menu menu = new Menu();
        string userInput;
        List<Goal> goals = new List<Goal>();
        string playerName = "";
        string playerFileName = "";
        string goalsFileName = "";
        string shopFileName = "";

        // File loading code written with the help of ChatGPT
        // It wrote some basic code for creating
        // new files and helped me write the code
        // for writing the default files


        Console.Clear();
        // Load in data or create new player
        // Get list of Players Data that's saved
        string[] players = Directory.GetDirectories("PlayersInfo");
        Console.WriteLine("Existing players:");
        foreach (string playerNameDirectory in players)
        {
            Console.WriteLine(Path.GetFileName(playerNameDirectory));
        }

        // Get player name from user
        do
        {
            Console.Write("Please enter player name to load data or press ENTER to create new profile: ");
            playerName = Console.ReadLine();
            if (string.IsNullOrEmpty(playerName))
            {
                // Run to create new player
                Console.Write("Enter new player name: ");
                playerName = Console.ReadLine();
                // Create default files
                Directory.CreateDirectory($"PlayersInfo/{playerName}");
                File.Create($"PlayersInfo/{playerName}/player.txt").Dispose();
                File.Create($"PlayersInfo/{playerName}/goals.txt").Dispose();
                File.Create($"PlayersInfo/{playerName}/shop.txt").Dispose();

                // Write default player info
                using (StreamWriter writer = new StreamWriter($"PlayersInfo/{playerName}/player.txt"))
                {
                    writer.WriteLine($"{playerName}");
                    writer.WriteLine("0");
                    writer.WriteLine($"Energy,100,-10,{DateTime.Now}");
                    writer.WriteLine($"Health,100,2,{DateTime.Now}");
                    writer.WriteLine($"Work,100,2,{DateTime.Now}");
                    writer.WriteLine($"Rest,100,2,{DateTime.Now}");
                }

                // Write default goals info
                using (StreamWriter writer = new StreamWriter($"PlayersInfo/{playerName}/goals.txt"))
                {
                    writer.WriteLine("SimpleGoal||Explore||Check out some menu options!||10||10||10||10||10||false");
                    writer.WriteLine("EternalGoal||Do Daily Planning||Add your tasks and prioritize for the day||20||20||20||20||20");
                    writer.WriteLine("ChecklistGoal||Finish 3 tasks||Finish a task!||30||30||30||30||30||false||3||0||10");
                }

                // Write default shop info (placeholder)
                using (StreamWriter writer = new StreamWriter($"PlayersInfo/{playerName}/shop.txt"))
                {
                    writer.WriteLine("// Shop data goes here");
                }
            }

        } while (!Directory.Exists($"PlayersInfo/{playerName}"));

        // Run to set correct loading files
        playerFileName = $"PlayersInfo/{playerName}/player.txt";
        goalsFileName = $"PlayersInfo/{playerName}/goals.txt";
        shopFileName = $"PlayersInfo/{playerName}/shop.txt";

        // Load all data from files
        // GOALS
        goals = menu.ReadGoalsFromFile(goalsFileName);
        // PLAYER
        Player player = Player.Load(playerFileName);

        

        // SHOP placeholder



        Console.Clear();
        // MENU
        while (isRunning)
        { 
            player.DecayStats();
            Console.WriteLine(player.RenderStatsDisplay());
            Console.WriteLine();
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

                        case "4":
                            newGoal = menu.NewProgressiveGoal();
                            goals.Add(newGoal);
                            break;
                        
                        default:
                            Console.WriteLine("Invalid input. Returning to menu. ");
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
                    // TODO Write save stuff
                    menu.WriteGoalsToFile(goalsFileName, goals);
                    player.Save(playerFileName);
                    Console.WriteLine("SHOP SAVE NOT IMPLIMENTED");
                    break;


                // MENU ITEM: BLANK (will become SHOP)   
                case "4":
                    break;


                // MENU ITEM: Record Event          
                case "5":

                    Console.WriteLine();
                    Console.WriteLine("You have the following goals: ");
                    menu.DisplayGoals(goals);
                    Console.Write("Which goal did you accomplish? ");
                    int goalIndex = int.Parse(Console.ReadLine());
                    player.DecayStats(); // Decay before adding stat increase from task
                    int pointsEarned = goals[goalIndex - 1].CheckOff(player);
                    Console.WriteLine();
                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                    Console.WriteLine($"You now have {player.GetPoints()} points. ");
                    Console.WriteLine();
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