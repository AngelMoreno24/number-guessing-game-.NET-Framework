using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            myInterfaceClient myProxy = new myInterfaceClient();


            //command keeps track of user input when asked if they want to end the game(prompted after guessing number correctly)
            string command = "";

            //variables used for saving values necessary to play game
            int guess = 0;
            string check = "";
            int attempt = 1;
            int game = 1;
            int lower = 1;
            int upper = 0;

            //while loop starts a new game at start and when prompted after guessing the number unless the user types "end", which will end the game
            while (command != "end")
            {
                //shows game number and increments with each game played
                Console.WriteLine("Game #{0}\n",game);
                game++;


                lower = 1;
                upper = 0;
                //while loop prompts user to input valid lower and upper limits until they type valid values
                while (lower > upper)
                {



                    //asks user to input a lower limit
                    Console.WriteLine("Please enter a lower limit");
                    string input = Console.ReadLine();

                    //checks if the input is an integer before continuing
                    bool canConvert = int.TryParse(input, out lower);
                    if (canConvert)
                    {

                        lower = Convert.ToInt32(input);
                    }
                    else
                    {
                        //If input cant convert to an integer, the user is asked to type a valid value until they type one
                        while (!canConvert)
                        {
                            Console.WriteLine("Please enter an integer value as the lower limit");
                            input = Console.ReadLine();
                            canConvert = int.TryParse(input, out lower);
                        }

                    }

                    //asks user to input a upper limit
                    Console.WriteLine("Please enter a upper limit");
                    input = Console.ReadLine();

                    //checks if the input is an integer before continuing
                    canConvert = int.TryParse(input, out upper);
                    if (canConvert)
                    {

                        upper = Convert.ToInt32(input);
                    }
                    else
                    {
                        //If input cant convert to an integer, the user is asked to type a valid value until they type one
                        while (!canConvert)
                        {
                            Console.WriteLine("Please enter an integer value as the upper limit");
                            input = Console.ReadLine();
                            canConvert = int.TryParse(input, out upper);
                        }

                    }

                    if (lower > upper)
                    {
                        Console.WriteLine("\nThe lower limit cant be higher than the upper limit. Please choose different values.\n");
                    }
                }

                //generates the secret number based on user intput
                int number = myProxy.SecretNumber(lower, upper);

                //while loop will continue the game until the user guesses the correct number
                while(check != "correct")
                {
                    
                    Console.WriteLine("\nAttempt #{0}",attempt);
                    Console.WriteLine("Make a guess");

                    string input = Console.ReadLine();
                    //checks if the input is an integer before continuing
                    bool canConvert = int.TryParse(input, out guess);
                    if (canConvert)
                    {
                        //checks if guess was correct
                        guess = Convert.ToInt32(input);
                        check = myProxy.checkNumber(guess, number);
                        Console.WriteLine("your guess is {0}", check);
                        attempt++;
                    }
                    else
                    {
                        //If input cant convert to an integer, the user is asked to type a valid value until they type one
                        while (!canConvert)
                        {
                            Console.WriteLine("Please enter an integer value as the guess");
                            input = Console.ReadLine();
                            canConvert = int.TryParse(input, out guess);
                        }

                        //checks if guess was correct
                        check = myProxy.checkNumber(guess, number);
                        Console.WriteLine("your guess is {0}", check);
                        attempt++;
                    }
                    
                }
                //resets the check value in case the user starts a new game
                check = "reset";
                attempt = 1;

                //asks the user if they want to play a new game or end it
                Console.WriteLine("\nType \"end\" to terminate the client. Press enter to start a new the game)");
                command = Console.ReadLine();
                Console.WriteLine("\n");
            }
            myProxy.Close(); //Closes the proxy & channel to the service
        }
    }
}
