using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Variable Declaration
        bool isRunning = true;
        Menu menu = new Menu();
        string userInput;
        List<Goal> goals = new List<Goal>();
        string playerName = "";
        string playerFileName = "";
        string goalsFileName = "";
        string shopFileName = "";



        // INNITIAL LOADING
        Console.Clear();
        // Load in data or create new player
        // Get list of Players Data that's saved
        string[] players = Directory.GetDirectories("PlayersInfo");
        Console.WriteLine("Existing players:");
        foreach (string playerNameDirectory in players)
        {
            Console.WriteLine(Path.GetFileName(playerNameDirectory));
        }

        do
        {
            Console.Write("Please enter player name to load data or press ENTER to create new profile: ");
            playerName = Console.ReadLine();
            if (string.IsNullOrEmpty(playerName))
            {
                // CREATE NEW PLAYER
                Console.Write("Enter new player name: ");
                playerName = Console.ReadLine();
                menu.CreateDefaultFiles(playerName);
            }

        } while (!Directory.Exists($"PlayersInfo/{playerName}"));


        // Run to set correct loading files
        playerFileName = $"PlayersInfo/{playerName}/player.txt";
        goalsFileName = $"PlayersInfo/{playerName}/goals.txt";
        shopFileName = $"PlayersInfo/{playerName}/shop.txt";
        // Load all data from files
        goals = menu.ReadGoalsFromFile(goalsFileName);
        Player player = Player.Load(playerFileName);
        Shop shop = Shop.LoadShopFromFile(shopFileName);





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
            Console.WriteLine("    4. Delete Goals");
            Console.WriteLine("    5. Record Event");
            Console.WriteLine("    6. Quit");
            Console.WriteLine("    7. Open Shop");
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
                    shop.Save(shopFileName);
                    Console.WriteLine("Files Saved");
                    break;


                // MENU ITEM: Delete Tasks 
                case "4":
                    List<int> indexList = new List<int>();
                    bool continueDeleteTaskPrompt = true;
                    Console.WriteLine("Delete Tasks: ");
                    do
                    {
                        Console.Write("Enter a task number to delete, or press ENTER to continue: ");
                        string newIndexString = Console.ReadLine();
                        if (newIndexString != "")
                        {
                            int newIndex = int.Parse(newIndexString);
                            indexList.Add(newIndex - 1);

                        }
                        else
                        {
                            continueDeleteTaskPrompt = false;
                        }
                    } while (continueDeleteTaskPrompt);

                    Console.WriteLine("Do you want to delete the following tasks? ");
                    foreach (int i in indexList)
                    {
                        Console.WriteLine(goals[i].RenderDisplay());
                    }
                    Console.WriteLine();
                    Console.Write("Press 1 to delete these tasks, or press ENTER to return to menu. ");
                    userInput = Console.ReadLine();
                    if (userInput == "1")
                    {
                        goals = menu.DeleteGoals(goals, indexList);
                        Console.WriteLine("Hurray! You've deleted some goals. Returning to main menu... ");
                    }
                    else
                    {
                        Console.WriteLine("Returning to menu... ");
                    }
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

                case "7":
                    player.SetPoints(shop.OpenShop(player.GetPoints()));
                    break;

                // INVALID INPUT CATCH            
                default:
                    Console.WriteLine("Please enter a valid input");
                    break;


            }
        }
    }
}