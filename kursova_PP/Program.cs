using System;

namespace kursova_PP
{
   public class Program
    {
        static void Main(string[] args)
        {
            Lists a = new Lists();
            string input = Console.ReadLine();
            while (input != "exit" && !String.IsNullOrEmpty(input))
            {
                string[] commandParts = a.SplitTemplate(input);
                string command = commandParts[0];
                switch (command)
                {
                    case ("add"):
                        switch (commandParts[1])
                        {
                            case ("galaxy"):
                                a.AddGalaxy(commandParts[2], commandParts[3], commandParts[4]);
                                break;
                            case ("star"):
                                a.AddStar(commandParts[2], commandParts[3], commandParts[6], commandParts[4], commandParts[7], commandParts[5]);
                                break;
                            case ("planet"):
                                a.AddPlanet(commandParts[2], commandParts[3], commandParts[4], commandParts[5]);
                                break;
                            case ("moon"):
                                a.AddMoon(commandParts[2], commandParts[3]);
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("stats"):
                        a.GetStats();
                        break;


                    case ("list"):
                        switch (commandParts[1])
                        {
                            case ("galaxies"):
                                a.ListGalaxies();
                                break;
                            case ("stars"):
                                a.ListStars();
                                break;
                            case ("planets"):
                                a.ListPlanets();
                                break;
                            case ("moons"):
                                a.ListMoons();
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("print"):
                        a.Print(commandParts[1]);
                        break;
                    default:
                        break;

                }
                input = Console.ReadLine();
            }
        }
    }
}
