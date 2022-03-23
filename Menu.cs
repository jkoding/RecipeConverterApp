using static System.Console;
using static RecipeConverterApp.Converter;

namespace RecipeConverterApp
{
    internal class Menu
    {

        private bool ExitApplication = false;

        public Menu()
        {
            // Start of the main program loop, program will continue to ReadLine() until user inputs a command.
            
            Setup();
            
            do
            {
                WriteLine("--------------------------------------------------------------------------");
                Write("Command ---> ");
                ReadUserInput();
            } while (!ExitApplication);
        
            
            // Runs once exit command is input.
            WriteLine("Press any key to exit...");
            ReadKey(true);
        
        }

        private void Setup()
        {
            // Setup the menu decoration for the application
            Title = "Recipe Unit Converter";
            ForegroundColor = ConsoleColor.Red;

            Clear();
            WriteLine("\t   Welcome to the Recipe Unit Converter!");
            DisplayMenuHelp();
            DisplayUnitList();
            WriteLine("Type \"clear\" to reset the console. Type \"exit\" to quit.\n");

        }

        private void DisplayMenuHelp()
        {
            WriteLine(@"
~~~~~~~~~~~~~~~~~~~~~~~~~~~INSTRUCTIONS~~~~~~~~~~~~~~~~~~~~~~~~~~~
To use this program enter the amount you want to convert with the 
unit you want to convert FROM and the unit you want to convert TO.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
An example would be: 1.2 tsp to mL
Which will display:  5.92 mL

Users can also just type the amount, convert from, convert to.
Example: 10 L mL
Result:  10000.00 L

The commands are case insensitive.
Example: 10 TEASPOON tO CuP
Result:  0.21 c");
        }

        private void DisplayUnitList()
        {
            WriteLine(@"
                            Units of Measurement
 _______________________________________________________________________
| milliliter  - mL    | liter - L | teaspoon - tsp  | tablespoon - Tbsp |
| fluid ounce - fl.oz | cup   - c | pint     - pt   | quart      - qt   | 
 -----------------------------------------------------------------------
");
        }

        private void ReadUserInput()
        {
            string userInput = ReadLine();
            List<string>userCommands = userInput.Split(" ").ToList();

            switch (true)
            {
                // bool b is only used in the context of this switch, using ReadLine().ToLower() will not allow case-sensitive unit abbreviations from being found.
                  //Exit Application
                case bool b when userInput.ToLower().Equals("exit"):
                    ExitApplication = true;
                    break;
                  // Reset Screen
                case bool b when userInput.ToLower().Equals("clear"):
                    Clear();
                    Setup();
                    break;
                  // Reprompt user
                case bool b when userCommands.Count() > 4 || userCommands.Count() < 3:
                    WriteLine("\nCommand is not formatted properly...please try again.\n");
                    break;
                  // remove "to" from command if present, else reprompt user
                case bool b when userCommands.Count() == 4 && userInput.ToLower().Contains("to"):
                    userCommands.RemoveAll(word => word.Equals("to", StringComparison.OrdinalIgnoreCase));
                    if (userCommands.Count() != 3)
                    {
                        WriteLine("\nCommand is not formatted properly...please try again.\n");
                        break;
                    }
                    else
                    {
                        ParseUserText.ParseCommands(userCommands);
                        break;
                    }
                  // Parse commands for further validation
                case bool b when userCommands.Count() == 3:
                    ParseUserText.ParseCommands(userCommands);
                    break;
                  // Reprompt user if input fails to meet any condition program is expecting.
                default:
                    WriteLine("\nCommand is not formatted properly...please try again.");
                    break;
            };

        }
        
    }
}
